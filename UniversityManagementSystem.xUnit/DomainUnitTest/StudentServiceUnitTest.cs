
using UniversityManagementSystem.Domain.Interfaces.StudentInterface;
using UniversityManagementSystem.Domain.Services.StudentServices;
using Moq;
using UniversityManagementSystem.Domain.Entities.StudentEntity;

namespace UniversityManagementSystem.UnitTest.DomainUnitTest
{
    public class StudentServiceUnitTest
    {
        private readonly StudentService _studentService;
        private readonly Mock<IStudentRepository> _MockRepository;
        public StudentServiceUnitTest()
        {
            _MockRepository = new Mock<IStudentRepository>();
            _studentService = new StudentService(_MockRepository.Object);
        }
        [Fact]
        public async Task GetStudentByIdAsync_InvalidId_ReturnNull()
        {
            Student result =await _studentService.GetStudentByIdAsync(1);
            Assert.Null(result);
        }
        [Fact]
        public async Task GetStudentByIdAsync_IdNotFound_ReturnNull()
        {
            int id = 1;
            _MockRepository.Setup(repo=>repo.GetStudentByIdAsync(id)).ReturnsAsync((Student)null);

            Student stu=await _studentService.GetStudentByIdAsync(id);
            Assert.Null(stu);
            _MockRepository.Verify(repo=>repo.GetStudentByIdAsync(id),Times.Once);
        }
        [Fact]
        public async Task GetStudentByIdAsync_StudentFound_ReturnInstance()
        {
            int id = 1;
            Student expectedStu=new Student() { StudentId=1,Name="Test"};
            _MockRepository.Setup(repo=>repo.GetStudentByIdAsync(id)).ReturnsAsync(expectedStu);

            Student result = await _studentService.GetStudentByIdAsync(id);

            Assert.Equal(expectedStu.StudentId, result.StudentId);
            Assert.Equal(expectedStu.Name, result.Name);
            _MockRepository.Verify(repo=>repo.GetStudentByIdAsync(id),Times.Once);
        }
        [Fact]
        public async Task GetStudentByIdAsync_GetError_ReturnNull()
        {
            int id = 0;
            _MockRepository.Setup(repo=>repo.GetStudentByIdAsync(id)).ReturnsAsync((Student)null);

            Student result = await _studentService.GetStudentByIdAsync(id);
            Assert.Null(result);
            _MockRepository.Verify(repo=>repo.GetStudentByIdAsync(id),Times.Once);
        }
    }
}
