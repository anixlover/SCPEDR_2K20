using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

using DAO;
using DTO;

namespace CTR
{
    public class Ctr_Solicitud
    {
        DaoSolicitud objDaoSolicitud;

        public Ctr_Solicitud ()
        {
            objDaoSolicitud = new DaoSolicitud();
        }

        public void RegistrarSolcitud_PC(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolcitud_PC(objsolicitud);
        }
        public void RegistrarSolcitud_PP(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_PP(objsolicitud);
        }

        public void RegistrarImgSolicitudP(byte[] bytes, int id)
        {
            objDaoSolicitud.RegistrarImgSolicitudP(bytes, id);
        }

        public void RegistrarSolicitud_LD(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_LD(objsolicitud);
        }
        public void RegistrarSolicitud_LD2(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_LD2(objsolicitud);
        }

        public void ActualizarEstado(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.UpdateEstadoSolicitud(objsolicitud);
        }

        public int CantidadSolicitud()
        {
            return objDaoSolicitud.CantidadSolicitudes();
        }

        public DataTable TablaConsultaEstado(DtoSolicitud objsolicitud, DtoMolduraxUsuario objmxu)
        {
            return objDaoSolicitud.ConsultarEstadoPago(objsolicitud,objmxu);
        }

        public void RegistrarSolicitud_PxC(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_PxC(objsolicitud);
        }

        public void RegistrarSolicitud_PxDP(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_PxPD(objsolicitud);
        }

    }
}
