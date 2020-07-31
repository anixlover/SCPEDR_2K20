using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using DAO;
using CTR;
using System.Data.SqlClient;
using System.Configuration;

public partial class CambiarContraseña : System.Web.UI.Page
{
    DtoUsuario dtoUser = new DtoUsuario();
    SqlConnection conexion = new SqlConnection(ConexionBD.CadenaConexion);
    CtrUsuario ctrusr = new CtrUsuario();
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                if (Session["DNIUsuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("registrar pedido personalizado", ex.Message + "Stac" + ex.StackTrace);
            }
        }
    }

    protected void btnsiguiente_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtpass.Text == "" | txtpass1.Text == "" | txtpass2.Text == "")
            {
                Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage4()");
                return;
            }
            if (txtpass1.Text != txtpass2.Text)
            {
                Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage1()");
          
                return;
            }
    
            if (txtpass1.Text.Length <8)
            {
                Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage6()");
                return;
            }

            dtoUser.FK_ITU_Cod = 1;
            string dni = Session["DNIUsuario"].ToString();
            string pass = Session["Contrasenia"].ToString();
            _log.CustomWriteOnLog("cambiarcontrasenia", "-------------------------------------------------------------------------------------------------------------");
            _log.CustomWriteOnLog("cambiarcontrasenia", "objtipousersession : " + dtoUser.FK_ITU_Cod);
            _log.CustomWriteOnLog("cambiarcontrasenia", "objpasssession : " + pass);
            _log.CustomWriteOnLog("cambiarcontrasenia", "objdni : " + dni);
            _log.CustomWriteOnLog("cambiarcontrasenia", "-------------------------------------------------------------------------------------------------------------");

            //no tocar explota
            dtoUser.PK_VU_Dni = dni;
            ctrusr.TraePass(dtoUser);

            if (dtoUser.VU_Contraseña != txtpass.Text)
            {
                Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage2()");
                return;
            }
            else
            {
                dtoUser.PK_VU_Dni = dni;
                dtoUser.VU_Contraseña = txtpass1.Text;
                ctrusr.CambiarContrasenia(dtoUser);
                Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage3()");
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("cambiarcontrasenia", "Error :" + ex.Message + "StackTrace" + ex.StackTrace);
            Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage5()");
            return;
        }
    }
}