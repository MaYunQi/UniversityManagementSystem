
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.Domain.Entities.StudentEntity;
using UniversityManagementSystem.Domain.Interfaces.StudentInterface;
using UniversityManagementSystem.Infrastructure.DbContexts;

namespace UniversityManagementSystem.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly WebApplicationDBContext _dbContext;
        public StudentRepository(WebApplicationDBContext dBContext)
        {
            _dbContext= dBContext; ;
        }
        public async Task<int> AddStudentAsync(Student student)
        {
            _dbContext.Students.Add(student);
            return await _dbContext.SaveChangesAsync();
        }

        public Task<int> BatchAddStudentsAsync(IEnumerable<Student> students)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteStudentAsync(int id)
        {
            Student student = await _dbContext.Students.FirstOrDefaultAsync(s => s.StudentId == id);
            if (student != null) 
            { 
                _dbContext.Students.Remove(student);
                return await _dbContext.SaveChangesAsync();
            }
            return -1;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsByDegreeAsync(Degree degree)
        {
            return await _dbContext.Students.Where(x=>x.Degree==degree).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsByFacultyIdAsync(int facultyId)
        {
            return await _dbContext.Students.Where(s=>s.FacultyId==facultyId).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsByMajorIdAsync(int majorId)
        {
            return await _dbContext.Students.Where(s => s.MajorId == majorId).ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(s=>s.Id==id);
        }

        public async Task<int> UpdateStudentAsync(Student student)
        {
            _dbContext.Students.Update(student);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Student>> GetAllStudentsByCourseIdAsync(int courseId)
        {
            throw new NotImplementedException();
        }
        public async Task<Student> GetStudentByStudentIdAsync(int studentId)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);
        }
        public async Task<int> GetLastStudentIdByFacultyIdAndDegreeAsync(int facultyId,Degree degree)
        {
            return await _dbContext.Students
                .Where(s => s.FacultyId == facultyId && s.Degree == degree)
                .OrderByDescending(s => s.StudentId)
                .Select(s => s.StudentId)
                .FirstOrDefaultAsync();
        }
    }
}
