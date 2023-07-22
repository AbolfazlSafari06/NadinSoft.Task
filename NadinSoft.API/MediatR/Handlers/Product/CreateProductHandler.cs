using MediatR;
using NadinSoft.API.MediatR.Commands;
using NadinSoft.Application.Contract.DTO.Product;
using NadinSoft.Application.Contract.IApplication.ProductApplication;

namespace NadinSoft.API.MediatR.Handlers.Product;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductApplication _productApplication;

    public CreateProductHandler(IProductApplication productApplication)
    {
        _productApplication = productApplication;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productApplication.CreateAsync(request.UserId,request.CreateProductDto);
        return product;
    }
}