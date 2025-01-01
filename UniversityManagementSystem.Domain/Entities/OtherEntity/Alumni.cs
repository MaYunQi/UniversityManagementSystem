namespace UniversityManagementSystem.Domain.Entities.OtherEntity
{
    public class Alumni : BaseEntity
    {
        public int AlumniId { get; private set; }
        public Guid Guid { get; private set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public int GraduationYear { get; set; }
        public Degree Degree { get; set; }
        public short MajorId { get; private set; }
    }
}
