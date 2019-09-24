using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Models
{
    public class CustoFlor
    {
        public int CustoFlorId { get; set; }
        public int FlorId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorCalculado { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual Flor Flores { get; set; }

    }
}
