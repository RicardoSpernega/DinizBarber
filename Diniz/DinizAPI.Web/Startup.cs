using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DinizAPI.Application;
using DinizAPI.Domain.Enuns;
using DinizAPI.Domain.Interfaces.Repositories;
using DinizAPI.Domain.Interfaces.Services;
using DinizAPI.Domain.Models.Api;
using DinizAPI.Infrastructure.Repositories;
using DinizAPI.Web.Utils.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DinizAPI.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Autenticação

           
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            #region Tratamento de Erros
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            #endregion

            #region Configuração Cors
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder
                    .SetIsOriginAllowed(origin => true)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithMethods("GET", "POST", "DELETE", "PUT", "OPTIONS")
                    .Build();
                });
            });
            #endregion

            #region Injeção de dependencias

            //services.AddTransient<IRepository, REpository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IHorarioService, HorarioService>();
            services.AddTransient<IHorarioRepository, HorarioRepository>();
            services.AddTransient<ILoginHorarioRepository, LoginHorarioRepository>();
            services.AddTransient<ILoginHorarioService, LoginHorarioService>();

            #endregion

            #region Configuração Versionamento
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
            #endregion

            #region Configuração Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Diniz API", Description = "Documentação da API", Version = "1" });
                c.EnableAnnotations();

                c.MapType<TipoStatusAPIEnum>(() => new OpenApiSchema
                {
                    Type = "string",
                    Enum = typeof(TipoStatusAPIEnum).GetEnumNames().Select(name => new OpenApiString(name)).Cast<IOpenApiAny>().ToList(),
                    Nullable = true
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
                // Apply the filters
                c.OperationFilter<RemoveVersionFromParameter>();
                c.DocumentFilter<ReplaceVersionWithExactValueInPath>();

                // Ensure the routes are added to the right Swagger doc
                c.DocInclusionPredicate((version, desc) =>
                {
                    if (!desc.TryGetMethodInfo(out MethodInfo methodInfo))
                        return false;

                    var versions = methodInfo.DeclaringType
                    .GetCustomAttributes(true)
                    .OfType<ApiVersionAttribute>()
                    .SelectMany(attr => attr.Versions);

                    var maps = methodInfo
                    .GetCustomAttributes(true)
                    .OfType<MapToApiVersionAttribute>()
                    .SelectMany(attr => attr.Versions)
                    .ToArray();

                    return versions.Any(v => $"v{v.ToString()}" == version)
                    && (!maps.Any() || maps.Any(v => $"v{v.ToString()}" == version));
                });
            });

            #endregion

            services.AddControllers();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("EnableCORS");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.RoutePrefix = string.Empty;
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
