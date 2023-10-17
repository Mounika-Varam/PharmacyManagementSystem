namespace PharmacyManagementSystem.API.Models.Domain
{
    public class Supplier
    {
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        // Navigation property
        public ICollection<Drug> Drugs { get; set; }
    }
}
