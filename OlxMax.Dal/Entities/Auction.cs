
using OlxMax.Dal.Entity;

namespace OlxMax.Dal.Entities
{
    public class Auction : BaseEntity
    {
        public double MinEmount { get; set; }

        public string? Description{ get; set; }

        public IList<Bet> Bets { get; set; } = new List<Bet>();
    }
}
