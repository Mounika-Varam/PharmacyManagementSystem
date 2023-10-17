using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.API.Models.Domain;

namespace PharmacyManagementSystem.API.Repositories
{
    public class SQLPickedUpOrderRepository : IPickedUpOrderRepository
    {
        private readonly PharmacyManagementDbContext _context;

        public SQLPickedUpOrderRepository(PharmacyManagementDbContext context)
        {
            _context = context;
        }

        public async Task<PickedUpOrder> CreatePickedUpOrderAsync(PickedUpOrder pickedUpOrder)
        {
            pickedUpOrder.PickedUpDate = DateTime.Now;
            await _context.PickedUpOrders.AddAsync(pickedUpOrder);
            await _context.SaveChangesAsync();
            return pickedUpOrder;
        }

        public async Task<PickedUpOrder> DeletePickedUpOrderAsync(Guid id)
        {
            var pickedUpOrder = await _context.PickedUpOrders.FirstOrDefaultAsync(p => p.PickedUpOrderId == id);
            if (pickedUpOrder == null)
            {
                return null;
            }

            _context.PickedUpOrders.Remove(pickedUpOrder);
            await _context.SaveChangesAsync();
            return pickedUpOrder;
        }

        public async Task<List<PickedUpOrder>> GetAllPickedUpOrdersAsync()
        {
            return await _context.PickedUpOrders.Include(p => p.Order).ThenInclude(o => o.Drug).ToListAsync();
        }

        public async Task<PickedUpOrder> GetPickedUpOrderByIdAsync(Guid id)
        {
            return await _context.PickedUpOrders.FirstOrDefaultAsync(p => p.PickedUpOrderId == id);
        }

        public async Task<PickedUpOrder> UpdatePickedUpOrderAsync(Guid id, PickedUpOrder pickedUpOrder)
        {
            var existingPickedUpOrder = await _context.PickedUpOrders.FirstOrDefaultAsync(p => p.PickedUpOrderId == id);

            if (existingPickedUpOrder == null)
            {
                return null;
            }

            existingPickedUpOrder.PickedUpDate = pickedUpOrder.PickedUpDate;
            existingPickedUpOrder.OrderId = pickedUpOrder.OrderId;

            await _context.SaveChangesAsync();
            return pickedUpOrder;

        }
    }
}
