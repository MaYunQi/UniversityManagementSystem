using Moq;
using UniversityManagementSystem.Domain.Entities.AcademicEntity;
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
            _mockCourseRepository = new Mock<ICourseRepository>();
            _courseService = new CourseService(_mockCourseRepository.Object);
        }
        [Fact]
        public async Task AddCourseAsync_NullCourse_ReturnMinusOne()
        {
            int expected = -1;
            Course course = null;

            int result = await _courseService.AddCourseAsync(course);
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task AddCourseAsync_AddSuccess_ReturnOne()
        {
            int expected = 1;
            Course course = new Course();
            _mockCourseRepository.Setup(repo => repo.AddCourseAsync(course)).ReturnsAsync(expected);

            int result = await _courseService.AddCourseAsync(course);
            Assert.Equal(expected, result);
            _mockCourseRepository.Verify(repo => repo.AddCourseAsync(course), Times.Once);
        }
        [Fact]
        public async Task AddCourseAsync_CourseExsit_ReturnZero()
        {
            int expected = -1;
            Course course = new Course();
            _mockCourseRepository.Setup(repo => repo.AddCourseAsync(course)).ReturnsAsync(0);
            _mockCourseRepository.Setup(repo => repo.GetCourseByCourseIdAsync(course.Id)).ReturnsAsync(new Course());

            int result = await _courseService.AddCourseAsync(course);
            Assert.Equal(expected, result);
            _mockCourseRepository.Verify(repo => repo.AddCourseAsync(course), Times.Once);
        }
        [Fact]
        public async Task AddCourseAsync_AddFail_ReturnZero()
        {
            int expected = 1;
            Course course = new Course();
            _mockCourseRepository.Setup(repo => repo.AddCourseAsync(course)).ReturnsAsync(expected);

            int result = await _courseService.AddCourseAsync(course);
            Assert.Equal(expected, result);
            _mockCourseRepository.Verify(repo => repo.AddCourseAsync(course), Times.Once);
        }
        [Fact]
        public async Task DeleteCourseAsync_InvalidId_ReturnMinusOne()
        {
            int id = -1;
            int result = await _courseService.DeleteCourseAsync(id);
            Assert.Equal(-1, result);
        }
        [Fact]
        public async Task DeleteCourseAsync_IdNotFound_ReturnMinusOne()
        {
            int id = 1;
            _mockCourseRepository.Setup(repo => repo.DeleteCourseAsync(id)).ReturnsAsync(0);
            _mockCourseRepository.Setup(repo => repo.GetCourseByCourseIdAsync(id)).ReturnsAsync((Course)null);

            int result = await _courseService.DeleteCourseAsync(id);
            Assert.Equal(-1, result);
            _mockCourseRepository.Verify(repo => repo.DeleteCourseAsync(id), Times.Once);
        }
        [Fact]
        public async Task DeleteCourseAsync_DeleteFail_ReturnZero()
        {
            int id = 1;
            _mockCourseRepository.Setup(repo => repo.DeleteCourseAsync(id)).ReturnsAsync(0);
            _mockCourseRepository.Setup(repo => repo.GetCourseByCourseIdAsync(id)).ReturnsAsync(new Course() { Name = "TEST" });

            int result = await _courseService.DeleteCourseAsync(id);
            Assert.Equal(0, result);
            _mockCourseRepository.Verify(repo => repo.DeleteCourseAsync(id), Times.Once);
        }
        [Fact]
        public async Task DeleteCourseAsync_DeleteSuccess_ReturnOne()
        {
            int id = 1;
            _mockCourseRepository.Setup(repo => repo.DeleteCourseAsync(id)).ReturnsAsync(1);

            int result = await _courseService.DeleteCourseAsync(id);
            Assert.Equal(1, result);
            _mockCourseRepository.Verify(repo => repo.DeleteCourseAsync(id), Times.Once);
        }
        [Fact]
        public async Task UpdateCourseAsync_NullCourse_ReturnMinusOne()
        {
            Course course = null;
            int result = await _courseService.UpdateCourseAsync(course);
            Assert.Equal(-1, result);
        }
        [Fact]
        public async Task UpdateCourseAsync_NotFound_ReturnMinusOne()
        {
            Course course = new Course();
            _mockCourseRepository.Setup(repo => repo.UpdateCourseAsync(course)).ReturnsAsync(0);
            _mockCourseRepository.Setup(repo => repo.GetCourseByCourseIdAsync(course.CourseId)).ReturnsAsync((Course)null);

            int result = await _courseService.UpdateCourseAsync(course);
            Assert.Equal(-1, result);
            _mockCourseRepository.Verify(repo => repo.UpdateCourseAsync(course), Times.Once);
        }
        [Fact]
        public async Task UpdateCourseAsync_UpdateFail_ReturnZero()
        {
            Course course = new Course();
            _mockCourseRepository.Setup(repo => repo.UpdateCourseAsync(course)).ReturnsAsync(0);
            _mockCourseRepository.Setup(repo => repo.GetCourseByCourseIdAsync(course.CourseId)).ReturnsAsync(course);

            int result = await _courseService.UpdateCourseAsync(course);
            Assert.Equal(0, result);
            _mockCourseRepository.Verify(repo => repo.UpdateCourseAsync(course), Times.Once);
        }
        [Fact]
        public async Task UpdateCourseAsync_Success_ReturnOne()
        {
            Course course = new Course();
            _mockCourseRepository.Setup(repo => repo.UpdateCourseAsync(course)).ReturnsAsync(1);

            int result = await _courseService.UpdateCourseAsync(course);
            Assert.Equal(1, result);
            _mockCourseRepository.Verify(repo => repo.UpdateCourseAsync(course), Times.Once);
        }
        [Fact]
        public async Task GetAllCoursesAsync_ReturnNull()
        {
            IEnumerable<Course> courses = null;
            _mockCourseRepository.Setup(repo => repo.GetAllCoursesAsync()).ReturnsAsync((IEnumerable<Course>)null);

            IEnumerable<Course> result = await _courseService.GetAllCoursesAsync();
            Assert.Null(result);
            _mockCourseRepository.Verify(repo => repo.GetAllCoursesAsync());
        }
        [Fact]
        public async Task GetAllCoursesAsync_ReturnList()
        {
            IEnumerable<Course> courses = new List<Course>()
            {
                new Course() { Name = "TEST1" },
                new Course() { Name = "TEST2" },
            };
            _mockCourseRepository.Setup(repo => repo.GetAllCoursesAsync()).ReturnsAsync(courses);

            IEnumerable<Course> result = await _courseService.GetAllCoursesAsync();
            Assert.NotNull(result);
            Assert.True(result.SequenceEqual(courses));
            _mockCourseRepository.Verify(repo => repo.GetAllCoursesAsync());
        }
        [Fact]
        public async Task GetCourseByCourseIdAsync_NotFound_ReturnNull()
        {
            int id = 0;
            Course course = null;
            _mockCourseRepository.Setup(repo => repo.GetCourseByCourseIdAsync(id)).ReturnsAsync(course);

            Course result = await _courseService.GetCourseByCourseIdAsync(id);
            Assert.Null(result);
            _mockCourseRepository.Verify(repo => repo.GetCourseByCourseIdAsync(id));
        }
        [Fact]
        public async Task GetCourseByCourseIdAsync_Found_ReturnCourse()
        {
            int id = 0;
            Course course = new Course();
            _mockCourseRepository.Setup(repo => repo.GetCourseByCourseIdAsync(id)).ReturnsAsync(course);

            Course result = await _courseService.GetCourseByCourseIdAsync(id);
            Assert.NotNull(result);
            _mockCourseRepository.Verify(repo => repo.GetCourseByCourseIdAsync(id));
        }
        [Fact]
        public async Task GetCourseByCourseCodeAsync_NotFound_ReturnNull()
        {
            string code = "";
            _mockCourseRepository.Setup(repo=>repo.GetCourseByCourseCodeAsync(code)).ReturnsAsync((Course)null);

            Course result = await _courseService.GetCourseByCourseCodeAsync(code);
            Assert.Null(result);
            _mockCourseRepository.Verify(repo => repo.GetCourseByCourseCodeAsync(code),Times.Once);
        }
        [Fact]
        public async Task GetCourseByCourseCodeAsync_Found_ReturnCourse()
        {
            string code = "";
            _mockCourseRepository.Setup(repo => repo.GetCourseByCourseCodeAsync(code)).ReturnsAsync(new Course());

            Course result = await _courseService.GetCourseByCourseCodeAsync(code);
            Assert.NotNull(result);
            _mockCourseRepository.Verify(repo => repo.GetCourseByCourseCodeAsync(code), Times.Once);
        }
    }
}
