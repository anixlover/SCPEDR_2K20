using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

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
                objuser.VU_Nombre = (string)reader[1];
                objuser.VU_Apellidos = (string)reader[2];
                objuser.IU_Celular = (int)reader[3];
                objuser.VU_Correo = (string)reader[5];                
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

        public void EnviarCorreoaVendedor(DtoUsuario objuser)
        {
            string Select = "SELECT VU_Correo, VU_Contrasenia, VU_Nombre from T_Usuario where PK_VU_Dni ='"
                + objuser.PK_VU_Dni + "'";

            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();

            if (reader.Read())
            {
                string senderr = "decormoldurassac@gmail.com";
                string senderrPass = "decormolduras";
                string displayName = "DECORMOLDURAS & ROSETONES SAC";

                var recipient = reader["VU_Correo"].ToString();
                var pass = reader["VU_Contrasenia"].ToString();
                var nombre = reader["VU_Nombre"].ToString();

                string body =
                    "<body>" +
                        "<h1>DECORMOLDURAS & ROSETONES SAC</h1>" +
                        "<h4>Bienvenid@ "+ nombre + "</h4>"+
                        "<span>No comparta esto con nadie." +
                        "<br></br><span>Su contraseña es: " + pass + "</span>" +
                        "<br></br><span> Saludos cordiales.<span>" +
                    "</body>";

                MailMessage mail = new MailMessage();
                mail.Subject = "Bienvenido";
                mail.From = new MailAddress(senderr.Trim(), displayName);
                mail.Body = body;
                mail.To.Add(recipient.Trim());
                mail.IsBodyHtml = true;
                //mail.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.Credentials = new System.Net.NetworkCredential(senderr.Trim(), senderrPass.Trim());
                NetworkCredential nc = new NetworkCredential(senderr, senderrPass);
                smtp.Credentials = nc;

                smtp.Send(mail);
            }
        }
        //public void EnviarBoletaxCorreo(DtoMoldura objmoldura, DtoTipoMoldura objtipo)
        //{
        //    //DataTable dt = null;
        //    conexion.Open();
        //    SqlCommand command = new SqlCommand("SP_Obtener_Moldura2", conexion);
        //    command.Parameters.AddWithValue("@codMol", objmoldura.PK_IM_Cod);
        //    SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
        //    command.CommandType = CommandType.StoredProcedure;
        //    //dt = new DataTable();
        //    //daAdaptador.Fill(dt);

        //    SqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        objmoldura.PK_IM_Cod = int.Parse(reader["PK_IM_Cod"].ToString());
        //        objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader["VBM_Imagen"].ToString());
        //        objtipo.VTM_Nombre = reader["VTM_Nombre"].ToString();
        //        objtipo.VTM_UnidadMetrica = reader["MedidaUM"].ToString();
        //        objmoldura.IM_Stock = int.Parse(reader["IM_Stock"].ToString());
        //        objmoldura.DM_Precio = Convert.ToDouble(reader["DM_Precio"].ToString());

        //        string senderr = "decormoldurassac@gmail.com";
        //        string senderrPass = "decormolduras";
        //        string displayName = "DECORMOLDURAS & ROSETONES SAC - Confirmacion de compra";

        //        var recipient = reader["VU_Correo"].ToString();
        //        var pass = reader["VU_Contrasenia"].ToString();
        //        var nombre = reader["VU_Nombre"].ToString();
        //        var nombremoldura = objtipo.VTM_UnidadMetrica;

        //        string body =
        //            "<body>" +
        //                "<h1>DECORMOLDURAS & ROSETONES SAC</h1>" +
        //                "<h2>Resumen del pedido</h2>" +
        //                "<h4>Bienvenid@ " + nombre + "</h4>" +
        //                "<span>No comparta esto con nadie." +
        //                "<br></br><span>Su contraseña es: " + pass + "</span>" +
        //                "<br></br><span> Saludos cordiales.<span>" +
        //            "</body>";

        //        MailMessage mail = new MailMessage();
        //        mail.Subject = "Bienvenido";
        //        mail.From = new MailAddress(senderr.Trim(), displayName);
        //        mail.Body = body;
        //        mail.To.Add(recipient.Trim());
        //        mail.IsBodyHtml = true;
        //        //mail.Priority = MailPriority.Normal;

        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.Port = 587;
        //        smtp.UseDefaultCredentials = false;
        //        smtp.EnableSsl = true;
        //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        //smtp.Credentials = new System.Net.NetworkCredential(senderr.Trim(), senderrPass.Trim());
        //        NetworkCredential nc = new NetworkCredential(senderr, senderrPass);
        //        smtp.Credentials = nc;

        //        smtp.Send(mail);
        //    }
        //    conexion.Close();
        //    //return dt;
        //}



        public void CambiarContra(DtoUsuario ojbusr)
        {
            SqlCommand command = new SqlCommand("SP_ActualizarContra", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@dni", ojbusr.PK_VU_Dni);
            command.Parameters.AddWithValue("@pass", ojbusr.VU_Contraseña);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public void TraeContra(DtoUsuario ojbusr)
        {
            string Select = "SELECT VU_Contrasenia from T_Usuario where PK_VU_Dni = @Dni";

            SqlCommand unComando = new SqlCommand(Select, conexion);
            unComando.Parameters.AddWithValue("@Dni", ojbusr.PK_VU_Dni);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                ojbusr.VU_Contraseña = reader["VU_Contrasenia"].ToString();
            }
            conexion.Close();
        }

        public void TraeData(DtoUsuario ojbusr)
        {
            //string Select = "SELECT VU_Contrasenia from T_Usuario where PK_VU_Dni = @Dni";

            //SqlCommand unComando = new SqlCommand(Select, conexion);
            //unComando.Parameters.AddWithValue("@Dni", ojbusr.PK_VU_Dni);
            //conexion.Open();
            //SqlDataReader reader = unComando.ExecuteReader();
            //bool hayRegistros = reader.Read();
            //if (hayRegistros)
            //{
            //    ojbusr.VU_Contraseña = reader["VU_Contrasenia"].ToString();
            //}
            //conexion.Close();

            string Select = "SELECT * from T_Usuario where PK_VU_Dni = @Dni";

            SqlCommand unComando = new SqlCommand(Select, conexion);

            unComando.Parameters.AddWithValue("@Dni", ojbusr.PK_VU_Dni);
            //_log.CustomWriteOnLog("Realizar venta 1", "txtIdentificadorUsuario.Text " + txtIdentificadorUsuario.Text);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                ojbusr.VU_Nombre = reader["VU_Nombre"].ToString();
                ojbusr.VU_Apellidos = reader["VU_Apellidos"].ToString();
                ojbusr.VU_Correo = reader["VU_Correo"].ToString();
                ojbusr.IU_Celular = Convert.ToInt32(reader["IU_Celular"].ToString());
            }

            //divBodyResultsDNI.Visible = true;
            conexion.Close();
        }
    }
}
