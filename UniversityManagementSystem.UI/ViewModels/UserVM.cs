using UniversityManagementSystem.UI.Validations;

namespace UniversityManagementSystem.UI.ViewModels
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        [DateOfBirthValidation]
        public DateTime DateOfBirh { get; set; }
    }
}
