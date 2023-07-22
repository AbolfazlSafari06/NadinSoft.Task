namespace NadinSoft.Application.Contract;

public class ResponseObject<T>
{
    public T? Data { get; set; }
    public bool IsSucceed { get; set; }
    public int StatusCode { get; set; } = 200;
    public string Message { get; set; } = "عملیات با موفقیت انجام شد";
}
public class ResponseObject
{ 
    public bool IsSucceed { get; set; }
    public int StatusCode { get; set; } = 200;
    public string Message { get; set; } = "عملیات با موفقیت انجام شد";
}