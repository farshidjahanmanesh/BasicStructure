using Loan.Framework.Commons.RequestResponses;

namespace Loan.Core.Domain.Communications.SmsSender
{
    public record SendSmsRequestV2(string LineNumber, string MessageText, string[] Mobiles) : BaseRequestDto;
}
