using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.AcademicEntity
{
    public class Faculty : BaseEntity
    {
        public sbyte FacultyId { get; private set; }
        public Guid Guid { get; private set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public ushort DeanId { get; set; }
        public DateTime EstablishedDate { get; set; }
    }
}
