using Loan.Framework.Commons.Dtos;
using Loan.Framework.Commons.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Core.Domain.Parameters.Book
{
    public record CreateBookInputParameter(string title, string authorName) : BaseInputParameter;
}
