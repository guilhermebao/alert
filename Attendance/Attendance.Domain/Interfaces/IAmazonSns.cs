namespace Attendance.Domain.Interfaces;

public interface IAmazonSns
{
    Task<bool> SendMessageSMS(string numeroTelefone, string mensagem);
}
