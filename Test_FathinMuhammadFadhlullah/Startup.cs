using System;
using System.Globalization;
using Test_FathinMuhammadFadhlullah.Repositories;
using Test_FathinMuhammadFadhlullah.Repositories.Impl;
using Test_FathinMuhammadFadhlullah.Services;
using Test_FathinMuhammadFadhlullah.Services.Impl;
using Test_FathinMuhammadFadhlullah.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace Test_FathinMuhammadFadhlullah
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IHostingEnvironment CurrentEnvironment { get; }
        public IConfiguration Configuration { get; }
        public static IConfiguration StaticConfig { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(Configuration.GetValue<double>("SessionSettings:IdleTimeout")); // It depends on user requirements.
                options.Cookie.Name = "auth_cookie";
                options.Cookie.SameSite = SameSiteMode.Lax;

            });

            services.AddResponseCaching();

            services.AddMvc(o =>
            {
                o.Filters.Add(new ResponseCacheAttribute { NoStore = true, Location = ResponseCacheLocation.None });
                o.CacheProfiles.Add("default", new CacheProfile
                {
                    Duration = 0,
                    Location = ResponseCacheLocation.Any,
                    NoStore = true
                });
            })
                   .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<IUserRepository>(o => new UserRepository(Configuration));
            services.AddTransient<IMenuRepository>(o => new MenuRepository(Configuration));
            services.AddTransient<IUserGroupRepository>(o => new UserGroupRepository(Configuration));
            services.AddTransient<IPenerbitRepository>(o => new PenerbitRepository(Configuration));
            services.AddTransient<IBukuRepository>(o => new BukuRepository(Configuration));

            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserGroupService, UserGroupService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            app.UseResponseCaching();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/NoAuth/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithRedirects("/NoAuth/Error/{0}");

            LogManager.Configuration.Variables["connectionString"] = Configuration.GetConnectionString("DefaultConnection");

            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings.Add(".apk", "application/com.android.package-install always");
            app.UseStaticFiles(new StaticFileOptions()
            {
                ContentTypeProvider = provider,
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
                    context.Context.Response.Headers.Append("Expires", "0");
                    context.Context.Response.Headers.Append("Pragma", "no-cache");
                }
            });

            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "areas", template: "{area:exists}/{controller}/{action}/{id?}", defaults: new { controller = "Home", action = "Index" });
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });

            var cultureInfo = new CultureInfo("id-ID");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            AppHttpContext.Services = app.ApplicationServices;
        }
    }
}
