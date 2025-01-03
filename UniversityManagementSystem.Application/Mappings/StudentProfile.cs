
using AutoMapper;
using UniversityManagementSystem.Application.DTOs.StudentDTOs;
using UniversityManagementSystem.Domain.Entities.StudentEntity;

namespace UniversityManagementSystem.Application.Mappings
{
    public class StudentProfile: Profile
    {
        public StudentProfile()
        {
            CreateMap<Student,CreateStudentDTO>();
            CreateMap<CreateStudentDTO, Student>();

            CreateMap<Student,UpdateStudentDTO>();
            CreateMap<UpdateStudentDTO, Student>();

            CreateMap<Student,GetStudentDTO>();
            CreateMap<GetStudentDTO, Student>();
        }
    }
}
