using System.ComponentModel.DataAnnotations;

namespace EdicoesEmMassa.Model
{
    public class TemperaturaModel
    {
        [Key]
        public int IdTemperatura { get; set; }
        [Required(ErrorMessage = "Digite o Código da Incubadora")]
        public IncubadoraModel Incubadora { get; set; }
        [Required(ErrorMessage = "Digite a temperatura atual")]
        public int IncubadoraIdIncubadora { get; set; }
        public double TemperaturaAtual { get; set; }
    }
}
