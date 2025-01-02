
namespace UniversityManagementSystem.Application.DTOs.StudentDTOs
{
    public class UpdateStudentDTO
    {
        public int Id { get;private set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public int? SupervisorId { get; set; }
        public string? ResearchTopic { get; set; }
        public string? DissertationTopic { get; set; }
    }
}
