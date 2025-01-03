using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.Domain.Entities.StudentEntity;

namespace UniversityManagementSystem.Domain.Interfaces.StudentInterface
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByIdAsync(uint id);
        Task<Student> GetStudentByStudentIdAsync(ulong studentId);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<IEnumerable<Student>> GetAllStudentsByFacultyIdAsync(sbyte facultyId);
        Task<IEnumerable<Student>> GetAllStudentsByMajorIdAsync(ushort majorId);
        Task<IEnumerable<Student>> GetAllStudentsByCourseIdAsync(ushort courseId);
        Task<IEnumerable<Student>> GetAllStudentsByDegreeAsync(Degree degree);
        Task<ulong> GetLastStudentIdByFacultyIdAndDegreeAsync(sbyte facultyId, Degree degree);
        Task<int> AddStudentAsync(Student student);
        Task<int> BatchAddStudentsAsync(IEnumerable<Student> students);
        Task<int> UpdateStudentAsync(Student student);
        Task<int> DeleteStudentAsync(uint id);
    }
}
