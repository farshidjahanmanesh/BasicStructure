using Loan.Framework.Commons.RequestResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Core.Domain.Communications.SmsSender
{
    public record SendSmsRequest(string phoneNumber, string text) : BaseRequestDto;
}
