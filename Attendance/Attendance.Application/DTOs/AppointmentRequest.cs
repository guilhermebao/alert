using System.ComponentModel.DataAnnotations;
namespace Attendance.Application.DTOs;
public class AppointmentRequest
{
    public Guid Id { get; set; }

    public DateTime DateTime { get; set; }

    public string Message { get; set; }

    public Guid CustomerId { get; set; }
}
