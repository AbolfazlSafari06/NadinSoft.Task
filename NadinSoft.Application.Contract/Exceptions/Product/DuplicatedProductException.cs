namespace NadinSoft.Application.Contract.Exceptions.Product;

public class DuplicatedProductException : NadinSoftException
{
    public DuplicatedProductException() : base(ExceptionsMessage.Product.DuplicatedProduct,400)
    {
    }
}