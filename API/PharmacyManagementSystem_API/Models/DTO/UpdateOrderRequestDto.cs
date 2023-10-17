using PharmacyManagementSystem.API.Enums;

namespace PharmacyManagementSystem.API.Models.DTO
{
    public class UpdateOrderRequestDto
    {
        //public int Quantity { get; set; }
        //public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        //public Guid UserId { get; set; }
        //public Guid DrugId { get; set; }
    }
}
