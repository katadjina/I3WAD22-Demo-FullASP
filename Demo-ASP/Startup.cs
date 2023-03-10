using BLLObject = Demo_BLL.Entities;
using DALObject = Demo_DAL.Entities;
using BLLServ = Demo_BLL.Services;
using DALServ = Demo_DAL.Services;
using Demo_Common.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_ASP.Handlers;

namespace Demo_ASP
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
            services.AddControllersWithViews();

            #region Service d'accessibilité du HttpContext par injection de dépendance
            services.AddHttpContextAccessor();
            #endregion

            #region Appel du sessionManager par injection de dépendance
            services.AddScoped<SessionManager>();
            #endregion

            #region Création du coockie de Session
            services.AddDistributedMemoryCache();
            services.AddSession(options=> {
                options.Cookie.Name = "Theatre.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(50);
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
            });
            #endregion

            #region  inj de dépendance
            services.AddScoped<IClientRepository<BLLObject.Client, int>, BLLServ.ClientService>();
            services.AddScoped<IClientRepository<DALObject.Client, int>, DALServ.ClientService>();
            services.AddScoped<IReservationRepository<BLLObject.Reservation, int>, BLLServ.ReservationService>();
            services.AddScoped<IReservationRepository<DALObject.Reservation, int>, DALServ.ReservationService>();
            services.AddScoped<ILogementRepository<BLLObject.Logement, int>, BLLServ.LogementService>();
            services.AddScoped<ILogementRepository<DALObject.Logement, int>, DALServ.LogementService>();
            //services.AddScoped<ITypeRepository<BLLObject.Type, int>, BLLServ.TypeService>();
            //services.AddScoped<ITypeRepository<DALObject.Type, int>, DALServ.TypeService>();
            #endregion
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

            app.UseSession();
            app.UseCookiePolicy();

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
