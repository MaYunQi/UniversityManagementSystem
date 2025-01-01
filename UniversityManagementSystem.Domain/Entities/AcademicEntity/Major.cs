using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.AcademicEntity
{
    public class Major : BaseEntity
    {
        public ushort MajorId { get; private set; }
        public Guid Guid { get; private set; }
        public string Name { get; set; }
        public sbyte FacultyId { get; private set; }
    }
}
