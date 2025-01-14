using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Data.Contexts;
using Models;

namespace Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // EntityFramework
        builder.Services.AddDbContext<AppDbContext>(o => o.UseLazyLoadingProxies()
            .UseSqlServer(connectionString, options => options.MigrationsAssembly("Data")));

        // Identiy
        builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.ExpireTimeSpan = TimeSpan.FromDays(7);
            options.SlidingExpiration = true;
            options.LoginPath = "/Auth/Login";
            options.AccessDeniedPath = "/Auth/Login";
        });

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 1;
            options.Password.RequiredUniqueChars = 1;
        });

        // Add services to the container.
        builder.Services.AddControllersWithViews();

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

        // Identity authentication
        app.UseAuthentication();

        app.UseAuthorization();

        app.UseStatusCodePagesWithRedirects("/404");

        app.MapControllerRoute(
            name: "404",
            pattern: "404",
            defaults: new { controller = "Base", action = "Error404" });

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}