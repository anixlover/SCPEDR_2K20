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

        public Ctr_Solicitud()
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
            return objDaoSolicitud.ConsultarEstadoPago(objsolicitud, objmxu);
        }

        public DataTable ListarSolicitudxEstado(DtoSolicitud objSolicitud, DtoMolduraxUsuario objmxu, DtoSolicitudEstado objSolicitudEstado)
        {
            return objDaoSolicitud.ListarSolicitudxEstado(objSolicitud, objmxu, objSolicitudEstado);
        }
        public void RegistrarSolicitud_PxC(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_PxC(objsolicitud);
        }

        public void RegistrarSolicitud_PxDP(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_PxPD(objsolicitud);
        }

        public DataSet OpcionesSolicitudEstado()
        {
            return objDaoSolicitud.desplegableSolicitudEstado();
        }

        public DataTable ListaSolicitudes()
        {
            return objDaoSolicitud.SelectSolicitudes();
        }
        public DataTable ListaMolduras(DtoSolicitud objsol)
        {
            return objDaoSolicitud.ListaMoldurasSolicitud(objsol);
        }
        public bool LeerSolicitud(DtoSolicitud objsol)
        {
            return objDaoSolicitud.SelectSolicitud(objsol);
        }
        public void actualizarEstadoObservacion(DtoSolicitud objsol)
        {
            bool correcto = true;
            correcto = objsol.VS_Comentario.Length > 0;
            if (!correcto)
            { objsol.error = 1; return; }
            objsol.error = 55;
            objDaoSolicitud.UpdateSolicitudObservada(objsol);
        }
        public void actualizarEstadoFecha(DtoSolicitud objsol)
        {
            bool correcto = true;
            correcto = objsol.DTS_FechaEmicion < objsol.DTS_FechaRecojo;
            if (!correcto)
            { objsol.error = 2; return; }
            objsol.error = 66;
            objDaoSolicitud.UpdateSolicitudFecha(objsol);
        }
        public void actualizarEstadoAproves(DtoSolicitud objsol)
        {
            objsol.error = 77;
            objDaoSolicitud.UpdateSolicitudPendiente(objsol);
        }
        public string HayPago(DtoSolicitud objsol)
        {
            return objDaoSolicitud.SelectSolicitudPago(objsol);
        }
        public bool leerSolicitudDiseñoPersonal(DtoSolicitud objsol)
        {
            return objDaoSolicitud.SelectSolicitudDiseñoPersonalizado(objsol);
        }
        public bool leerSolicitudTipo(DtoSolicitud objsol)
        {
            return objDaoSolicitud.SelectSolicitudTipo(objsol);
        }
        public DataTable Listar_Solicitud_Personalizado()
        {
            return objDaoSolicitud.Listar_Solicitud_Personalizado();
        }
    }
}

