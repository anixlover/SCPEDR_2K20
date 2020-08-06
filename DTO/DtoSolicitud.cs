using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoSolicitud
    {
        public int PK_IS_Cod { get; set; }
        public string VS_TipoSolicitud { get; set; }
        public byte[] VBS_Imagen { get; set; }
        public double VS_Medida { get; set; }
        public int IS_Cantidad { get; set; }
        public double DS_PrecioAprox { get; set; }
        public double DS_ImporteTotal { get; set; }
        public string VS_Comentario { get; set; }
        public DateTime DTS_FechaEmicion { get; set; }
        public DateTime DTS_FechaRegistro { get; set; }
        public int IS_Ndias { get; set; }
        public DateTime DTS_FechaRecojo { get; set; }

        public int IS_EstadoPago { get; set; }

        //Esto no existre en la tabla actual T_Solicitud en la bd 
        public string FK_VU_Dni { get; set; }
        //
        public int FK_ISE_Cod { get; set; }

        public int error { get; set; }
    }
}
