using System;
using System.Text;

namespace Loan.Core.Domain.Contracts
{
    public interface IUserDataService
    {
        public bool? IsAuthenticated { get; }
        public string UserId { get; }//todo: must set when add identity
        public string CurrentURL { get; }
        public string IP { get;}
    }
}
