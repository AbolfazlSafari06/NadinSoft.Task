using Microsoft.Extensions.DependencyInjection;
using NadinSoft.Application.Contract.IApplication.ProductApplication;
using NadinSoft.Domain.IRepositories.ProductRepository;
using NadinSoft.Infrastructure.Repositories;

namespace NadinSoft.Application.Inject;

public static class ProductInjector
{
    public static void InjectProductServices(this IServiceCollection services)
    {
        services.AddTransient<IProductApplication, ProductApplication>();
        services.AddTransient<IProductRepository, ProductRepository>();
    }
}