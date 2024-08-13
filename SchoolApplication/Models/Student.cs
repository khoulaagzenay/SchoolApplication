using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SchoolApplication.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name can only contain letters.")]
        public string Lastname { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Student), nameof(ValidateBirthdate))]
        public DateTime Birthdate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public bool HasSubscribed { get; set; }

        //Navigations properties
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();

        //MUST BE public static TO WORK IN VALIDATION
        public static ValidationResult ValidateBirthdate(DateTime birthdate)
        {
            var age = DateTime.Today.Year - birthdate.Year;
            if (birthdate > DateTime.Today.AddYears(-age)) age--;

            if (age < 15 || age > 60)
            {
                return new ValidationResult("Age must be between 15 and 60.");
            }

            return ValidationResult.Success;
        }

    }
}
