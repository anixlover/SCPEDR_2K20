using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace CTR
{
    public class CtrDatoFactura
    {
        DaoDatoFactura factura;
        public CtrDatoFactura()
        {
            factura = new DaoDatoFactura();
        }
        public int ultimo()
        {
            return factura.UltimoID();
        }
        public void RegistrarDatoFactura(DtoDatoFactura objfactura)
        {
            bool correcto = true;
            DtoDatoFactura objfactura2 = new DtoDatoFactura();
            objfactura2.FK_VU_DNI = objfactura.FK_VU_DNI;
            correcto = !factura.selectRUC(objfactura2);
            if (!correcto)
            {
                objfactura.error = 2;
                return;
            }
            objfactura.error = 77;
            factura.InsertarDatoFactura(objfactura);
        }
    }
}
