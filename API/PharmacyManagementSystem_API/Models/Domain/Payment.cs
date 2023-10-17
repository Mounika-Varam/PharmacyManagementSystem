using PharmacyManagementSystem.API.Enums;

namespace PharmacyManagementSystem.API.Models.Domain
{
    public class Payment
    {
        public Guid PaymentId { get; set; }
        public PaymentMethod Method { get; set; }
        public decimal Amount { get; set; }
        public Guid OrderId { get; set; }

        // Navigation property
        public Order Order { get; set; }
    }
}
