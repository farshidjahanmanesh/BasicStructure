using Loan.Core.Domain.Contracts.Repositories;
using Loan.Core.Domain.Dtos.Repositories.Book;
using Loan.InfraLoan.Persistence.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LoanDbContext context;

        public BookRepository(LoanDbContext context)
        {
            this.context = context;
        }
        public async Task<GetBookOutputDto> GetBook(GetBookInputDto model)
        {
            return await context.Books.Where(c => c.Id == model.BookId).ProjectToType<GetBookOutputDto>().FirstOrDefaultAsync();
        }
    }
}
