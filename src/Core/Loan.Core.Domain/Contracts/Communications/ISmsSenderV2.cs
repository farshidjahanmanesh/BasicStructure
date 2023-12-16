using Loan.Core.Domain.Communications.SmsSender;
using Refit;

namespace Loan.Core.Domain.Contracts.Communications
{
    [Headers("X-API-KEY: J4fMpaiSafduISRIcfY8oCA1FgOEltWPSJmKosqAWDpyNMeyN90FnWPNAmAa0OdB")]
    public interface ISmsSenderV2
    {
        [Post("/v1/send/bulk")]
        Task<ApiResponse<object>> SendSms([Body(BodySerializationMethod.Json)] SendSmsRequestV2 request);
    }
}
