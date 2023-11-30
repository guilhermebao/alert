using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Attendance.Domain.Interfaces;

namespace Attendance.Infra.Integration;

public class AmazonSns : IAmazonSns
{
    private readonly string _accessKey;
    private readonly string _secretKey;
    private readonly RegionEndpoint _region;

    private readonly IAmazonSimpleNotificationService _snsClient;

    public AmazonSns()
    {
        _accessKey = "AKIAQFZR4ZA5EZREZHGV";
        _secretKey = "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";
        _region = RegionEndpoint.USEast1;

        _snsClient = new AmazonSimpleNotificationServiceClient(_accessKey, _secretKey, _region);
    }

    public async Task<bool> SendMessageSMS(string phoneNumber, string message)
    {
        try
        {
            var request = new PublishRequest
            {
                Message = message,
                PhoneNumber = phoneNumber
            };

            var response = await _snsClient.PublishAsync(request);

            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao enviar mensagem SMS: {ex.Message}");
            return false;
        }
    }
}
