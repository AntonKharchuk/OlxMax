
using OlxMax.Dal.Features.AuctionFeatures;
using OlxMax.Dal.Features.UserFeatures;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlxMax.Business.FeatureServices.Interfaces
{
    public interface IAuctionService
    {
        Task<IEnumerable<GetAuctionDto>> GetAllAuctionsAsync();

        Task<GetAuctionDto> GetAuctionByIdAsync(int id);

        Task<GetAuctionDto> AddNewAuctionAsync(CreateAuctionDto createDto);

        Task<GetAuctionDto> UpdateAuctionAsync(UpdateAuctionDto updateDto);

        Task<GetAuctionDto> DeleteAuctionAsync(int id);
    }
}
