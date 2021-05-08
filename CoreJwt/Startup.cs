using System;
using AutoMapper;
using CoreJwt.EmailServices;
using CoreJwt.Helpers;
using CoreJwt.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using System.IO;
namespace WebApi {
    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        // add services to the DI container
        public void ConfigureServices (IServiceCollection services) {
            services.Configure<AppSettings> (Configuration.GetSection ("AppSettings"));
            var key = System.Text.Encoding.UTF8.GetBytes (Configuration["AppSettings:Secret"].ToString ());
            services.AddDbContext<StoreContext> (s => s.UseSqlServer (Configuration.GetConnectionString ("DefaultConnection")));
            services.AddSingleton<IEmailSender, EmailSender> ();
            services.Configure<EmailOptions> (Configuration);
            services.AddCors ();
            services.AddAuthentication (x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer (c => {
                c.RequireHttpsMetadata = false;
                c.SaveToken = false;
                c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey (key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
           
            services.AddScoped<IAuthenticationRepo, AuthenticationRepo> ();
            services.AddControllers (option => { option.EnableEndpointRouting = false; })
                .SetCompatibilityVersion (CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson (options => {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver ();
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        // configure the HTTP request pipeline
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseRouting ();

            // global cors policy
            app.UseCors (x => x
                .AllowAnyOrigin ()
                .AllowAnyMethod ()
                .AllowAnyHeader ());
            app.UseStaticFiles (new StaticFileOptions () {
                FileProvider = new PhysicalFileProvider (Path.Combine (env.ContentRootPath, "Images")),
                    RequestPath = "/Images"
            });
            app.UseEndpoints (x => x.MapControllers ());
        }
    }
}