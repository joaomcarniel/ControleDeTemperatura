using EdicoesEmMassa.Model;
using System.Collections.Generic;

namespace EdicoesEmMassa.Service
{
    public interface IIncubatorService
    {
        public List<Incubadora> GetAll();
        public Incubadora GetById(int id);
        public void Creating(Incubadora incubadora);
        public void Update(Incubadora incubadora);
        public void Delete(int id);
    }
}
