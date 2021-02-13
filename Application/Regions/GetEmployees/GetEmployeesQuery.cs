using Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Regions.GetEmployees
{
    public class GetEmployeesQuery : IRequest<List<GetEmployeesVM>>
    {
        public int RegionId { get; set; }
        public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<GetEmployeesVM>>
        {
            private readonly IApplicationDbContext _context;

            public GetEmployeesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<GetEmployeesVM>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
            {
                List<GetEmployeesVM> model = new List<GetEmployeesVM>();
                int currentRegionId = request.RegionId;

                await AddEmployeesFromRootRegionToList(request.RegionId, model, cancellationToken);

                var getSubRegionsForRegion = await _context.GetSubRegionsByParentId(request.RegionId).ToListAsync(cancellationToken);

                if(getSubRegionsForRegion.Count > 0)
                {
                    await AddEmployeesToList(model, getSubRegionsForRegion.Select(a => a.RegionId).ToList(), cancellationToken);

                    var countries = await _context.Regions.Where(w => getSubRegionsForRegion.Select(a => a.RegionId).Contains(w.ParentRegion.RegionId)).ToListAsync(cancellationToken);

                    if (countries.Count > 0)
                    {
                        await AddEmployeesToList(model, countries.Select(a => a.RegionId).ToList(), cancellationToken);
                    }
                }

                return model;
            }

            private async Task AddEmployeesFromRootRegionToList(int regionId, List<GetEmployeesVM> model, CancellationToken cancellationToken)
            {
                var employeesForRegion = await _context.GetEmployeesByRegionId(regionId).ToListAsync(cancellationToken);
                AddEmployeeRange(model, employeesForRegion);
            }

            private async Task AddEmployeesToList(List<GetEmployeesVM> model, List<int> regionsId, CancellationToken cancellationToken)
            {
                var employeesForRegion = await _context.Employees.Where(w => regionsId.Contains(w.RegionId)).ToListAsync(cancellationToken);
                AddEmployeeRange(model, employeesForRegion);
            }

            private void AddEmployeeRange(List<GetEmployeesVM> model, List<Domain.Employee.Employee> employees)
            {
                model.AddRange(employees.Select(a => new GetEmployeesVM()
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Regions = a.Region.Name,
                    Id = a.Id
                }));
            }
        }
    }
}
