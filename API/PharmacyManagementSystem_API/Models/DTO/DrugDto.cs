namespace PharmacyManagementSystem.API.Models.DTO
{
    public class DrugDto
    {
        public Guid DrugId { get; set; }
        public string DrugName { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
