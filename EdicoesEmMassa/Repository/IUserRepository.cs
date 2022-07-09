using EdicoesEmMassa.Model;

namespace EdicoesEmMassa.Repository
{
    public interface IUserRepository
    {
        User GetUser(string userName);
    }
}
