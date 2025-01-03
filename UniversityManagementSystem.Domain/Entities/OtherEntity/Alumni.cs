namespace UniversityManagementSystem.Domain.Entities.OtherEntity
{
    public class Alumni : BaseEntity
    {
        public uint AlumniId { get; private set; }
        public Guid Guid { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public ushort GraduationYear { get; set; }
        public Degree Degree { get; set; }
        public ushort MajorId { get; private set; }
    }
}
