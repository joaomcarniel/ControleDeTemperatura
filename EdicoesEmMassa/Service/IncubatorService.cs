using EdicoesEmMassa.Model;
using EdicoesEmMassa.Repository;
using System;
using System.Collections.Generic;

namespace EdicoesEmMassa.Service
{
    public class IncubatorService : IIncubatorService
    {
        public readonly IIncubadoraRepository _incubadoraRepository;

        public IncubatorService(IIncubadoraRepository incubadoraRepository)
        {
            _incubadoraRepository = incubadoraRepository;
        }

        public List<Incubadora> GetAll()
        {
            return _incubadoraRepository.GetAll();
        }
        public Incubadora GetById(int id)
        {
            return _incubadoraRepository.GetById(id);
        }
        public void Creating(Incubadora incubadora)
        {
            _incubadoraRepository.Creating(incubadora);
        }
        public void Update(Incubadora incubadora)
        {
            _incubadoraRepository.Update(incubadora);
        }
        public void Delete(int id)
        {
            try
            {
                _incubadoraRepository.Delete(id);

            }catch(Exception e)
            {

            }
            
        }

    }
}
