
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

        //public async Task<GetBetDto> UpdateBetAsync(UpdateBetDto updateDto)
        //{
        //    var currentBet = await _betRepository.GetByIdAsync(updateDto.Id);
        //    if (currentBet! is null)
        //    {
        //        throw new EntityNotFoundException($"No Bet with Id '{updateDto.Id}'");
        //    }

        //    var bet = _mapper.Map<Bet>(updateDto);

        //    var auction = await _auctionRepository.GetByIdAsync(bet.AuctionId);

        //    var user = await _userRepository.GetByIdAsync(bet.UserId);

        //    await ValidateFields(bet, auction, user);


        //    if (bet.Emount- currentBet.Emount > user.Balace)
        //        throw new ArgumentOutOfRangeException("'user.Balace' must be greater than 'bet.Emount - currentBet.Emount'");

        //    var updatedBet = await _betRepository.UpdateAsync(bet.Id, bet);

        //    user.Balace -= (bet.Emount - currentBet.Emount);

        //    await _userRepository.UpdateAsync(user.Id, user);

        //    return  _mapper.Map<GetBetDto>(updatedBet);
        //}
        public async Task<GetBetDto> AddNewBetAsync(CreateBetDto createDto)
        {
            var bet = _mapper.Map<Bet>(createDto);

            var auction = await _auctionRepository.GetByIdAsync(bet.AuctionId);

            var user = await _userRepository.GetByIdAsync(bet.UserId);

            bool HasUserBetsOnAuction()
            {
                foreach (var userBet in auction.Bets)
                {
                    if (userBet.UserId == user.Id)
                        return true;
                }
                return false;
            }

            await ValidateFields(bet, auction, user);

            if (bet.Emount > user.Balace)
                throw new ArgumentOutOfRangeException("'user.Balace' must be greater than 'bet.Emount'");

            if (!HasUserBetsOnAuction()&&auction.MinEmount > bet.Emount)
                throw new ArgumentOutOfRangeException("'bet.Emount' must be greater than 'auction.MinEmount'");

            var createdBet = await _betRepository.AddAsync(bet);

            user.Balace -= bet.Emount;

            await _userRepository.UpdateAsync(user.Id, user);

            return _mapper.Map<GetBetDto>(createdBet);
        }
        private async Task ValidateFields(Bet bet, Auction auction, User user)
        {
            if (bet.Emount < 1)
                throw new ArgumentOutOfRangeException("'bet.Emount' must be greater than zero");

            if (user! is null)
                throw new EntityNotFoundException($"No User with Id '{bet.UserId}'");
            if (auction! is null)
                throw new EntityNotFoundException($"No Auction with Id '{bet.AuctionId}'");
        }
        public async Task<GetBetDto> DeleteBetAsync(int id)
        {
            var deletedBet = await _betRepository.DeleteAsync(id)!
                            ?? throw new EntityNotFoundException($"No Bet with Id '{id}'");

            return _mapper.Map<GetBetDto>(deletedBet);
        }
    }
}
