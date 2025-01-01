using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.StudentEntity
{
    public class Student : BaseEntity
    {
        public int StudentId { get; private set; }
        public Guid Guid { get; private set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public sbyte NationId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public sbyte FacultyId { get; set; }
        public ushort MajorId { get; set; }
        public Degree Degree { get; set; }
        public int? SupervisorId { get; set; }
        public string? ResearchTopic { get; set; }
        public string? DissertationTopic { get; set; }
    }
}
