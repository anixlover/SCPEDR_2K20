﻿using System;
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

        public void RegistrarSolicitud_LD(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_LD(objsolicitud);
        }

        public int CantidadSolicitud()
        {
            return objDaoSolicitud.CantidadSolicitudes();
        }

    }
}
