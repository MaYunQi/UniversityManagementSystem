
using UniversityManagementSystem.Domain.Entities.AcademicEntity;
using UniversityManagementSystem.Domain.Interfaces.AcademicInterface;

namespace UniversityManagementSystem.Domain.Services.AcademicServices
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository= courseRepository;
        }
        public Task<int> AddCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteCourseAsync(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAllCoursesByFacultyIdAsync(int facultId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAllCoursesByMajorIdAsync(int majorId)
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetCourseByCourseCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetCourseByCourseIdAsync(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
