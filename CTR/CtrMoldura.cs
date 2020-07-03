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
    }
}
