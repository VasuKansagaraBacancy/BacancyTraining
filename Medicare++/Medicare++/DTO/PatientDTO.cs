using System.ComponentModel.DataAnnotations;

namespace Medicare__.DTO
{
    public class PatientDTO
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name can't be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name can't be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female, or Other.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Aadhar number is required.")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Aadhar number must be 12 digits.")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Aadhar number must be numeric and exactly 12 digits.")]
        public string AadharNo { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address can't be longer than 200 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "City can't be longer than 100 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression(@"^\+91[6-9]\d{9}$", ErrorMessage = "Phone number must be a valid Indian number with +91 prefix.")]
        public string MobileNo { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
    }
}
