using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class DaoSolicitud
    {
        SqlConnection conexion;
        public DaoSolicitud()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void RegistrarSolicitud_LD(DtoSolicitud objsolicitud)
        {
            SqlCommand command = new SqlCommand("SP_RegistrarSolicitud_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@impt", objsolicitud.DS_ImporteTotal);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
           
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objsolicitud.PK_IS_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }
        public int CantidadSolicitudes()
        {

            int valor_retornado = 0;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM T_Solicitud");

            Console.WriteLine(cmd);
            conexion.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {   
                valor_retornado = int.Parse(reader[0].ToString());

            }
            conexion.Close();

            return valor_retornado;
        }
        public void UpdateEstadoSolicitud(DtoSolicitud objsolicitud)
        {
            string update = "UPDATE T_Solicitud SET FK_ISE_Cod = 6, DTS_FechaEmicion='"+ DateTime.Today.Date +"' Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(update, conexion);
            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
