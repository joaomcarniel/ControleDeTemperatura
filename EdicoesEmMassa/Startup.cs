using EdicoesEmMassa.DataContext;
using EdicoesEmMassa.Repository;
using EdicoesEmMassa.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql;
using System;

namespace EdicoesEmMassa
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
            services.AddSwaggerGen();
            var _connectionString = Configuration.GetConnectionString("DataBase").ToString();
            services.AddDbContext<jupiterContext>(o => o.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString)));

            services.AddScoped<IIncubadoraRepository, IncubadoraRepository>();
            services.AddScoped<ITemperaturaRepository, TemperaturaRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRelatorioService, RelatorioService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IIncubatorService, IncubatorService>();

            services.AddAuthentication("Identity.Login").AddCookie("Identity.Login", config =>
            {
                config.Cookie.Name = "Identity.Login";
                config.LoginPath = "/Login";
                config.AccessDeniedPath = "/Home";
                config.ExpireTimeSpan = TimeSpan.FromHours(1);
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

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
