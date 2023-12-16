using Microsoft.AspNetCore.Http;
using Loan.Core.Domain.Contracts;
using System;
using System.Linq;
using System.Security.Claims;

namespace Loan.API.REST.Models
{
    public class UserDataService : IUserDataService
    {
        private readonly IHttpContextAccessor _context;

        public UserDataService(IHttpContextAccessor context)
        {
            this._context = context;
        }
        public bool? IsAuthenticated { get => _context?.HttpContext?.User?.Identity.IsAuthenticated; }
        public string UserId { get => _context?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier); }
        public string CurrentURL { get => $"{_context.HttpContext.Request.Host}{_context.HttpContext.Request.Path}{_context.HttpContext.Request.QueryString}"; }
        public string IP
        {
            get => _context != null && _context.HttpContext != null &&
                _context.HttpContext.Request.Headers.Any(o => o.Key == "X-Forwarded-For") ?
                _context.HttpContext?.Request.Headers.First(o => o.Key == "X-Forwarded-For").Value.ToString() :
                _context.HttpContext?.Connection.RemoteIpAddress?.ToString();
        }
    }
}
