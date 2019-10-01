using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Models
{
    public class CustoFlor
    {
        [Key]
        public int CustoFlorId { get; set; }
        [Display(Name = "Tipo Flor")]
        public int FlorId { get; set; }
        public int Quantidade { get; set; }
        [Display(Name = "Valor calculado")]
        public decimal ValorCalculado { get; set; }
        [Display(Name = "Data de cadastro")]
        public DateTime DataCadastro { get; set; }

        public virtual Flor Flores { get; set; }

    }
}
