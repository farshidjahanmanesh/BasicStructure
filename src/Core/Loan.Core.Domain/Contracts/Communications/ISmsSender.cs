﻿using Loan.Core.Domain.Communications.SmsSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Core.Domain.Contracts.Communications
{
    public interface ISmsSender
    {
        Task SendSms(SendSmsRequest request);
    }
}
