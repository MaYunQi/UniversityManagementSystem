
using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.AcademicEntity
{
    public class GPA: BaseEntity
    {
        public uint StudentId { get; private set; }
        public string Semester { get; private set; }
        public float GPAScore { get; private set; }
        public float CummulativeGPA {  get; private set; }
    }
}
