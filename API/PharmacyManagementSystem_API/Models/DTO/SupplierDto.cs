
namespace PharmacyManagementSystem.API.Models.DTO
{
    public class SupplierDto
    {
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public ICollection<DrugDto> Drugs { get; set; }

    }
}
