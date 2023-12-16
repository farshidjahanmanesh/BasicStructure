using Loan.Framework.Endpoints.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Loan.API.REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [RequestLimit]
    public class BaseController : ControllerBase
    {

    }
}
