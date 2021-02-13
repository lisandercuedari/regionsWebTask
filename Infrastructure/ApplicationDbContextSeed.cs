using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Domain.Region;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContextSeed
    {
        public class RegionFromCSV
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public int? ParentRegionId { get; set; }
        }

        public class EmployeeFromCSV
        {
            public int RegionId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public static async Task SeedCSVDataAsync(ApplicationDbContext context)
        {
            if (!context.Regions.Any())
            {
                await InsertRegions(context);
            }

            if (!context.Employees.Any())
            {
                await InsertEmployees(context);
            }
        }

        public static List<RegionFromCSV> ReadRegionsFromCsv(string filePath)
        {
            List<RegionFromCSV> regionsList = new List<RegionFromCSV>();

            string line = "";
            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                var rr = line.Split(",");
                int? parentRegionId = null;
                string regionName = "";
                int regionId = 0;

                if (rr[0].Contains("\""))
                {
                    regionId = Int32.Parse(rr[2]);
                    regionName = rr[0].Replace("\"", "") + rr[1].Replace("\"", "");
                    parentRegionId = string.IsNullOrEmpty(rr[3]) ? default(int?) : int.Parse(rr[3]);
                }
                else
                {
                    regionId = Int32.Parse(rr[1]);
                    regionName = rr[0];
                    parentRegionId = string.IsNullOrEmpty(rr[2]) ? default(int?) : int.Parse(rr[2]);
                }

                regionsList.Add(new RegionFromCSV()
                {
                    Name = regionName,
                    Id = regionId,
                    ParentRegionId = parentRegionId
                });
            }

            file.Close();

            return regionsList;
        }

        public static async Task InsertRegions(ApplicationDbContext context)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "CSV", "regions.csv");
            var regionsList = ReadRegionsFromCsv(path);
            //Insert root regions
            var rootRegionsFromCSV = regionsList.Where(a => a.ParentRegionId == null).Select(a => a.Id).ToList();
            var rootRegions = regionsList.Where(a => a.ParentRegionId == null)
                .Select(a => new Region()
                {
                    RegionId = a.Id,
                    Name = a.Name,
                    Created = DateTime.Now
                }).ToList();

            context.Regions.AddRange(rootRegions);
            await context.SaveChangesAsync();
            //Get all inserted root Regions
            var allRegions = context.Regions;



            //Insert regions that have the root Regions has Parents
            var remainingRegions = regionsList.Where(a => a.ParentRegionId != null && rootRegionsFromCSV.Contains(a.ParentRegionId.Value)).Select(a => new Region()
            {
                RegionId = a.Id,
                Name = a.Name,
                Created = DateTime.Now,
                ParentRegion = allRegions.FirstOrDefault(w => w.RegionId == a.ParentRegionId)
            }).ToList();

            context.Regions.AddRange(remainingRegions);
            await context.SaveChangesAsync();
            var allSecondLevelRegions = context.Regions.Where(a => a.ParentRegion != null).ToList();


            //foreach(var region in )


            //Insert all the others
            var thirdLevelRegions = regionsList.Where(a => a.ParentRegionId != null && remainingRegions.Select(w => w.RegionId).Contains(a.ParentRegionId.Value)).Select(a => new Region()
            {
                RegionId = a.Id,
                Name = a.Name,
                Created = DateTime.Now,
                ParentRegion = allSecondLevelRegions.FirstOrDefault(w => w.RegionId == a.ParentRegionId)
            }).ToList();

            context.Regions.AddRange(thirdLevelRegions);
            await context.SaveChangesAsync();
        }

        public static async Task InsertEmployees(ApplicationDbContext context)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "CSV", "employees.csv");
            var employeesFromCSV = ReadEmployeesFromCsv(path);

            context.Employees.AddRange(employeesFromCSV.Select(a=> new Domain.Employee.Employee()
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                RegionId = a.RegionId,
                Created = DateTime.Now
            }));
            await context.SaveChangesAsync();
        }

        public static List<EmployeeFromCSV> ReadEmployeesFromCsv(string filePath)
        {
            List<EmployeeFromCSV> regionsList = new List<EmployeeFromCSV>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<EmployeeFromCSV>().ToList();
            }
        }
    }
}
