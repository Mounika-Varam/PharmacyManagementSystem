using PharmacyManagementSystem.API.Models.Domain;

namespace PharmacyManagementSystem.API.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<List<Order>> GetAllOrdersAsync();
        Task<List<Order>> GetPendingOrdersAsync();
        Task<List<Order>> GetAllPickedUpOrdersAsync();
        Task<Order> GetOrderByIdAsync(Guid id);
        Task<Order> UpdateOrderAsync(Guid id, Order order);
        Task<Order> DeleteOrderAsync(Guid id);

    }
}
