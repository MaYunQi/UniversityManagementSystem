
using UniversityManagementSystem.Domain.Entities.StudentEntity;
using UniversityManagementSystem.Domain.Interfaces.StudentInterface;

namespace UniversityManagementSystem.Domain.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            if (id < 0)
                return null;
            Student student=await _studentRepository.GetStudentByIdAsync(id);
            return student;
        }

        public Task<int> UpdateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }
        public Task<int> AddStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllDoctoralStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllDoctoralStudentsWithFacultyIdAsync(int facultyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllGraduateStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllGraduateStudentsWithFacultyIdAsync(int facultyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllStudentsWithCourseIdAsync(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllStudentsWithFacultyIdAsync(int facultyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllUndergraduateStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllUndergraduateStudentsWithFacultyIdAsync(int facultyId)
        {
            throw new NotImplementedException();
        }
    }
}
