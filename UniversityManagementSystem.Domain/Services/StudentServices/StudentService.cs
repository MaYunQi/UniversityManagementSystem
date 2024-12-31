
using UniversityManagementSystem.Domain.Entities.AcademicEntity;
using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.Domain.Entities.StudentEntity;
using UniversityManagementSystem.Domain.Interfaces.AcademicInterface;
using UniversityManagementSystem.Domain.Interfaces.StudentInterface;

namespace UniversityManagementSystem.Domain.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IFacultyRepository _facultyRepository;
        public StudentService(IStudentRepository studentRepository,IFacultyRepository facultyRepository)
        {
            _studentRepository = studentRepository;
            _facultyRepository=facultyRepository;
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
        public async Task<IEnumerable<Student>> GetAllStudentsByFacultyIdAsync(int facultyId)
        {
            if (facultyId < 0)
                return null;
            Faculty faculty=await _facultyRepository.GetFacultyByIdAsync(facultyId);
            if (faculty == null)
                return null;
            return await _studentRepository.GetAllStudentsByFacultyIdAsync(facultyId);
        }
        public async Task<IEnumerable<Student>> GetAllUndergraduateStudentsByFacultyIdAsync(int facultyId)
        {
            IEnumerable<Student> allStudents = await GetAllStudentsByFacultyIdAsync(facultyId);
            if (allStudents == null)
                return null;
            return allStudents.Where(stu => stu.Degree == Degree.Bachelor).ToList();
        }
        public async Task<IEnumerable<Student>> GetAllGraduateStudentsByFacultyIdAsync(int facultyId)
        {
            IEnumerable<Student> allStudents = await GetAllStudentsByFacultyIdAsync(facultyId);
            if (allStudents == null)
                return null;
            return allStudents.Where(stu => stu.Degree == Degree.Master).ToList();
        }
        public async Task<IEnumerable<Student>> GetAllDoctoralStudentsByFacultyIdAsync(int facultyId)
        {
            IEnumerable<Student> allStudents = await GetAllStudentsByFacultyIdAsync(facultyId);
            if (allStudents == null)
                return null;
            return allStudents.Where(stu => stu.Degree == Degree.PhD).ToList();
        }
        public Task<IEnumerable<Student>> GetAllStudentsByCourseIdAsync(int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
