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
    public class DaoSolicitudxMoldura
    {
        SqlConnection conexion;
        public DaoSolicitudxMoldura()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void RegistrarSolicitudxMoldura_LD(DtoSolicitudxMoldura ObjSxm)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_SXM_LD", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idS", ObjSxm.FK_IS_Cod);
            command.Parameters.AddWithValue("@idM", ObjSxm.FK_IM_Cod);
            command.Parameters.AddWithValue("@cant", ObjSxm.ISM_Cantidad);
            command.Parameters.AddWithValue("@precio", ObjSxm.DSM_Precio);

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable ListarSXM_LD(DtoSolicitud objsol)
        {
            DataTable dtmolduras = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_SXM_LD", conexion);
            command.Parameters.AddWithValue("@dni", objsol.FK_VU_Dni);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }
        public void EliminarSolicitudxMoldura_LD(DtoSolicitudxMoldura ObjSxm)
        {
            SqlCommand command = new SqlCommand("SP_Eliminar_SXM_LD", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idS", ObjSxm.FK_IS_Cod);
            command.Parameters.AddWithValue("@idM", ObjSxm.FK_IM_Cod);

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void ObtenerSolicitudxMoldura_LD(DtoMoldura objmoldura, DtoSolicitudxMoldura ObjSxm, DtoTipoMoldura objtipo)
        {
            SqlCommand command = new SqlCommand("SP_Detalle_SXM_LD", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idS", ObjSxm.FK_IS_Cod);
            command.Parameters.AddWithValue("@idM", ObjSxm.FK_IM_Cod);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter moldura = new SqlDataAdapter(command);
            moldura.Fill(ds);
            moldura.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objmoldura.PK_IM_Cod = int.Parse(reader[0].ToString());
                objmoldura.VM_Descripcion = reader[1].ToString();
                objtipo.PK_ITM_Tipo = int.Parse(reader[2].ToString());
                objtipo.VTM_Nombre = reader[3].ToString();
                objmoldura.DM_Medida = Convert.ToDouble(reader[4].ToString());
                objtipo.VTM_UnidadMetrica = reader[5].ToString();
                ObjSxm.ISM_Cantidad = int.Parse(reader[6].ToString());
                ObjSxm.DSM_Precio = double.Parse(reader[7].ToString());
                objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader[8].ToString());
            }
            conexion.Close();
            conexion.Dispose();
        }


    }
    
}
