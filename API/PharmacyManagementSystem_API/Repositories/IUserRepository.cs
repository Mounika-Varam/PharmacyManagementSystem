using PharmacyManagementSystem.API.Models.Domain;

namespace PharmacyManagementSystem.API.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<Guid?> GetUserByEmailAsync(string email);

        Task<User> CreateUserAsync(User user);
        //Task<User> UpdateUserAsync(Guid id, User user);
        //Task<User> DeleteUserAsync(Guid id);
    }
}
