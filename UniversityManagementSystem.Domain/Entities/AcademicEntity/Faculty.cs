using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.AcademicEntity
{
    public class Faculty : BaseEntity
    {
        public short FacultyId { get; private set; }
        public Guid Guid { get; private set; }
        public string Name { get; set; }
    }
}
