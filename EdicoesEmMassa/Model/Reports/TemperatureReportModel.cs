using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EdicoesEmMassa.Model.Reports
{
    public class TemperatureReportModel
    {
        [Key]
        public int id_temperatura { get; set; }
        public int id_incubadora { get; set; }
        public DateTime update_date { get; set; }
        public float temperatura_fixada { get; set; }
        public string cod_incubadora { get; set; }
        public float temperatura_atual { get; set; }
    }
}
