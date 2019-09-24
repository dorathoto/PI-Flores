using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Models.Enum
{
    public enum TipoMovimentacao
    {
        [Display(Name = "Selecione Tipo Movimentação")]
        Nenhum = 0,
        [Display(Name = "Entrada")]
        Entrada = 1,
        [Display(Name = "Saída")]
        Saida = 2
    }
}
