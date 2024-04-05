using DOWNNOTIFIER.BusinessLayer.Abstract;
using DOWNNOTIFIER.BusinessLayer.Concrete;
using DOWNNOTIFIER.Notification.Concrete;
using DOWNNOTIFIER.WebApp.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DOWNNOTIFIER.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IUserRoleBL, UserRoleBL>();
            builder.Services.AddTransient<IUserBL, UserBL>();
            builder.Services.AddTransient<IApplicationBL, ApplicationBL>();

            builder.Services.AddSingleton<EMailNotification>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            // Add services to the container.
            builder.Services.AddControllersWithViews(x => x.Filters.Add(new GeneralException()));

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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Dashboard}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
