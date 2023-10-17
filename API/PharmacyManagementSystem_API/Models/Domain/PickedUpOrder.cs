namespace PharmacyManagementSystem.API.Models.Domain
{
    public class PickedUpOrder
    {
        public Guid PickedUpOrderId { get; set; }
        public DateTime PickedUpDate { get; set; }

        public Guid OrderId { get; set; }


        // Navigation property
        public Order Order { get; set; }
    }
}
