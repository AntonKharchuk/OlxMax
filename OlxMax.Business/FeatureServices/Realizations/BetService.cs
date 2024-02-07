
using OlxMax.Business.FeatureServices.Interfaces;
using OlxMax.Dal.Features.BetFeatures;

using AutoMapper;
using OlxMax.Dal.Repositories;
using OlxMax.Dal.Exeptions;
using OlxMax.Dal.Entities;
using OlxMax.Dal.Features.UserFeatures;
using Microsoft.Extensions.Options;

namespace OlxMax.Business.FeatureServices.Realizations
{
    public class BetService : IBetService
    {
        private readonly IBetRepository _betRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAuctionRepository _auctionRepository;
        private readonly IMapper _mapper;

        public BetService(
            IBetRepository betRepository,
            IUserRepository userRepository,
            IAuctionRepository auctionRepository,
            IMapper mapper
            )
        {
            _betRepository = betRepository;
            _userRepository = userRepository;
            _auctionRepository = auctionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetBetDto>> GetAllBetsAsync()
        {
            var bets = await _betRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GetBetDto>>(bets);
        }

        public async Task<GetBetDto> GetBetByIdAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            var bet = await _betRepository.GetByIdAsync(id)!
                          ?? throw new EntityNotFoundException($"No Bet with Id '{id}'");

            return _mapper.Map<GetBetDto>(bet);
        }

        public async Task<GetBetDto> UpdateBetAsync(UpdateBetDto updateDto)
        {
            if (await _betRepository.GetByIdAsync(updateDto.Id)! is null)
            {
                throw new EntityNotFoundException($"No Bet with Id '{updateDto.Id}'");
            }

            await ValidateForeignKey(updateDto.UserId, updateDto.AuctionId);

            var bet = _mapper.Map<Bet>(updateDto);

            var updatedBet = await _betRepository.UpdateAsync(bet.Id, bet);

            return  _mapper.Map<GetBetDto>(updatedBet);
        }
        public async Task<GetBetDto> AddNewBetAsync(CreateBetDto createDto)
        {
            await ValidateForeignKey(createDto.UserId, createDto.AuctionId);

            var bet = _mapper.Map<Bet>(createDto);

            var createdBet = await _betRepository.AddAsync(bet);

            return _mapper.Map<GetBetDto>(createdBet);
        }

        public async Task<GetBetDto> DeleteBetAsync(int id)
        {
            var deletedBet = await _betRepository.DeleteAsync(id)!
                            ?? throw new EntityNotFoundException($"No Bet with Id '{id}'");

            return _mapper.Map<GetBetDto>(deletedBet);
        }

        private async Task ValidateForeignKey(int userId , int auctionId)
        {
            if (await _userRepository.GetByIdAsync(userId)! is null)
            {
                throw new EntityNotFoundException($"No User with Id '{userId}'");
            }

            if (await _auctionRepository.GetByIdAsync(auctionId)! is null)
            {
                throw new EntityNotFoundException($"No Auction with Id '{auctionId}'");
            }
        }

    }
}
