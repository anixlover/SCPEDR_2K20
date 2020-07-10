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
    public class DaoVenta
    {
        SqlConnection conexion;

        public DaoVenta()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void obtenerDatosClienteD(DtoUsuario objdatousr)
        {
            SqlCommand command = new SqlCommand("SP_Obtener_user_dni", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@dni", objdatousr.PK_VU_Dni);

        }
        public void obtenerDatosClienteR(DtoUsuario objdatousr)
        {
            SqlCommand command = new SqlCommand("SP_Obtener_user_dni", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@dni", objdatousr.PK_VU_Dni);

        }
        public void obtenerMoldura(DtoMoldura objdatousr)
        {
            SqlCommand command = new SqlCommand("SP_Obtener_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@codMol", objdatousr.PK_IM_Cod);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter moldura = new SqlDataAdapter(command);
            moldura.Fill(ds);
            moldura.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objdatousr.DM_Medida = Convert.ToDouble(reader[0].ToString());
                objdatousr.IM_Stock = int.Parse(reader[1].ToString());
                objdatousr.DM_Precio = Convert.ToDouble(reader[2].ToString());
            }
            conexion.Close();
            conexion.Dispose();

        }
    }
}
