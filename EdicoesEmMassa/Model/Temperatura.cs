using System;
using System.Collections.Generic;

#nullable disable

namespace EdicoesEmMassa.Model
{
    public partial class Temperatura
    {
        public int id_temperatura { get; set; }
        public int id_incubadora { get; set; }
        public float temperatura_atual { get; set; }
        public DateTime? update_date { get; set; }

        //public virtual Incubadora id_incubadoraNavigation { get; set; }
    }
}
