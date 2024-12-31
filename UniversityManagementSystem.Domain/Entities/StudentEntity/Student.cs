using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.StudentEntity
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public int NationID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public int FacultyId { get; set; }
        public int MajorId { get; set; }
        public Degree Degree { get; set; }
        public int? SuperviorId { get; set; }
        public string? ResearchTopic { get; set; }
        public string? DissertationTopic { get; set; }
    }
}
