using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.AcademicEntity
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public CourseType CourseType { get; set; }
        public int MajorID {  get; set; }
    }
}
