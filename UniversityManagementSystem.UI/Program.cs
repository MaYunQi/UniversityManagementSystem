
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Application.Mappings;
using UniversityManagementSystem.Infrastructure.DbContexts;

namespace UniversityManagementSystem.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<WebApplicationDBContext>(options => options.UseMySql(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8,0,40))));
           
            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<StudentProfile>();
            });

            var app = builder.Build();

            if(builder.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
