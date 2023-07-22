using MediatR;
using NadinSoft.API.MediatR.Queries;
using NadinSoft.Application.Contract.DTO.Product;
using NadinSoft.Application.Contract.IApplication.ProductApplication;

namespace NadinSoft.API.MediatR.Handlers.Product;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IProductApplication _productApplication;

    public GetProductByIdHandler(IProductApplication productApplication)
    {
        _productApplication = productApplication;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productApplication.GetByIdAsync(request.UserId,request.Id);
    }
}