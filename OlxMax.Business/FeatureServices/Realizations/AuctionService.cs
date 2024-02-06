
using OlxMax.Business.FeatureServices.Interfaces;
using OlxMax.Dal.Features.AuctionFeatures;

namespace OlxMax.Business.FeatureServices.Realizations
{
    public class AuctionService : IAuctonService
    {
        public Task<GetAuctionDto> AddNewAuctonAsync(CreateAuctionDto createRecordDto)
        {
            throw new NotImplementedException();
        }

        public Task<GetAuctionDto> DeleteAuctonAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAuctionDto>> GetAllAuctonsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetAuctionDto> GetAuctonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAuctionDto>> GetAuctonCardAsync(int patientId)
        {
            throw new NotImplementedException();
        }

        public Task<GetAuctionDto> UpdateAuctonAsync(UpdateAuctionDto updateRecordDto)
        {
            throw new NotImplementedException();
        }
    }
}
