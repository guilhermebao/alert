using System.ComponentModel.DataAnnotations;

namespace Attendance.Application.DTOs;

public class UserDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MaxLength(250, ErrorMessage = "O nome não pode ter mais de 250 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    [MaxLength(100, ErrorMessage = "A senha deve ter no máximo 100 caracteres")]
    [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
    public string Password { get; set; }

    [Required(ErrorMessage = "O email é obrigatório")]
    [MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
    public string Email  { get; set; }

}
