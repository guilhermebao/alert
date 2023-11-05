using Attendance.Domain.Entities;

namespace Attendance.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User, Guid>
{
    Task<User> GetUserByEmailAsync(string email);
}
