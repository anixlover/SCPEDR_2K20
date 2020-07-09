using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoDatoFactura
    {
        public int PK_IDF_Cod { get; set; }
        public string IDF_RUC { get; set; }
        public string VDF_RazonSocial { get; set; }
        public string FK_VU_DNI { get; set; }
        public int error { get; set; }
    }
}
