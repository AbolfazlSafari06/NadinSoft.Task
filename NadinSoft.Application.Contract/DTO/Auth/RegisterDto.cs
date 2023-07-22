using System.ComponentModel.DataAnnotations;

namespace NadinSoft.Application.Contract.DTO.Auth;

public class RegisterDto
{
    [Required(ErrorMessage = "FirstName is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "LastName is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "UserName is required")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Email is required"), DataType(DataType.EmailAddress,ErrorMessage = "Email is Invalid")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } 
}