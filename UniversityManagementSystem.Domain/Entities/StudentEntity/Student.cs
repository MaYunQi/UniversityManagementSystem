using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.StudentEntity
{
    public class Student : BaseEntity
    {
        public int StudentId { get; private set; }
        public Guid Guid { get; private set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public short NationID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public short FacultyId { get; set; }
        public short MajorId { get; set; }
        public Degree Degree { get; set; }
        public int? SuperviorId { get; set; }
        public string? ResearchTopic { get; set; }
        public string? DissertationTopic { get; set; }
    }
}
