using PharmacyManagementSystem.API.Models.Domain;

namespace PharmacyManagementSystem.API.Repositories
{
    public interface IPickedUpOrderRepository
    {
        Task<List<PickedUpOrder>> GetAllPickedUpOrdersAsync();
        Task<PickedUpOrder> GetPickedUpOrderByIdAsync(Guid id);

        Task<PickedUpOrder> CreatePickedUpOrderAsync(PickedUpOrder pickedUpOrder);
        Task<PickedUpOrder> UpdatePickedUpOrderAsync(Guid id, PickedUpOrder pickedUpOrder);
        Task<PickedUpOrder> DeletePickedUpOrderAsync(Guid id);
    }
}
