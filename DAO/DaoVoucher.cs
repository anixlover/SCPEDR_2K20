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
            cmd.Parameters.AddWithValue("@foto", Objvoucher.VBV_Foto);
            cmd.Parameters.AddWithValue("@importe", Objvoucher.DV_ImporteDepositado);
            cmd.Parameters.AddWithValue("@comentario", Objvoucher.VV_Comentario);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
