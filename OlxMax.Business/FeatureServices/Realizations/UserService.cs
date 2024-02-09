
using AutoMapper;

using OlxMax.Business.FeatureServices.Interfaces;
using OlxMax.Dal.Entities;
using OlxMax.Dal.Exeptions;
using OlxMax.Dal.Features.UserFeatures;
using OlxMax.Dal.Repositories;

using System.ComponentModel.DataAnnotations;

namespace OlxMax.Business.FeatureServices.Realizations
{
    public class UserService : IUserService
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
        public async Task<GetUserDto> GetUserByUserNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentOutOfRangeException(nameof(userName));
            }

            var user = await _userRepository.GetByUserNameAsync(userName)!
                          ?? throw new EntityNotFoundException($"No User with UserName '{userName}'");

            return _mapper.Map<GetUserDto>(user);
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
            await ValidateUserName(createUserDto.UserName);

            var user = _mapper.Map<User>(createUserDto);


            var createdUser = await _userRepository.AddAsync(user);

            return _mapper.Map<GetUserDto>(createdUser);
        }

        private async Task ValidateUserName(string userName)
        {
            var allUsers = await  _userRepository.GetAllAsync();
            foreach (var user in allUsers)
            {
                if (user.UserName == userName)
                {
                    throw new ValidationException($"User with userName '{userName}' allready exists");
                }
            }
        }

        public async Task<GetUserDto> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            await ValidateUserName(updateUserDto.UserName);

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

        public async Task<bool> CanLogInUserAsync(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentOutOfRangeException(nameof(userName));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentOutOfRangeException(nameof(password));
            }

            var result = await _userRepository.CanLogInAsync(userName,password);

            return result;  
        }
    }
}
