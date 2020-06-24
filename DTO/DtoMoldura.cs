using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoMoldura
    {
        public int PK_IM_Cod { get; set; }
        public string VM_Descripcion { get; set; }
        public byte[] VBM_Imagen { get; set; }
        public double DM_Medida { get; set; }
        public int IM_Stock { get; set; }
        public double DM_Precio { get; set; }
        public int IM_Estado { get; set; }
        public int FK_ITM_Tipo { get; set; }
    }
}
