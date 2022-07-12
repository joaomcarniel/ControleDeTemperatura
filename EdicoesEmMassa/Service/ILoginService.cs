using EdicoesEmMassa.Model;
using System.Security.Claims;

namespace EdicoesEmMassa.Service
{
    public interface ILoginService
    {
        public ClaimsPrincipal ValidateLogin(string userName, string senha);

        public ClaimsPrincipal GetClaims(User user);
    }
}
