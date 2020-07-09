using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace CTR
{
    public class CtrPago
    {
        DaoPago objpagodao;
        public CtrPago()
        {
            objpagodao = new DaoPago();
        }
        public void RegistrarPago(DtoPago objpago)
        {
            double costo;
            bool correcto = true;
            DtoPago objpago2 = new DtoPago();
            objpago2.FK_IS_Cod = objpago.FK_IS_Cod;
            objpago2.DP_ImportePagado = objpago.DP_ImportePagado;            
            costo = objpagodao.SelectCosto(objpago2);
            correcto = objpago2.DP_ImportePagado >= (costo/2);
            if (!correcto)
            {
                objpago.error = 3;
                return;
            }
            DtoPago objpago3 = new DtoPago();
            objpago3.DP_ImportePagado = objpago.DP_ImportePagado;
            correcto = objpago3.DP_ImportePagado <= costo;
            if (!correcto)
            {
                objpago.error = 4;
                return;
            }
            objpago.error = 77;
            objpagodao.InsertarPago(objpago);
        }
        public double Costo(DtoPago pago)
        {
            return objpagodao.SelectCosto(pago);
        }
    }
}
