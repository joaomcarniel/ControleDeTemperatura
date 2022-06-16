using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EdicoesEmMassa.Model
{
    public partial class IncubadoraModel
    {
        [Key]
        public int IdIncubadora { get; set; }
        [Required(ErrorMessage = "Digite o Código da Incubadora")]
        public string CodIncubadora { get; set; }
        [Required(ErrorMessage = "Digite a temperatura ideal")]
        public double TemperaturaFixada { get; set; }
    }
}
