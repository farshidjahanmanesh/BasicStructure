using Ardalis.Result;
using Loan.Core.Domain.Dtos.Services.Book;

namespace Loan.Core.Domain.Contracts.Services
{
    public interface IBookService
    {
        Task<Result> CreateBook(CreateBookInputDto model);
        Task<Result<GetBookOutputDto>> GetBook(GetBookInputDto model);
    }
}
