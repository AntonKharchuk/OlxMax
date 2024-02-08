


using System.ComponentModel.DataAnnotations;

namespace OlxMax.Dal.Features.AuctionImages
{
    public class GetAuctionImageDto
    {
        public int Id { get; set; }

        public int AuctionId { get; set; }

        [Required]
        public required string Image { get; set; }
    }
    
    public class CreateAuctionImageDto
    {
        public int AuctionId { get; set; }

        [Required]
        public required string Image { get; set; }
    }

}
