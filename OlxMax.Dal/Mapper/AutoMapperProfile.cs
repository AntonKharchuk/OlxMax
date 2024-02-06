
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using AutoMapper;
using OlxMax.Dal.Features.UserFeatures;
using OlxMax.Dal.Entities;
using OlxMax.Dal.Features.AuctionFeatures;
using OlxMax.Dal.Features.BetFeatures;

namespace OlxMax.Dal.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetUserDto, User>().ReverseMap();
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<UpdateUserDto, User>().ReverseMap();

            CreateMap<GetAuctionDto, Auction>().ReverseMap();
            CreateMap<CreateAuctionDto, Auction>().ReverseMap();
            CreateMap<UpdateAuctionDto, Auction>().ReverseMap();

            CreateMap<GetBetDto, Bet>().ReverseMap();
            CreateMap<CreateBetDto, Bet>().ReverseMap();
            CreateMap<UpdateBetDto, Bet>().ReverseMap();
        }
    }
}
