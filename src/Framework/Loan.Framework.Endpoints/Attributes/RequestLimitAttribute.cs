using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Loan.Core.Domain.Contracts;
using System;
using System.Net;
using Loan.Core.Domain.Exceptions;

namespace Loan.Framework.Endpoints.Attributes
{
    //[AttributeUsage(AttributeTargets.Method)]
    public class RequestLimitAttribute : ActionFilterAttribute
    {
        //public RequestLimitAttribute(string name)
        //{
        //    Name = name;
        //}
        //public string Name { get; }
        public LimitType LimitType { get; set; } = LimitType.UserName;
        //public int NoOfRequest { get; set; } = 1;
        //public int Seconds { get; set; } = 1;
        private static MemoryCache Cache { get; } = new(new MemoryCacheOptions());
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = ((ControllerBase)context.Controller)
                                .ControllerContext.ActionDescriptor.ControllerName;
            var actionName = ((ControllerBase)context.Controller)
                                .ControllerContext.ActionDescriptor.ActionName;

            var userService = (IUserDataService)context.HttpContext.RequestServices.GetService(typeof(IUserDataService));
            //var userName = userService.UserId;
            var configs = (IConfiguration)context.HttpContext.RequestServices.GetService(typeof(IConfiguration));

            var memoryCacheKey = $"{controllerName}_{actionName}_{userService.IP}";
            Cache.TryGetValue(memoryCacheKey, out int prevReqCount);
            if (prevReqCount >= int.Parse(configs["Limit:NoOfRequest"]))
            {
                throw new RateLimitException($"Request limit is exceeded. Try again in {int.Parse(configs["Limit:Seconds"])} seconds.");
                
            }
            else
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(int.Parse(configs["Limit:Seconds"])));
                Cache.Set(memoryCacheKey, prevReqCount + 1, cacheEntryOptions);
            }
        }
    }
    public enum LimitType
    {
        Ip,
        UserName
    }
}
