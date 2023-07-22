using MediatR;
using NadinSoft.Application.Contract.DTO.Product;

namespace NadinSoft.API.MediatR.Queries;

public class GetProductsQuery : IRequest<List<ProductDto>>
{
    public string? UserId { get; set; }
}