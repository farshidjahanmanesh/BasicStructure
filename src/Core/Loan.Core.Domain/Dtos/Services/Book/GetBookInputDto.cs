using Loan.Framework.Commons.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Loan.Core.Domain.Dtos.Services.Book
{
    public record GetBookInputDto(int BookId) : BaseInputDto;
}
