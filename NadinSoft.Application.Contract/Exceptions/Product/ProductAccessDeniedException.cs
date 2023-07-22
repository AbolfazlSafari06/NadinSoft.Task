namespace NadinSoft.Application.Contract.Exceptions.Product;

public class ProductAccessDeniedException : NadinSoftException
{
    public ProductAccessDeniedException() : base(ExceptionsMessage.Product.AccessDenied, 403)
    {
    }
}