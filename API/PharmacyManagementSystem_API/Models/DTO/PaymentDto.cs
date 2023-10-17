using PharmacyManagementSystem.API.Enums;

namespace PharmacyManagementSystem.API.Models.DTO
{
    public class PaymentDto
    {
        public Guid PaymentId { get; set; }
        public PaymentMethod Method { get; set; }
        public decimal Amount { get; set; }
        public Guid OrderId { get; set; }
    }
}
