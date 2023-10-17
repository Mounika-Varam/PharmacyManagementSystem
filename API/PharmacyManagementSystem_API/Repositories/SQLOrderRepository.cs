using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.API.Enums;
using PharmacyManagementSystem.API.Models.Domain;

namespace PharmacyManagementSystem.API.Repositories
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly PharmacyManagementDbContext _context;

        public SQLOrderRepository(PharmacyManagementDbContext context)
        {
            _context = context;
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> DeleteOrderAsync(Guid id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
            if (order != null)
            {
                return null;
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.Include(o => o.Drug).ToListAsync();
        }
        public async Task<List<Order>> GetPendingOrdersAsync()
        {

            var orders = await _context.Orders.Where(o => (int)o.Status == (int)OrderStatus.Verified || (int)o.Status == (int)OrderStatus.Pending).ToListAsync();
            return orders;
        }

        public async Task<List<Order>> GetAllPickedUpOrdersAsync()
        {
            return await _context.Orders.Where(o => (int)o.Status == (int)OrderStatus.PickedUp).ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<Order> UpdateOrderAsync(Guid id, Order order)
        {
            var existingOrder = await GetOrderByIdAsync(id);
            if (existingOrder == null)
            {
                return null;
            }

        
            existingOrder.Status = order.Status;

            await _context.SaveChangesAsync();
            return existingOrder;
        }
    }
}
