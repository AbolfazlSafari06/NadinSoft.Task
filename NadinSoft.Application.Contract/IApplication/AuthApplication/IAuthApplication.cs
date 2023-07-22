using NadinSoft.Application.Contract.DTO.Auth;

namespace NadinSoft.Application.Contract.IApplication.AuthApplication;

public interface IAuthApplication
{ 
    Task RegisterAsync(RegisterDto registerDto);
    Task<string> LoginAsync(LoginDto loginDto); 
}