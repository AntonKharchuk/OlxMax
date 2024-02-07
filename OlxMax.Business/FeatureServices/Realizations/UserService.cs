
using AutoMapper;

using OlxMax.Business.FeatureServices.Interfaces;
using OlxMax.Dal.Entities;
using OlxMax.Dal.Exeptions;
using OlxMax.Dal.Features.UserFeatures;
using OlxMax.Dal.Repositories;

namespace OlxMax.Business.FeatureServices.Realizations
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper
            )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetUserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GetUserDto>>(users);
        }

        public async Task<GetUserDto> GetUserByIdAsync(int id)
        {
            if (id<0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            var user = await _userRepository.GetByIdAsync(id)!
                          ?? throw new EntityNotFoundException($"No User with Id '{id}'");

            return _mapper.Map<GetUserDto>(user);
        }

        public async Task<GetUserDto> AddNewUserAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);

            var createdUser = await _userRepository.AddAsync(user);

            return _mapper.Map<GetUserDto>(createdUser);
        }

        public async Task<GetUserDto> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            if (await _userRepository.GetByIdAsync(updateUserDto.Id)! is null)
            {
                throw new EntityNotFoundException($"No User with Id '{updateUserDto.Id}'");
            }
            var userToUpdate = _mapper.Map<User>(updateUserDto);

            var updatedUser = await _userRepository.UpdateAsync(updateUserDto.Id, userToUpdate);

            return _mapper.Map<GetUserDto>(updatedUser);
        }

        public async Task<GetUserDto> DeleteUserAsync(int id)
        {
            var deletedUser = await _userRepository.DeleteAsync(id)!
                            ?? throw new EntityNotFoundException($"No User with Id '{id}'");

            return _mapper.Map<GetUserDto>(deletedUser);
        }
    }
}
