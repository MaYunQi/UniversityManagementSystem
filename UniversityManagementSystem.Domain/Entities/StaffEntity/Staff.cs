using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Entities.StaffEntity
{
    public  class Staff
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public StaffType Type { get; set; }
        public int? FacultyId { get; set; }
        public AcademicTitle Title { get; set; }
    }
}
