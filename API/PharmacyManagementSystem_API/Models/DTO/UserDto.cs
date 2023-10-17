﻿using PharmacyManagementSystem.API.Enums;

namespace PharmacyManagementSystem.API.Models.DTO
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; } 
        public Gender Gender { get; set; }

        public string Role { get; set; }
    }
}
