
using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.Domain.Entities.StudentEntity;

namespace UniversityManagementSystem.Domain.Interfaces.StudentInterface
{
    public interface IStudentService
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<int> AddStudentAsync(Student student);
        Task<int> UpdateStudentAsync(Student student);
        Task<int> DeleteStudentAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<IEnumerable<Student>> GetAllUndergraduateStudentsAsync();
        Task<IEnumerable<Student>> GetAllGraduateStudentsAsync();
        Task<IEnumerable<Student>> GetAllDoctoralStudentsAsync();
        Task<IEnumerable<Student>> GetAllStudentsByFacultyIdAsync(int facultyId);
        Task<IEnumerable<Student>> GetAllUndergraduateStudentsByFacultyIdAsync(int facultyId);
        Task<IEnumerable<Student>> GetAllGraduateStudentsByFacultyIdAsync(int facultyId);
        Task<IEnumerable<Student>> GetAllDoctoralStudentsByFacultyIdAsync(int facultyId);
        Task<IEnumerable<Student>> GetAllStudentsByCourseIdAsync(int courseId);
        Task<IEnumerable<Student>> GetAllStudentsByMajorIdAsync(int majorId);
    }
}
