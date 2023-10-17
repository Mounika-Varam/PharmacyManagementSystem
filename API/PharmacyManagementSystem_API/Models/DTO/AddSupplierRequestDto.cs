using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.API.Models.DTO
{
    public class AddSupplierRequestDto
    {
        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Contact number is required.")]

        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid contact number.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage ="Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        //public ICollection<DrugDto> Drugs { get; set; }

    }
}
