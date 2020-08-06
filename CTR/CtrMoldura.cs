using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO;
using DTO;

namespace CTR
{
    public class CtrMoldura
    {
        DaoMoldura objDaoMoldura;
        public CtrMoldura()
        {
            objDaoMoldura = new DaoMoldura();
        }
        public void registrarNuevaMoldura(DtoMoldura objDtoMoldura)
        {
            objDaoMoldura.RegistrarMoldura(objDtoMoldura);
        }
        public DataSet OpcionesTipoMoldura()
        {
            return objDaoMoldura.desplegableTipoMoldura();
        }
        public DataTable ListaMolduras()
        {
            return objDaoMoldura.ListarMolduras();
        }
        public void ObtenerImagen_Desc_Moldura(DtoMoldura objDtoMoldura)
        {
            objDaoMoldura.ObtenerImgMoldura(objDtoMoldura);
        }
        public void ObtenerMoldura(DtoMoldura objmoldura, DtoTipoMoldura objtipo)
        {
            objDaoMoldura.ObtenerMoldura(objmoldura, objtipo);
        }
        public DataTable CalcularSubtotal(DtoMoldura objmoldura, DtoTipoMoldura objtipo, double cant)
        {
            return objDaoMoldura.CalcularSubtotal(objmoldura, objtipo, cant);
            
        }

        public DataTable ObtenerMoldura2(DtoMoldura objmoldura, DtoTipoMoldura objtipo)
        {
            return objDaoMoldura.ObtenerMoldura2(objmoldura, objtipo);
        }

        public void ActualizarRegistroMoldura(DtoMoldura objmoldura)
        {
            objDaoMoldura.ActualizarMoldura(objmoldura);
        }
        public void ActualizarImgMoldura(DtoMoldura objmoldura)
        {
            objDaoMoldura.ActualizarImgMoldura(objmoldura);
        }

        public void registrarImgMoldura(byte[] bytes, int id)
        {
            objDaoMoldura.RegistrarImgMoldura(bytes, id);
        }

        public DataTable ListarMoldurasByTipoMoldura(DtoTipoMoldura objDtoTipoMoldura)
        {
            return objDaoMoldura.ListarMoldurasByTipoMoldura(objDtoTipoMoldura);
        }
        public DataTable ListarMoldurasPaginaInicial(DtoTipoMoldura objDtoTipoMoldura)
        {
            return objDaoMoldura.ListarMoldurasPaginaInicial(objDtoTipoMoldura);
        }
        public DataTable ListarTodoMoldura(DtoMoldura objDtoMoldura)
        {
            return objDaoMoldura.ListarTodoMolduras(objDtoMoldura);
        }
        public int StockMoldura_(DtoMoldura objDtoMoldura)
        {
            return objDaoMoldura.StockMoldura(objDtoMoldura);
        }
        public void PrecioAprox(DtoMoldura objMoldura)
        {
            objDaoMoldura.PrecioAprox(objMoldura);
        }
        public double Aprox(DtoMoldura objMoldura) 
        {
            return objDaoMoldura.Aprox(objMoldura);
        }
        public void ActualizarStockxMoldura(DtoMoldura objmoldura)
        {
            objDaoMoldura.ActualizarStockxMoldura(objmoldura);
        }

        public bool MolduraExiste(DtoMoldura objmoldura)
        {
            return objDaoMoldura.SelectMolduraID(objmoldura);
        }

    }
}
