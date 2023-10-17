using PharmacyManagementSystem.API.Models.Domain;

namespace PharmacyManagementSystem.API.Repositories
{
    public interface IPaymentRepository
    {
        //Task<List<Payment>> GetAllPaymentsAsync();
        //Task<Payment> GetPaymentByIdAsync(Guid id);

        Task<Payment> CreatePaymentAsync(Payment payment);
        //Task<Payment> UpdatePaymentAsync(Guid id, Payment payment);
        //Task<Payment> DeletePaymentAsync(Guid id);
    }
}
