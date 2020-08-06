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
            objfactura2.IDF_RUC = objfactura.IDF_RUC;
            correcto = !factura.selectRUC(objfactura2);
            if (!correcto)
            {
                objfactura.error = 2;
                return;
            }
            correcto =10<objfactura.IDF_RUC.Length &&objfactura.IDF_RUC.Length< 12;
            if (!correcto) { objfactura.error = 3; return; }
            for (int i = 0; i < objfactura.IDF_RUC.Length; i++)
            {
                correcto = char.IsDigit(objfactura.IDF_RUC.Trim()[i]);
            }
            if (!correcto) { objfactura.error = 4; return; }
            objfactura.error = 77;
            factura.InsertarDatoFactura(objfactura);
        }
    }
}
