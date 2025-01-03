
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
        public async Task<int> AddCourseAsync(Course course)
        {
            if (course == null)
                return -1;
            int result = await _courseRepository.AddCourseAsync(course);
            if (result == 0)
            {
                Course local= await _courseRepository.GetCourseByCourseIdAsync(course.CourseId);
                if (local == null)
                    return 0;
                else
                    return -1;
            }
            return result;
        }

        public async Task<int> DeleteCourseAsync(ushort courseId)
        {
            if (courseId < 0)
                return -1;
            int result = await _courseRepository.DeleteCourseAsync(courseId);
            if (result == 0)
            {
                Course local = await _courseRepository.GetCourseByCourseIdAsync(courseId);
                if (local == null)
                    return -1;
                else
                    return 0;
            }
            return result;
        }
        public async Task<int> UpdateCourseAsync(Course course)
        {
            if(course==null)
                return -1;
            int result = await _courseRepository.UpdateCourseAsync(course);
            if (result == 0)
            {
                Course local = await _courseRepository.GetCourseByCourseIdAsync(course.CourseId);
                if (local == null)
                    return -1;
                else
                    return 0;
            }
            return result;
        }
        public async Task<Course> GetCourseByCourseCodeAsync(string code)
        {
            return await _courseRepository.GetCourseByCourseCodeAsync(code);
        }

        public async Task<Course> GetCourseByCourseIdAsync(ushort courseId)
        {
            return await _courseRepository.GetCourseByCourseIdAsync(courseId);
        }
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllCoursesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesByFacultyIdAsync(sbyte facultId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesByMajorIdAsync(ushort majorId)
        {
            throw new NotImplementedException();
        }
    }
}
