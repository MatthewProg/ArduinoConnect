using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArduinoConnect.DataAccess.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;

namespace ArduinoConnect.Web
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
            var config = new MapperConfiguration(cfg =>
            {
                //DataAccess -> Response
                cfg.CreateMap<DataAccess.Models.TokenModel, Web.ResponseModels.TokenModel>();
                cfg.CreateMap<DataAccess.Models.DataTableModel, Web.ResponseModels.DataTableModel>();
                cfg.CreateMap<DataAccess.Models.ExchangeTableModel, Web.ResponseModels.ExchangeTableModel>();
                cfg.CreateMap<DataAccess.Models.ReceiverModel, Web.ResponseModels.ReceiverModel>();
                cfg.CreateMap<DataAccess.Models.UserTableModel, Web.ResponseModels.UserTableModel>();

                //Request -> DataAccess
                //NOT USED cfg.CreateMap<Web.RequestModels.DataTableModel, DataAccess.Models.DataTableModel>();
                cfg.CreateMap<Web.RequestModels.ExchangeTableModel, DataAccess.Models.ExchangeTableModel>();
                //NOT USED cfg.CreateMap<Web.RequestModels.ReceiverModel, DataAccess.Models.ReceiverModel>();
                //NOT USED cfg.CreateMap<Web.RequestModels.TokenModel, DataAccess.Models.TokenModel>();
                //NOT USED cfg.CreateMap<Web.RequestModels.UserTableModel, DataAccess.Models.UserTableModel>();
            });
            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
