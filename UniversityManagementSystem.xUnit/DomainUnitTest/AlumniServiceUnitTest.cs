using UniversityManagementSystem.Domain.Interfaces.AlumniInterface;
using UniversityManagementSystem.Domain.Services.AlumniServices;
using Moq;
using UniversityManagementSystem.Domain.Entities.OtherEntity;
namespace UniversityManagementSystem.UnitTest.DomainUnitTest
{
    public class AlumniServiceUnitTest
    {
        private readonly Mock<IAlumniRepository> _mockRepository;
        private readonly IAlumniService _service;
        public AlumniServiceUnitTest()
        {
            _mockRepository=new Mock<IAlumniRepository> ();
            _service = new AlumniService(_mockRepository.Object);
        }
        [Fact]
        public async Task GetAlumniByIdAsync_ValidId_ReturnsAlumni()
        {
            var id = 1;
            Alumni expectedAlumni=new Alumni {AlumniId = id, Name="John Wick"};
            _mockRepository.Setup(repo=>repo.GetAlumniByIdAsync(id)).ReturnsAsync(expectedAlumni);

            Alumni result = await _service.GetAlumniByIdAsync(id);

            Assert.NotNull(result);
            Assert.Equal(expectedAlumni.AlumniId,result.AlumniId);
            Assert.Equal(expectedAlumni.Name,result.Name);

            _mockRepository.Verify(repo=>repo.GetAlumniByIdAsync(id),Times.Once);
        }
        [Fact]
        public async Task GetAlumniByIdAsync_InvalidId_ReturnsNull()
        {
            int id = -1;
     
            Alumni result = await _service.GetAlumniByIdAsync(id);

            Assert.Null(result);
        }
        [Fact]
        public async Task GetAlumniByIdAsync_IdNotFound_ReturnsNull()
        {
            int id = 999;
            _mockRepository.Setup(repo=>repo.GetAlumniByIdAsync(id)).ReturnsAsync((Alumni)null);

            Alumni result = await _service.GetAlumniByIdAsync(id);

            Assert.Null(result);

            _mockRepository.Verify(repo=>repo.GetAlumniByIdAsync(id),Times.Once);
        }
        [Fact]
        public async Task AddAlumniAsync_AlumniIsNull_ReturnMinusOne()
        {
            Alumni alumni = null;
        
            int result = await _service.AddAlumniAsync(alumni);
            Assert.Equal(-1, result);
        }
        [Fact]
        public async Task AddAlumniAsync_AlreadyExist_ReturnMinusOne()
        {
            Alumni alumni = new Alumni();
            _mockRepository.Setup(repo => repo.GetAlumniByIdAsync(alumni.AlumniId)).ReturnsAsync(new Alumni());

            int result = await _service.AddAlumniAsync(alumni);
            Assert.Equal(-1, result);
        }
        [Fact]
        public async Task AddAlumniAsync_AddSuccess_ReturnOne()
        {
            Alumni alumni = new Alumni();
            _mockRepository.Setup(repo => repo.AddAlumniAsync(alumni)).ReturnsAsync(1);

            int result = await _service.AddAlumniAsync(alumni);
            Assert.Equal(1, result);
            _mockRepository.Verify(repo=>repo.AddAlumniAsync(alumni),Times.Once);
        }
        [Fact]
        public async Task AddAlumniAsync_AddError_ReturnZero()
        {
            Alumni alumni = new Alumni();
            _mockRepository.Setup(repo => repo.AddAlumniAsync(alumni)).ReturnsAsync(0);

            int result = await _service.AddAlumniAsync(alumni);
            Assert.Equal(0, result);
            _mockRepository.Verify(repo => repo.AddAlumniAsync(alumni), Times.Once);
        }
        [Fact]
        public async Task DeleteAlumniAsync_NotFound_ReturnMinusOne()
        {
            int id = 1;
            _mockRepository.Setup(repo => repo.DeleteAlumniAsync(id)).ReturnsAsync(0);
            _mockRepository.Setup(repo=>repo.GetAlumniByIdAsync(id)).ReturnsAsync((Alumni)null);

            int result=await _service.DeleteAlumniAsync(id);
            Assert.Equal(-1, result);
            _mockRepository.Verify(repo => repo.DeleteAlumniAsync(id), Times.Once);
        }
        [Fact]
        public async Task DeleteAlumniAsync_DeleteSuccess_ReturnOne()
        {
            int id = 1;
            int expectedResult = 1;
            _mockRepository.Setup(repo => repo.DeleteAlumniAsync(id)).ReturnsAsync(expectedResult);

            int result = await _service.DeleteAlumniAsync(id);

            Assert.Equal(expectedResult, result);
            _mockRepository.Verify(repo => repo.DeleteAlumniAsync(id), Times.Once);
        }
        [Fact]
        public async Task DeleteAlumniAsync_DeleteError_ReturnZero()
        {
            int id = 1;
            Alumni alumni = new Alumni();
            _mockRepository.Setup(repo => repo.DeleteAlumniAsync(id)).ReturnsAsync(0);
            _mockRepository.Setup(repo=>repo.GetAlumniByIdAsync(id)).ReturnsAsync(alumni);

            int result = await _service.DeleteAlumniAsync(id);
            Assert.Equal(0, result);
            _mockRepository.Verify(repo => repo.DeleteAlumniAsync(id), Times.Once);
        }
        [Fact]
        public async Task DeleteAlumniAsync_InvalidId_ReturnMinusOne()
        {
            int id = -1;
            int result = await _service.DeleteAlumniAsync(id);
            Assert.Equal(-1, result);
        }
        [Fact]
        public async Task UpdateAlumniAsync_AlumniNotFound_ReturnMinusOne()
        {
            int expectedResult = -1;
            Alumni alumni = new Alumni()
            {
                AlumniId = 1
            };
            _mockRepository.Setup(repo=>repo.UpdateAlumniAsync(alumni)).ReturnsAsync(0);
            _mockRepository.Setup(repo=>repo.GetAlumniByIdAsync(alumni.AlumniId)).ReturnsAsync((Alumni)null);

            int result = await _service.UpdateAlumniAsync(alumni);
            Assert.Equal(expectedResult, result);
            _mockRepository.Verify(repo=>repo.UpdateAlumniAsync(alumni),Times.Once);
        }
        [Fact]
        public async Task UpdateAlumniAsync_AlumniIsNull_ReturnMinusOne()
        {
            int expectedResult = -1;
            int result = await _service.UpdateAlumniAsync(null);
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public async Task UpdateAlumniAsync_UpdateError_ReturnZero()
        {
            int expectedResult =0;
            Alumni alumni = new Alumni();
            _mockRepository.Setup(repo=>repo.UpdateAlumniAsync(alumni)).ReturnsAsync(expectedResult);
            _mockRepository.Setup(repo=>repo.GetAlumniByIdAsync(alumni.AlumniId)).ReturnsAsync(alumni);
            int result =await _service.UpdateAlumniAsync(alumni);
            Assert.Equal(expectedResult, result);
            _mockRepository.Verify(repo=>repo.UpdateAlumniAsync(alumni),  Times.Once);
        }
        [Fact]
        public async Task UpdateAlumniAsync_UpdateSuccess_ReturnOne()
        {
            int expectedResult = 1;
            Alumni alumni = new Alumni();
            _mockRepository.Setup(repo => repo.UpdateAlumniAsync(alumni)).ReturnsAsync(expectedResult);

            int result = await _service.UpdateAlumniAsync(alumni);
            Assert.Equal(expectedResult, result);
            _mockRepository.Verify(repo => repo.UpdateAlumniAsync(alumni), Times.Once);
        }
    }
}
