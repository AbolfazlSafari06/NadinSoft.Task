using Microsoft.Extensions.DependencyInjection;
using NadinSoft.Application.Contract.IApplication.AuthApplication;

namespace NadinSoft.Application.Inject;

public static class AuthInjector
{
    public static void InjectAuthServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthApplication, AuthApplication>();
    }
}