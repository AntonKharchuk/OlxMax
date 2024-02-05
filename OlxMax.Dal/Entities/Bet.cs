
using OlxMax.Dal.Entity;

using System.ComponentModel;
using System.Globalization;

namespace OlxMax.Dal.Entities
{
    public class Bet:BaseEntity
    {
        public double Emount { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public int AuctionId { get; set; }
        public Auction? Auction { get; set; }
    }
}
