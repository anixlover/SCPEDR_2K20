using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoMolduraxUsuario
    {
        public int PK_IMU_Cod { get; set; }
        public string FK_VU_Cod { get; set; }
        public int FK_IM_Cod { get; set; }
        public int IMU_Cantidad { get; set; }
        public double DMU_Precio { get; set; }
        public int FK_IS_Cod { get; set; }
        public int FK_IMXUE_Cod { get; set; }
    }
}
