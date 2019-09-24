using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Models
{
    public class TipoFlor
    {
        public int TipoFlorId { get; set; }
        public string Nome { get; set; }
        public int IrrigacaoSemana { get; set; }
        public decimal IrrigacaoTempo { get; set; }
        public int IrrigacaoQtdPessoas { get; set; }
        public bool Estufa { get; set; }
        public DateTime DataCadastro { get; set; }


        //falta icollection flor
    }
}
