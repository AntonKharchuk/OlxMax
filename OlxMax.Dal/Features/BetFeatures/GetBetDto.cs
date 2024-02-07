
using OlxMax.Dal.Entities;

using System.ComponentModel.DataAnnotations;

namespace OlxMax.Dal.Features.BetFeatures
{
    public class GetBetDto
    {
        public int Id { get; set; }

        public double Emount { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int AuctionId { get; set; }
    }

    public class CreateBetDto
    {
        public double Emount { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int AuctionId { get; set; }
    }

    public class UpdateBetDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public double Emount { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int AuctionId { get; set; }
    }
}
