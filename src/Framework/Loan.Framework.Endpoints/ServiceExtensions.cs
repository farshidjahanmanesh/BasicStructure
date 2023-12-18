using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Loan.Framework.Commons.Contracts;
using Loan.Framework.Commons.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

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

        public static IServiceCollection AddJWTService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IJWTService, JWTService>(c => new JWTService(""));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };
            });

            return services;
        }

    }
}
