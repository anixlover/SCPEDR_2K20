using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace CTR
{
    public class CtrVoucher
    {
        DaoVoucher objvoucherdao;
        public CtrVoucher()
        {
            objvoucherdao = new DaoVoucher();
        }

        public void RegistrarVoucher(DtoVoucher voucher)
        {
            objvoucherdao.InsertarVoucher(voucher);
        }
        public void RegistrarImagenVoucher(byte[] arreglo, string ID)
        {
            objvoucherdao.InsertarImagenVoucher(arreglo,ID);
        }
    }
}
