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
    public class DaoMolduraxUsuario
    {
        SqlConnection conexion;
        public DaoMolduraxUsuario()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void InsertarMolduraxUsuario(DtoMolduraxUsuario objMolduraxUsuario)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_MXU_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idU", objMolduraxUsuario.FK_VU_Cod);
            command.Parameters.AddWithValue("@idM", objMolduraxUsuario.FK_IM_Cod);
            command.Parameters.AddWithValue("@cant", objMolduraxUsuario.IMU_Cantidad);
            command.Parameters.AddWithValue("@pre", objMolduraxUsuario.DMU_Precio);

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void InsertarMolduraxUsuariox2(DtoMolduraxUsuario objMolduraxUsuario)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_MXU_C_3", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idU", objMolduraxUsuario.FK_VU_Cod);
            command.Parameters.AddWithValue("@idM", objMolduraxUsuario.FK_IM_Cod);
            command.Parameters.AddWithValue("@cant", objMolduraxUsuario.IMU_Cantidad);
            command.Parameters.AddWithValue("@pre", objMolduraxUsuario.DMU_Precio);
            command.Parameters.Add("@newId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();

            using (SqlDataReader dr = command.ExecuteReader())
            {
                objMolduraxUsuario.PK_IMU_Cod = Convert.ToInt32(command.Parameters["@newId"].Value);
            }
            conexion.Close();
        }
        public DataTable ListarMXU(DtoMolduraxUsuario objmxu)
        {
            DataTable dtmxu = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_MXU_C", conexion);
            command.Parameters.AddWithValue("@idU", objmxu.FK_VU_Cod);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmxu = new DataTable();
            daAdaptador.Fill(dtmxu);
            conexion.Close();
            return dtmxu;
        }
        public void ObtenerMXU(DtoMoldura objmoldura,DtoMolduraxUsuario objmxu,DtoTipoMoldura tm)
        {
            SqlCommand command = new SqlCommand("SP_Detalle_MXU_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", objmxu.PK_IMU_Cod);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter moldura = new SqlDataAdapter(command);
            moldura.Fill(ds);
            moldura.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objmxu.PK_IMU_Cod = Convert.ToInt32(reader[0].ToString());
                objmoldura.PK_IM_Cod = Convert.ToInt32(reader[1].ToString());
                tm.PK_ITM_Tipo= Convert.ToInt32(reader[2].ToString());
                objmoldura.VM_Descripcion = reader[3].ToString();
            
                tm.VTM_Nombre = reader[4].ToString();
                objmoldura.DM_Medida=Convert.ToDouble(reader[5].ToString());
                tm.VTM_UnidadMetrica = reader[6].ToString();
                objmxu.IMU_Cantidad= Convert.ToInt32(reader[7].ToString());
                objmxu.DMU_Precio = Convert.ToDouble(reader[8].ToString());
                objmoldura.DM_Precio = Convert.ToDouble(reader[9].ToString());
            }
            conexion.Close();
            conexion.Dispose();
        }
        public void eliminarMXU(DtoMolduraxUsuario objmxu)
        {
            SqlCommand command = new SqlCommand("SP_Eliminar_MXU_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", objmxu.PK_IMU_Cod);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void actualizarMXU(DtoMolduraxUsuario objmxu)
        {
            SqlCommand command = new SqlCommand("SP_ActualizarCant_MXU_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", objmxu.PK_IMU_Cod);
            command.Parameters.AddWithValue("@cant", objmxu.IMU_Cantidad);
            command.Parameters.AddWithValue("@precio", objmxu.DMU_Precio);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void actualizarMXUSol(DtoMolduraxUsuario objmxu)
        {
            SqlCommand command = new SqlCommand("SP_ActualizarSol_MXU_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", objmxu.PK_IMU_Cod);
            command.Parameters.AddWithValue("@sol", objmxu.FK_IS_Cod);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void actualizarMXUSolP(DtoMolduraxUsuario objmxu)
        {
            SqlCommand command = new SqlCommand("SP_ActualizarSol_MXU_P", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", objmxu.PK_IMU_Cod);
            command.Parameters.AddWithValue("@sol", objmxu.FK_IS_Cod);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void registrarMXU(DtoMolduraxUsuario objMolduraxUsuario)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_MXU_P", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idU", objMolduraxUsuario.FK_VU_Cod);
            command.Parameters.AddWithValue("@idM", objMolduraxUsuario.FK_IM_Cod);
            command.Parameters.AddWithValue("@cant", objMolduraxUsuario.IMU_Cantidad);
            command.Parameters.AddWithValue("@pre", objMolduraxUsuario.DMU_Precio);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objMolduraxUsuario.PK_IMU_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }

        public void registrarMXUP(DtoMolduraxUsuario objMolduraxUsuario)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_MXU_PP", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idU", objMolduraxUsuario.FK_VU_Cod);
            command.Parameters.AddWithValue("@cant", objMolduraxUsuario.IMU_Cantidad);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objMolduraxUsuario.PK_IMU_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }

        public DataTable listarMolduraxSxU(DtoMolduraxUsuario dtoMolduraxUsuario)
        {
            DataTable dtList = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_listarmolduraxusuarioGV", conexion);
            command.Parameters.AddWithValue("@dni", dtoMolduraxUsuario.FK_VU_Cod);
            command.Parameters.AddWithValue("@idsol", dtoMolduraxUsuario.FK_IS_Cod);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtList = new DataTable();
            daAdaptador.Fill(dtList);
            conexion.Close();
            return dtList;
        }

        public DataTable listarMolduraxusuarioxincidente(DtoMolduraxUsuario dtoMolduraxUsuario)
        {
            DataTable dtList = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_listarmolduraxusuarioxincidenteGV", conexion);
            command.Parameters.AddWithValue("@dni", dtoMolduraxUsuario.FK_VU_Cod);
            command.Parameters.AddWithValue("@idsol", dtoMolduraxUsuario.FK_IS_Cod);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtList = new DataTable();
            daAdaptador.Fill(dtList);
            conexion.Close();
            return dtList;
        }
        

    }
    
}
