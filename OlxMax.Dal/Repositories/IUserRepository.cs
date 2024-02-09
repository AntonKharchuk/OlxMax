
using OlxMax.Dal.Entities;

namespace OlxMax.Dal.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User>? GetByUserNameAsync(string userName);
        Task<bool> CanLogInAsync(string username, string password);
    }
}
