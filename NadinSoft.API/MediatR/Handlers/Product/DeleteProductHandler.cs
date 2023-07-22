using MediatR;
using NadinSoft.API.MediatR.Commands;
using NadinSoft.Application.Contract.IApplication.ProductApplication;

namespace NadinSoft.API.MediatR.Handlers.Product;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductApplication _productApplication;

    public DeleteProductHandler(IProductApplication productApplication)
    {
        _productApplication = productApplication;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _productApplication.RemoveAsync(request.UserId, request.id);
        return Unit.Value;
    }
}