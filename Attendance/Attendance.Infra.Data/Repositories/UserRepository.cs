using Attendance.Domain.Entities;
using Attendance.Domain.Interfaces;
using Attendance.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Attendance.Infra.Data.Repositories;

public class UserRepository : BaseRepository<User, Guid>, IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
