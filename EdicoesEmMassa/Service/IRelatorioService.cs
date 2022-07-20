using EdicoesEmMassa.Model;
using System.Collections.Generic;

namespace EdicoesEmMassa.Service
{
    public interface IRelatorioService
    {
        public void DeserializeTemperatura();
        void CreatePDF(List<Temperatura> selectedTemperature);
    }
}
