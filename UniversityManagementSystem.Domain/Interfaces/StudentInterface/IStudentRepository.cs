using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.Domain.Entities.StudentEntity;

namespace UniversityManagementSystem.Domain.Interfaces.StudentInterface
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> GetStudentByStudentIdAsync(int studentId);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<IEnumerable<Student>> GetAllStudentsByFacultyIdAsync(int facultyId);
        Task<IEnumerable<Student>> GetAllStudentsByMajorIdAsync(int majorId);
        Task<IEnumerable<Student>> GetAllStudentsByCourseIdAsync(int courseId);
        Task<IEnumerable<Student>> GetAllStudentsByDegreeAsync(Degree degree);
        Task<int> GetLastStudentIdByFacultyIdAndDegreeAsync(int facultyId, Degree degree);
        Task<int> AddStudentAsync(Student student);
        Task<int> BatchAddStudentsAsync(IEnumerable<Student> students);
        Task<int> UpdateStudentAsync(Student student);
        Task<int> DeleteStudentAsync(int id);
    }
}
