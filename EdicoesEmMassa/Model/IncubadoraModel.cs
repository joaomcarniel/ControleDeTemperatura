using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EdicoesEmMassa.Model
{
    public partial class IncubadoraModel
    {
        [Key]
        public int IdIncubadora { get; set; }
        public string CodIncubadora { get; set; }
        public double TemperaturaFixada { get; set; }
    }
}
