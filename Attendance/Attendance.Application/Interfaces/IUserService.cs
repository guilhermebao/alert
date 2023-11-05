using Attendance.Application.DTOs;

namespace Attendance.Application.Interfaces;

public interface IUserService
{
    Task<bool> DeleteUserAsync(Guid id);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> CreateUserAsync(UserCreateDto customerDto);
    Task<UserDto> GetUserByEmailAsync(string email);
    Task<UserDto> GetUserByIdAsync(Guid id);
    UserDto UpdateUserAsync(Guid id, UserCreateDto customerDto);

}
