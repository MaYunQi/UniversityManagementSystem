
using UniversityManagementSystem.Domain.Entities.OtherEntity;
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

        public async Task<int> UpdateStudentAsync(Student student)
        {
            if (student == null)
                return -1;
            int result=await _studentRepository.UpdateStudentAsync(student);
            if(result==0)
            {
                Student local = await _studentRepository.GetStudentByIdAsync(student.StudentId);
                if(local==null)
                    return -1;
                else
                    return 0;
            }
            return result;
        }

        public async Task<int> AddStudentAsync(Student student)
        {
            if(student==null)
                return -1;
            int result=await _studentRepository.AddStudentAsync(student); 
            if(result==0)
            {
                Student local = await _studentRepository.GetStudentByIdAsync(student.StudentId);
                if (local != null)
                    return -1;
                else 
                    return 0;
            }
            return result;
        }

        public async Task<int> DeleteStudentAsync(int id)
        {
            if(id<0)
                return -1;
            int result=await _studentRepository.DeleteStudentAsync(id);
            if(result==0)
            {
                Student local = await _studentRepository.GetStudentByIdAsync(id);
                if (local != null)
                    return 0;
                else
                    return -1;
            }
            return result;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            IEnumerable<Student> stuList = await _studentRepository.GetAllStudentsAsync();
            return stuList;
        }
        
        public async Task<IEnumerable<Student>> GetAllUndergraduateStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsByDegreeAsync(Degree.Bachelor);
        }

        public async Task<IEnumerable<Student>> GetAllGraduateStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsByDegreeAsync(Degree.Master);
        }

        public async Task<IEnumerable<Student>> GetAllDoctoralStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsByDegreeAsync(Degree.PhD);
        }
        public Task<IEnumerable<Student>> GetAllStudentsWithFacultyIdAsync(int facultyId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Student>> GetAllUndergraduateStudentsWithFacultyIdAsync(int facultyId)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Student>> GetAllGraduateStudentsWithFacultyIdAsync(int facultyId)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Student>> GetAllDoctoralStudentsWithFacultyIdAsync(int facultyId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Student>> GetAllStudentsWithCourseIdAsync(int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
