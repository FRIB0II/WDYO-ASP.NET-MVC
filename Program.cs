using Microsoft.EntityFrameworkCore;
using WhatDoYouOwn_ASPNET.Helper;
using WhatDoYouOwn_ASPNET.Repository.Interfaces;
using WhatDoYouOwn_ASPNET.Repository.Repositorys;

namespace WhatDoYouOwn_ASPNET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configuração do banco de dados MySQL.
            builder.Services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("Database")
                );
            });

            // Injeção de depedência.
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserSession, UserSession>();
            builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}
