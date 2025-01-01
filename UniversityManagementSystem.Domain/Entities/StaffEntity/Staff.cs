using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.StaffEntity
{
    public  class Staff : BaseEntity
    {
        public int StaffId { get; private set; }
        public Guid Guid { get; private set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public StaffType StaffType { get; set; }
        public short? FacultyId { get; set; }
        public AcademicTitle Title { get; set; }
    }
}
