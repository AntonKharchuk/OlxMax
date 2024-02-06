
using OlxMax.Dal.Entities;

using System.ComponentModel.DataAnnotations;

namespace OlxMax.Dal.Features.AuctionFeatures
{
    public class GetAuctionDto
    {
        public int Id { get; set; }
     
        public double MinEmount { get; set; }

        public string? Description { get; set; }

        public ICollection<Bet> Bets { get; } = new List<Bet>();
    }
    public class CreateAuctionDto
    {
        [Required]
        public double MinEmount { get; set; }

        [Required]
        public string? Description { get; set; }
    }
    public class UpdateAuctionDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public double MinEmount { get; set; }

        [Required]
        public string? Description { get; set; }

        public ICollection<Bet> Bets { get; } = new List<Bet>();
    }
}
