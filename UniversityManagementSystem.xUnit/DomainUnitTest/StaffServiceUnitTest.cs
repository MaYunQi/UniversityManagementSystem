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
            Staff staff = new Staff() { FirstName = "Test"};
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
            Staff staff = new Staff() { FirstName = "TEST" };
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
            Staff staff = new Staff() { FirstName = "TEST" };
            _MockStaffRepository.Setup(repo => repo.AddStaffAsync(staff)).ReturnsAsync(1);

            int result = await _staffService.AddStaffAsync(staff);
            Assert.Equal(expected, result);
            _MockStaffRepository.Verify(repo => repo.AddStaffAsync(staff), Times.Once);
        }
        [Fact]
        public async Task DeleteStaffAsync_InvalidId_ReturnMinusOne()
        {
            int id = -1;
            int expected = -1;
            int result=await _staffService.DeleteStaffAsync(id); 
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task DeleteStaffAsync_IdNotFound_ReturnMinusOne()
        {
            int id =1;
            int expected = -1;
            _MockStaffRepository.Setup(repo => repo.DeleteStaffAsync(id)).ReturnsAsync(0);
            _MockStaffRepository.Setup(repo => repo.GetStaffByIdAsync(id)).ReturnsAsync((Staff)null); 
           
            int result = await _staffService.DeleteStaffAsync(id);
            Assert.Equal(expected, result);
            _MockStaffRepository.Verify(repo => repo.DeleteStaffAsync(id),Times.Once);
        }
        [Fact]
        public async Task DeleteStaffAsync_DeleteError_ReturnZero()
        {
            int id = 1;
            int expected =0;
            _MockStaffRepository.Setup(repo => repo.DeleteStaffAsync(id)).ReturnsAsync(0);
            _MockStaffRepository.Setup(repo => repo.GetStaffByIdAsync(id)).ReturnsAsync(new Staff() { FirstName = "TEST" });

            int result = await _staffService.DeleteStaffAsync(id);
            Assert.Equal(expected, result);
            _MockStaffRepository.Verify(repo => repo.DeleteStaffAsync(id), Times.Once);
        }
        [Fact]
        public async Task DeleteStaffAsync_DeleteSuccess_ReturnOne()
        {
            int id = 1;
            int expected = 1;
            _MockStaffRepository.Setup(repo=>repo.DeleteStaffAsync(id)).ReturnsAsync(1);


            int result = await _staffService.DeleteStaffAsync(id);
            Assert.Equal(expected, result);
            _MockStaffRepository.Verify(repo => repo.DeleteStaffAsync(id),Times.Once);
        }
        [Fact]
        public async Task GetStaffByIdAsync_InvalidId_ReturnNull()
        {
            int id = -1;
            Staff result=await _staffService.GetStaffByIdAsync(id);
            Assert.Null(result);
        }
        [Fact]
        public async Task GetStaffByIdAsync_StaffNotFound_ReturnNull()
        {
            int id = 1;
            _MockStaffRepository.Setup(repo=>repo.GetStaffByIdAsync(id)).ReturnsAsync((Staff)null);

            Staff result=await _staffService.GetStaffByIdAsync(id);
            Assert.Null(result);
            _MockStaffRepository.Verify(repo => repo.GetStaffByIdAsync(id),Times.Once);
        }
        [Fact]
        public async Task GetStaffByIdAsync_Found_ReturnStaff()
        {
            int id = 1;
            Staff staff=new Staff() { FirstName = "TEST" };
            _MockStaffRepository.Setup(repo => repo.GetStaffByIdAsync(id)).ReturnsAsync(staff);
            Staff result = await _staffService.GetStaffByIdAsync(id);
            Assert.NotNull(result);
            Assert.Equal(staff, result);
            _MockStaffRepository.Verify(repo => repo.GetStaffByIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task UpdateStaffAsync_NullStaff_ReturnMinusOne()
        {
            Staff staff = null;
            int expected = -1;
            int result=await _staffService.UpdateStaffAsync(staff); 
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task UpdateStaffAsync_StaffNotFound_ReturnMinusOne()
        {
            Staff staff=new Staff() { FirstName = "TEST" };
            _MockStaffRepository.Setup(re=>re.UpdateStaffAsync(staff)).ReturnsAsync(0);
            _MockStaffRepository.Setup(re => re.GetStaffByIdAsync(staff.StaffId)).ReturnsAsync((Staff)null);

            int result=await (_staffService.UpdateStaffAsync(staff));
            Assert.Equal(-1, result);
            _MockStaffRepository.Verify(re => re.UpdateStaffAsync(staff),Times.Once);
        }
        [Fact]
        public async Task UpdateStaffAsync_UpdateError_ReturnZero()
        {
            Staff staff = new Staff() { FirstName = "TEST" };
            _MockStaffRepository.Setup(re => re.UpdateStaffAsync(staff)).ReturnsAsync(0);
            _MockStaffRepository.Setup(re => re.GetStaffByIdAsync(staff.StaffId)).ReturnsAsync(new Staff());

            int result = await (_staffService.UpdateStaffAsync(staff));
            Assert.Equal(0, result);
            _MockStaffRepository.Verify(re => re.UpdateStaffAsync(staff), Times.Once);
        }
        [Fact]
        public async Task UpdateStaffAsync_UpdateSuccess_ReturnOne()
        {
            Staff staff = new Staff() { FirstName = "TEST" };
            _MockStaffRepository.Setup(re => re.UpdateStaffAsync(staff)).ReturnsAsync(1);

            int result = await (_staffService.UpdateStaffAsync(staff));
            Assert.Equal(1, result);
            _MockStaffRepository.Verify(re => re.UpdateStaffAsync(staff), Times.Once);
        }
        [Fact]
        public async Task GetAllStaffAsync_NoStaff_ReturnNull()
        {
            _MockStaffRepository.Setup(repo=>repo.GetAllStaffAsync()).ReturnsAsync((IEnumerable<Staff>) null);

            IEnumerable<Staff> result = await _staffService.GetAllStaffAsync();
            Assert.Null(result);
            _MockStaffRepository.Verify(repo => repo.GetAllStaffAsync(),Times.Once);
        }
        [Fact]
        public async Task GetAllStaffAsync_StaffFound_ReturnList()
        {
            IEnumerable<Staff> staff=new List<Staff>() 
            {
                new Staff() { FirstName="TEST1" },
                new Staff() { FirstName="TEST2"},
            };
            _MockStaffRepository.Setup(repo => repo.GetAllStaffAsync()).ReturnsAsync(staff);

            IEnumerable<Staff> result = await _staffService.GetAllStaffAsync();
            Assert.NotNull(result);
            Assert.True(result.SequenceEqual(staff));
            _MockStaffRepository.Verify(repo => repo.GetAllStaffAsync(), Times.Once);
        }
    }
}
