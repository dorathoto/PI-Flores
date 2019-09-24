using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Models
{
    public class Flor
    {
        public int FlorId { get; set; }
        public DateTime DataPlantacao { get; set; }
        public DateTime? DataColheitaEstimada { get; set; }
        public decimal? AreaHorizontalPlantada { get; set; }
        public decimal? AreaVerticalPlantada { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual ICollection<CustoFlor> CustoFlores { get; set; }
    }
}
