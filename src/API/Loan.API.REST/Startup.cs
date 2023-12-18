using Loan.API.REST.Models;
using Loan.Core.Application;
using Loan.Core.Domain.Contracts;
using Loan.Framework.Commons.Contracts;
using Loan.Framework.Commons.Services;
using Loan.Framework.Endpoints;
using Loan.Framework.Endpoints.Middlewares;
using Loan.InfraLoan.Persistence;
using Loan.Infrastructure.Communication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System;
using System.Text;
using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;
namespace Loan.API.REST
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader());
            });

            services.AddJWTService(Configuration);
            services.AddControllers(options =>
            {
                options.AddArdalisResult();
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddPersistenceServices(Configuration);
            services.AddApplicationServices();
            services.AddCommunicationServices(Configuration);

            //services.AddSwaggerGen();
            services.AddSwaggerGen(config =>
            {
                config.CustomSchemaIds(s => s.FullName?.Replace("+", "-"));
                config.UseAllOfToExtendReferenceSchemas();
                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
                //config.UseInlineDefinitionsForEnums();
                config.AddEnumsWithValuesFixFilters();
                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                            Enter 'Bearer' [space] and then your token in the text input below.
                            \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                config.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
              {
                new OpenApiSecurityScheme
                {
                  Reference = new OpenApiReference
                    {
                      Type = ReferenceType.SecurityScheme,
                      Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,

                  },
                  new List<string>()
                }
        });


            });

            services.AddHttpContextAccessor();

            services.AddScoped<IUserDataService, UserDataService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
            });
            app.UseRequestResponseLoggingMiddleware();
            app.UseExceptionMiddleware();
            app.UseEndpoints(config =>
            {
                config.MapDefaultControllerRoute();
            });
        }


    }
}
