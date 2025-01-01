using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.AcademicEntity
{
    public class Examination : BaseEntity
    {
        public ushort ExamId { get; private set; }
        public Guid Guid { get; private set; }
        public ushort CourseId { get; private set; }
    }
}
