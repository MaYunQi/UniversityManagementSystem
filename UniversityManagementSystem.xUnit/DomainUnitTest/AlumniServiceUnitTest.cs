﻿using UniversityManagementSystem.Domain.Interfaces.AlumniInterface;
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
        [Fact]
        public async Task GetAllAlumniAsync_GetSuccess_ReturnList()
        {
            IEnumerable<Alumni> list = new List<Alumni>() 
            {
                new Alumni() {AlumniId = 1},
                new Alumni() {AlumniId = 2},
            };
            _mockRepository.Setup(repo=>repo.GetAllAlumniAsync()).ReturnsAsync(list);

            IEnumerable<Alumni> result = await _service.GetAllAlumniAsync();

            Assert.NotNull(result);
            Assert.True(list.SequenceEqual(result));
            _mockRepository.Verify(repo => repo.GetAllAlumniAsync(),Times.Once);
        }
        [Fact]
        public async Task GetAllAlumniAsync_GetError_ReturnNull()
        {
            _mockRepository.Setup(repo => repo.GetAllAlumniAsync()).ReturnsAsync((IEnumerable<Alumni >)null);

            IEnumerable<Alumni> result = await _service.GetAllAlumniAsync();
            Assert.Null(result);
            _mockRepository.Verify(repo => repo.GetAllAlumniAsync(), Times.Once);
        }
        [Fact]
        public async Task GetAllUndergraduateAlumniAsync_GetSuccess_ReturnList()
        {
            IEnumerable<Alumni> list = new List<Alumni>()
            {
                new Alumni() {AlumniId = 1,Degree=Degree.Bachelor},
                new Alumni() {AlumniId = 2,Degree=Degree.Bachelor},
            };
            _mockRepository.Setup(repo => repo.GetAllAlumniByDegreeAsync(Degree.Bachelor)).ReturnsAsync(list);

            IEnumerable<Alumni> result = await _service.GetAllUndergraduateAlumniAsync();

            Assert.NotNull(result);
            Assert.True(list.SequenceEqual(result));
            _mockRepository.Verify(repo => repo.GetAllAlumniByDegreeAsync(Degree.Bachelor),Times.Once);
        }
        [Fact]
        public async Task GetAllUndergraduateAlumniAsync_GetError_ReturnNull()
        {
            _mockRepository.Setup(repo => repo.GetAllAlumniByDegreeAsync(Degree.Bachelor)).ReturnsAsync((IEnumerable<Alumni>)null);

            IEnumerable<Alumni> result = await _service.GetAllUndergraduateAlumniAsync();
            Assert.Null(result);
            _mockRepository.Verify(repo => repo.GetAllAlumniByDegreeAsync(Degree.Bachelor), Times.Once);
        }
        [Fact]
        public async Task GetAllGraduateAlumniAsync_GetSuccess_ReturnList()
        {
            IEnumerable<Alumni> list = new List<Alumni>()
            {
                new Alumni() {AlumniId = 1,Degree=Degree.Master},
                new Alumni() {AlumniId = 2,Degree=Degree.Master},
            };
            _mockRepository.Setup(repo => repo.GetAllAlumniByDegreeAsync(Degree.Master)).ReturnsAsync(list);

            IEnumerable<Alumni> result = await _service.GetAllGraduateAlumniAsync();

            Assert.NotNull(result);
            Assert.True(list.SequenceEqual(result));
            _mockRepository.Verify(repo => repo.GetAllAlumniByDegreeAsync(Degree.Master), Times.Once);
        }
        [Fact]
        public async Task GetAllGraduateAlumniAsync_GetError_ReturnNull()
        {
            _mockRepository.Setup(repo => repo.GetAllAlumniByDegreeAsync(Degree.Master)).ReturnsAsync((IEnumerable<Alumni>)null);

            IEnumerable<Alumni> result = await _service.GetAllGraduateAlumniAsync();
            Assert.Null(result);
            _mockRepository.Verify(repo => repo.GetAllAlumniByDegreeAsync(Degree.Master), Times.Once);
        }
        [Fact]
        public async Task GetAllDoctoralAlumniAsync_GetSuccess_ReturnList()
        {
            IEnumerable<Alumni> list = new List<Alumni>()
            {
                new Alumni() {AlumniId = 1,Degree=Degree.PhD},
                new Alumni() {AlumniId = 2,Degree=Degree.PhD},
            };
            _mockRepository.Setup(repo => repo.GetAllAlumniByDegreeAsync(Degree.PhD)).ReturnsAsync(list);

            IEnumerable<Alumni> result = await _service.GetAllDoctoralAlumniAsync();

            Assert.NotNull(result);
            Assert.True(list.SequenceEqual(result));
            _mockRepository.Verify(repo => repo.GetAllAlumniByDegreeAsync(Degree.PhD), Times.Once);
        }
        [Fact]
        public async Task GetAllDoctoralAlumniAsync_GetError_ReturnNull()
        {
            _mockRepository.Setup(repo => repo.GetAllAlumniByDegreeAsync(Degree.PhD)).ReturnsAsync((IEnumerable<Alumni>)null);

            IEnumerable<Alumni> result = await _service.GetAllDoctoralAlumniAsync();
            Assert.Null(result);
            _mockRepository.Verify(repo => repo.GetAllAlumniByDegreeAsync(Degree.PhD), Times.Once);
        }
        [Fact]
        public async Task GetAllAlumniByYearAsync_InvalidYear_ReturnNull()
        {
            int year = -1;
            IEnumerable<Alumni> list=await _service.GetAllAlumniByYearAsync(year);
            Assert.Null(list);
        }
        [Fact]
        public async Task GetAllAlumniByYearAsync_NotFound_ReturnNull()
        {
            int year =2020;
            _mockRepository.Setup(repo=>repo.GetAllAlumniByYearAsync(year)).ReturnsAsync((IEnumerable<Alumni>)null);
            IEnumerable<Alumni> list = await _service.GetAllAlumniByYearAsync(year);
            Assert.Null(list);
            _mockRepository.Verify(repo => repo.GetAllAlumniByYearAsync(year),Times.Once);
        }
        [Fact]
        public async Task GetAllAlumniByYearAsync_GetSuccess_ReturnList()
        {
            int year = 2020;
            IEnumerable<Alumni> list = new List<Alumni>()
            {
                new Alumni {AlumniId=1},
                new Alumni {AlumniId=2}
            };
            _mockRepository.Setup(repo => repo.GetAllAlumniByYearAsync(year)).ReturnsAsync(list);

            IEnumerable<Alumni> result = await _service.GetAllAlumniByYearAsync(year);

            Assert.NotNull(result);
            Assert.True(result.SequenceEqual(list));
        }
    }
}
