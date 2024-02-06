
using OlxMax.Dal.DbContexts;
using OlxMax.Dal.Entities;

namespace OlxMax.Dal.Repositories
{
    public class AuctionRepository : GenericRepository<Auction>, IAuctionRepository
    {
        public AuctionRepository(DefaultAppDbContext context) : base(context)
        {
        }
    }
}
