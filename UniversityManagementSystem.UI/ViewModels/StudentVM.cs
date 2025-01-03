using System.ComponentModel.DataAnnotations;
using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.UI.Validations;

namespace UniversityManagementSystem.UI.ViewModels
{
    public class StudentVM
    {
        [ScaffoldColumn(false)]
        public uint Id { get; set; }
        public ulong StudentId { get; set; }
        [ScaffoldColumn(false)]
        public Guid Guid { get; set; }
        [Required]
        [StringLength(20,MinimumLength =3)]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public sbyte NationId { get; set; }
        [Required]
        [DateOfBirthValidation]
        [Display(Name ="Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        public DateTime EnrollmentDate { get; set; }
        [Required]
        [Phone]
        public string PhoneNo { get; set; }
        [Required]
        [MaxLength(255)]
        public string Address { get; set; }
        [Required]
        public sbyte FacultyId { get; set; }
        [Required]
        public ushort MajorId { get; set; }
        [Required]
        public Degree Degree { get; set; }
    }
}
