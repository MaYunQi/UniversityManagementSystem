using UniversityManagementSystem.Domain.Interfaces.StudentInterface;
using UniversityManagementSystem.Domain.Services.StudentServices;
using UniversityManagementSystem.Domain.Entities.StudentEntity;
using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.Domain.Interfaces.AcademicInterface;
using UniversityManagementSystem.Domain.Entities.AcademicEntity;
using Moq;

namespace UniversityManagementSystem.UnitTest.DomainUnitTest
{
    public class StudentServiceUnitTest
    {
        private readonly StudentService _studentService;
        private readonly Mock<IStudentRepository> _MockStudentRepository;
        private readonly Mock<IFacultyRepository> _MockFacultyRepository;
        public StudentServiceUnitTest()
        {
            _MockStudentRepository = new Mock<IStudentRepository>();
            _MockFacultyRepository = new Mock<IFacultyRepository>();
            _studentService = new StudentService(_MockStudentRepository.Object,_MockFacultyRepository.Object );
        }
        [Fact]
        public async Task GetStudentByIdAsync_InvalidId_ReturnNull()
        {
            Student result = await _studentService.GetStudentByIdAsync(1);
            Assert.Null(result);
        }
        [Fact]
        public async Task GetStudentByIdAsync_IdNotFound_ReturnNull()
        {
            int id = 1;
            _MockStudentRepository.Setup(repo => repo.GetStudentByIdAsync(id)).ReturnsAsync((Student)null);

            Student stu = await _studentService.GetStudentByIdAsync(id);
            Assert.Null(stu);
            _MockStudentRepository.Verify(repo => repo.GetStudentByIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetStudentByIdAsync_StudentFound_ReturnInstance()
        {
            int id = 1;
            Student expectedStu = new Student() { Name = "Test" };
            _MockStudentRepository.Setup(repo => repo.GetStudentByIdAsync(id)).ReturnsAsync(expectedStu);

            Student result = await _studentService.GetStudentByIdAsync(id);

            Assert.Equal(expectedStu.StudentId, result.StudentId);
            Assert.Equal(expectedStu.Name, result.Name);
            _MockStudentRepository.Verify(repo => repo.GetStudentByIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetStudentByIdAsync_GetError_ReturnNull()
        {
            int id = 0;
            _MockStudentRepository.Setup(repo => repo.GetStudentByIdAsync(id)).ReturnsAsync((Student)null);

            Student result = await _studentService.GetStudentByIdAsync(id);
            Assert.Null(result);
            _MockStudentRepository.Verify(repo => repo.GetStudentByIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task UpdateStudentAsync_NullStudent_ReturnMinusOne()
        {
            int expectedResult = -1;
            Student student = null;
            int result = await _studentService.UpdateStudentAsync(student);
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public async Task UpdateStudentAsync_StudentNoFound_ReturnMinusOne()
        {
            int expectedResult = -1;
            Student student = new Student() { Name = "TEST" };
            _MockStudentRepository.Setup(repo => repo.UpdateStudentAsync(student)).ReturnsAsync(0);
            _MockStudentRepository.Setup(repo => repo.GetStudentByIdAsync(student.StudentId)).ReturnsAsync((Student)null);

            int result = await _studentService.UpdateStudentAsync(student);
            Assert.Equal(expectedResult, result);
            _MockStudentRepository.Verify(repo => repo.UpdateStudentAsync(student), Times.Once);
        }
        [Fact]
        public async Task UpdateStudentAsync_UpdateError_ReturnZero()
        {
            int expectedResult = 0;
            Student student = new Student() { Name = "TEST" };
            _MockStudentRepository.Setup(repo => repo.UpdateStudentAsync(student)).ReturnsAsync(0);
            _MockStudentRepository.Setup(repo => repo.GetStudentByIdAsync(student.StudentId)).ReturnsAsync(student);

            int result = await _studentService.UpdateStudentAsync(student);
            Assert.Equal(expectedResult, result);
            _MockStudentRepository.Verify(repo => repo.UpdateStudentAsync(student), Times.Once);
        }
        [Fact]
        public async Task UpdateStudentAsync_UpdateSuccess_ReturnOne()
        {
            int expectedResult = 1;
            Student student = new Student() { Name = "TEST" };
            _MockStudentRepository.Setup(repo => repo.UpdateStudentAsync(student)).ReturnsAsync(expectedResult);

            int result = await _studentService.UpdateStudentAsync(student);
            Assert.Equal(expectedResult, result);
            _MockStudentRepository.Verify(repo => repo.UpdateStudentAsync(student), Times.Once);
        }
        [Fact]
        public async Task AddStudentAsync_NullStudent_ReturnMinusOne()
        {
            int expectedResult = -1;
            Student student = null;

            int result = await _studentService.AddStudentAsync(student);
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public async Task AddStudentAsync_StudentExsits_ReturnMinusOne()
        {
            int expectedResult = -1;
            Student student = new Student() { Name = "TEST" };
            _MockStudentRepository.Setup(repo => repo.AddStudentAsync(student)).ReturnsAsync(0);
            _MockStudentRepository.Setup(repo => repo.GetStudentByIdAsync(student.StudentId)).ReturnsAsync(new Student() { Name = "TEST" });

            int result = await _studentService.AddStudentAsync(student);
            Assert.Equal(expectedResult, result);
            _MockStudentRepository.Verify(repo => repo.AddStudentAsync(student), Times.Once);
        }
        [Fact]
        public async Task AddStudentAsync_AddError_ReturnZero()
        {
            int expectedResult = 0;
            Student student = new Student() { Name = "TEST" };
            _MockStudentRepository.Setup(repo => repo.AddStudentAsync(student)).ReturnsAsync(0);
            _MockStudentRepository.Setup(repo => repo.GetStudentByIdAsync(student.StudentId)).ReturnsAsync((Student)null);

            int result=await _studentService.AddStudentAsync(student);
            Assert.Equal(expectedResult, result);
            _MockStudentRepository.Verify(repo => repo.AddStudentAsync(student),Times.Once);
        }
        [Fact]
        public async Task AddStudentAsync_AddSuccess_ReturnOne()
        {
            int expectedResult = 1;
            Student student = new Student() {Name="TEST"};
            _MockStudentRepository.Setup(repo => repo.AddStudentAsync(student)).ReturnsAsync(expectedResult);

            int result=await _studentService.AddStudentAsync(student);
            Assert.Equal(expectedResult, result);
            _MockStudentRepository.Verify(repo => repo.AddStudentAsync(student), Times.Once);
        }
        [Fact]
        public async Task DeleteStudentAsync_InvalidId_ReturnMinusOne()
        {
            int id = 0;
            int expectedResult = -1;

            int result = await _studentService.DeleteStudentAsync(id);

            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public async Task DeleteStudentAsync_IdNotFound_ReturnMinusOne()
        {
            int id = 0;
            int expectedResult = -1;
            _MockStudentRepository.Setup(repo=>repo.DeleteStudentAsync(id)).ReturnsAsync(0);
            _MockStudentRepository.Setup(repo=>repo.GetStudentByIdAsync(id)).ReturnsAsync((Student)null);

            int result=await _studentService.DeleteStudentAsync(id);
            Assert.Equal(expectedResult, result);
            _MockStudentRepository.Verify(repo => repo.DeleteStudentAsync(id),Times.Once);
        }
        [Fact]
        public async Task DeleteStudentAsync_DeleteError_ReturnZero()
        {
            int id = 0;
            int expectedResult = 0;
            _MockStudentRepository.Setup(repo => repo.DeleteStudentAsync(id)).ReturnsAsync(0);
            _MockStudentRepository.Setup(repo => repo.GetStudentByIdAsync(id)).ReturnsAsync(new Student() { Name = "TEST" });

            int result = await _studentService.DeleteStudentAsync(id);
            Assert.Equal(expectedResult, result);
            _MockStudentRepository.Verify(repo => repo.DeleteStudentAsync(id), Times.Once);
        }
        [Fact]
        public async Task DeleteStudentAsync_DeleteSuccess_ReturnOne()
        {
            int id = 0;
            int expectedResult = 1;
            _MockStudentRepository.Setup(repo => repo.DeleteStudentAsync(id)).ReturnsAsync(expectedResult);

            int result = await _studentService.DeleteStudentAsync(id);
            Assert.Equal(expectedResult, result);
            _MockStudentRepository.Verify(repo => repo.DeleteStudentAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetAllStudentsAsync_GetSuccess_ReturnList()
        {
            List<Student> list= new List<Student>()
            {
                new Student() { Name="Test1" },
                new Student() { Name="Test2"}
            };
            _MockStudentRepository.Setup(repo => repo.GetAllStudentsAsync()).ReturnsAsync(list);

            IEnumerable<Student> result = await _studentService.GetAllStudentsAsync();
            Assert.NotNull(result);
            Assert.True(list.SequenceEqual(result));
        }
        [Fact]
        public async Task GetAllStudentsAsync_GetError_ReturnNull()
        {
            _MockStudentRepository.Setup(repo=>repo.GetAllStudentsAsync()).ReturnsAsync((IEnumerable<Student>)null);

            List<Student> result=(List<Student>)await _studentService.GetAllStudentsAsync();
            Assert.Null(result);
        }
        [Fact]
        public async Task GetAllUndergraduateStudentsAsync_NotFound_ReturnNull()
        {
            _MockStudentRepository.Setup(repo=>repo.GetAllStudentsByDegreeAsync(Degree.Bachelor)).ReturnsAsync((IEnumerable<Student>)null);

            IEnumerable<Student> result=await _studentService.GetAllUndergraduateStudentsAsync();
            Assert.Null(result);
            _MockStudentRepository.Verify(repo => repo.GetAllStudentsByDegreeAsync(Degree.Bachelor),Times.Once);
        }
        [Fact]
        public async Task GetAllUndergraduateStudentsAsync_Found_ReturnList()
        {
            IEnumerable<Student> students=new List<Student>() 
            { 
                new Student() {Name="TEST1"},
                new Student() {Name="TEST2"},
            };
            _MockStudentRepository.Setup(repo => repo.GetAllStudentsByDegreeAsync(Degree.Bachelor)).ReturnsAsync(students);

            IEnumerable<Student> result = await _studentService.GetAllUndergraduateStudentsAsync();

            Assert.NotNull(result);
            Assert.True(result.SequenceEqual(students));
            _MockStudentRepository.Verify(repo => repo.GetAllStudentsByDegreeAsync(Degree.Bachelor), Times.Once);
        }
        [Fact]
        public async Task GetAllGraduateStudentsAsync_NotFound_ReturnNull()
        {
            _MockStudentRepository.Setup(repo => repo.GetAllStudentsByDegreeAsync(Degree.Master)).ReturnsAsync((IEnumerable<Student>)null);

            IEnumerable<Student> result = await _studentService.GetAllGraduateStudentsAsync();
            Assert.Null(result);
            _MockStudentRepository.Verify(repo => repo.GetAllStudentsByDegreeAsync(Degree.Master), Times.Once);
        }
        [Fact]
        public async Task GetAllGraduateStudentsAsync_Found_ReturnList()
        {
            IEnumerable<Student> students = new List<Student>()
            {
                new Student() {Name = "TEST1"},
                new Student() {Name="TEST2"},
            };
            _MockStudentRepository.Setup(repo => repo.GetAllStudentsByDegreeAsync(Degree.Master)).ReturnsAsync(students);

            IEnumerable<Student> result = await _studentService.GetAllGraduateStudentsAsync();

            Assert.NotNull(result);
            Assert.True(result.SequenceEqual(students));
            _MockStudentRepository.Verify(repo => repo.GetAllStudentsByDegreeAsync(Degree.Master), Times.Once);
        }
        [Fact]
        public async Task GetAllDoctoralStudentsAsync_NotFound_ReturnNull()
        {
            _MockStudentRepository.Setup(repo => repo.GetAllStudentsByDegreeAsync(Degree.PhD)).ReturnsAsync((IEnumerable<Student>)null);

            IEnumerable<Student> result = await _studentService.GetAllDoctoralStudentsAsync();
            Assert.Null(result);
            _MockStudentRepository.Verify(repo => repo.GetAllStudentsByDegreeAsync(Degree.PhD), Times.Once);
        }
        [Fact]
        public async Task GetAllDoctoralStudentsAsync_Found_ReturnList()
        {
            IEnumerable<Student> students = new List<Student>()
            {
                new Student() {Name="TEST"},
                new Student() {Name="TEST"},
            };
            _MockStudentRepository.Setup(repo => repo.GetAllStudentsByDegreeAsync(Degree.PhD)).ReturnsAsync(students);

            IEnumerable<Student> result = await _studentService.GetAllDoctoralStudentsAsync();

            Assert.NotNull(result);
            Assert.True(result.SequenceEqual(students));
            _MockStudentRepository.Verify(repo => repo.GetAllStudentsByDegreeAsync(Degree.PhD), Times.Once);
        }
        [Fact]
        public async Task GetAllStudentsByFacultyIdAsync_InvalidId_ReturnNull()
        {
            int id = -1;

            IEnumerable<Student> result = await _studentService.GetAllStudentsByFacultyIdAsync(id);
            Assert.Null(result);
        }
        [Fact]
        public async Task GetAllStudentsByFacultyIdAsync_FacultyNotFound_ReturnNull()
        {
            int id = 1;
            _MockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync((Faculty)null);

            IEnumerable<Student> result = await _studentService.GetAllStudentsByFacultyIdAsync(id);
            Assert.Null(result);
            _MockFacultyRepository.Verify(repo => repo.GetFacultyByIdAsync(id),Times.Once);
        }
        [Fact]
        public async Task GetAllStudentsByFacultyIdAsync_FacultyWithNoStudent_ReturnNull()
        {
            int id = 1;
            Faculty faculty = new Faculty() { Name = "TEST" };
            _MockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync(faculty);
            _MockStudentRepository.Setup(repo=>repo.GetAllStudentsByFacultyIdAsync(id)).ReturnsAsync((IEnumerable<Student>)null);

            IEnumerable<Student> result = await _studentService.GetAllStudentsByFacultyIdAsync(id);
            Assert.Null(result);
            _MockStudentRepository.Verify(repo => repo.GetAllStudentsByFacultyIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetAllStudentsByFacultyIdAsync_FacultyWithStudents_ReturnList()
        {
            int id = 1;
            IEnumerable<Student> students = new List<Student>() 
            {
                new Student() { Name="TEST1" },
                new Student() { Name="TEST2" }
            };
            Faculty faculty = new Faculty() { Name = "TEST" };
            _MockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync(faculty);
            _MockStudentRepository.Setup(repo => repo.GetAllStudentsByFacultyIdAsync(id)).ReturnsAsync(students);

            IEnumerable<Student> result = await _studentService.GetAllStudentsByFacultyIdAsync(id);
            Assert.NotNull(result);
            Assert.True(result.SequenceEqual(students));
            _MockStudentRepository.Verify(repo => repo.GetAllStudentsByFacultyIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetAllUndergraduateStudentsByFacultyIdAsync_InvalidId_ReturnNull()
        {
            int id = -1;

            IEnumerable<Student> result = await _studentService.GetAllUndergraduateStudentsByFacultyIdAsync(id);
            Assert.Null(result);
        }
        [Fact]
        public async Task GetAllUndergraduateStudentsByFacultyIdAsync_FacultyNotFound_ReturnNull()
        {
            int id = 1;
            _MockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync((Faculty)null);

            IEnumerable<Student> result = await _studentService.GetAllUndergraduateStudentsByFacultyIdAsync(id);
            Assert.Null(result);
            _MockFacultyRepository.Verify(repo => repo.GetFacultyByIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetAllUndergraduateStudentsByFacultyIdAsync_FacultyWithNoStudent_ReturnNull()
        {
            int id = 1;
            Faculty faculty = new Faculty() { Name = "TEST" };
            _MockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync(faculty);
            _MockStudentRepository.Setup(repo => repo.GetAllStudentsByFacultyIdAsync(id)).ReturnsAsync((IEnumerable<Student>)null);

            IEnumerable<Student> result = await _studentService.GetAllUndergraduateStudentsByFacultyIdAsync(id);
            Assert.Null(result);
            _MockStudentRepository.Verify(repo => repo.GetAllStudentsByFacultyIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetAllUndergraduateStudentsByFacultyIdAsync_FacultyWithStudents_ReturnList()
        {
            int id = 1;
            IEnumerable<Student> students = new List<Student>()
            {
                new Student() {  Degree=Degree.Bachelor },
                new Student() {  Degree=Degree.Bachelor}
            };
            Faculty faculty = new Faculty() { Name = "TEST" };
            _MockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync(faculty);
            _MockStudentRepository.Setup(repo => repo.GetAllStudentsByFacultyIdAsync(id)).ReturnsAsync(students);

            IEnumerable<Student> result = await _studentService.GetAllUndergraduateStudentsByFacultyIdAsync(id);
            Assert.NotNull(result);
            Assert.True(result.SequenceEqual(students));
            _MockStudentRepository.Verify(repo => repo.GetAllStudentsByFacultyIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetAllGraduateStudentsByFacultyIdAsync_InvalidId_ReturnNull()
        {
            int id = -1;

            IEnumerable<Student> result = await _studentService.GetAllGraduateStudentsByFacultyIdAsync(id);
            Assert.Null(result);
        }
        [Fact]
        public async Task GetAllGraduateStudentsByFacultyIdAsync_FacultyNotFound_ReturnNull()
        {
            int id = 1;
            _MockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync((Faculty)null);

            IEnumerable<Student> result = await _studentService.GetAllGraduateStudentsByFacultyIdAsync(id);
            Assert.Null(result);
            _MockFacultyRepository.Verify(repo => repo.GetFacultyByIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetAllGraduateStudentsByFacultyIdAsync_FacultyWithNoStudent_ReturnNull()
        {
            int id = 1;
            Faculty faculty = new Faculty() { Name = "TEST" };
            _MockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync(faculty);
            _MockStudentRepository.Setup(repo => repo.GetAllStudentsByFacultyIdAsync(id)).ReturnsAsync((IEnumerable<Student>)null);

            IEnumerable<Student> result = await _studentService.GetAllGraduateStudentsByFacultyIdAsync(id);
            Assert.Null(result);
            _MockStudentRepository.Verify(repo => repo.GetAllStudentsByFacultyIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetAllGraduateStudentsByFacultyIdAsync_FacultyWithStudents_ReturnList()
        {
            int id = 1;
            IEnumerable<Student> students = new List<Student>()
            {
                new Student() { Degree=Degree.Master},
                new Student() { Degree=Degree.Master}
            };
            Faculty faculty = new Faculty() { Name = "TEST" };
            _MockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync(faculty);
            _MockStudentRepository.Setup(repo => repo.GetAllStudentsByFacultyIdAsync(id)).ReturnsAsync(students);

            IEnumerable<Student> result = await _studentService.GetAllGraduateStudentsByFacultyIdAsync(id);
            Assert.NotNull(result);
            Assert.True(result.SequenceEqual(students));
            _MockStudentRepository.Verify(repo => repo.GetAllStudentsByFacultyIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetAllDoctoralStudentsByFacultyIdAsync_InvalidId_ReturnNull()
        {
            int id = -1;

            IEnumerable<Student> result = await _studentService.GetAllDoctoralStudentsByFacultyIdAsync(id);
            Assert.Null(result);
        }
        [Fact]
        public async Task GetAllDoctoralStudentsByFacultyIdAsync_FacultyNotFound_ReturnNull()
        {
            int id = 1;
            _MockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync((Faculty)null);

            IEnumerable<Student> result = await _studentService.GetAllDoctoralStudentsByFacultyIdAsync(id);
            Assert.Null(result);
            _MockFacultyRepository.Verify(repo => repo.GetFacultyByIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetAllDoctoralStudentsByFacultyIdAsync_FacultyWithNoStudent_ReturnNull()
        {
            int id = 1;
            Faculty faculty = new Faculty() { Name = "TEST" };
            _MockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync(faculty);
            _MockStudentRepository.Setup(repo => repo.GetAllStudentsByFacultyIdAsync(id)).ReturnsAsync((IEnumerable<Student>)null);

            IEnumerable<Student> result = await _studentService.GetAllDoctoralStudentsByFacultyIdAsync(id);
            Assert.Null(result);
            _MockStudentRepository.Verify(repo => repo.GetAllStudentsByFacultyIdAsync(id), Times.Once);
        }
        [Fact]
        public async Task GetAllDoctoralStudentsByFacultyIdAsync_FacultyWithStudents_ReturnList()
        {
            int id = 1;
            IEnumerable<Student> students = new List<Student>()
            {
                new Student() {  Degree=Degree.PhD},
                new Student() {  Degree=Degree.PhD}
            };
            Faculty faculty = new Faculty() { Name = "TEST" };
            _MockFacultyRepository.Setup(repo => repo.GetFacultyByIdAsync(id)).ReturnsAsync(faculty);
            _MockStudentRepository.Setup(repo => repo.GetAllStudentsByFacultyIdAsync(id)).ReturnsAsync(students);

            IEnumerable<Student> result = await _studentService.GetAllDoctoralStudentsByFacultyIdAsync(id);
            Assert.NotNull(result);
            Assert.True(result.SequenceEqual(students));
            _MockStudentRepository.Verify(repo => repo.GetAllStudentsByFacultyIdAsync(id), Times.Once);
        }
    }
}