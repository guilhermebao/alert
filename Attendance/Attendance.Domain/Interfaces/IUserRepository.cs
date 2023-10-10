using Attendance.Domain.Entites;

namespace Attendance.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User, Guid>
{
}
