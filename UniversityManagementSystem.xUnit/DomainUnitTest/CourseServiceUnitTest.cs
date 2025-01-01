using Moq;
using UniversityManagementSystem.Domain.Interfaces.AcademicInterface;
using UniversityManagementSystem.Domain.Services.AcademicServices;

namespace UniversityManagementSystem.UnitTest.DomainUnitTest
{
    public class CourseServiceUnitTest
    {
        private readonly Mock<ICourseRepository> _mockCourseRepository;
        private readonly CourseService _courseService;
        public CourseServiceUnitTest()
        {
            _mockCourseRepository=new Mock<ICourseRepository>();
            _courseService = new CourseService(_mockCourseRepository.Object);
        }
    }
}
