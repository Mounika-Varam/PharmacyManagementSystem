using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.API.Models.Domain;

namespace PharmacyManagementSystem.API.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly PharmacyManagementDbContext _context;
        public SQLUserRepository(PharmacyManagementDbContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        //public async Task<User> DeleteUserAsync(Guid id)
        //{
        //    var user = await _context.Users.FirstOrDefaultAsync(d => d.UserId == id);
        //    if (user == null)
        //    {
        //        return null;
        //    }

        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();
        //    return user;
        //}

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();

        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<Guid?> GetUserByEmailAsync(string email)
        {
            return _context.Users
            .Where(u => u.Email.ToLower() == email.ToLower())
            .Select(u => u.UserId)
            .FirstOrDefault();
        }
        //public async Task<User> UpdateUserAsync(Guid id, User user)
        //{
        //    var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

        //    if (existingUser == null)
        //    {
        //        return null;
        //    }

        //    existingUser.FullName = user.FullName;
        //    existingUser.Email = user.Email;
        //    existingUser.PhoneNumber = user.PhoneNumber;
        //    existingUser.Gender = user.Gender;
        //    existingUser.Role = user.Role;

        //    await _context.SaveChangesAsync();
        //    return existingUser;
        //}
    }
}
