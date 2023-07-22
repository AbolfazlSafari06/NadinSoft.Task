using MediatR;
using NadinSoft.API.MediatR.Commands;
using NadinSoft.Application.Contract.DTO.Product;
using NadinSoft.Application.Contract.IApplication.ProductApplication;

namespace NadinSoft.API.MediatR.Handlers.Product;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto>
{
    private readonly IProductApplication _productApplication;

    public UpdateProductHandler(IProductApplication productApplication)
    {
        _productApplication = productApplication;
    }

    public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productApplication.UpdateAsync(request.UserId,request.UpdateProductDto);
        return product;
    }
}