using Loan.Core.Domain.Dtos.Repositories.Book;

namespace Loan.Core.Domain.Contracts.Repositories
{
    public interface IBookRepository
    {
        Task<GetBookOutputDto> GetBook(GetBookInputDto model);
    }
}
