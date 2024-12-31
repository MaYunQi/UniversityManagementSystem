
using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.Domain.Entities.StudentEntity;

namespace UniversityManagementSystem.Domain.Interfaces.StudentInterface
{
    public interface IStudentService
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<IEnumerable<Student>> GetAllStudentsWithFacultyIdAsync(int facultyId);
        Task<IEnumerable<Student>> GetAllStudentsWithCourseIdAsync(int courseId);
        Task<IEnumerable<Student>> GetAllStudentsByDegree(Degree degree);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
    }
}
