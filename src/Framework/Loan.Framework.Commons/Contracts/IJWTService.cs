using Loan.Framework.Commons.Dtos.JWTService;

namespace Loan.Framework.Commons.Contracts
{
    public interface IJWTService
    {
        Task<GetTokenOutputDto> GetToken(GetTokenInputDto inputModel);
    }
}
