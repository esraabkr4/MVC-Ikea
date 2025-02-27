using Ikea.DAL.Persistence.Data;
using Ikea.DAL.Persistence.Repository.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Ikea.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //New Method
            builder.Services.AddDbContext<ApplicationDbContext>((optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString( "DefualtConnection"));
                
            });
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //Old Method 
            //builder.Services.AddScoped<ApplicationDbContext>();
            //builder.Services.AddScoped<DbContextOptions<ApplicationDbContext>>((ServiceProvider) =>
            //{
            //    //return new DbContextOptions<ApplicationDbContext>();//not recommended
            //    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //    optionsBuilder.UseSqlServer("Server=.;DataBase=IkeaDB;Trusted_Connection=True;TrustServerCertificate=True;");
            //    var options= optionsBuilder.Options;
            //    return options;
            //});
            #endregion

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
