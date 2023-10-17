using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.API.Models.DTO
{
    public class AddDrugRequestDto
    {
        [Required]
        public string DrugName { get; set; }
        public string ImageUrl { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}
