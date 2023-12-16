using Loan.Core.Domain.Parameters.Book;
using Loan.Framework.Commons.Entities;

namespace Loan.Core.Domain.Entities
{
    public class Book : Entity<long>
    {
        protected Book()
        {

        }
        public string Title { get; private set; }
        public string AuthorName { get; private set; }

        public static Book CreateBook(CreateBookInputParameter parameters)
        {
            return new Book()
            {
                AuthorName = parameters.authorName,
                Title = parameters.title
            };
        }
    }
}
