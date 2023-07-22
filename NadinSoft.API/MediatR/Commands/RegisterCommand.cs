using MediatR;
using NadinSoft.Application.Contract.DTO.Auth;

namespace NadinSoft.API.MediatR.Commands;

public class RegisterCommand : IRequest<Unit> 
{
    public RegisterDto RegisterDto { get; set; }
}