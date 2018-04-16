using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FitcareWebAPIModel.Provider.JWT
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}
