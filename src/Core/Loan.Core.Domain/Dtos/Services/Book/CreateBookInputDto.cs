using Loan.Framework.Commons.Dtos;

namespace Loan.Core.Domain.Dtos.Services.Book
{
    public record CreateBookInputDto(string title, string authorName) : BaseInputDto;
}
