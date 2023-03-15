using System;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;
namespace CleanArchitecture.Application.Common.Interface
{
    public interface IApplicationDBContext
    {
        DbSet<Employee> Employee { get; set; }
        DbSet<Department> Department { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

