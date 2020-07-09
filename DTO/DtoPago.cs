using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoPago
    {
        public string PK_VP_Cod { get; set; }
        public int IP_TipoPago { get; set; }
        public double DP_ImportePagado { get; set; }
        public double DP_ImporteRestante { get; set; }
        public int IP_TipoCertificado { get; set; }
        public string VP_RUC { get; set; }
        public int FK_IS_Cod { get; set; }
        public int error { get; set; }
    }
}
