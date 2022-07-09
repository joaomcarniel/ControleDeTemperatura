using EdicoesEmMassa.Model;
using EdicoesEmMassa.Repository;
using System;

namespace EdicoesEmMassa.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidateLogin(string userName, string password)
        {
            User user = _userRepository.GetUser(userName);
            return (user.UserName == userName & user.UserPass == password);

        }
    }
}
