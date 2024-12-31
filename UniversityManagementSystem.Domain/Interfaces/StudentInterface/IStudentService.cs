
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
        Task<IEnumerable<Student>> GetAllStudentsWithFacultyIdAsync(int facultyId);
        Task<IEnumerable<Student>> GetAllUndergraduateStudentsWithFacultyIdAsync(int facultyId);
        Task<IEnumerable<Student>> GetAllGraduateStudentsWithFacultyIdAsync(int facultyId);
        Task<IEnumerable<Student>> GetAllDoctoralStudentsWithFacultyIdAsync(int facultyId);
        Task<IEnumerable<Student>> GetAllStudentsWithCourseIdAsync(int courseId);
    }
}
