
using UniversityManagementSystem.Domain.Entities.AcademicEntity;

namespace UniversityManagementSystem.Domain.Interfaces.AcademicInterface
{
    public interface ICourseService
    {
        Task<Course> GetCourseByCourseIdAsync(int courseId);
        Task<Course> GetCourseByCourseCodeAsync(string code);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<IEnumerable<Course>> GetAllCoursesByFacultyIdAsync(int facultId);
        Task<IEnumerable<Course>> GetAllCoursesByMajorIdAsync(int majorId);
        Task<int> AddCourseAsync(Course course);
        Task<int> DeleteCourseAsync(int courseId);
        Task<int> UpdateCourseAsync(Course course);
    }
}
