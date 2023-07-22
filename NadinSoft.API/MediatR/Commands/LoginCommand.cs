using MediatR;
using NadinSoft.Application.Contract.DTO.Auth; 

namespace NadinSoft.API.MediatR.Commands;

public class LoginCommand : IRequest<string>
{
    public LoginDto LoginDto { get; set; }
}