using MediatR;
using NadinSoft.Application.Contract.DTO.Product;

namespace NadinSoft.API.MediatR.Commands;

public class CreateProductCommand : IRequest<ProductDto>
{
    public CreateProductDto CreateProductDto { get; set; }
    public string UserId { get; set; }
}