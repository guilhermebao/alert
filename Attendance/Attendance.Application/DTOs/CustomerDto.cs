using System.ComponentModel.DataAnnotations;

namespace Attendance.Application.DTOs;

public class CustomerDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(200, ErrorMessage = "O campo Nome deve ter no máximo 200 caracteres.")]
    public string Name { get; set; }

    [StringLength(20, ErrorMessage = "O campo Número de Telefone deve ter no máximo 20 caracteres.")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo Endereço deve ter no máximo 100 caracteres.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
    [StringLength(50, ErrorMessage = "O campo Cidade deve ter no máximo 50 caracteres.")]
    public string City { get; set; }

    [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
    [StringLength(50, ErrorMessage = "O campo Bairro deve ter no máximo 50 caracteres.")]
    public string Neighborhood { get; set; }

    [Required(ErrorMessage = "O campo Número é obrigatório.")]
    [StringLength(10, ErrorMessage = "O campo Número deve ter no máximo 10 caracteres.")]
    public string Number { get; set; }
}
