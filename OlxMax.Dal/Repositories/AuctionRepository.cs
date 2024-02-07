
using Microsoft.EntityFrameworkCore;

using OlxMax.Dal.DbContexts;
using OlxMax.Dal.Entities;

namespace OlxMax.Dal.Repositories
{
    public class AuctionRepository : GenericRepository<Auction>, IAuctionRepository
    {
        public AuctionRepository(DbContexOnStartUpCreation context) : base(context)
        {
        }

        public override async Task<IEnumerable<Auction>> GetAllAsync()
        {
            var result =  await base.GetAllAsync();

            foreach (var item in result)
            {
                item.Bets = await GetBetsByAuctionId(item.Id);
            }

            return result;
        }
        public override async Task<Auction>? GetByIdAsync(int id)
        {
            var result = await base.GetByIdAsync(id);
            result.Bets = await GetBetsByAuctionId(result.Id);
            return result;
        }

        private Task<List<Bet>> GetBetsByAuctionId(int id)
        {
            return _context.Bets.Include(b => b.User).Where(b => b.AuctionId == id).ToListAsync();
        } 

    }
}
