using EdicoesEmMassa.DataContext;
using EdicoesEmMassa.Model;
using System.Linq;

namespace EdicoesEmMassa.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly jupiterContext _dbContext;
        public UserRepository(jupiterContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User GetUser(string userName, string password)
        {
            return _dbContext.Users.FirstOrDefault(x => x.UserName == userName && x.UserPass == password);
        }
    }
}
