using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Models
{
    public class TipoFlor
    {
        [Display(Name = "Tipo Flor")]
        public int TipoFlorId { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Irrigação da Semana")]
        public int IrrigacaoSemana { get; set; }
        [Display(Name = "Tempo de irrigação")]
        public decimal IrrigacaoTempo { get; set; }
        [Display(Name = "Quantidade de pessoas irrigação")]
        public int IrrigacaoQtdPessoas { get; set; }
        public bool Estufa { get; set; }
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
        public virtual ICollection<Flor> Flores { get; set; }

        //falta icollection flor
    }
}
