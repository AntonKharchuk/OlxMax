
using Microsoft.EntityFrameworkCore;

using OlxMax.Dal.DbContexts;
using OlxMax.Dal.Entities;

namespace OlxMax.Dal.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContexOnStartUpCreation context) : base(context)
        {
        }

        public async Task<bool> CanLogInAsync(string username, string password)
        {
            var user = await _table.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);

            return user != null;
        }

        public async Task<User>? GetByUserNameAsync(string userName)
        {
            var result = await _table.FirstOrDefaultAsync(g => g.UserName == userName);
            return result!;
        }
    }


}
