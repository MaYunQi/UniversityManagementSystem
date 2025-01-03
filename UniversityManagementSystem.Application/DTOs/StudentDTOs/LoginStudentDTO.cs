
namespace UniversityManagementSystem.Application.DTOs.StudentDTOs
{
    public  class LoginStudentDTO
    {
        public ulong StudentId { get; set; }
        public string PasswordHash { get; set; }
    }
}
