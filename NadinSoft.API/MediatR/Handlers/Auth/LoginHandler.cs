using MediatR;
using NadinSoft.API.MediatR.Commands;
using NadinSoft.Application.Contract.IApplication.AuthApplication;

namespace NadinSoft.API.MediatR.Handlers.Auth;

public class LoginHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IAuthApplication _authApplication;
    public LoginHandler(IAuthApplication authApplication)
    {
        _authApplication = authApplication;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var loginAsync = await _authApplication.LoginAsync(request.LoginDto);
        return loginAsync;
    }
}