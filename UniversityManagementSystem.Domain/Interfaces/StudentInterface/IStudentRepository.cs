using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.Domain.Entities.StudentEntity;

namespace UniversityManagementSystem.Domain.Interfaces.StudentInterface
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<IEnumerable<Student>> GetAllStudentsWithFacultyIdAsync(int facultyId);
        Task<IEnumerable<Student>> GetAllStudentsWithCourseIdAsync(int courseId);
        Task<IEnumerable<Student>> GetAllStudentsByDegreeAsync(Degree degree);
        Task<int> AddStudentAsync(Student student);
        Task<int> BatchAddStudentsAsync(IEnumerable<Student> students);
        Task<int> UpdateStudentAsync(Student student);
        Task<int> DeleteStudentAsync(int id);
    }
}
