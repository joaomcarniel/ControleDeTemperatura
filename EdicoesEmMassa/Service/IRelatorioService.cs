namespace EdicoesEmMassa.Service
{
    public interface IRelatorioService
    {
        public void DeserializeTemperatura();
        void CreatePDF(int qtdTemperatura);
    }
}
