using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.AcademicEntity
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public RegisterationType RegisterationType { get; set; }
        public int FacultiId { get; set; }
        public int MajorId {  get; set; }
    }
}
