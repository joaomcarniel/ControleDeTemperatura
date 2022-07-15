using EdicoesEmMassa.Model;
using EdicoesEmMassa.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EdicoesEmMassa.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ClaimsPrincipal ValidateLogin(string userName, string password)
        {
            try
            {
                User user = _userRepository.GetUser(userName, password);
                return GetClaims(user);
            }
            catch
            {
                return null;
            }
            
        }

        public ClaimsPrincipal GetClaims(User user)
        {
            List<Claim> access = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };
            var identity = new ClaimsIdentity(access, "Identity.Login");
            return new ClaimsPrincipal(new[] { identity }); 
        }
    }
}
