using Attendance.Application.DTOs;
using Attendance.Application.Interfaces;
using Attendance.Domain.Entities;
using Attendance.Domain.Interfaces;
using AutoMapper;

namespace Attendance.Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly ICustomerService _customerService;
    private readonly IAmazonSnsService _amazonSnsService;
    private readonly IMapper _mapper;

    public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, ICustomerService customerService, IAmazonSnsService amazonSnsService)
    {
        _appointmentRepository = appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _customerService = customerService;
        _amazonSnsService = amazonSnsService;
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

    public async Task<bool> SendCustomerMessageAsync(Guid clienteId, Guid agendamentoId)
    {
        try
        {
            var custumerDto = await _customerService.GetCustomerByIdAsync(clienteId);

            if (custumerDto == null || string.IsNullOrWhiteSpace(custumerDto.PhoneNumber))
            {
                Console.WriteLine("Não foi possível carregar as informações do cliente ou o número de telefone está vazio.");
                return false;
            }

            var appointmentDto = await GetAppointmentByIdAsync(agendamentoId);

            if (appointmentDto == null || string.IsNullOrWhiteSpace(appointmentDto.Message))
            {
                Console.WriteLine("Não foi possível carregar as informações do agendamento ou a mensagem está vazia.");
                return false;
            }

            var mensagemEnviadaComSucesso = await _amazonSnsService.SendMessageSMSAsync(custumerDto.PhoneNumber, appointmentDto.Message);

            return mensagemEnviadaComSucesso;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao enviar mensagem para o cliente: {ex.Message}");
            return false;
        }
    }
}
