using Loan.Framework.Commons.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Core.Domain.Dtos.Repositories.Book
{
    public record GetBookInputDto(int BookId) : BaseInputDto;
    public record GetBookOutputDto(int BookId, string Title, string AuthorName) : BaseOutputDto;
}
