namespace EdicoesEmMassa.Service
{
    public interface ILoginService
    {
        public bool ValidateLogin(string userName, string senha);
    }
}
