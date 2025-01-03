using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Application.DTOs.StudentDTOs;
using UniversityManagementSystem.Application.Services;
using UniversityManagementSystem.UI.ViewModels;

namespace UniversityManagementSystem.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly StudentAppService _studentAppService;
        public StudentController(StudentAppService studentAppService,IMapper mapper)
        {
            _mapper=mapper;
            _studentAppService=studentAppService;
        }
        public IActionResult Index(IMapper mapper)
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddStudent() 
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentVM studentVM)
        {
            CreateStudentDTO studentDTO = _mapper.Map<CreateStudentDTO>(studentVM);
            int result = await _studentAppService.AddStudentAsync(studentDTO);
            return View();
        }
    }
}
