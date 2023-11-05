using Attendance.Application.DTOs;
using Attendance.Application.Interfaces;
using Attendance.Domain.Entities;
using Attendance.Domain.Interfaces;
using AutoMapper;

namespace Attendance.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            await _userRepository.RemoveAsync(id);
            return true;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users =  await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> CreateUserAsync(UserCreateDto UserCreateDto)
        {
            var user = _mapper.Map<User>(UserCreateDto);
            var userIncluded = await _userRepository.AddAsync(user);
            return _mapper.Map<UserDto>(userIncluded);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public UserDto UpdateUserAsync(Guid id, UserCreateDto UserCreateDto)
        {
            var user = _mapper.Map<User>(UserCreateDto);
            var userUpdated = _userRepository.Update(user);
            return _mapper.Map<UserDto>(userUpdated);
        }
        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return _mapper.Map<UserDto>(user);
        }
    }
}
