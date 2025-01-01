
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Domain.Entities.AcademicEntity;
using UniversityManagementSystem.Domain.Entities.StudentEntity;

namespace UniversityManagementSystem.Infrastructure.DbContexts
{
     public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options):base(options) { }

        DbSet<Student> Students { get; set; }
        DbSet<Faculty> Faculties { get; set; }
    }
}
