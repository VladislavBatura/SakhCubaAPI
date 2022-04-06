using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SakhCubaAPI
{
    public class AuthOptions
    {
        public const string ISSUER = "SakhCubaServer";
        public const string AUDIENCE = "SakhCubaClient";
        const string KEY = "MoySuperKluchDlyaSakhCuba";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
            new(Encoding.UTF8.GetBytes(KEY));
    }
}
