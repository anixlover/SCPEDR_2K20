﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ConexionBD
    {
        public static string CadenaConexion
        {
            get
            {
                //Conexion Alexandra
                //return @"data source=ALE\SQLEXPRESS; initial catalog=BD_SCPEDR; integrated security=SSPI;";
                //Conexion Marcial
                return @"data source=LAPTOP-UEI1JFVM; initial catalog=BD_SCPEDR; integrated security=SSPI;";
                //Conexion Maciel
                //return @"data source=HELLO; initial catalog=BD_SCPEDR; integrated security=SSPI;";
                //Conexion Ana
                //return @"data source=(Local); initial catalog=BD_SCPEDR; integrated security=SSPI;";
                //ConexionBD alvar0
                //return "server = DESKTOP-IAELG6V\\SQLEXPRESS ; database=BD_SCPEDR ; integrated security = true;";
            }
        }
    }
}
