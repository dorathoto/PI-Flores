using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Models
{
    public class Flor
    {
        [Key]
        public int FlorId { get; set; }

        [Display(Name = "Tipo Flor")]
        public int TipoFlorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Data da Plantação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DataPlantacao { get; set; }

        [Display(Name = "Descrição")]
        [MaxLength(200, ErrorMessage = "{0} pode ter no máximo {1}caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Descricao { get; set; }
        [Display(Name = "Data estimada da colheita")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? DataColheitaEstimada { get; set; }
        [Display(Name = "Tamnho da area plantada horizontal")]
        public decimal? AreaHorizontalPlantada { get; set; }
        [Display(Name = "Tamnho da area plantada vertical")]
        public decimal? AreaVerticalPlantada { get; set; }
        [Display(Name = "Data de cadastro")]
        public DateTime DataCadastro { get; set; }


        public virtual TipoFlor TipoFlor { get; set; }
        public virtual ICollection<CustoFlor> CustoFlores { get; set; }
       
    }
}
