namespace NadinSoft.Application.Contract.Exceptions;

public class ExceptionsMessage
{
    public static class Product
    {
        public const string DuplicatedProduct = "همچین محصولی با ManufactureEmail و ProductDate وجود دارد.";
        public const string NotFoundProduct = "همچین محصولی یافت نشد";
        public const string AccessDenied = "شما این محصول را ایجاد نکرده اید.نمی توانید آنرا تغیر دهید";
        public static class CreateModel
        {
            public const string NameLengthError = "نام نباید بیش از 256 حرف باشد";
            public const string EmailFormatError = "ایمیل درست نمیباشد";
        }

    }   
    public static class Auth
    {
        public const string DuplicatedUserInUserName = "کاربری با این نام کاربری وجود دارد";
        public const string NotFoundUser = "همچین کاربری یافت نشد";
        public const string InvalidPassword = "رمز عبور اشتباه می باشد";
        public static class CreateModel
        {
            public const string NameLengthError = "نام نباید بیش از 256 حرف باشد";
            public const string EmailFormatError = "ایمیل درست نمیباشد";
        }

    }

}