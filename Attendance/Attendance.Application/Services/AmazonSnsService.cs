using Attendance.Application.Interfaces;
using Attendance.Domain.Interfaces;

namespace Attendance.Application.Services;

public class AmazonSnsService : IAmazonSnsService
{
    private readonly IAmazonSns _amazonSns;

    public AmazonSnsService(IAmazonSns amazonSns)
    {
        _amazonSns = amazonSns ?? throw new ArgumentNullException(nameof(amazonSns));
    }

    public async Task<bool> SendMessageSMSAsync(string phoneNumber, string message)
    {
        try
        {
            var mensagemEnviadaComSucesso = await _amazonSns.SendMessageSMS(phoneNumber, message);

            return mensagemEnviadaComSucesso;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao enviar mensagem SMS: {ex.Message}");
            return false;
        }
    }
}
