using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Loan.Core.Domain.Contracts.Services;
using Loan.Core.Domain.Dtos.Services.Book;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Loan.API.REST.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet("GetBook")]
        [TranslateResultToActionResult]
        [ExpectedFailures(ResultStatus.NotFound, ResultStatus.Invalid, ResultStatus.Error)]
        public async Task<Result<GetBookOutputDto>> GetBook([FromQuery]GetBookInputDto bookModel)
        {
            var book = await bookService.GetBook(bookModel);
            return book;
        }
    }
}
