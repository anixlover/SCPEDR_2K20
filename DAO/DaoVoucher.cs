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
    public class DaoVoucher
    {
        SqlConnection conexion;
        public DaoVoucher()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void InsertarVoucher(DtoVoucher Objvoucher)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarVoucher", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numvoucher", Objvoucher.PK_VV_NumVoucher);
            cmd.Parameters.AddWithValue("@importe", Objvoucher.DV_ImporteDepositado);
            cmd.Parameters.AddWithValue("@comentario", Objvoucher.VV_Comentario);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void InsertarImagenVoucher(byte[] obj, string pkvoucher)
        {
            SqlCommand cmd = new SqlCommand("RegistrarImagenVoucher", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numvoucher", pkvoucher);
            cmd.Parameters.AddWithValue("@foto",obj);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public bool SelectPagoVoucher(DtoVoucher v)
        {
            string Select = "SELECT * from T_Voucher where PK_VV_NumVoucher ='" +  v.PK_VV_NumVoucher+"'";
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                v.VBV_Foto = (byte[])reader[1];
                v.DV_ImporteDepositado = Convert.ToDouble(reader[2].ToString());
            }
            conexion.Close();
            return hayRegistros;
        }
    }
}
