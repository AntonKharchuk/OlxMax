
using OlxMax.Dal.DbContexts;
using OlxMax.Dal.Entities;

namespace OlxMax.Dal.Repositories
{
    public class BetRepository : GenericRepository<Bet>, IBetRepository
    {
        protected BetRepository(DefaultAppDbContext context) : base(context)
        {
        }
    }
}
