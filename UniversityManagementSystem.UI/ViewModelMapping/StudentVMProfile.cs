using AutoMapper;
using UniversityManagementSystem.Application.DTOs.StudentDTOs;
using UniversityManagementSystem.UI.ViewModels;

namespace UniversityManagementSystem.UI.ViewModelMapping
{
    public class StudentVMProfile : Profile
    {
        public StudentVMProfile()
        {
            CreateMap<StudentVM, CreateStudentDTO>();
            CreateMap<CreateStudentDTO, StudentVM>();
        }
    }
}
