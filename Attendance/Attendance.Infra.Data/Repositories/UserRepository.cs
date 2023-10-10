using Attendance.Domain.Entites;
using Attendance.Domain.Interfaces;
using Attendance.Infra.Data.Context;

namespace Attendance.Infra.Data.Repositories;

public class UserRepository : BaseRepository<User, Guid>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

}
