using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Domain.Employee;
using Domain.Region;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public partial interface IApplicationDbContext
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }

    //Bounded contexts is the preferred way, but for the simplicity of the task keeping it just with Partial interface
    public partial interface IApplicationDbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public Task<Region> GetRegionById(int id,
            CancellationToken cancellationToken = new CancellationToken());
        public Task<Employee> GetEmployeeById(int id,
            CancellationToken cancellationToken = new CancellationToken());
    }
}
