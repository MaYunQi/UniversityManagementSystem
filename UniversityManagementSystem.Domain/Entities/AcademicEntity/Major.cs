using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.AcademicEntity
{
    public class Major : BaseEntity
    {
        public short MajorId { get; private set; }
        public Guid Guid { get; private set; }
        public string Name { get; set; }
        public short FacultyId { get; private set; }
    }
}
