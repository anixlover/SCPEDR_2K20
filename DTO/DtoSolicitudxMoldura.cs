using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoSolicitudxMoldura
    {
        public int FK_IS_Cod { get; set; }
        public int FK_IM_Cod { get; set; }
        public int ISM_Cantidad { get; set; }
        public double DSM_Precio { get; set; }
        public int FK_ISXME_Cod { get; set; }
    }
}
