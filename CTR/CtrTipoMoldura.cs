using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    public class CtrTipoMoldura
    {
        DaoTipoMoldura objDaoTipoMoldura;
        
        public CtrTipoMoldura()
        {
            objDaoTipoMoldura = new DaoTipoMoldura();
        }
        public void DetallesMolduraByTipoMoldura(DtoTipoMoldura objtipo, DtoMoldura objmoldura)
        {
            objDaoTipoMoldura.DetallesMolduraByTipoMoldura(objtipo, objmoldura);
        }
        public void InspeccionarMolduraByTipoMoldura(DtoTipoMoldura objtipo, DtoMoldura objmoldura)
        {
            objDaoTipoMoldura.InspeccionarMolduraByTipoMoldura(objtipo, objmoldura);
        }
        public void leerUnidadMetrica(DtoTipoMoldura dtoTipo)
        {
            objDaoTipoMoldura.DetallesTipoMoldura(dtoTipo);
        }
    }
}
