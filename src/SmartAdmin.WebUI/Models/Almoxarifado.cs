
using SmartAdmin.WebUI.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Models
{
    public class Almoxarifado
    {
        public int AlmoxarifadoId { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorFinal { get; set; }
        public int Quantidade { get; set; }
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }



    }
}
