using System.ComponentModel.DataAnnotations;
namespace Attendance.Application.DTOs;
public class AppointmentCreateDto
{
    [Required(ErrorMessage = "O campo Data e Hora é obrigatório.")]
    public DateTime DateTime { get; set; }

    [StringLength(255, ErrorMessage = "O campo Mensagem deve ter no máximo 255 caracteres.")]
    public string Message { get; set; }

    [Required(ErrorMessage = "O campo CustomerId é obrigatório.")]
    public Guid CustomerId { get; set; }
}
