using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoVoucher
    {
        public string PK_VV_NumVoucher { get; set; }
        public byte[] VBV_Foto { get; set; }
        public double DV_ImporteDepositado { get; set; }
        public string VV_Comentario { get; set; }
        public string FK_VP_Cod { get; set; }
    }
}
