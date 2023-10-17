using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.API.Models.Domain;

namespace PharmacyManagementSystem.API.Repositories
{
    public class SQLSupplierRepository : ISupplierRepository
    {
        private readonly PharmacyManagementDbContext _context;

        public SQLSupplierRepository(PharmacyManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {

            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier> DeleteSupplierAsync(Guid id)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.SupplierId == id);
            if (supplier == null)
            {
                return null;
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers.Include(s => s.Drugs).ToListAsync();
        }

        public async Task<Supplier> GetSupplierByIdAsync(Guid id)
        {
            return await _context.Suppliers.Include(s => s.Drugs).FirstOrDefaultAsync(s => s.SupplierId == id);
        }

        public async Task<Supplier> UpdateSupplierAsync(Guid id, Supplier supplier)
        {
            var existingSupplier = await _context.Suppliers.Include(s => s.Drugs).FirstOrDefaultAsync(s => s.SupplierId == id);

            if (existingSupplier == null)
            {
                return null;
            }

            existingSupplier.Drugs.Clear();

            var availableDrugs = await _context.Drugs.ToListAsync();

            foreach(var drug in supplier.Drugs)
            {
                existingSupplier.Drugs.Add(availableDrugs.First(d => d.DrugId == drug.DrugId));
            }
            existingSupplier.Name = supplier.Name;
            existingSupplier.Email = supplier.Email;
            existingSupplier.ContactNumber = supplier.ContactNumber;

            await _context.SaveChangesAsync();
            return existingSupplier;
        }
    }
}
