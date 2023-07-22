namespace NadinSoft.Application.Contract.Exceptions.Auth;

public class AuthException : NadinSoftException
{
    public AuthException(string exceptionMessage, int statusCode) : base(exceptionMessage, statusCode)
    {
    }
}