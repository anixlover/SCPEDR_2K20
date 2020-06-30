using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

using DAO;
using DTO;
namespace CTR
{
    public class CtrSolicitudxMoldura
    {
        DaoSolicitudxMoldura  objDaoSXM;

        public CtrSolicitudxMoldura()
        {
        objDaoSXM = new DaoSolicitudxMoldura();
        }

        public void registrarSXM_LD(DtoSolicitudxMoldura objSXM)
        {
            objDaoSXM.RegistrarSolicitudxMoldura_LD(objSXM);
        }
        public DataTable ListarSXM_LD(DtoSolicitud objsolicitud)
        {
            return objDaoSXM.ListarSXM_LD(objsolicitud);
        }
        public void EliminarSXM_LD(DtoSolicitudxMoldura objSXM)
        {
            objDaoSXM.EliminarSolicitudxMoldura_LD(objSXM);
        }
        public void ObtenerSolicitudxMoldura_LD(DtoMoldura objmoldura, DtoSolicitudxMoldura ObjSxm, DtoTipoMoldura objtipo)
        {
            objDaoSXM.ObtenerSolicitudxMoldura_LD(objmoldura, ObjSxm, objtipo);
        }

    }
}
