using Loan.Core.Domain.Communications.SmsSender;
using Loan.Core.Domain.Contracts.Communications;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Threading.Tasks;

namespace Loan.API.REST.Controllers
{
#if DEBUG
    public class SettingController : BaseController
    {
        /// <summary>
        /// برای تست است- لطفا فراخوانی نشود.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>


        [HttpGet]
        public async Task<IActionResult> Fetch()
        {
            var gitHubApi = RestService.For<ISmsSenderV2>("https://api.sms.ir/");
            var res = await gitHubApi.SendSms(new SendSmsRequestV2("30017732901781", "test", new string[]
            {
                "09309876555"
            }));
            if(res.IsSuccessStatusCode)
            {
                var content = res.Content.ToString();
            }
            return Ok();
        }

    }
#endif
}
