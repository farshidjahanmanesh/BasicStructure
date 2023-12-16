using Loan.Core.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;
using System.Dynamic;
using System.Text;

namespace Loan.Framework.Endpoints.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //todo
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/hc"))
            {
                await _next(context);
                return;
            }

            var request = context.Request;
            var stopWatch = Stopwatch.StartNew();
            var requestTime = DateTime.Now;
            var (body, header) = await ReadRequestBody(request);
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            var response = context.Response;
            response.Body = responseBody;
            await _next(context);
            stopWatch.Stop();

            var responseBodyContent = await ReadResponseBody(response);
            await responseBody.CopyToAsync(originalBodyStream);
            ExpandoObject responseObj = null;
            List<ExpandoObject> responseListObj = null;
            try
            {
                responseObj = JsonConvert.DeserializeObject<ExpandoObject>(responseBodyContent, new ExpandoObjectConverter());
            }
            catch (Exception ex)
            {
                responseListObj = JsonConvert.DeserializeObject<List<ExpandoObject>>(responseBodyContent, new ExpandoObjectConverter());
            }

            dynamic requestObj = JsonConvert.DeserializeObject<ExpandoObject>(body, new ExpandoObjectConverter());
            string category = "loan";

            //var logger = context.RequestServices.GetService<ILoggerRepository>();
            //await logger.AddRequestResponseLog(new RequestResponseLog()
            //{
            //    ElapsedMilliseconds = stopWatch.ElapsedMilliseconds,
            //    Method = request.Method,
            //    Host = request.Host.Value,
            //    Schema = request.Scheme,
            //    Path = request.Path,
            //    QueryString = request.QueryString.ToString(),
            //    RequestBodyContent = body,
            //    RequestHeaderContent = header,
            //    RequestTime = requestTime,
            //    ResponseBodyContent = responseBodyContent,
            //    StatusCode = response.StatusCode,
            //    TraceIdentifier = context.TraceIdentifier,
            //    UserId = context.User.Identity.IsAuthenticated ? context.User.FindFirstValue(ClaimTypes.NameIdentifier) : "0",
            //    UserName = context.User?.Identity?.Name,
            //    ServiceName = "eshop",
            //    Claims = JsonConvert.SerializeObject(context.User.Claims.Select(h => new { h.Type, h.Value }))
            //});
        }

        private static async Task<(string body, string header)> ReadRequestBody(HttpRequest request)
        {
            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Seek(0, SeekOrigin.Begin);

            return (bodyAsText, JsonConvert.SerializeObject(request.Headers.ToDictionary(h => h.Key, h => h.Value)));// string.Join(",", request.Headers.Select(o => $"{o.Key}: {o.Value} ")));
        }

        private static async Task<string> ReadResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var bodyAsText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }
    }
}
