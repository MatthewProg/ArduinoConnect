using ArduinoConnect.DataAccess.DataAccess;
using ArduinoConnect.Web.Managers;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ArduinoConnect.Web
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
            var config = new MapperConfiguration(cfg =>
            {
                //DataAccess -> Response
                cfg.CreateMap<DataAccess.Models.TokenModel, Web.ResponseModels.TokenModel>();
                cfg.CreateMap<DataAccess.Models.DataTableModel, Web.ResponseModels.DataTableModel>();
                cfg.CreateMap<DataAccess.Models.ExchangeTableModel, Web.ResponseModels.ExchangeTableModel>();
                cfg.CreateMap<DataAccess.Models.ReceiverModel, Web.ResponseModels.ReceiverModel>();
                cfg.CreateMap<DataAccess.Models.UserTableModel, Web.ResponseModels.UserTableModel>();

                //Request -> DataAccess
                cfg.CreateMap<Web.RequestModels.DataTableModel, DataAccess.Models.DataTableModel>();
                cfg.CreateMap<Web.RequestModels.ExchangeTableModel, DataAccess.Models.ExchangeTableModel>();
                cfg.CreateMap<Web.RequestModels.UserTableModel, DataAccess.Models.UserTableModel>();
            });
            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Start/Index";
                    options.Cookie.Name = "ArduinoConnectCookie";
                });
            services.AddControllersWithViews();
            services.AddSingleton<IHttpClientManager, HttpClientManager>();
            services.AddSingleton<IApiManager, ApiManager>();
            services.AddSingleton<ISqlDataAccess, SqlDataAccess>(serviceProvider =>
            {
                return new SqlDataAccess(Configuration.GetConnectionString("MainDB"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Error/Error");
                app.UseStatusCodePagesWithReExecute("/Error/Error","?errorCode={0}");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict
            };
            app.UseCookiePolicy(cookiePolicyOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Start}/{action=Index}");
            });
        }
    }
}
