using AutoMapper;
using FaMEServices.Interfaces;
using FaMEServices.Logics;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Repositories.Repositories;
using FaMEServices.Security.Interfaces;
using FaMEServices.Security.Logics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;

namespace FaMEServices
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
            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFaMEHelper, FaMEHelper>();
            services.AddScoped<IProfileLogic, ProfileLogic>();
            services.AddScoped<IAttendanceLogic, AttendanceLogic>();
            services.AddScoped<ILeaveLogic, LeaveLogic>();
            services.AddScoped<ITransferLogic, TransferLogic>();
            services.AddScoped<IReportsLogic, ReportsLogic>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<ITransferRepository, TransferRepository>();
            services.AddScoped<IReportsRepository, ReportsRepository>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var signingKey = Convert.FromBase64String(Configuration["Jwt:SigningSecret"]);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "FaMEServices",
                    Description = "FaMEServices",
                    //TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Dhiraj Bairagi",
                        Email = "dhiraj.bairagi@yahoo.com",
                        Url = new Uri("https://www.linkedin.com/in/dhirajbairagi/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "FaMEServices",
                        //Url = new Uri("https://example.com/license"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
