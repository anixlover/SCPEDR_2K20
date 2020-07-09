using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;


namespace DAO
{
    public class DaoPago
    {
        SqlConnection conexion;
        public DaoPago()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void InsertarPago(DtoPago objpago)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarPago", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tipo", objpago.IP_TipoPago);
            cmd.Parameters.AddWithValue("@pagado", objpago.DP_ImportePagado);
            cmd.Parameters.AddWithValue("@restante", objpago.DP_ImporteRestante);
            cmd.Parameters.AddWithValue("@tipocertificado", objpago.IP_TipoCertificado);
            cmd.Parameters.AddWithValue("@ruc", objpago.VP_RUC);
            cmd.Parameters.AddWithValue("@solicitud", objpago.FK_IS_Cod);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public double SelectCosto(DtoPago objsolicitud)
        {
            SqlCommand unComando = new SqlCommand("select DS_ImporteTotal from T_Solicitud where PK_IS_Cod =" + objsolicitud.FK_IS_Cod, conexion);
            conexion.Open();
            var ultimo = unComando.ExecuteScalar().ToString();
            conexion.Close();
            return Convert.ToDouble(ultimo);
        }
    }
}
