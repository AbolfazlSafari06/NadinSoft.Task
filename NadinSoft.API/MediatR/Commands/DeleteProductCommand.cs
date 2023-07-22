using MediatR;

namespace NadinSoft.API.MediatR.Commands;

public class DeleteProductCommand : IRequest<Unit>
{
    public Guid id { get; set; }
    public string UserId { get; set; }
}