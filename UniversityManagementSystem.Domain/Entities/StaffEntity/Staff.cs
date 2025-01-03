using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.StaffEntity
{
    public  class Staff : BaseEntity
    {
        public uint StaffId { get; private set; }
        public string PasswordHash { get; set; }
        public Guid Guid { get; private set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public StaffType StaffType { get; set; }
        public sbyte? FacultyId { get; set; }
        public AcademicTitle Title { get; set; }
    }
}
