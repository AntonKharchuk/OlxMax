
using OlxMax.Dal.Exeptions;
using OlxMax.Dal.Features.UserFeatures;

namespace OlxMax.Business.FeatureServices.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> GetAllUsersAsync();

        Task<GetUserDto> GetUserByIdAsync(int id);

        Task<GetUserDto> GetUserByUserNameAsync(string userName);

        Task<bool> CanLogInUserAsync(string userName, string password);

        Task<GetUserDto> AddNewUserAsync(CreateUserDto createUserDto);

        Task<GetUserDto> UpdateUserAsync(UpdateUserDto updateUserDto);

        Task<GetUserDto> DeleteUserAsync(int id);
    }
}
