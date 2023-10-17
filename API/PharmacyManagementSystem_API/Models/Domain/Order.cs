using PharmacyManagementSystem.API.Enums;

namespace PharmacyManagementSystem.API.Models.Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public Guid UserId { get; set; }
        public Guid DrugId { get; set; }


        // Navigation Properties
        public User User { get; set; }
        public Drug Drug { get; set; }
        public PickedUpOrder PickedUpOrder { get; set; }
        public Payment Payment { get; set; }
    }
}
