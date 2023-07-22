namespace NadinSoft.Application.Contract.Exceptions.Product;

public class NotFoundProductException : NadinSoftException
{
    public NotFoundProductException() : base(ExceptionsMessage.Product.NotFoundProduct, 404)
    {
    }
}