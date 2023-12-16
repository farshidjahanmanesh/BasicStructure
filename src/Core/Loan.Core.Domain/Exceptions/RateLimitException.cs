using System;

namespace Loan.Core.Domain.Exceptions
{
    public class RateLimitException : ApplicationException
    {
        public RateLimitException(string message) : base(message)
        {

        }
    }
}
