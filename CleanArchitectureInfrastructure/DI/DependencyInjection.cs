using System;
using CleanArchitecture.Application.Common.Interface;
using CleanArchitecture.Infrastructure.Persistent;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.DI

{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("SummerClassDatabasePostgreSQL"),
                b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IApplicationDBContext>(provider => provider.GetService<ApplicationDBContext>());
            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}

