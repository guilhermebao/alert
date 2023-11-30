using Attendance.Application.DTOs;

namespace Attendance.Application.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
    Task<AppointmentDto> GetAppointmentByIdAsync(Guid id);
    Task<AppointmentDto> CreateAppointmentAsync(AppointmentCreateDto appointmentDto);
    Task<AppointmentDto> UpdateAppointmentAsync(Guid id, AppointmentDto appointmentDto);
    Task<bool> DeleteAppointmentAsync(Guid id);
    Task<bool> SendCustomerMessageAsync(Guid customerId, Guid agendamentoId);
}
