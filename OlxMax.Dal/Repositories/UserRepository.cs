
using OlxMax.Dal.DbContexts;
using OlxMax.Dal.Entities;

namespace OlxMax.Dal.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DefaultAppDbContext context) : base(context)
        {
        }
    }


}
