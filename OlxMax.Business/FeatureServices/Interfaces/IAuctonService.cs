
using OlxMax.Dal.Features.AuctionFeatures;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlxMax.Business.FeatureServices.Interfaces
{
    public interface IAuctonService
    {
        Task<IEnumerable<GetAuctionDto>> GetAuctonCardAsync(int patientId);

        Task<IEnumerable<GetAuctionDto>> GetAllAuctonsAsync();

        Task<GetAuctionDto> GetAuctonByIdAsync(int id);

        Task<GetAuctionDto> AddNewAuctonAsync(CreateAuctionDto createRecordDto);

        Task<GetAuctionDto> UpdateAuctonAsync(UpdateAuctionDto updateRecordDto);

        Task<GetAuctionDto> DeleteAuctonAsync(int id);
    }
}
