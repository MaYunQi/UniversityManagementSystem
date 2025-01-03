using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Application.Mappings;
using UniversityManagementSystem.Application.Services;
using UniversityManagementSystem.Domain.Interfaces.AcademicInterface;
using UniversityManagementSystem.Domain.Interfaces.StudentInterface;
using UniversityManagementSystem.Domain.Services.AcademicServices;
using UniversityManagementSystem.Domain.Services.StudentServices;
using UniversityManagementSystem.Infrastructure.DbContexts;
using UniversityManagementSystem.Infrastructure.Repositories;
using UniversityManagementSystem.UI.ViewModelMapping;

namespace UniversityManagementSystem.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<WebApplicationDBContext>(option =>
            option.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion("8.0.40")
            ));

           
            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<StudentProfile>();
                cfg.AddProfile<StudentVMProfile>();
            });
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<StudentAppService>();

            builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();
            builder.Services.AddScoped<IFacultyService, FacultyService>();
            //builder.Services.AddScoped<FacultyAppService>();

            var app = builder.Build();

            if(builder.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(
                name:"Defalut",
                pattern:"{controller=Home}/{Action=Index}/{id?}");
            app.Run();
        }
    }
}
