using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Primitives;
using AuthServer.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Core;
using OpenIddict.EntityFrameworkCore.Models;

namespace AuthServer
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
                options.UseOpenIddict();
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            services.AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                        .UseDbContext<ApplicationDbContext>();
                })
                .AddServer(options =>
                {
                    options.UseMvc();

                    options.AllowImplicitFlow();

                    options.RegisterScopes(OpenIdConnectConstants.Scopes.Email,
                       OpenIdConnectConstants.Scopes.Profile,
                       OpenIddictConstants.Scopes.Roles);

                    options.SetAccessTokenLifetime(TimeSpan.FromMinutes(20));

                    options.DisableHttpsRequirement();

                    options.EnableLogoutEndpoint("/connect/logout")
                        .EnableUserinfoEndpoint("/api/userinfo")
                        .EnableIntrospectionEndpoint("/connect/introspect")
                        .EnableAuthorizationEndpoint("/connect/authorize");

                    options.AddEphemeralSigningKey();

                    // options.AddDevelopmentSigningCertificate();

                    // options.AddSigningKey(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("953183eb-988d-403e-8b8a-7dd9cd44e303")));

                    // options.AddSigningKey(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdjkahsdjkhasjkdhajkshdjkahdjkHJKSAHDJKAHJKDHAJKSHDJKDKL")));

                    options.UseJsonWebTokens();
                });

            services.AddCors();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.Authority = "http://localhost:5000/";
                    options.Audience = "dataEventRecords";
                    options.RequireHttpsMetadata = false;
                    options.IncludeErrorDetails = true;

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        NameClaimType = OpenIdConnectConstants.Claims.Subject,
                        RoleClaimType = OpenIdConnectConstants.Claims.Role,
                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddDebug(LogLevel.Information);
            loggerFactory.AddConsole(LogLevel.Information);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            {
                options.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();

            InitializeAsync(app.ApplicationServices).GetAwaiter().GetResult();

        }

        private async Task InitializeAsync(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await context.Database.EnsureCreatedAsync();

                await CreateApplicationsAsync();

                async Task CreateApplicationsAsync()
                {
                    var manager = scope.ServiceProvider.GetRequiredService<OpenIddictApplicationManager<OpenIddictApplication>>();

                    var descriptor = new OpenIddictApplicationDescriptor
                    {
                        ClientId = "angular-spa",
                        DisplayName = "Angular Client App",
                        PostLogoutRedirectUris = { new Uri("http://localhost:9000/signout-oidc") },
                        RedirectUris = { new Uri("http://localhost:9000/assets/signin-oidc.html") },
                        Permissions =
                        {
                            OpenIddictConstants.Permissions.Endpoints.Authorization,
                            OpenIddictConstants.Permissions.Endpoints.Logout,
                            OpenIddictConstants.Permissions.GrantTypes.Implicit,
                            OpenIddictConstants.Permissions.Scopes.Email,
                            OpenIddictConstants.Permissions.Scopes.Profile,
                            OpenIddictConstants.Permissions.Scopes.Roles,
                        },
                    };

                    var existingApp = await manager.FindByClientIdAsync("angular-spa");
                    if (existingApp == null)
                    {


                        await manager.CreateAsync(descriptor);
                    }
                    else
                    {
                        await manager.DeleteAsync(existingApp);
                        await manager.CreateAsync(descriptor);
                    }
                }
            }
        }
    }
}
