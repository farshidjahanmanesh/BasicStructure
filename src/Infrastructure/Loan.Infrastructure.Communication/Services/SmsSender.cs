using Loan.Core.Domain.Communications.SmsSender;
using Loan.Core.Domain.Contracts.Communications;

namespace Loan.Infrastructure.Communication.Services
{
    public class SmsSender : ISmsSender
    {
        public Task SendSms(SendSmsRequest request)
        {
            return Task.CompletedTask;
        }
    }
}
