﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Application;
using Domain;
using Domain.Employee;
using Domain.Region;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public Task<Region> GetRegionById(int id,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Regions.FirstOrDefaultAsync(e => e.RegionId == id, cancellationToken);
        }

        public IQueryable<Region> GetSubRegionsByParentId(int parentId)
        {
            return Regions.Where(e => e.ParentRegion.RegionId == parentId);
        }

        public Task<Employee> GetEmployeeById(int id,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public IQueryable<Employee> GetEmployeesByRegionId(int regionId)
        {
            return Employees.Include(a=>a.Region).Where(e => e.RegionId == regionId);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Region>().Property(m => m.RegionId).ValueGeneratedNever();
            base.OnModelCreating(builder);
        }
    }
}
