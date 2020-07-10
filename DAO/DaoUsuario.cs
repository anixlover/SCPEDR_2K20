﻿using System;
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
        public int validacionLogin(string usuario, string clave)
        {

            int valor_retornado = 0;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM T_USUARIO as U WHERE" +
                " U.PK_VU_Dni = '" + usuario + "' AND U.VU_Contrasenia = '" + clave + "'", conexion);



            Console.WriteLine(cmd);
            conexion.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {    //valor_retornado = reader[0].ToString();
                valor_retornado = int.Parse(reader[0].ToString());

            }
            conexion.Close();

            return valor_retornado;
        }

        public DtoUsuario datosUsuario(String usuario)
        {
            SqlCommand cmd = new SqlCommand("select U.FK_ITU_Cod," +
                "U.VU_Nombre," +
                "U.VU_Apellidos," +
                "U.VU_Correo, " +
                "U.PK_VU_Dni," +
                "U.IU_Celular," +
                "U.DTU_FechaNac" +
                " from T_Usuario as U " +
                "where U.PK_VU_Dni = '" + usuario + "'", conexion);

            DtoUsuario usuarioDto = new DtoUsuario();
            DtoTipoUsuario tipousuarioDto = new DtoTipoUsuario();



            conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                tipousuarioDto.PK_ITU_Cod = int.Parse(reader[0].ToString());
                usuarioDto.FK_ITU_Cod = int.Parse(reader[0].ToString());
                usuarioDto.VU_Nombre = reader[1].ToString();
                usuarioDto.VU_Apellidos = reader[2].ToString();
                usuarioDto.VU_Correo = reader[3].ToString();
                usuarioDto.PK_VU_Dni = reader[4].ToString();
                usuarioDto.IU_Celular = int.Parse(reader[5].ToString());
                usuarioDto.DTU_FechaNac = DateTime.Parse(reader[6].ToString());

            }
            conexion.Close();

            return (usuarioDto);
        }
    }
}
