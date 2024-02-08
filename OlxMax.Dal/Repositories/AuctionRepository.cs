
using Microsoft.EntityFrameworkCore;

using OlxMax.Dal.DbContexts;
using OlxMax.Dal.Entities;
using OlxMax.Dal.Exeptions;

namespace OlxMax.Dal.Repositories
{
    public class AuctionRepository : GenericRepository<Auction>, IAuctionRepository
    {
        public AuctionRepository(DbContexOnStartUpCreation context) : base(context)
        {
        }

        public override async Task<IEnumerable<Auction>> GetAllAsync()
        {
            return await _table.Include(a => a.Bets).Include(a => a.Images).ToListAsync();

        }
        public override async Task<Auction>? GetByIdAsync(int id)
        {
            var result = await _table.Include(a => a.Bets).Include(a => a.Images).FirstOrDefaultAsync(g => g.Id == id);
            return result;
        }

        private Task<List<Bet>> GetBetsByAuctionId(int id)
        {
            return _context.Bets.Include(b => b.User).Where(b => b.AuctionId == id).ToListAsync();
        } 

    }
}
