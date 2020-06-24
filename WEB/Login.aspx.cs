using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DAO;
using DTO;
using CTR;
using System.Security.Cryptography;
using System.Text;

public partial class Login :  System.Web.UI.Page        
{
    SqlConnection conexion;
    protected void Page_Load(object sender, EventArgs e)
    {
        conexion = new SqlConnection(ConexionBD.CadenaConexion);
    }

        DtoUsuario usr = new DtoUsuario();

    //public static string GetSHA256(string str)
    //{
    //    SHA256 sha256 = SHA256Managed.Create();
    //    ASCIIEncoding encoding = new ASCIIEncoding();
    //    byte[] stream = null;
    //    StringBuilder sb = new StringBuilder();
    //    stream = sha256.ComputeHash(encoding.GetBytes(str));
    //    for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
    //    return sb.ToString();
    //}

    Log lo = new Log();
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string dni = txtDni.Text;
            string pass = txtContraseña.Text;
            //string epass = GetSHA256(pass);

            SqlCommand Comando = new SqlCommand("SELECT PK_VU_Dni, VU_Contrasenia, FK_ITU_Cod FROM T_Usuario WHERE " +
            "PK_VU_Dni = @ID and VU_Contrasenia=@pass ", conexion);
            Comando.Parameters.AddWithValue("@ID", dni);
            Comando.Parameters.AddWithValue("@pass", pass);
            conexion.Open();
            SqlDataReader registro = Comando.ExecuteReader();

            //if (dni == "")
            //{
            //    string script = "alert(\"Ingrese Usuario y contraseña\");";
            //    ScriptManager.RegisterStartupScript(this, GetType(),
            //                                      "ServerControlScript", script, true);
            //}

            //if (pass == "")
            //{
            //    string script = "alert(\"Ingrese su contraseña\");";
            //    ScriptManager.RegisterStartupScript(this, GetType(),
            //                                      "ServerControlScript", script, true);
            //}

            if (registro.Read())
            {
                
                var rol = registro["FK_ITU_Cod"].ToString();
                if (rol == "1")     /*cliente*/
                {
                    Session["dni"] = usr.FK_ITU_Cod;
                    Response.Redirect("MasterPage.aspx");
                }
                else if (rol == "2")   /*gerente*/
                {
                    Response.Redirect("GestionCatalogo.aspx");
                }
                else if (rol == "3")     /*vendedor*/
                {
                    Response.Redirect("MasterPage.aspx");
                }
                else if (rol == "4")     /*trabajador*/
                {
                    Response.Redirect("MasterPage.aspx");
                }
                else
                {
                    string script2 = "alert(\"Usuario o contrseña incorrecta\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                    "ServerControlScript", script2, true);
                    Response.Redirect("Login.aspx");
                }

            }

            //else
            //{
            //    if (txtDni.Text == null && txtContraseña.Text == null)
            //    {
            //        string script2 = "alert(\"Usuario o contrseña incorrecta\");";
            //        ScriptManager.RegisterStartupScript(this, GetType(),
            //        "ServerControlScript", script2, true);

            //    }
            //    else if (txtContraseña.Text == null)
            //    {
            //        string script = "alert(\"Usuario o contrseña incorrecta\");";
            //        ScriptManager.RegisterStartupScript(this, GetType(),
            //        "ServerControlScript", script, true);
            //    }
            //    else if (txtDni.Text == null)
            //    {
            //        string script = "alert(\"Usuario o contrseña incorrecta\");";
            //        ScriptManager.RegisterStartupScript(this, GetType(),
            //        "ServerControlScript", script, true);
            //    }

            //}

        }
        catch(Exception ex)
        {
            lo.CustomWriteOnLog("login", "Error = " + ex.Message + "stack"+  ex.StackTrace);
            string script = "alert(\"Error,please reload\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
        }

    }

}


//        try
//        {
//            string Select = "select PK_VU_Dni , VU_Contrasenia from T_Usuario where PK_VU_Dni = '"
//                + txtDni.Text + "'and VU_Contrasenia = '" + txtContraseña.Text + "'";
//SqlCommand unComando = new SqlCommand(Select, conexion);
//conexion.Open();
//            SqlDataReader reader = unComando.ExecuteReader();
//            if (reader.Read())
//            {
//                string script = "alert(\"Bienvenido a SCPEDR\");";
//ScriptManager.RegisterStartupScript(this, GetType(),
//                                      "ServerControlScript", script, true);
//conexion.Close();
//Response.Redirect("MasterPage.aspx");

//}
//            else
//            {
//                conexion.Close();
//                string script = "alert(\"Usuario o contrseña incorrecta\");";
//ScriptManager.RegisterStartupScript(this, GetType(),
//                                      "ServerControlScript", script, true);
//txtDni.Text = "";
//txtContraseña.Text = "";
//}
//        }
//        catch (Exception)
//        {
//            string script = "alert(\"Error mdfk\");";
//ScriptManager.RegisterStartupScript(this, GetType(),
//                                  "ServerControlScript", script, true);
//}




//public async Task<IActionResult> LogIn(login user)
//{
//    //    bool dni = _context.TUsuario.Any(x => x.PkIuDni == user.Dni);
//    //    bool contra = _context.TUsuario.Any(con => con.VuContraseña == user.Contra);


//    var us = (from c in _context.TUsuario
//              where c.PkIuDni == user.Dni && c.VuContraseña == user.Contra
//              select new usr()
//              {
//                  dniusr = c.PkIuDni,



//              }).FirstOrDefault();
//    var us1 = (from c in _context.TUsuario
//               where c.PkIuDni == user.Dni && c.VuContraseña == user.Contra
//               select new usr()
//               {
//                   passusr = c.VuContraseña,


//               }).FirstOrDefault();
//    var us2 = (from c in _context.TUsuario
//               where c.PkIuDni == user.Dni && c.VuContraseña == user.Contra
//               select new usr()
//               {
//                   tipousr = c.FkItuTipoUsuario


//               }).FirstOrDefault();


//    if (us == null && us1 == null && us2 == null)
//    {
//        ModelState.AddModelError("Errores", "Los datos son incorrectos");

//        return RedirectToAction("LogIn", "Acces");

//    }

//    else
//    {
//        bool dni = _context.TUsuario.Any(x => x.PkIuDni == us.dniusr);
//        bool contra = _context.TUsuario.Any(con => con.VuContraseña == us1.passusr);

//        if (dni == true && contra == true && us2.tipousr == 1)
//        {
//            await Task.Delay(100);
//            return RedirectToAction("ParticipanteView", "Participante");

//        }
//        else if (dni == true && contra == true && us2.tipousr == 2) //ariana
//        {

//            return RedirectToAction("AdministradorView", "Admin");
//        }
//        else if (dni == true && contra == true && us2.tipousr == 3) //ariana
//        {

//            return RedirectToAction("JuradoView", "Jurado");
//        }
//        else if (dni == true && contra == true && us2.tipousr == 4) //ariana
//        {

//            return RedirectToAction("PresentadorView", "Presentador");
//        }
//        else
//        {
//            return RedirectToAction("LogIn", "Acces");
//        }
//    }
//}