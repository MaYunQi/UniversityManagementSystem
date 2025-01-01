using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.AcademicEntity
{
    public class Course:BaseEntity
    {
        public short CourseId { get; private set; }
        public Guid Guid { get; private set; }
        public string CourseCode { get; private set; }
        public string Name { get; set; }
        public sbyte Credit { get; private set; }
        public string Semester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Schedule { get; set; }
        public sbyte MaxStudents { get; set; }
        public sbyte CurrentEnrollment { get; set; }
        public List<string>? Prerequisities { get; set; }
        public short FacultyId { get; private set; }
        public short MajorId {  get; private set; }
    }
}
