namespace Attendance.Domain.Account;

public interface IAuthenticateAsync
{
    Task<bool> AuthenticateAsync(string email, string senha);
    Task<bool> UserExists(string email);
    public string GenerateToken(Guid id, string email);
}
