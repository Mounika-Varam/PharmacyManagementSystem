namespace PharmacyManagementSystem.API.Models.DTO
{
    public class UpdateDrugRequestDto
    {
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
