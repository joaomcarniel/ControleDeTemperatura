using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EdicoesEmMassa.Model
{
    public partial class IncubadoraModel
    {
        [Key]
        public int id_incubadora { get; set; }
        [Required(ErrorMessage = "Digite o Código da Incubadora")]
        public string cod_incubadora { get; set; }
        [Required(ErrorMessage = "Digite a temperatura ideal")]
        public double temperatura_fixada { get; set; }
    }
}
