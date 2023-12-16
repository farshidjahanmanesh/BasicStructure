using Loan.Core.Domain.Contracts.Communications;
using Loan.Infrastructure.Communication.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Loan.Infrastructure.Communication
{

    public static class CommunicationServiceRegistration
    {
        public static IServiceCollection AddCommunicationServices(this IServiceCollection services, IConfiguration configration)
        {
            services.AddScoped<ISmsSender, SmsSender>();
            return services;
        }
    }
}
