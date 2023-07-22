namespace NadinSoft.Application.Contract.Exceptions;

public class NadinSoftException : Exception
{
    public NadinSoftException(string exceptionMessage,int statusCode)
    {
        Message = exceptionMessage;
        StatusCode = statusCode;
    }
    public override string Message { get;}
    public int StatusCode { get; set; }
}