using FluentValidation;
using Loan.Core.Application.Pipelines;
using Loan.Core.Application.Services;
using Loan.Core.Domain.Contracts.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Loan.Core.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FluentValidationPipeline<,>));


            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
