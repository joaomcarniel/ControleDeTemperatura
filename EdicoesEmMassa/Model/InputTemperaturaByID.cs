using System.ComponentModel.DataAnnotations;

namespace EdicoesEmMassa.Model
{
    public class InputTemperaturaByID
    {
        [Required]
        [Display(Description = "Id da incubadora")]
        public int Id { get; set; }
        [Required]
        [Display(Description = "Temperatura atual")]
        public double TemperaturaAtual { get; set; }
    }
}
