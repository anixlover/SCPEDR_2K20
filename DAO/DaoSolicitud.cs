﻿using System;
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

        public void RegistrarSolcitud_PC(DtoSolicitud objsolicitud)
        {
            SqlCommand command = new SqlCommand("SP_RegistrarSolcitud_PC", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@tipos", objsolicitud.VS_TipoSolicitud);
            command.Parameters.AddWithValue("@cantidad", objsolicitud.IS_Cantidad);
            command.Parameters.AddWithValue("@impt", objsolicitud.DS_ImporteTotal);
            command.Parameters.AddWithValue("@comen", objsolicitud.VS_Comentario);
            command.Parameters.AddWithValue("@femi", objsolicitud.DTS_FechaEmicion);
            command.Parameters.AddWithValue("@epago", objsolicitud.IS_EstadoPago);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objsolicitud.PK_IS_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }

        

        public void RegistrarSolicitud_PP(DtoSolicitud objsolicitud)
        {
            SqlCommand command = new SqlCommand("SP_RegistrarSolcitud_PP", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@tipos", objsolicitud.VS_TipoSolicitud);
            var binary1 = command.Parameters.Add("@imagen", SqlDbType.VarBinary, -1);
            binary1.Value = DBNull.Value;
            command.Parameters.AddWithValue("@medida", objsolicitud.DS_Medida);
            command.Parameters.AddWithValue("@cantidad", objsolicitud.IS_Cantidad);
            command.Parameters.AddWithValue("@aprox", objsolicitud.DS_PrecioAprox);
            command.Parameters.AddWithValue("@comen", objsolicitud.VS_Comentario);
            command.Parameters.AddWithValue("@femi", objsolicitud.DTS_FechaEmicion);
            command.Parameters.AddWithValue("@epago", objsolicitud.IS_EstadoPago);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objsolicitud.PK_IS_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }

        public void RegistrarImgSolicitudP(byte[] bytes, int id)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_Img_SolicitudP", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idSol", id);
            command.Parameters.AddWithValue("@imagen", bytes);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
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
