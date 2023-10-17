using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.API.Models.DTO
{
    public class LoginRequestDto
    {
        [Required]
        //[RegularExpression("^[^@\\s]+@[^@\\s]+\\.(com|net|org|gov)$", ErrorMessage = "Invalid Email Address")]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
