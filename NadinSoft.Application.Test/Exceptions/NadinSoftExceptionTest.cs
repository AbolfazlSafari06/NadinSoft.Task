using NadinSoft.Application.Contract.Exceptions;
using NadinSoft.Application.Contract.Exceptions.Product;
using Xunit;

namespace NadinSoft.Application.Test.Exceptions;

public class NadinSoftExceptionTest
{
    [Fact]
    public void NadinSoftException_Should_Have_message_And_StatusCode_That_We_Passed()
    {

        var exceptionMessage = "test";
        var exceptionStatusCode = 1234;
        var exception = new NadinSoftException(exceptionMessage, exceptionStatusCode);

        Assert.Equal(exceptionMessage, exception.Message);
        Assert.Equal(exceptionStatusCode, exception.StatusCode);
    }
    [Fact]
    public void DuplicatedProductException_Should_Have_Right_message_And_StatusCode()
    {
        var exception = new DuplicatedProductException();
        var exceptionMessage = exception.Message;
        var exceptionStatusCode = exception.StatusCode;

        Assert.Equal(exceptionMessage, ExceptionsMessage.Product.DuplicatedProduct);
        Assert.Equal(exceptionStatusCode, 400);
    }

    [Fact]
    public void NotFoundProductException_Should_Have_Right_message_And_StatusCode()
    {
        var exception = new NotFoundProductException();
        var exceptionMessage = exception.Message;
        var exceptionStatusCode = exception.StatusCode;

        Assert.Equal(exceptionMessage, ExceptionsMessage.Product.NotFoundProduct);
        Assert.Equal(exceptionStatusCode, 404);
    }
    [Fact]
    public void ProductAccessDeniedException_Should_Have_Right_message_And_StatusCode()
    {
        var exception = new ProductAccessDeniedException();
        var exceptionMessage = exception.Message;
        var exceptionStatusCode = exception.StatusCode;

        Assert.Equal(exceptionMessage, ExceptionsMessage.Product.AccessDenied);
        Assert.Equal(exceptionStatusCode, 404);
    }
}