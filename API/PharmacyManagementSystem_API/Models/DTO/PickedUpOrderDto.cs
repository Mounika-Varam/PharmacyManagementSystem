namespace PharmacyManagementSystem.API.Models.DTO
{
    public class PickedUpOrderDto
    {
        public Guid PickedUpOrderId { get; set; }
        public DateTime PickedUpDate { get; set; }

        public Guid OrderId { get; set; }

    }
}
