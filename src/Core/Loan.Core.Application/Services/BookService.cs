using Ardalis.Result;
using Loan.Core.Domain.Contracts.Communications;
using Loan.Core.Domain.Contracts.Repositories;
using Loan.Core.Domain.Contracts.Services;
using Loan.Core.Domain.Dtos.Services.Book;
using Mapster;

namespace Loan.Core.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly ISmsSender smsSender;

        public BookService(IBookRepository bookRepository, ISmsSender smsSender)
        {
            this.bookRepository = bookRepository;
            this.smsSender = smsSender;
        }
        public async Task<Result> CreateBook(CreateBookInputDto model)
        {
            return Result.Success();
        }

        public async Task<Result<Domain.Dtos.Services.Book.GetBookOutputDto>> GetBook(Domain.Dtos.Services.Book.GetBookInputDto model)
        {
            var book = await bookRepository.GetBook(model.Adapt<Domain.Dtos.Repositories.Book.GetBookInputDto>());
            if (book == null)
                return Result.NotFound("abcd","abbc");
            return Result.Success(book.Adapt<Domain.Dtos.Services.Book.GetBookOutputDto>());
        }

    }

}
