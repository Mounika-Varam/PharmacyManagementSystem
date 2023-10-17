using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.API.Models.Domain;

namespace PharmacyManagementSystem.API.Repositories
{
    public class SQLDrugRepository : IDrugRepository
    {
        private readonly PharmacyManagementDbContext _context;

        public SQLDrugRepository(PharmacyManagementDbContext context)
        {
            _context = context;
        }
        public async Task<Drug> CreateDrugAsync(Drug drug)
        {
            await _context.Drugs.AddAsync(drug);
            await _context.SaveChangesAsync();
            return drug;
        }

        public async Task<Drug> DeleteDrugAsync(Guid id)
        {
            var drug = await _context.Drugs.FirstOrDefaultAsync(d => d.DrugId == id);
            if (drug == null)
            {
                return null;
            }

            _context.Drugs.Remove(drug);
            await _context.SaveChangesAsync();
            return drug;
        }

        public async Task<List<Drug>> GetAllDrugsAsync()
        {
            return await _context.Drugs.ToListAsync();
        }

        public async Task<Drug> GetDrugByIdAsync(Guid id)
        {
            return await _context.Drugs.FirstOrDefaultAsync(d => d.DrugId == id);
        }

        public async Task<Drug> UpdateDrugAsync(Guid id, Drug drug)
        {
            var existingDrug = await _context.Drugs.FirstOrDefaultAsync(d => d.DrugId == id);

            if (existingDrug == null)
            {
                return null;
            }

            existingDrug.DrugName = drug.DrugName;
            existingDrug.ExpiryDate = drug.ExpiryDate;
            existingDrug.Price = drug.Price;
            existingDrug.Quantity = drug.Quantity;

            await _context.SaveChangesAsync();
            return existingDrug;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Drugs.AnyAsync(s => s.DrugId == id);
        }

        public async Task<bool> UpdateDrugImageAsync(Guid id, string imageUrl)
        {
            var drug = await GetDrugByIdAsync(id);
            if (drug != null)
            {
                drug.ImageUrl = imageUrl;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Drug>> GetOutOfStockDrugs()
        {
            return await _context.Drugs.Where(d => d.Quantity <= 0).ToListAsync();
        }

        public async Task<List<Drug>> GetExpiredDrugs()
        {
            return await _context.Drugs.Where(d => d.ExpiryDate <= DateTime.Now).ToListAsync();
        }
    }
}
