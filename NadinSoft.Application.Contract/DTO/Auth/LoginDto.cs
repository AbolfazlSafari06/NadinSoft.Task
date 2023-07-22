using System.ComponentModel.DataAnnotations; 

namespace NadinSoft.Application.Contract.DTO.Auth;

public class LoginDto
{
    [Required(ErrorMessage = nameof(UserName))]
    public string UserName { get; set; }

    [Required(ErrorMessage = nameof(Password))]
    public string Password { get; set; }
}