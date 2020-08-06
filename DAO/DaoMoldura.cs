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
    public class DaoMoldura
    {
        SqlConnection conexion;
        public DaoMoldura()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataTable ListarMolduras()
        {
            DataTable dtmolduras = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Molduras", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }
        public DataTable ListarMoldurasByTipoMoldura(DtoTipoMoldura objtipo)
        {
            DataTable dtmolduras = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Moldura_by_TipoMoldura", conexion);
            command.Parameters.AddWithValue("@idTipoMold", objtipo.PK_ITM_Tipo);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }
        public void RegistrarMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@descripcion", objmoldura.VM_Descripcion);
            //command.Parameters.AddWithValue("@imagen", DBNull.Value);
            var binary1 = command.Parameters.Add("@imagen", SqlDbType.VarBinary, -1);
            binary1.Value = DBNull.Value;
            command.Parameters.AddWithValue("@medida", objmoldura.DM_Medida);
            command.Parameters.AddWithValue("@stock", objmoldura.IM_Stock);
            command.Parameters.AddWithValue("@precio", objmoldura.DM_Precio);
            command.Parameters.AddWithValue("@estado", objmoldura.IM_Estado);
            command.Parameters.AddWithValue("@idtipom", objmoldura.FK_ITM_Tipo);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            //command.ExecuteNonQuery();

            //SqlParameter retValue = new SqlParameter("@NewId", SqlDbType.Int).Direction=Par;
            //retValue.Direction = ParameterDirection.ReturnValue;
            //command.Parameters.Add(retValue);
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objmoldura.PK_IM_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }
        public void RegistrarImgMoldura(byte[] bytes, int id)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_Img_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idMol", id);
            command.Parameters.AddWithValue("@imagen", bytes);
            conexion.Open();
            //SqlParameter retValue = new SqlParameter("@NewId", SqlDbType.Int);
            //retValue.Direction = ParameterDirection.ReturnValue;
            //command.Parameters.Add(retValue);
            //using (SqlDataReader dr = command.ExecuteReader())
            //{
            //    objmoldura.PK_IM_Cod = Convert.ToInt32(retValue.Value);
            //}
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void ActualizarMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Actualizar_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idMol", objmoldura.PK_IM_Cod);
            command.Parameters.AddWithValue("@descripcion", objmoldura.VM_Descripcion);
            command.Parameters.AddWithValue("@medida", objmoldura.DM_Medida);
            command.Parameters.AddWithValue("@stock", objmoldura.IM_Stock);
            command.Parameters.AddWithValue("@precio", objmoldura.DM_Precio);
            command.Parameters.AddWithValue("@estado", objmoldura.IM_Estado);
            command.Parameters.AddWithValue("@idtipom", objmoldura.FK_ITM_Tipo);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void ActualizarImgMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Actualizar_Img_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idMol", objmoldura.PK_IM_Cod);
            command.Parameters.AddWithValue("@imagen", objmoldura.VBM_Imagen);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public DataSet desplegableTipoMoldura()
        {
            SqlDataAdapter tipomol = new SqlDataAdapter("SP_Desplegable_Tipo_Moldura", conexion);
            tipomol.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DS = new DataSet();
            tipomol.Fill(DS);
            return DS;
        }
        public void ObtenerMoldura(DtoMoldura objmoldura, DtoTipoMoldura objtipo)
        {
            SqlCommand command = new SqlCommand("SP_Obtener_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@codMol", objmoldura.PK_IM_Cod);
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
                objmoldura.IM_Estado = int.Parse(reader[6].ToString());
                objmoldura.IM_Stock = int.Parse(reader[7].ToString());
                objmoldura.DM_Precio = Convert.ToDouble(reader[8].ToString());
                objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader[9].ToString());
            }

            conexion.Close();
            conexion.Dispose();
        }

        public DataTable ObtenerMoldura2(DtoMoldura objmoldura, DtoTipoMoldura objtipo)
        {
            DataTable dt = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Obtener_Moldura2", conexion);
            command.Parameters.AddWithValue("@codMol", objmoldura.PK_IM_Cod);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            daAdaptador.Fill(dt);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                objmoldura.PK_IM_Cod = int.Parse(reader["PK_IM_Cod"].ToString());
                objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader["VBM_Imagen"].ToString());
                objtipo.VTM_Nombre = reader["VTM_Nombre"].ToString();
                objtipo.VTM_UnidadMetrica = reader["MedidaUM"].ToString();
                objmoldura.IM_Stock = int.Parse(reader["IM_Stock"].ToString());
                objmoldura.DM_Precio = Convert.ToDouble(reader["DM_Precio"].ToString());
            }
            conexion.Close();
            return dt;
        }
      
        public bool SelectMolduraID(DtoMoldura objmoldura)
        {
            string Select = "SELECT * from T_Moldura where PK_IM_Cod =" + objmoldura.PK_IM_Cod;

            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objmoldura.PK_IM_Cod = int.Parse(reader[0].ToString());
                objmoldura.VM_Descripcion = reader[1].ToString();
                objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader[2].ToString());
                objmoldura.IM_Stock = int.Parse(reader[3].ToString());
                objmoldura.DM_Medida = Convert.ToDouble(reader[4].ToString());
                objmoldura.DM_Precio = Convert.ToDouble(reader[5].ToString());
            }
            conexion.Close();
            return hayRegistros;
        }
        public void ObtenerImgMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_GetImageById", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", objmoldura.PK_IM_Cod);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter moldura = new SqlDataAdapter(command);
            moldura.Fill(ds);
            moldura.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader[1].ToString());
                objmoldura.VM_Descripcion = reader[1].ToString();
                objmoldura.IM_Stock = int.Parse(reader[2].ToString());
            }
            conexion.Close();
            conexion.Dispose();
        }

        public void ObtenerMoldurasxTipoMoldura(DtoMoldura objmoldura, DtoTipoMoldura objtipo)
        {
            SqlCommand command = new SqlCommand("SP_Detalles_Moldura_by_TipoMoldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@codMol", objmoldura.PK_IM_Cod);
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
                objmoldura.IM_Estado = int.Parse(reader[6].ToString());
                objmoldura.IM_Stock = int.Parse(reader[7].ToString());
                objmoldura.DM_Precio = Convert.ToDouble(reader[8].ToString());
                objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader[9].ToString());
            }
            conexion.Close();
            conexion.Dispose();
        }
        public DataTable ListarMoldurasPaginaInicial(DtoTipoMoldura objtipo)
        {
            DataTable dtmolduras = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Detalles_Moldura_by_TipoMoldura", conexion);
            command.Parameters.AddWithValue("@idTipoMold", objtipo.PK_ITM_Tipo);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }

        public DataTable ListarTodoMolduras(DtoMoldura objmoldura)
        {
            DataTable dtmolduras = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Todo_Moldura", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }
        public int StockMoldura(DtoMoldura objMoldura)
        {
            try
            {
                SqlConnection con = new SqlConnection("data source=DESKTOP-IAELG6V\\SQLEXPRESS; initial catalog=BD_SCPEDR; integrated security=SSPI;");
                int valor_retornado = 0;
                SqlCommand cmd = new SqlCommand("SELECT IM_Stock FROM T_Moldura WHERE PK_IM_Cod=" + objMoldura.PK_IM_Cod, con);

                Console.WriteLine(cmd);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    valor_retornado = int.Parse(reader[0].ToString());

                }
                con.Close();

                return valor_retornado;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public void PrecioAprox(DtoMoldura objMoldura)
        {
            SqlCommand command = new SqlCommand("SP_PrecioAprox", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idtipomol", objMoldura.FK_ITM_Tipo);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public double Aprox(DtoMoldura objMoldura)
        {
            //SqlConnection con = new SqlConnection(@"data source=DESKTOP-4LVLNRM; initial catalog=BD_SCPEDR; integrated security=SSPI;");
            //double aprox = 0;
            SqlCommand cmd = new SqlCommand("select sum(DM_Precio)/ COUNT(*) as promedio from T_Moldura where FK_ITM_Moldura = " + objMoldura.FK_ITM_Tipo, conexion);
            Console.WriteLine(cmd);
            conexion.Open();
            string aprox = cmd.ExecuteScalar().ToString();
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.Read())
            //{
            //    aprox = double.Parse(reader[0].ToString());

            //}
            conexion.Close();
            if (aprox == "")
            {
                return 0;
            }
            //return aprox;
            return Convert.ToDouble(aprox);
            /** 
             * SqlCommand unComando = new SqlCommand("select DS_ImporteTotal from T_Solicitud where PK_IS_Cod =" + objsolicitud.FK_IS_Cod, conexion);
            conexion.Open();
            var ultimo = unComando.ExecuteScalar().ToString();
            conexion.Close();
            return Convert.ToDouble(ultimo);**/
        }

        public void ActualizarStockxMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Actualizar_Stock_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idMol", objmoldura.PK_IM_Cod);
            command.Parameters.AddWithValue("@stock", objmoldura.IM_Stock);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable CalcularSubtotal(DtoMoldura objmoldura, DtoTipoMoldura objtipo, double cant)
        {
            DataTable dt = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_CalcularSubtotal", conexion);
            command.Parameters.AddWithValue("@codMol", objmoldura.PK_IM_Cod);
            command.Parameters.AddWithValue("@cantidad", cant);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            daAdaptador.Fill(dt);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                objmoldura.PK_IM_Cod = int.Parse(reader["PK_IM_Cod"].ToString());
                objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader["VBM_Imagen"].ToString());
                objtipo.VTM_Nombre = reader["VTM_Nombre"].ToString();
                objtipo.VTM_UnidadMetrica = reader["MedidaUM"].ToString();
                objmoldura.IM_Stock = int.Parse(reader["IM_Stock"].ToString());
                objmoldura.DM_Precio = Convert.ToDouble(reader["DM_Precio"].ToString());
                objmoldura.DM_Medida = Double.Parse(reader["Subtotal"].ToString());

            }
            conexion.Close();
            return dt;
        }





    }
}
