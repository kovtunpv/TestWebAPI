using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Test.Web.API
{
    public class AuthOptions
    {
        public const string ISSUER = "TestAuthServer";
        public const string AUDIENCE = "http://localhost:1080/";
        const string KEY = "sdfsgdbsdhsgfdgdsfbnfs";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
