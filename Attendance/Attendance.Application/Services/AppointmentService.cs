using Attendance.Application.DTOs;
using Attendance.Application.Interfaces;
using Attendance.Domain.Entities;
using Attendance.Domain.Interfaces;
using AutoMapper;

namespace Attendance.Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
    {
        var appointments = await _appointmentRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
    }

    public async Task<AppointmentDto> GetAppointmentByIdAsync(Guid id)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(id);
        return _mapper.Map<AppointmentDto>(appointment);
    }

    public async Task<AppointmentDto> CreateAppointmentAsync(AppointmentCreateDto appointmentDto)
    {
        var appointment = _mapper.Map<Appointment>(appointmentDto);
        appointment.Id = Guid.NewGuid();
        var createdAppointment = await _appointmentRepository.AddAsync(appointment);
        return _mapper.Map<AppointmentDto>(createdAppointment);
    }

    public async Task<AppointmentDto> UpdateAppointmentAsync(Guid id, AppointmentDto appointmentDto)
    {
        var existingAppointment = await _appointmentRepository.GetByIdAsync(id);
        if (existingAppointment == null)
        {
            return null;
        }

        _mapper.Map(appointmentDto, existingAppointment);
        var updatedAppointment = _appointmentRepository.Update(existingAppointment);
        return _mapper.Map<AppointmentDto>(updatedAppointment);
    }

    public async Task<bool> DeleteAppointmentAsync(Guid id)
    {
        var existingAppointment = await _appointmentRepository.GetByIdAsync(id);
        if (existingAppointment == null)
        {
            return false;
        }

        await _appointmentRepository.RemoveAsync(id);
        return true;
    }
}
