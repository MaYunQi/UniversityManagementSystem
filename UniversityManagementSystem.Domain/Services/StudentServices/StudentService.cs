
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
        public async Task<Student> GetStudentByIdAsync(uint id)
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
                Student local = await _studentRepository.GetStudentByIdAsync(student.Id);
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
                Student local = await _studentRepository.GetStudentByIdAsync(student.Id);
                if (local != null)
                    return -1;
                else 
                    return 0;
            }
            return result;
        }

        public async Task<int> DeleteStudentAsync(uint id)
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
            return await _studentRepository.GetAllStudentsAsync();
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

        public async Task<IEnumerable<Student>> GetAllStudentsByFacultyIdAsync(sbyte facultyId)
        {
            if (facultyId < 0)
                return null;
            Faculty faculty = await _facultyRepository.GetFacultyByIdAsync(facultyId);
            if (faculty == null)
                return null;
            return await _studentRepository.GetAllStudentsByFacultyIdAsync(facultyId);
        }

        public async Task<IEnumerable<Student>> GetAllUndergraduateStudentsByFacultyIdAsync(sbyte facultyId)
        {
            IEnumerable<Student> allStudents = await GetAllStudentsByFacultyIdAsync(facultyId);
            if (allStudents == null)
                return null;
            return allStudents.Where(stu => stu.Degree == Degree.Bachelor).ToList();
        }

        public async Task<IEnumerable<Student>> GetAllGraduateStudentsByFacultyIdAsync(sbyte facultyId)
        {
            IEnumerable<Student> allStudents = await GetAllStudentsByFacultyIdAsync(facultyId);
            if (allStudents == null)
                return null;
            return allStudents.Where(stu => stu.Degree == Degree.Master).ToList();
        }

        public async Task<IEnumerable<Student>> GetAllDoctoralStudentsByFacultyIdAsync(sbyte facultyId)
        {
            IEnumerable<Student> allStudents = await GetAllStudentsByFacultyIdAsync(facultyId);
            if (allStudents == null)
                return null;
            return allStudents.Where(stu => stu.Degree == Degree.PhD).ToList();
        }

        public Task<IEnumerable<Student>> GetAllStudentsByCourseIdAsync(ushort courseId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsByMajorIdAsync(ushort majorId)
        {
            return await _studentRepository.GetAllStudentsByMajorIdAsync(majorId);
        }

        public async Task<Student> GetStudentByStudentIdAsync(ulong studentId)
        {
            return await _studentRepository.GetStudentByStudentIdAsync(studentId);
        }

        public async Task<ulong> GetLastStudentIdByFacultyIdAsync(sbyte facultyId,Degree degree)
        {
            return await _studentRepository.GetLastStudentIdByFacultyIdAndDegreeAsync(facultyId, degree);
        }

        public async Task<ulong> GetLastStudentIdByFacultyIdAndDegreeAsync(sbyte facultyId, Degree degree)
        {
            return await _studentRepository.GetLastStudentIdByFacultyIdAndDegreeAsync(facultyId,degree);
        }
    }
}
