namespace Attendance.Application.DTOs;

public class SendMessageDto
{
    public Guid CustomerId { get; set; }
    public Guid AppointmentId { get; set; }
}
