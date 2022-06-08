using System;
using System.Collections.Generic;

#nullable disable

namespace EdicoesEmMassa.Model
{
    public partial class Incubadora
    {
        public int IdIncubadora { get; set; }
        public string CodIncubadora { get; set; }
        public double TemperaturaFixada { get; set; }
    }
}
