using Loan.Core.Domain.Contracts.Repositories;
using Loan.Framework.Commons.Entities;
using Loan.InfraLoan.Persistence.Contexts;
using Loan.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Loan.InfraLoan.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configration)
        {
            services.AddDbContext<LoanDbContext>(config =>
            {
                config.UseSqlServer(configration.GetConnectionString("default"));
            });


            services.AddScoped<IBookRepository, BookRepository>();

            //var domainAssembly = Assembly.GetAssembly(typeof(Entity<>));
            //var persistAssembly = Assembly.GetAssembly(typeof(PersistenceServiceRegistration));
            //var repositoryInterfaces = domainAssembly.GetTypes().Where(c => c.IsInterface == true && c.FullName.ToLower().Contains("repository"));
            //var repositoryImplementations = persistAssembly.GetTypes().Where(c => c.IsClass == true
            //&& c.FullName.ToLower().Contains("repository"));
            //foreach (var @class in repositoryImplementations)
            //{
            //    foreach (var @interface in repositoryInterfaces)
            //    {
            //        if (@interface.IsAssignableFrom(@class))
            //            services.AddScoped(@interface, @class);
            //    }
            //}


            return services;
        }
    }
}
