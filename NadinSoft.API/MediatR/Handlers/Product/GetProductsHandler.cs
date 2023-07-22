using MediatR;
using NadinSoft.API.MediatR.Queries;
using NadinSoft.Application.Contract.DTO.Product;
using NadinSoft.Application.Contract.IApplication.ProductApplication;

namespace NadinSoft.API.MediatR.Handlers.Product;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IProductApplication _productApplication;

    public GetProductsHandler(IProductApplication productApplication)
    {
        _productApplication = productApplication;
    }

    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productApplication.GetListAsync(request.UserId);
    }
}