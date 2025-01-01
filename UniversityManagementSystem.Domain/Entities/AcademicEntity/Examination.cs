using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.AcademicEntity
{
    public class Examination : BaseEntity
    {
        public short ExamId { get; private set; }
        public Guid Guid { get; private set; }
        public short CourseId { get; private set; }
    }
}
