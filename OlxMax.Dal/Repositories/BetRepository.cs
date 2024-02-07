
using Microsoft.EntityFrameworkCore;

using OlxMax.Dal.DbContexts;
using OlxMax.Dal.Entities;

namespace OlxMax.Dal.Repositories
{
    public class BetRepository : GenericRepository<Bet>, IBetRepository
    {
        public BetRepository(DefaultAppDbContext context) : base(context)
        {
        }

        public override async Task<Bet> AddAsync(Bet entity)
        {
            var addedEntity = await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
            var auction = await _context.Auctions.FirstOrDefaultAsync(a => a.Id == entity.AuctionId);
            auction.Bets.Add(addedEntity.Entity);
            await _context.SaveChangesAsync();

            return addedEntity.Entity; 
        }
        //public override async Task<Bet> DeleteAsync(int id)
        //{
        //    var result = await base.GetByIdAsync(id);
        //    result.Bets = await GetBetsByAuctionId(result.Id);
        //    return result;
        //}
    }
}
