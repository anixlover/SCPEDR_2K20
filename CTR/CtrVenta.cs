using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public class CtrVenta
    {
        DaoVenta objDaoVenta;
        DaoUsuario objuser;

        public CtrVenta()
        {
            objDaoVenta = new DaoVenta();
        }
        public void obtenerDatosClientexDni(DtoUsuario objDtoUser)
        {
            objuser.SelectUsuario(objDtoUser);
        }
        public void obtenerDatosClientexRuc()
        {
            //objDaoVenta.obtenerDatosClienteR();
        }
        public void ObtenerMoldura(DtoMoldura objDtoMoldura)
        {
            objDaoVenta.obtenerMoldura(objDtoMoldura);
        }
    }
}
