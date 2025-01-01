using UniversityManagementSystem.Domain.Interfaces.AlumniInterface;
using UniversityManagementSystem.Domain.Services.AlumniServices;
using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.Domain.Interfaces.AcademicInterface;
using UniversityManagementSystem.Domain.Entities.AcademicEntity;
using UniversityManagementSystem.Domain.Services.AcademicServices;
using Moq;

namespace UniversityManagementSystem.UnitTest.DomainUnitTest
{
    public class AlumniServiceUnitTest
    {
        private readonly Mock<IAlumniRepository> _mockAlumniRepository;
        private readonly Mock<IFacultyRepository> _mockFacultyRepository;
        private readonly IAlumniService _alumniService;
        private readonly IFacultyService _facultyService;
        public AlumniServiceUnitTest()
        {
            _mockAlumniRepository=new Mock<IAlumniRepository> ();
            _mockFacultyRepository=new Mock<IFacultyRepository> ();
            _alumniService = new AlumniService(_mockAlumniRepository.Object, _mockFacultyRepository.Object);
            _facultyService = new FacultyService(_mockFacultyRepository.Object);
        }
        [Fact]
        public async Task GetAlumniByIdAsync_ValidId_ReturnsAlumni()
        {
            var id = 1;
            Alumni expectedAlumni=new Alumni { Name="John Wick"};
            _mockAlumniRepository.Setup(repo=>repo.GetAlumniByIdAsync(id)).ReturnsAsync(expectedAlumni);

            Alumni result = await _alumniService.GetAlumniByIdAsync(id);

            Assert.NotNull(result);
            Assert.Equal(expectedAlumni.AlumniId,result.AlumniId);
            Assert.Equal(expectedAlumni.Name,result.Name);

            _mockAlumniRepository.Verify(repo=>repo.GetAlumniByIdAsync(id),Times.Once);
        }
        [Fact]
        public async Task GetAlumniByIdAsync_InvalidId_ReturnsNull()
        {
            int id = -1;
     
            Alumni result = await _alumniService.GetAlumniByIdAsync(id);

            Assert.Null(result);
        }
        [Fact]
        public async Task GetAlumniByIdAsync_IdNotFound_ReturnsNull()
        {
            int id = 999;
            _mockAlumniRepository.Setup(repo=>repo.GetAlumniByIdAsync(id)).ReturnsAsync((Alumni)null);

            Alumni result = await _alumniService.GetAlumniByIdAsync(id);

            Assert.Null(result);

            _mockAlumniRepository.Verify(repo=>repo.GetAlumniByIdAsync(id),Times.Once);
        }
        [Fact]
        public async Task AddAlumniAsync_AlumniIsNull_ReturnMinusOne()
        {
            Alumni alumni = null;
        
            int result = await _alumniService.AddAlumniAsync(alumni);
            Assert.Equal(-1, result);
        }
        [Fact]
        public async Task AddAlumniAsync_AlreadyExist_ReturnMinusOne()
        {
            Alumni alumni = new Alumni();
            _mockAlumniRepository.Setup(repo => repo.GetAlumniByIdAsync(alumni.AlumniId)).ReturnsAsync(new Alumni());

            int result = await _alumniService.AddAlumniAsync(alumni);
            Assert.Equal(-1, result);
        }
        [Fact]
        public async Task AddAlumniAsync_AddSuccess_ReturnOne()
        {
            Alumni alumni = new Alumni();
            _mockAlumniRepository.Setup(repo => repo.AddAlumniAsync(alumni)).ReturnsAsync(1);

            int result = await _alumniService.AddAlumniAsync(alumni);
            Assert.Equal(1, result);
            _mockAlumniRepository.Verify(repo=>repo.AddAlumniAsync(alumni),Times.Once);
        }
        [Fact]
        public async Task AddAlumniAsync_AddError_ReturnZero()
        {
            Alumni alumni = new Alumni();
            _mockAlumniRepository.Setup(repo => repo.AddAlumniAsync(alumni)).ReturnsAsync(0);

            int result = await _alumniService.AddAlumniAsync(alumni);
            Assert.Equal(0, result);
            _mockAlumniRepository.Verify(repo => repo.AddAlumniAsync(alumni), Times.Once);
        }
        [Fact]
        public async Task DeleteAlumniAsync_NotFound_ReturnMinusOne()
        {
            int id = 1;
            _mockAlumniRepository.Setup(repo => repo.DeleteAlumniAsync(id)).ReturnsAsync(0);
            _mockAlumniRepository.Setup(repo=>repo.GetAlumniByIdAsync(id)).ReturnsAsync((Alumni)null);

            int result=await _alumniService.DeleteAlumniAsync(id);
            Assert.Equal(-1, result);
            _mockAlumniRepository.Verify(repo => repo.DeleteAlumniAsync(id), Times.Once);
        }
        [Fact]
        public async Task DeleteAlumniAsync_DeleteSuccess_ReturnOne()
        {
            int id = 1;
            int expectedResult = 1;
            _mockAlumniRepository.Setup(repo => repo.DeleteAlumniAsync(id)).ReturnsAsync(expectedResult);

            int result = await _alumniService.DeleteAlumniAsync(id);

            Assert.Equal(expectedResult, result);
            _mockAlumniRepository.Verify(repo => repo.DeleteAlumniAsync(id), Times.Once);
        }
        [Fact]
        public async Task DeleteAlumniAsync_DeleteError_ReturnZero()
        {
            int id = 1;
            Alumni alumni = new Alumni();
            _mockAlumniRepository.Setup(repo => repo.DeleteAlumniAsync(id)).ReturnsAsync(0);
            _mockAlumniRepository.Setup(repo=>repo.GetAlumniByIdAsync(id)).ReturnsAsync(alumni);

            int result = await _alumniService.DeleteAlumniAsync(id);
            Assert.Equal(0, result);
            _mockAlumniRepository.Verify(repo => repo.DeleteAlumniAsync(id), Times.Once);
        }
        [Fact]
        public async Task DeleteAlumniAsync_InvalidId_ReturnMinusOne()
        {
            int id = -1;
            int result = await _alumniService.DeleteAlumniAsync(id);
            Assert.Equal(-1, result);
        }
        [Fact]
        public async Task UpdateAlumniAsync_AlumniNotFound_ReturnMinusOne()
        {
            int expectedResult = -1;
            Alumni alumni = new Alumni()
            {
                Name = "Test"
            };
            _mockAlumniRepository.Setup(repo=>repo.UpdateAlumniAsync(alumni)).ReturnsAsync(0);
            _mockAlumniRepository.Setup(repo=>repo.GetAlumniByIdAsync(alumni.AlumniId)).ReturnsAsync((Alumni)null);

            int result = await _alumniService.UpdateAlumniAsync(alumni);
            Assert.Equal(expectedResult, result);
            _mockAlumniRepository.Verify(repo=>repo.UpdateAlumniAsync(alumni),Times.Once);
        }
        [Fact]
        public async Task UpdateAlumniAsync_AlumniIsNull_ReturnMinusOne()
        {
            int expectedResult = -1;
            int result = await _alumniService.UpdateAlumniAsync(null);
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public async Task UpdateAlumniAsync_UpdateError_ReturnZero()
        {
            int expectedResult =0;
            Alumni alumni = new Alumni();
            _mockAlumniRepository.Setup(repo=>repo.UpdateAlumniAsync(alumni)).ReturnsAsync(expectedResult);
            _mockAlumniRepository.Setup(repo=>repo.GetAlumniByIdAsync(alumni.AlumniId)).ReturnsAsync(alumni);
            int result =await _alumniService.UpdateAlumniAsync(alumni);
            Assert.Equal(expectedResult, result);
            _mockAlumniRepository.Verify(repo=>repo.UpdateAlumniAsync(alumni),  Times.Once);
        }
        [Fact]
        public async Task UpdateAlumniAsync_UpdateSuccess_ReturnOne()
        {
            int expectedResult = 1;
            Alumni alumni = new Alumni();
            _mockAlumniRepository.Setup(repo => repo.UpdateAlumniAsync(alumni)).ReturnsAsync(expectedResult);

            int result = await _alumniService.UpdateAlumniAsync(alumni);
            Assert.Equal(expectedResult, result);
            _mockAlumniRepository.Verify(repo => repo.UpdateAlumniAsync(alumni), Times.Once);
        }
        [Fact]
        public async Task GetAllAlumniAsync_GetSuccess_ReturnList()
        {
            IEnumerable<Alumni> list = new List<Alumni>() 
            {
                new Alumni() {Name = "Test1"},
                new Alumni() {Name = "Test2"},
            };
            _mockAlumniRepository.Setup(repo=>repo.GetAllAlumniAsync()).ReturnsAsync(list);

            IEnumerable<Alumni> result = await _alumniService.GetAllAlumniAsync();

            Assert.NotNull(result);
            Assert.True(list.SequenceEqual(result));
            _mockAlumniRepository.Verify(repo => repo.GetAllAlumniAsync(),Times.Once);
        }
        [Fact]
        public async Task GetAllAlumniAsync_GetError_ReturnNull()
        {
            _mockAlumniRepository.Setup(repo => repo.GetAllAlumniAsync()).ReturnsAsync((IEnumerable<Alumni >)null);

            IEnumerable<Alumni> result = await _alumniService.GetAllAlumniAsync();
            Assert.Null(result);
            _mockAlumniRepository.Verify(repo => repo.GetAllAlumniAsync(), Times.Once);
        }
        [Fact]
        public async Task GetAllUndergraduateAlumniAsync_GetSuccess_ReturnList()
        {
            IEnumerable<Alumni> list = new List<Alumni>()
            {
                new Alumni() {Degree=Degree.Bachelor},
                new Alumni() {Degree=Degree.Bachelor},
            };
            _mockAlumniRepository.Setup(repo => repo.GetAllAlumniByDegreeAsync(Degree.Bachelor)).ReturnsAsync(list);

            IEnumerable<Alumni> result = await _alumniService.GetAllUndergraduateAlumniAsync();

            Assert.NotNull(result);
            Assert.True(list.SequenceEqual(result));
            _mockAlumniRepository.Verify(repo => repo.GetAllAlumniByDegreeAsync(Degree.Bachelor),Times.Once);
        }
        [Fact]
        public async Task GetAllUndergraduateAlumniAsync_GetError_ReturnNull()
        {
            _mockAlumniRepository.Setup(repo => repo.GetAllAlumniByDegreeAsync(Degree.Bachelor)).ReturnsAsync((IEnumerable<Alumni>)null);

            IEnumerable<Alumni> result = await _alumniService.GetAllUndergraduateAlumniAsync();
            Assert.Null(result);
            _mockAlumniRepository.Verify(repo => repo.GetAllAlumniByDegreeAsync(Degree.Bachelor), Times.Once);
        }
        [Fact]
        public async Task GetAllGraduateAlumniAsync_GetSuccess_ReturnList()
        {
            IEnumerable<Alumni> list = new List<Alumni>()
            {
                new Alumni() {Degree=Degree.Master},
                new Alumni() {Degree=Degree.Master},
            };
            _mockAlumniRepository.Setup(repo => repo.GetAllAlumniByDegreeAsync(Degree.Master)).ReturnsAsync(list);

            IEnumerable<Alumni> result = await _alumniService.GetAllGraduateAlumniAsync();

            Assert.NotNull(result);
            Assert.True(list.SequenceEqual(result));
            _mockAlumniRepository.Verify(repo => repo.GetAllAlumniByDegreeAsync(Degree.Master), Times.Once);
        }
        [Fact]
        public async Task GetAllGraduateAlumniAsync_GetError_ReturnNull()
        {
            _mockAlumniRepository.Setup(repo => repo.GetAllAlumniByDegreeAsync(Degree.Master)).ReturnsAsync((IEnumerable<Alumni>)null);

            IEnumerable<Alumni> result = await _alumniService.GetAllGraduateAlumniAsync();
            Assert.Null(result);
            _mockAlumniRepository.Verify(repo => repo.GetAllAlumniByDegreeAsync(Degree.Master), Times.Once);
        }
        [Fact]
        public async Task GetAllDoctoralAlumniAsync_GetSuccess_ReturnList()
        {
            IEnumerable<Alumni> list = new List<Alumni>()
            {
                new Alumni() {Degree=Degree.PhD},
                new Alumni() {Degree=Degree.PhD},
            };
            _mockAlumniRepository.Setup(repo => repo.GetAllAlumniByDegreeAsync(Degree.PhD)).ReturnsAsync(list);

            IEnumerable<Alumni> result = await _alumniService.GetAllDoctoralAlumniAsync();

            Assert.NotNull(result);
            Assert.True(list.SequenceEqual(result));
            _mockAlumniRepository.Verify(repo => repo.GetAllAlumniByDegreeAsync(Degree.PhD), Times.Once);
        }
        [Fact]
        public async Task GetAllDoctoralAlumniAsync_GetError_ReturnNull()
        {
            _mockAlumniRepository.Setup(repo => repo.GetAllAlumniByDegreeAsync(Degree.PhD)).ReturnsAsync((IEnumerable<Alumni>)null);

            IEnumerable<Alumni> result = await _alumniService.GetAllDoctoralAlumniAsync();
            Assert.Null(result);
            _mockAlumniRepository.Verify(repo => repo.GetAllAlumniByDegreeAsync(Degree.PhD), Times.Once);
        }
        [Fact]
        public async Task GetAllAlumniByYearAsync_InvalidYear_ReturnNull()
        {
            int year = -1;
            IEnumerable<Alumni> list=await _alumniService.GetAllAlumniByYearAsync(year);
            Assert.Null(list);
        }
        [Fact]
        public async Task GetAllAlumniByYearAsync_NotFound_ReturnNull()
        {
            int year =2020;
            _mockAlumniRepository.Setup(repo=>repo.GetAllAlumniByYearAsync(year)).ReturnsAsync((IEnumerable<Alumni>)null);
            IEnumerable<Alumni> list = await _alumniService.GetAllAlumniByYearAsync(year);
            Assert.Null(list);
            _mockAlumniRepository.Verify(repo => repo.GetAllAlumniByYearAsync(year),Times.Once);
        }
        [Fact]
        public async Task GetAllAlumniByYearAsync_GetSuccess_ReturnList()
        {
            int year = 2020;
            IEnumerable<Alumni> list = new List<Alumni>()
            {
                new Alumni {Name = "Test1"},
                new Alumni {Name = "Test2"}
            };
            _mockAlumniRepository.Setup(repo => repo.GetAllAlumniByYearAsync(year)).ReturnsAsync(list);

            IEnumerable<Alumni> result = await _alumniService.GetAllAlumniByYearAsync(year);

            Assert.NotNull(result);
            Assert.True(result.SequenceEqual(list));
        }
        [Fact]
        public async Task GetAllAlumniByFacultyIdAsync_InvalidId_ReturnNull()
        {
            int id = -1;

            IEnumerable<Alumni> list = await _alumniService.GetAllAlumniByFacultyIdAsync(id);

            Assert.Null(list);
        }
        [Fact]
        public async Task GetAllAlumniByFacultyIdAsync_FacultyNotFound_ReturnNull()
        {
            int id = 1;
            _mockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync((Faculty)null);

            IEnumerable<Alumni> result = await _alumniService.GetAllAlumniByFacultyIdAsync(id);
            Assert.Null(result);
            _mockFacultyRepository.Verify(repo => repo.GetFacultyByIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetAllAlumniByFacultyIdAsync_FacultyWIthNoStudent_ReturnNull()
        {
            int id = 1;
            Faculty faculty = new Faculty() { Name="TEST"};
            _mockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync(faculty);
            _mockAlumniRepository.Setup(repo=>repo.GetAllAlumniByFacultyIdAsync(id)).ReturnsAsync((IEnumerable<Alumni>)null);

            IEnumerable<Alumni> result = await _alumniService.GetAllAlumniByFacultyIdAsync(id);
            Assert.Null(result);
            _mockFacultyRepository.Verify(repo => repo.GetFacultyByIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetAllAlumniByFacultyIdAsync_FacultyWIthStudents_ReturnList()
        {
            int id = 1;
            Faculty faculty = new Faculty() { Name = "TEST" };
            IEnumerable<Alumni> alumnis = new List<Alumni>() 
            {
                new Alumni() { Name="TEST"},
                new Alumni() { Name="TEST"}
            };
            _mockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync(faculty);
            _mockAlumniRepository.Setup(repo => repo.GetAllAlumniByFacultyIdAsync(id)).ReturnsAsync(alumnis);

            IEnumerable<Alumni> result = await _alumniService.GetAllAlumniByFacultyIdAsync(id);
            Assert.True(result.SequenceEqual(alumnis));
            _mockFacultyRepository.Verify(repo => repo.GetFacultyByIdAsync(id), Times.Once);
        }
    }
}
