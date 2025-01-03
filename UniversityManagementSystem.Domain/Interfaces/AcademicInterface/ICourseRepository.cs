
using UniversityManagementSystem.Domain.Entities.AcademicEntity;

namespace UniversityManagementSystem.Domain.Interfaces.AcademicInterface
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseByCourseIdAsync(ushort courseId);
        Task<Course> GetCourseByCourseCodeAsync(string code);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<IEnumerable<Course>> GetAllCoursesByFacultyIdAsync(sbyte facultId);
        Task<IEnumerable<Course>> GetAllCoursesByMajorIdAsync(ushort majorId);
        Task<int> AddCourseAsync(Course course);
        Task<int> DeleteCourseAsync(ushort courseId);
        Task<int> UpdateCourseAsync(Course course);
    }
}
