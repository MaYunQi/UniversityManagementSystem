
using AutoMapper;
using System.Security.Cryptography;
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
            ulong lastStudentId = await _studentService.GetLastStudentIdByFacultyIdAndDegreeAsync(studentDTO.FacultyId,studentDTO.Degree);
            if(lastStudentId==0)
                lastStudentId=GenerateStudentIdFromFacultyId(studentDTO.FacultyId);
            studentDTO.StudentId = lastStudentId + 1;
            Student student = _mapper.Map<Student>(studentDTO);
            student.PasswordHash = GenerateDefaultPasswordByPhoneNo(student.PhoneNo);
            return await _studentService.AddStudentAsync(student);
        }
        public async Task<int> DeleteStudentAsync(uint id)
        {
            return await _studentService.DeleteStudentAsync(id);
        }
        public async Task<int> UpdateStudentAsync(UpdateStudentDTO studentDTO)
        {
            Student student=_mapper.Map<Student>(studentDTO);
            return await _studentService.UpdateStudentAsync(student);
        }
        public async Task<GetStudentDTO> GetStudentByIdAsync(uint id)
        {
            Student student=await _studentService.GetStudentByIdAsync(id);
            return _mapper.Map<GetStudentDTO>(student);
        }
        public async Task<GetStudentDTO> GetStudentByStudentIdAsync(uint id)
        {
            Student student = await _studentService.GetStudentByStudentIdAsync(id);
            return _mapper.Map<GetStudentDTO>(student);
        }
        public async Task<IEnumerable<GetStudentDTO>> GetAllStudentAsync()
        {
            IEnumerable<Student> students=await _studentService.GetAllStudentsAsync();
            return _mapper.Map<List<GetStudentDTO>>(students);
        }
        private ulong GenerateStudentIdFromFacultyId(sbyte facultyId)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(DateTime.Now.Year.ToString());
            string facultid = facultyId.ToString("D3");
            stringBuilder.Append(facultid);
            stringBuilder.Append("0000");
            return Convert.ToUInt64(stringBuilder.ToString()); 
        }
        private string GenerateDefaultPasswordByPhoneNo(string phoneNo)
        {
            return ComputerSHA256Hash(phoneNo);
        }
        private string ComputerSHA256Hash(string input)
        {
            using (SHA256 sha= SHA256.Create())
            {
                byte[] bytes=Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha.ComputeHash(bytes);

                StringBuilder hash = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hash.Append(b.ToString("x2")); 
                }
                return hash.ToString();
            }
        }
    }
}
