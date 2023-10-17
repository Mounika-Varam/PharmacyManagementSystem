using PharmacyManagementSystem.API.Models.Domain;

namespace PharmacyManagementSystem.API.Repositories
{
    public interface IDrugRepository
    {
        Task<List<Drug>> GetAllDrugsAsync();
        Task<Drug> GetDrugByIdAsync(Guid id);

        Task<Drug> CreateDrugAsync(Drug drug);
        Task<Drug> UpdateDrugAsync(Guid id, Drug drug);

        //Task<Drug> UpdateDrugQuantityAsync(Guid id, Drug drug);
        Task<Drug> DeleteDrugAsync(Guid id);

        Task<bool> UpdateDrugImageAsync(Guid id, string imageUrl);

        Task<bool> ExistsAsync(Guid id);

        Task<List<Drug>> GetOutOfStockDrugs();
        Task<List<Drug>> GetExpiredDrugs();
    }
}
