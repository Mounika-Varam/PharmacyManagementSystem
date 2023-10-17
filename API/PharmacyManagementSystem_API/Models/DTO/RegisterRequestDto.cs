using PharmacyManagementSystem.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.API.Models.DTO
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage ="Email is required")]
        //[RegularExpression("^[^@\\s]+@[^@\\s]+\\.(com|net|org|gov)$", ErrorMessage = "Invalid Email Address")]
        [EmailAddress]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Full Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Full name must be between 2 and 50 characters.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Full name can only contain letters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Phone Number is required.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

        public string Role { get; set; }

    }
}
