using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.API.Models.Domain;

namespace PharmacyManagementSystem.API.Repositories
{
    public class SQLPaymentRepository : IPaymentRepository
    {
        private readonly PharmacyManagementDbContext _context;

        public SQLPaymentRepository(PharmacyManagementDbContext context)
        {
            _context = context;
        }
        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        //public async Task<Payment> DeletePaymentAsync(Guid id)
        //{
        //    var payment = await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId == id);
        //    if (payment == null)
        //    {
        //        return null;
        //    }

        //    _context.Payments.Remove(payment);
        //    await _context.SaveChangesAsync();
        //    return payment;
        //}

        //public async Task<List<Payment>> GetAllPaymentsAsync()
        //{
        //    return await _context.Payments.ToListAsync();

        //}

        //public async Task<Payment> GetPaymentByIdAsync(Guid id)
        //{
        //    return await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId == id);
        //}

        //public async Task<Payment> UpdatePaymentAsync(Guid id, Payment payment)
        //{
        //    var existingPayment = await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId == id);

        //    if (existingPayment == null)
        //    {
        //        return null;
        //    }

        //    existingPayment.Method = payment.Method;
        //    existingPayment.Amount = payment.Amount;
        //    existingPayment.OrderId = payment.OrderId;

        //    await _context.SaveChangesAsync();
        //    return existingPayment;
        //}
    }
}
