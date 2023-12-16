using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Loan.Framework.Endpoints
{
    public static class ServiceExtensions
    {
        public static MvcOptions AddArdalisResult(this MvcOptions options)
        {
            return options.AddDefaultResultConvention()
                .AddResultConvention(resultStatusMap => resultStatusMap
                .AddDefaultMap()
                .For(ResultStatus.Ok, HttpStatusCode.OK)
                .For(ResultStatus.NotFound, HttpStatusCode.NotFound));
        }

      //  public static IServiceCollection AddSwaggerGen2(this IServiceCollection services)
      //  {
           
      //      return services.AddSwaggerGen(config =>
      //      {
      //          config.CustomSchemaIds(s => s.FullName?.Replace("+", "-"));
      //          config.UseAllOfToExtendReferenceSchemas();
      //          var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
      //          config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
      //          //config.UseInlineDefinitionsForEnums();
      //          config.AddEnumsWithValuesFixFilters();
      //          config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      //          {
      //              Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
      //                      Enter 'Bearer' [space] and then your token in the text input below.
      //                      \r\n\r\nExample: 'Bearer 12345abcdef'",
      //              Name = "Authorization",
      //              In = ParameterLocation.Header,
      //              Type = SecuritySchemeType.ApiKey,
      //              Scheme = "Bearer"
      //          });

      //          config.AddSecurityRequirement(new OpenApiSecurityRequirement()
      //{
      //        {
      //          new OpenApiSecurityScheme
      //          {
      //            Reference = new OpenApiReference
      //              {
      //                Type = ReferenceType.SecurityScheme,
      //                Id = "Bearer"
      //              },
      //              Scheme = "oauth2",
      //              Name = "Bearer",
      //              In = ParameterLocation.Header,

      //            },
      //            new List<string>()
      //          }
      //  });


      //      });
      //  }
    }
}
