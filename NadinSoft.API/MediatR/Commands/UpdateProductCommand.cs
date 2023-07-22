using MediatR;
using NadinSoft.Application.Contract.DTO.Product;

namespace NadinSoft.API.MediatR.Commands;

public class UpdateProductCommand : IRequest<ProductDto>
{
    public UpdateProductDto UpdateProductDto { get; set; }
    public string UserId{ get; set; }
}