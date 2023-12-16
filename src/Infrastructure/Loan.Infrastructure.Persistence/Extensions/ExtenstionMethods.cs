using System.Linq;

namespace Loan.InfraLoan.Persistence.Extensions
{
    internal static class ExtenstionMethods
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> queryable, int pageNumber, int pageSize)
        {
            return queryable.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }

}
