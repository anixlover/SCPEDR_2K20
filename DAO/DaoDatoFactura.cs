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
    public class DaoDatoFactura
    {
        SqlConnection conexion;
        public DaoDatoFactura()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public int UltimoID()
        {
            SqlCommand unComando = new SqlCommand("select Max(PK_IDF_Cod) from T_DatoFactura ", conexion);
            conexion.Open();
            var ultimo = unComando.ExecuteScalar();
            conexion.Close();
            return Convert.ToInt32(ultimo);
        }
        public void InsertarDatoFactura(DtoDatoFactura factura)
        {
            SqlCommand command = new SqlCommand("SP_InsertarDatoFactura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", factura.PK_IDF_Cod);
            command.Parameters.AddWithValue("@ruc", factura.IDF_RUC);
            command.Parameters.AddWithValue("@dni", factura.FK_VU_DNI);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public bool selectRUC(DtoDatoFactura objfactura)
        {
            string Select = "SELECT * from T_DatoFactura where FK_VU_Dni ='" + objfactura.FK_VU_DNI + "' and VDF_Ruc='"+objfactura.IDF_RUC+"'";
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objfactura.IDF_RUC = (string)reader[1];
            }
            conexion.Close();
            return hayRegistros;
        }
    }
}
