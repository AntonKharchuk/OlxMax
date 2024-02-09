
using Microsoft.EntityFrameworkCore;

using OlxMax.Dal.DbContexts;
using OlxMax.Dal.Entities;
using OlxMax.Dal.Security;

namespace OlxMax.Dal.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContexOnStartUpCreation context) : base(context)
        {
        }

        public override Task<User> AddAsync(User entity)
        {
            entity.Password = PasswordHasher.HashPassword(entity.Password!);
            return base.AddAsync(entity);
        }

        public async Task<bool> CanLogInAsync(string username, string password)
        {
            var user = await _table.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                return false;
            }

            var result = PasswordHasher.VerifyPassword(user.Password!, password);

            return result;
        }

        public async Task<User>? GetByUserNameAsync(string userName)
        {
            var result = await _table.FirstOrDefaultAsync(g => g.UserName == userName);
            return result!;
        }
    }


}
