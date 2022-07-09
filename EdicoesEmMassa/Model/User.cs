using System;
using System.Collections.Generic;

#nullable disable

namespace EdicoesEmMassa.Model
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
    }
}
