using OlxMax.Dal.Features.BetFeatures;

namespace OlxMax.Business.FeatureServices.Interfaces
{
    public interface IBetService
    {
        Task<IEnumerable<GetBetDto>> GetAllBetsAsync();

        Task<GetBetDto> GetBetByIdAsync(int id);

        Task<GetBetDto> AddNewBetAsync(CreateBetDto createDto);

        Task<GetBetDto> DeleteBetAsync(int id);
    }
}
