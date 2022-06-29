using System.ComponentModel.DataAnnotations;

namespace EdicoesEmMassa.Model
{
    public class TemperaturaModel
    {
        [Key]
        public int id_temperatura { get; set; }
        /*[Required(ErrorMessage = "Digite o Código da Incubadora")]
        public IncubadoraModel Incubadora { get; set; }*/
        [Required(ErrorMessage = "Digite a temperatura atual")]
        public int id_incubadora { get; set; }
        public double temperatura_atual { get; set; }
    }
}
