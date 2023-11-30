namespace Attendance.Application.Interfaces;

public interface IAmazonSnsService
{
    Task<bool> SendMessageSMSAsync(string numeroTelefone, string mensagem);
}
