
using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.Domain.Entities.StudentEntity;

namespace UniversityManagementSystem.Domain.Interfaces.StudentInterface
{
    public interface IStudentService
    {
        Task<Student> GetStudentByIdAsync(uint id);
        Task<Student> GetStudentByStudentIdAsync(ulong studentId);
        Task<int> AddStudentAsync(Student student);
        Task<int> UpdateStudentAsync(Student student);
        Task<int> DeleteStudentAsync(uint id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<IEnumerable<Student>> GetAllUndergraduateStudentsAsync();
        Task<IEnumerable<Student>> GetAllGraduateStudentsAsync();
        Task<IEnumerable<Student>> GetAllDoctoralStudentsAsync();
        Task<IEnumerable<Student>> GetAllStudentsByFacultyIdAsync(sbyte facultyId);
        Task<IEnumerable<Student>> GetAllUndergraduateStudentsByFacultyIdAsync(sbyte facultyId);
        Task<IEnumerable<Student>> GetAllGraduateStudentsByFacultyIdAsync(sbyte facultyId);
        Task<IEnumerable<Student>> GetAllDoctoralStudentsByFacultyIdAsync(sbyte facultyId);
        Task<IEnumerable<Student>> GetAllStudentsByCourseIdAsync(ushort  courseId);
        Task<IEnumerable<Student>> GetAllStudentsByMajorIdAsync(ushort majorId);
        Task<ulong> GetLastStudentIdByFacultyIdAndDegreeAsync(sbyte facultyId, Degree degree);
    }
}
