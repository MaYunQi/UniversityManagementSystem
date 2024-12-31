namespace UniversityManagementSystem.Domain.Entities.OtherEntity
{
    public class Alumni
    {
        public int AlumniId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public int GraduationYear { get; set; }
        public Degree Degree { get; set; }
        public int MajorId { get; set; }
    }
}
