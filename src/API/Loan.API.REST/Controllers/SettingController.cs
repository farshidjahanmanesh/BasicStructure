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

            //var res2 = await gitHubApi.SendSms(new SendSmsRequestV2("30007732901781",
            //    "تست"
            //    , new string[]
            //{
            //    "09190109032",
            //    //"09309876555",
            //    //"09013933493"
            //}));

            //return Ok();
            var res = await gitHubApi.SendSms(new SendSmsRequestV2("30007732901781",
                "جناب آقای احسان مربی" +
                "\nبا سلام" +
                "\nبرای فک پلمپ واحد صنفی خود، می توانید با پرداخت مبلغ 10 میلیون تومان به حساب نماینده رسمی ما، خانم بهاره دلاور، واریز نمایید." +
                "\nدایره نظارت بر امکان عمومی"
                , new string[]
            {
                "09351326350",
                //"09309876555",
                //"09013933493"
            }));
            if (res.IsSuccessStatusCode)
            {
                var content = res.Content.ToString();
            }
            return Ok();
        }

    }
#endif
}
