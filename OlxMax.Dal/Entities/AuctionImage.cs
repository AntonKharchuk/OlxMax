
using OlxMax.Dal.Entity;

using System.ComponentModel.DataAnnotations;

namespace OlxMax.Dal.Entities
{
    public class AuctionImage:BaseEntity
    {
        [Required]
        public string? Image { get; set; } 

        public int AuctionId { get; set; }

        public Auction? Auction { get; set; }
    }
}
