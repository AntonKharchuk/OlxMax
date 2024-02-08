using OlxMax.Dal.Features.AuctionImages;

namespace OlxMax.Business.FeatureServices.Interfaces
{
    public interface IAuctionImageService
    {
        Task<GetAuctionImageDto> GetAuctionImageByIdAsync(int id);

        Task<GetAuctionImageDto> AddNewAuctionImageAsync(CreateAuctionImageDto createDto);

        Task<GetAuctionImageDto> DeleteAuctionImageAsync(int auctionId, int imageId);
    }
}
