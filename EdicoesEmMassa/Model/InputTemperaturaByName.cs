using System.ComponentModel.DataAnnotations;

namespace EdicoesEmMassa.Model
{
    public class InputTemperaturaByName
    {
        [Required]
        [Display(Description = "Nome da incubadora")]
        public string Name { get; set; }
        [Required]
        [Display(Description = "Temperatura atual")]
        public double TemperaturaAtual { get; set; }
    }
}
