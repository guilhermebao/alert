using Attendance.Application.DTOs;
using Attendance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));
    }

    [HttpGet]

    public async Task<ActionResult<IEnumerable<AppointmentRequest>>> GetAppointments()
    {
        var appointments = await _appointmentService.GetAllAppointmentsAsync();
        return Ok(appointments);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<AppointmentDto>> GetAppointment(Guid id)
    {
        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

        if (appointment == null)
        {
            return NotFound();
        }

        return Ok(appointment);
    }

    [HttpPost]

    public async Task<ActionResult<AppointmentDto>> CreateAppointment(AppointmentCreateDto appointmentDto)
    {
        var createdAppointment = await _appointmentService.CreateAppointmentAsync(appointmentDto);
        return CreatedAtAction(nameof(GetAppointment), new { id = createdAppointment.Id }, createdAppointment);
    }

    [HttpPost("SendCustomerMessage")]

    public async Task<ActionResult<bool>> EnviarMensagemCliente([FromBody] SendMessageDto enviarMensagemClienteDto)
    {
        if (enviarMensagemClienteDto == null || enviarMensagemClienteDto.CustomerId == Guid.Empty
            || enviarMensagemClienteDto.AppointmentId == Guid.Empty)
        {
            return BadRequest("Parâmetros inválidos para enviar mensagem ao cliente.");
        }

        var mensagemEnviadaComSucesso = await _appointmentService.SendCustomerMessageAsync(
            enviarMensagemClienteDto.CustomerId, enviarMensagemClienteDto.AppointmentId);

        return Ok(mensagemEnviadaComSucesso);
    }
}
