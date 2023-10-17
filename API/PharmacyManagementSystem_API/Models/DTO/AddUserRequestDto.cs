using PharmacyManagementSystem.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.API.Models.DTO
{
    public class AddUserRequestDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

        public string Role { get; set; }
    }
}
