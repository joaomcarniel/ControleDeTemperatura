using System;

namespace EdicoesEmMassa.Entity
{
    public class TemperaturaHistorico
    {
        public long Id { get; set; }
        public double TemperaturaAtual { get; set; }
        public DateTime DataCriacao { get; set; }
        //Referencia N:1
        public Incubadora Incubadora { get; set; }
        public int IdIncubadora { get; set; }
    }
}
