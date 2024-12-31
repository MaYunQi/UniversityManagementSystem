using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.UI.Validations
{
    public class DateOfBirthValidation:ValidationAttribute
    {
        private readonly int minimumYear = 2000;
        public DateOfBirthValidation() { }
        public DateOfBirthValidation(int minimumyear)
        {
            minimumYear = minimumyear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                DateTime date = (DateTime)value;
                if(date.Year< minimumYear || date.Year>DateTime.Today.Year)
                {
                    return new ValidationResult("Wrong with the year");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
