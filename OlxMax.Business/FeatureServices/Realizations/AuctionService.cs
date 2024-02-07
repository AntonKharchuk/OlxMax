
using AutoMapper;

using OlxMax.Business.FeatureServices.Interfaces;
using OlxMax.Dal.Entities;
using OlxMax.Dal.Exeptions;
using OlxMax.Dal.Features.AuctionFeatures;
using OlxMax.Dal.Features.UserFeatures;
using OlxMax.Dal.Repositories;

namespace OlxMax.Business.FeatureServices.Realizations
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IBetRepository _betRepository;
        private readonly IMapper _mapper;

        public AuctionService(
            IAuctionRepository auctionRepository,
            IBetRepository betRepository,
            IMapper mapper
            )
        {
            _auctionRepository = auctionRepository;
            _betRepository = betRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAuctionDto>> GetAllAuctionsAsync()
        {
            var auctions = await _auctionRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GetAuctionDto>>(auctions);
        }

        public async Task<GetAuctionDto> GetAuctionByIdAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            var auction = await _auctionRepository.GetByIdAsync(id)!
                          ?? throw new EntityNotFoundException($"No Auction with Id '{id}'");

            return _mapper.Map<GetAuctionDto>(auction);
        }

        public async Task<GetAuctionDto> AddNewAuctionAsync(CreateAuctionDto createDto)
        {
            var auction = _mapper.Map<Auction>(createDto);
            var createdAuciton = await _auctionRepository.AddAsync(auction);
            return _mapper.Map<GetAuctionDto>(createdAuciton);
        }

        public async Task<GetAuctionDto> UpdateAuctionAsync(UpdateAuctionDto udateDto)
        {
            if (await _auctionRepository.GetByIdAsync(udateDto.Id)! is null)
            {
                throw new EntityNotFoundException($"No Auction with Id '{udateDto.Id}'");
            }

            var auctioonToUpdate = _mapper.Map<Auction>(udateDto);

            var updatedAuction = await _auctionRepository.UpdateAsync(auctioonToUpdate.Id, auctioonToUpdate);

            return _mapper.Map<GetAuctionDto>(updatedAuction);
        }
       

        public async Task<GetAuctionDto> DeleteAuctionAsync(int id)
        {
            var deletedAuction = await _auctionRepository.DeleteAsync(id)!
                            ?? throw new EntityNotFoundException($"No Auction with Id '{id}'");

            return _mapper.Map<GetAuctionDto>(deletedAuction);
        }


        
    }
}
