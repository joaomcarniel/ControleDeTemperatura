using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EdicoesEmMassa.Entity
{
    public class Incubadora
    {
        public Incubadora()
        {
            Historicos = new HashSet<TemperaturaHistorico>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe uma descrição para a incubadora")]
        public string Name { get; set; }
        public double TemperaturaIdeal { get; set; }
        public double TemperaturaAtual { get; set; }
        public DateTime DataCriacao { get; set; }

        public ICollection<TemperaturaHistorico> Historicos { get; set; }
    }
}
