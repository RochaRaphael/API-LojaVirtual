using API_LojaVirtual.Models;
using System.Security.Claims;

namespace API_LojaVirtual.Extensions
{
    public static class LoginClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims(this Usuario usuario)
        {
            var result = new List<Claim>
        {
            new(ClaimTypes.Name, usuario.Login)
        };
            result.AddRange(
                usuario.Login.Select(login => new Claim(ClaimTypes.Role, usuario.Login))
            );
            return result;
        }
    }
}
