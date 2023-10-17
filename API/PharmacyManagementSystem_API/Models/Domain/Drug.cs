namespace PharmacyManagementSystem.API.Models.Domain
{
    public class Drug
    {
        public Guid DrugId { get; set; }
        public string DrugName { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }


        // Navigation properties
        public ICollection<Order> Orders { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
    }
}
