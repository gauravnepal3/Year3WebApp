using System;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Infrastructure.Persistent
{
    public class ApplicationDBContext : DbContext, IApplicationDBContext
    {
        private readonly IDateTime _dateTime;
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, IDateTime dateTime)
            : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<BaseEntity> entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}

