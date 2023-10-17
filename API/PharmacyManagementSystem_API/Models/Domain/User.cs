using PharmacyManagementSystem.API.Enums;
using System.Reflection;

namespace PharmacyManagementSystem.API.Models.Domain
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

        public string Role { get; set; }



        // Navigation properties
        public ICollection<Order> Orders { get; set; }
    }
}
