using OlxMax.Dal.DbContexts;
using OlxMax.Dal.Entities;

namespace OlxMax.Dal.Repositories
{
    public class AuctionImageRepository : GenericRepository<AuctionImage>, IAuctionImageRepository
    {
        public AuctionImageRepository(DbContexOnStartUpCreation context) : base(context)
        {
        }
    }
}
