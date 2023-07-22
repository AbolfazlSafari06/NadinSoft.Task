using MediatR;
using NadinSoft.API.MediatR.Commands;
using NadinSoft.Application.Contract.IApplication.AuthApplication;

namespace NadinSoft.API.MediatR.Handlers.Auth;

public class RegisterHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly IAuthApplication _authApplication;
    public RegisterHandler(IAuthApplication authApplication)
    {
        _authApplication = authApplication;
    }

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _authApplication.RegisterAsync(request.RegisterDto);
        return Unit.Value;
    }
}