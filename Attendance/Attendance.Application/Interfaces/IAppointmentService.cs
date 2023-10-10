using Attendance.Application.DTOs;

namespace Attendance.Application.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
    Task<AppointmentDto> GetAppointmentByIdAsync(Guid id);
    Task<AppointmentDto> CreateAppointmentAsync(AppointmentDto appointmentDto);
    Task<AppointmentDto> UpdateAppointmentAsync(Guid id, AppointmentDto appointmentDto);
    Task<bool> DeleteAppointmentAsync(Guid id);
}
