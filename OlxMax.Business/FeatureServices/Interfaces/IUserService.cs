
using OlxMax.Dal.Exeptions;
using OlxMax.Dal.Features.UserFeatures;

namespace OlxMax.Business.FeatureServices.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> GetAllUsersAsync();

        Task<GetUserDto> GetUserByIdAsync(int id);

        Task<GetUserDto> AddNewUserAsync(CreateUserDto createUserDto);

        Task<GetUserDto> UpdateUserAsync(UpdateUserDto updateUserDto);

        Task<GetUserDto> DeleteUserAsync(int id);
    }
}
