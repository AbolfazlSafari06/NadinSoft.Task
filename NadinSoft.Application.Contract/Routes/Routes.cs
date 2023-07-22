using System.Linq;

namespace NadinSoft.Application.Contract.Routes;

public static class Routes
{
    public static class Product
    {
        public const string RootAddress = "api/Product";
        public const string Delete = "{id:Guid}";

        public static class Get
        {
            public const string GetById = "{id:Guid}";
            public const string Index = "Summery";
        }

        public static class Post
        {
            public const string Create = "{campaignId:Guid}/merchants";
        }
    }
    public static class Auth
    {
        public const string RootAddress = "api/Auth";
        public const string Login = "Login";
        public const string Register = "Register";
    }

}