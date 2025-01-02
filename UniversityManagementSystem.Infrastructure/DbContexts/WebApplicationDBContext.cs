
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Domain.Entities.AcademicEntity;
using UniversityManagementSystem.Domain.Entities.StudentEntity;

namespace UniversityManagementSystem.Infrastructure.DbContexts
{
     public class WebApplicationDBContext:DbContext
    {
        public WebApplicationDBContext(DbContextOptions<WebApplicationDBContext> options):base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

    }
}
