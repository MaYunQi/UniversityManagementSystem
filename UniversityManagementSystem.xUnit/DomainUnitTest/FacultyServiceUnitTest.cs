using Moq;
using UniversityManagementSystem.Domain.Entities.AcademicEntity;
using UniversityManagementSystem.Domain.Interfaces.AcademicInterface;
using UniversityManagementSystem.Domain.Services.AcademicServices;
namespace UniversityManagementSystem.UnitTest.DomainUnitTest
{
    public class FacultyServiceUnitTest
    {
        private readonly FacultyService _facultyService;
        private readonly Mock<IFacultyRepository> _mockRepository;
        public FacultyServiceUnitTest()
        {
            _mockRepository = new Mock<IFacultyRepository>();
            _facultyService = new FacultyService(_mockRepository.Object);
        }
        [Fact]
        public async Task GetAllFacultiesAsync_NotFound_ReturnNull()
        {
            _mockRepository.Setup(repo => repo.GetAllFacultiesAsync()).ReturnsAsync((IEnumerable<Faculty>)null);

            IEnumerable<Faculty> result = await _facultyService.GetAllFacultiesAsync();
            Assert.Null(result);
            _mockRepository.Verify(repo => repo.GetAllFacultiesAsync(), Times.Once);
        }
        [Fact]
        public async Task GetAllFacultiesAsync_Found_ReturnList()
        {
            IEnumerable<Faculty> list = new List<Faculty>()
            {
                new Faculty() {FacultyId=1},
                new Faculty() {FacultyId=2},
            };
            _mockRepository.Setup(repo => repo.GetAllFacultiesAsync()).ReturnsAsync(list);

            IEnumerable<Faculty> result = await _facultyService.GetAllFacultiesAsync();

            Assert.NotNull(result);
            Assert.True(result.SequenceEqual(list));
            _mockRepository.Verify(repo => repo.GetAllFacultiesAsync(), Times.Once);
        }
        [Fact]
        public async Task GetFacultyById_InvalidId_ReturnNull()
        {
            int id = -1;
            Faculty result = await _facultyService.GetFacultyByIdAsync(id);
            Assert.Null(result);
        }
        [Fact]
        public async Task GetFacultyById_NotFound_ReturnNull()
        {
            int id = 1;
            _mockRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync((Faculty)null);

            Faculty result = await _facultyService.GetFacultyByIdAsync(id);
            Assert.Null(result);
            _mockRepository.Verify(repo => repo.GetFacultyByIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetFacultyById_Found_ReturnFaculty()
        {
            int id = 1;
            Faculty faculty = new Faculty() { FacultyId = 1 };
            _mockRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync(faculty);

            Faculty result = await _facultyService.GetFacultyByIdAsync(id);
            Assert.NotNull(result);
            Assert.Equal(faculty.FacultyId, result.FacultyId);
        }
        [Fact]
        public async Task AddFacultyAsync_Null_ReturnMinusOne()
        {
            int expected = -1;

            int result = await _facultyService.AddFacultyAsync(null);

            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task AddFacultyAsync_Exsit_ReturnMinusOne()
        {
            int expected = -1;
            Faculty faculty = new Faculty() { FacultyId=1};
            _mockRepository.Setup(repo=>repo.AddFacultyAsync(faculty)).ReturnsAsync(0);
            _mockRepository.Setup(repo=>repo.GetFacultyByIdAsync(faculty.FacultyId)).ReturnsAsync(faculty);

            int result = await _facultyService.AddFacultyAsync(faculty);
            Assert.Equal(expected, result);
            _mockRepository.Verify(repo => repo.AddFacultyAsync(faculty),Times.Once);
        }
        [Fact]
        public async Task AddFacultyAsync_AddError_ReturnZero()
        {
            int expected = 0;
            Faculty faculty = new Faculty() { FacultyId = 1 };
            _mockRepository.Setup(repo => repo.AddFacultyAsync(faculty)).ReturnsAsync(0);
            _mockRepository.Setup(repo => repo.GetFacultyByIdAsync(faculty.FacultyId)).ReturnsAsync((Faculty)null);

            int result = await _facultyService.AddFacultyAsync(faculty);
            Assert.Equal(expected, result);
            _mockRepository.Verify(repo => repo.AddFacultyAsync(faculty), Times.Once);
        }
        [Fact]
        public async Task AddFacultyAsync_AddSuccess_ReturnOne()
        {
            int expected = 1;
            Faculty faculty = new Faculty() { FacultyId = 1 };
            _mockRepository.Setup(repo => repo.AddFacultyAsync(faculty)).ReturnsAsync(expected);

            int result = await _facultyService.AddFacultyAsync(faculty);
            Assert.Equal(expected, result);
            _mockRepository.Verify(repo => repo.AddFacultyAsync(faculty), Times.Once);
        }
        [Fact]
        public async Task DeleteFacultyAsync_InvalidId_ReturnMinusOne()
        {
            int id = -1;
            int expected = -1;
            int result=await _facultyService.DeleteFacultyAsync(id);
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task DeleteFacultyAsync_FacultyNotFound_ReturnMinusOne()
        {
            int id = 0;
            int expected = -1;
            _mockRepository.Setup(repo => repo.DeleteFacultyAsync(id)).ReturnsAsync(0);
            _mockRepository.Setup(repo=>repo.GetFacultyByIdAsync(id)).ReturnsAsync((Faculty)null);

            int result = await _facultyService.DeleteFacultyAsync(id);
            Assert.Equal(expected, result);
            _mockRepository.Verify(repo => repo.DeleteFacultyAsync(id),Times.Once);
        }
        [Fact]
        public async Task DeleteFacultyAsync_DeleteError_ReturnZero()
        {
            int id = 1;
            int expected = 0;
            _mockRepository.Setup(repo => repo.DeleteFacultyAsync(id)).ReturnsAsync(expected);
            _mockRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync(new Faculty()); ;

            int result = await _facultyService.DeleteFacultyAsync(id);
            Assert.Equal(expected, result);
            _mockRepository.Verify(repo => repo.DeleteFacultyAsync(id), Times.Once);
        }
        [Fact]
        public async Task DeleteFacultyAsync_DeleteSuccess_ReturnOne()
        {
            int id = 1;
            int expected = 1;
            _mockRepository.Setup(repo=>repo.DeleteFacultyAsync(id)).ReturnsAsync(expected);
            
            int result = await _facultyService.DeleteFacultyAsync(id);
            Assert.Equal(expected, result);
            _mockRepository.Verify(repo => repo.DeleteFacultyAsync(id),Times.Once);
        }
        [Fact]
        public async Task UpdateFacultyAsync_NullFaculty_ReturnMinusOne()
        {
            int expected = -1;
            Faculty faculty = null;

            int result = await _facultyService.UpdateFacultyAsync(faculty);
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task UpdateFacultyAsync_FacultyNotFound_ReturnMinusOne()
        {
            int expected = -1;
            Faculty faculty = new Faculty() { FacultyId=1};
            _mockRepository.Setup(repo => repo.UpdateFacultyAsync(faculty)).ReturnsAsync(0);
            _mockRepository.Setup(repo =>repo.GetFacultyByIdAsync(faculty.FacultyId)).ReturnsAsync((Faculty)null);

            int result = await _facultyService.UpdateFacultyAsync(faculty);
            Assert.Equal(expected, result);
            _mockRepository.Verify(repo => repo.UpdateFacultyAsync(faculty),Times.Once);
        }
        [Fact]
        public async Task UpdateFacultyAsync_DeleteError_ReturnZero()
        {
            int expected =0;
            Faculty faculty = new Faculty() { FacultyId = 1 };
            _mockRepository.Setup(repo => repo.UpdateFacultyAsync(faculty)).ReturnsAsync(0);
            _mockRepository.Setup(repo => repo.GetFacultyByIdAsync(faculty.FacultyId)).ReturnsAsync(faculty);

            int result = await _facultyService.UpdateFacultyAsync(faculty);
            Assert.Equal(expected, result);
            _mockRepository.Verify(repo => repo.UpdateFacultyAsync(faculty), Times.Once);
        }
        [Fact]
        public async Task UpdateFacultyAsync_DeleteSuccess_ReturnOne()
        {
            int expected = 1;
            Faculty faculty = new Faculty() { FacultyId = 1 }; 
            _mockRepository.Setup(repo => repo.UpdateFacultyAsync(faculty)).ReturnsAsync(1);

            int result = await _facultyService.UpdateFacultyAsync(faculty);
            Assert.Equal(expected, result);
            _mockRepository.Verify(repo => repo.UpdateFacultyAsync(faculty), Times.Once);
        }
    }
}
