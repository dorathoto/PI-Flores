
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
        [Display(Name = "Valor Unitário")]
        public decimal ValorUnitario { get; set; }
        [Display(Name = "Valor Final")]
        public decimal ValorFinal { get; set; }
        public int Quantidade { get; set; }
        [Display(Name = "Tipo de movimentação")]
        public TipoMovimentacao TipoMovimentacao { get; set; }
        [Display(Name = "Descrição")]
        [MaxLength(200, ErrorMessage = "{0} pode ter no máximo {1}caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Descricao { get; set; }
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }



    }
}
