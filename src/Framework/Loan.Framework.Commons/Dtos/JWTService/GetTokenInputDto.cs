using System.Security.Claims;

namespace Loan.Framework.Commons.Dtos.JWTService
{
    public record GetTokenInputDto(List<Claim> Claims) : BaseInputDto;
}
