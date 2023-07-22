using MediatR;
using NadinSoft.Application.Contract.DTO.Product;

namespace NadinSoft.API.MediatR.Queries;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
}