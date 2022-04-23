using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BicycleRental.Server.Helpers
{
    public static class Jwt
    {
        public static int GetId(string token)
        {
            token = token.Substring(7);
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);
            string value = jsonToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            int id = Convert.ToInt32(value);
            return id;
        }
    }
}
