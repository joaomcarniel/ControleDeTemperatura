using System;
using System.Collections.Generic;

#nullable disable

namespace EdicoesEmMassa.Model
{
    public partial class Incubadora
    {
        /*public Incubadora()
        {
            Temperaturas = new HashSet<Temperatura>();
        }*/

        public int id_incubadora { get; set; }
        public string cod_incubadora { get; set; }
        public float temperatura_fixada { get; set; }

        //public virtual ICollection<Temperatura> Temperaturas { get; set; }
    }
}
