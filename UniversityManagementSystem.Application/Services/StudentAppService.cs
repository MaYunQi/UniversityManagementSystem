
using AutoMapper;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using UniversityManagementSystem.Application.DTOs.StudentDTOs;
using UniversityManagementSystem.Domain.Entities.StudentEntity;
using UniversityManagementSystem.Domain.Interfaces.StudentInterface;

namespace UniversityManagementSystem.Application.Services
{
    public class StudentAppService
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        public StudentAppService(IMapper mapper,IStudentService studentService)
        {
            _mapper= mapper;
            _studentService = studentService;
        }
        public async Task<int> AddStudentAsync(CreateStudentDTO studentDTO)
        {
            studentDTO.Guid = Guid.NewGuid();
            int lastStudentId = await _studentService.GetLastStudentIdByFacultyIdAndDegreeAsync(studentDTO.FacultyId,studentDTO.Degree);
            if(lastStudentId==0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(DateTime.Now.Year.ToString());
                string facultid=studentDTO.FacultyId.ToString("D3");
                stringBuilder.Append(facultid);
                stringBuilder.Append("0000");
                lastStudentId=Convert.ToInt32(stringBuilder.ToString());
            }
            studentDTO.StudentId = lastStudentId + 1;
            Student student = _mapper.Map<Student>(studentDTO);
            return await _studentService.AddStudentAsync(student);
        }
        public async Task<int> DeleteStudentAsync(int id)
        {
            return await _studentService.DeleteStudentAsync(id);
        }
        public async Task<int> UpdateStudentAsync(UpdateStudentDTO studentDTO)
        {
            Student student=_mapper.Map<Student>(studentDTO);
            return await _studentService.UpdateStudentAsync(student);
        }
        public async Task<GetStudentDTO> GetStudentByIdAsync(int id)
        {
            Student student=await _studentService.GetStudentByIdAsync(id);
            return _mapper.Map<GetStudentDTO>(student);
        }
        public async Task<GetStudentDTO> GetStudentByStudentIdAsync(int id)
        {
            Student student = await _studentService.GetStudentByStudentIdAsync(id);
            return _mapper.Map<GetStudentDTO>(student);
        }
        public async Task<IEnumerable<GetStudentDTO>> GetAllStudentAsync()
        {
            IEnumerable<Student> students=await _studentService.GetAllStudentsAsync();
            return _mapper.Map<List<GetStudentDTO>>(students);
        }
    }
}
