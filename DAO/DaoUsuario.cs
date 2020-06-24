using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;


namespace DAO
{
    public class DaoUsuario
    {
        SqlConnection conexion;
        public DaoUsuario()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void InsertarCliente(DtoUsuario ObjUsuario)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_Usuario", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", ObjUsuario.PK_VU_Dni);
            command.Parameters.AddWithValue("@nombre", ObjUsuario.VU_Nombre);
            command.Parameters.AddWithValue("@apellido", ObjUsuario.VU_Apellidos);
            command.Parameters.AddWithValue("@celular", ObjUsuario.IU_Celular);
            command.Parameters.AddWithValue("@fecha", ObjUsuario.DTU_FechaNac);
            command.Parameters.AddWithValue("@correo", ObjUsuario.VU_Correo);
            command.Parameters.AddWithValue("@contra", ObjUsuario.VU_Contraseña);

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public bool SelectUsuario(DtoUsuario objuser)
        {
            string Select = "SELECT * from T_Usuario where PK_VU_Dni ='" + objuser.PK_VU_Dni + "'";
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objuser.PK_VU_Dni = (string)reader[0];
                objuser.IU_Celular = (int)reader[3];
            }
            else objuser.error = 1;
            conexion.Close();
            return hayRegistros;
        }
        public bool SelectUsuarioXcelular(DtoUsuario objuser)
        {
            string Select = "SELECT * from T_Usuario where IU_Celular ='" + objuser.IU_Celular + "'";
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objuser.PK_VU_Dni = (string)reader[0];
                objuser.IU_Celular = (int)reader[3];
            }
            else objuser.error = 1;
            conexion.Close();
            return hayRegistros;
        }
        public bool SelectUsuarioXcorreo(DtoUsuario objuser)
        {
            string Select = "SELECT * from T_Usuario where VU_Correo ='" + objuser.VU_Correo + "'";
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objuser.PK_VU_Dni = (string)reader[0];
                objuser.IU_Celular = (int)reader[3];
                objuser.VU_Correo = (string)reader[5];
            }
            else objuser.error = 1;
            conexion.Close();
            return hayRegistros;
        }
    }
}
