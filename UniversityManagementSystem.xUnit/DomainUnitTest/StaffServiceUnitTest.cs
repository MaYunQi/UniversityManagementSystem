using Moq;
using UniversityManagementSystem.Domain.Entities.StaffEntity;
using UniversityManagementSystem.Domain.Interfaces.AcademicInterface;
using UniversityManagementSystem.Domain.Interfaces.StaffInterface;
using UniversityManagementSystem.Domain.Services.StaffServices;

namespace UniversityManagementSystem.UnitTest.DomainUnitTest
{
    public class StaffServiceUnitTest
    {
        private readonly StaffService _staffService;
        private readonly Mock<IStaffRepository> _MockStaffRepository;
        private readonly Mock<IFacultyRepository> _MockFacultyRepository;
        public StaffServiceUnitTest()
        {
            _MockStaffRepository=new Mock<IStaffRepository>();
            _MockFacultyRepository=new Mock<IFacultyRepository>();
            _staffService =new StaffService(_MockStaffRepository.Object, _MockFacultyRepository.Object);
        }

        [Fact]
        public async Task AddStaffAsync_NullStaff_ReturnMinusOne()
        {
            int expected = -1;
            Staff staff = null;
            int result = await _staffService.AddStaffAsync(staff);
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task AddStaffAsync_StaffExsit_ReturnMinusOne()
        {
            int expected = -1;
            Staff staff = new Staff() { StaffId=1};
            _MockStaffRepository.Setup(repo=>repo.AddStaffAsync(staff)).ReturnsAsync(0);
            _MockStaffRepository.Setup(repo=>repo.GetStaffByIdAsync(staff.StaffId)).ReturnsAsync(staff);

            int result=await _staffService.AddStaffAsync(staff); 
            Assert.Equal(expected, result);
            _MockStaffRepository.Verify(repo => repo.AddStaffAsync(staff),Times.Once);
        }
        [Fact]
        public async Task AddStaffAsync_AddError_ReturnZero()
        {
            int expected = 0;
            Staff staff = new Staff() { StaffId = 1 };
            _MockStaffRepository.Setup(repo => repo.AddStaffAsync(staff)).ReturnsAsync(0);
            _MockStaffRepository.Setup(repo => repo.GetStaffByIdAsync(staff.StaffId)).ReturnsAsync((Staff)null);

            int result = await _staffService.AddStaffAsync(staff);
            Assert.Equal(expected, result);
            _MockStaffRepository.Verify(repo => repo.AddStaffAsync(staff), Times.Once);
        }
        [Fact]
        public async Task AddStaffAsync_AddSuccess_ReturnOne()
        {
            int expected = 1;
            Staff staff = new Staff() { StaffId = 1 };
            _MockStaffRepository.Setup(repo => repo.AddStaffAsync(staff)).ReturnsAsync(1);

            int result = await _staffService.AddStaffAsync(staff);
            Assert.Equal(expected, result);
            _MockStaffRepository.Verify(repo => repo.AddStaffAsync(staff), Times.Once);
        }
    }
}
