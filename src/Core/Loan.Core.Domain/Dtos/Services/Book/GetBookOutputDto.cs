using Loan.Framework.Commons.Dtos;

namespace Loan.Core.Domain.Dtos.Services.Book
{
    public record GetBookOutputDto(string Title, string AuthorName, int BookId) : BaseOutputDto;
}
