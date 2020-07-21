using System;
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
                //return @"data source=LAPTOP-UEI1JFVM; initial catalog=BD_SCPEDR; integrated security=SSPI;";
                //Conexion Maciel
                //return @"data source=HELLO; initial catalog=BD_SCPEDR; integrated security=SSPI;";
                //Conexion Ana
                return @"data source=DESKTOP-4LVLNRM; initial catalog=BD_SCPEDR; integrated security=SSPI;";
                //Conexion Alvaro
                //return "data source=DESKTOP-IAELG6V\\SQLEXPRESS; initial catalog=BD_SCPEDR; integrated security=SSPI;";
                //return "data source=(Local); initial catalog=BD_SCPEDR; integrated security=SSPI;";
            }
        }
    }
}
