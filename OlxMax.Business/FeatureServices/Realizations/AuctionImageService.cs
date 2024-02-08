
using AutoMapper;

using OlxMax.Business.FeatureServices.Interfaces;
using OlxMax.Dal.Entities;
using OlxMax.Dal.Exeptions;
using OlxMax.Dal.Features.AuctionImages;
using OlxMax.Dal.Features.BetFeatures;
using OlxMax.Dal.Repositories;

namespace OlxMax.Business.FeatureServices.Realizations
{
    public class AuctionImageService : IAuctionImageService
    {
        private readonly IAuctionImageRepository _auctionImageRepository;
        private readonly IAuctionRepository _auctionRepository;
        private readonly IMapper _mapper;

        public AuctionImageService(
            IAuctionImageRepository auctionImageRepository,
            IAuctionRepository auctionRepository,
            IMapper mapper
            )
        {
            _auctionImageRepository = auctionImageRepository;
            _auctionRepository = auctionRepository;
            _mapper = mapper;
        }

        public async Task<GetAuctionImageDto> AddNewAuctionImageAsync(CreateAuctionImageDto createDto)
        {
            var auctionImage = _mapper.Map<AuctionImage>(createDto); //"aGVsbG8="  "hello" in base64

            var auction = await _auctionRepository.GetByIdAsync(auctionImage.AuctionId);

            if (auction is null)
                throw new EntityNotFoundException($"No Auction with Id '{auctionImage.AuctionId}'");

            var createdAuctionImage = await _auctionImageRepository.AddAsync(auctionImage);

            return _mapper.Map<GetAuctionImageDto>(createdAuctionImage)!;
        }

        public async Task<GetAuctionImageDto> DeleteAuctionImageAsync(int id)
        {
            var deletedAuction = await _auctionImageRepository.DeleteAsync(id)!
                            ?? throw new EntityNotFoundException($"No AuctionImage with Id '{id}'");

            return _mapper.Map<GetAuctionImageDto>(deletedAuction)!;
        }

        public async Task<GetAuctionImageDto> GetAuctionImageByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
