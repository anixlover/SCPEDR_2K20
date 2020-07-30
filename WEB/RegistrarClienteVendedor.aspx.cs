using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using DAO;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;



public partial class RegistrarClienteVendedor : System.Web.UI.Page
{
    DtoUsuario objuser = new DtoUsuario();
    CtrUsuario objuserneg = new CtrUsuario();
    SqlConnection conexion = new SqlConnection(ConexionBD.CadenaConexion);
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _log.CustomWriteOnLog("Registro de usuario", "_______________________________________________________________________________ENTRO A FUNCION REGISTRAR_____________________________________________________________________");
            RadioButton1.Checked = true;
            txtExtranjero.Visible = false;
        }
    }
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {        
        try
        {
            if (txtNombres.Text == "" | txtApellidos.Text == "" | txtCelular.Text == "" | txtCorreo.Text == "" | txtFechaNacimiento.Text == "")
            {
                //lblMsje.Text = "COMPLETE EL FORMULARIO!!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'});", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "mensajes","<script>swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'})</script>");
                return;
            }
            if (txtDNI.Text == "" && RadioButton1.Checked == true)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'});", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'})</script>");
                return;
            }
            if (txtExtranjero.Text == "" && RadioButton2.Checked == true)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'});", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'})</script>");
                return;
            }
            //DtoUsuario objuser = new DtoUsuario(txtDNI.Text, txtNombres.Text, txtApellidos.Text, Convert.ToInt32(txtCelular.Text), Convert.ToDateTime(txtFechNac.Text), txtCorreo.Text, txtContraseña.Text, 1);
            _log.CustomWriteOnLog("Registro de usuario", "_______________________________________________________________________________ENTRO A FUNCION REGISTRAR_____________________________________________________________________");

            _log.CustomWriteOnLog("Registro de usuario", "Valores ingresados");
            _log.CustomWriteOnLog("Registro de usuario", "DNI = " + txtDNI.Text);
            _log.CustomWriteOnLog("Registro de usuario", "txtNombres = " + txtNombres.Text);
            _log.CustomWriteOnLog("Registro de usuario", "txtApellidos = " + txtApellidos.Text);
            _log.CustomWriteOnLog("Registro de usuario", "txtCelular = " + txtCelular.Text);
            _log.CustomWriteOnLog("Registro de usuario", "txtFechaNacimiento = " + txtFechaNacimiento.Text);
            _log.CustomWriteOnLog("Registro de usuario", "txtCorreo = " + txtCorreo.Text);
            //_log.CustomWriteOnLog("Registro de usuario", "txtContrasenia = " + txtContrasenia.Text);

            if (RadioButton1.Checked == true)
            {
                objuser.PK_VU_Dni = txtDNI.Text;
                objuser.VU_Contraseña ="01"+ txtDNI.Text + DateTime.Today.Day.ToString();
            }
            if (RadioButton2.Checked == true)
            {
                objuser.PK_VU_Dni = txtExtranjero.Text;
                objuser.VU_Contraseña ="01"+txtExtranjero.Text+DateTime.Today.Day.ToString();
            }

            objuser.VU_Nombre = txtNombres.Text;
            objuser.VU_Apellidos = txtApellidos.Text;
            objuser.IU_Celular = Convert.ToInt32(txtCelular.Text);
            DateTime a = new DateTime();
            a = Convert.ToDateTime(txtFechaNacimiento.Text);
            DateTime b = new DateTime(a.Year, a.Month, a.Day);


            objuser.DTU_FechaNac = Convert.ToDateTime(b.ToString("yyyy-MM-dd hh:mm:ss"));
            objuser.VU_Correo = txtCorreo.Text;            

            objuserneg.RegistrarUsuario(objuser);
            //objuser.PK_VU_Dni =  txtDNI.Text;
            //objuserneg.EnviarCorreoVendedor(objuser);

            msjeRegistrar(objuser);
            if (objuser.error == 77)
            {
                txtFechaNacimiento.Text = "00/00/00 00:00:00";
                txtExtranjero.Text = "";
                txtDNI.Text = "";
                txtNombres.Text = "";
                txtApellidos.Text = "";
                txtCelular.Text = "";
                txtCorreo.Text = "";
                //txtContrasenia.Text = "";        
                objuserneg.EnviarCorreoVendedor(objuser);
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("Registro de usuario", "Error  = " + ex.Message);
            throw;
        }
    }

    private void msjeRegistrar(DtoUsuario u)
    {
        switch (u.error)
        {
            case 1:
                //lblMsje.Text = "Nombre(s) invalido";
                _log.CustomWriteOnLog("Registro de usuario", "Nombre invalido");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Nombre invalido', 'bottom', 'center', null, null);", true);
                break;
            case 2:
                _log.CustomWriteOnLog("Registro de usuario", "Apellido invalido");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Apellido invalido', 'bottom', 'center', null, null);", true);
                //lblMsje.Text = "Apellido(s) invalido";
                break;
            case 3:
                //lblMsje.Text = "Correo invalido";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Correo invalido', 'bottom', 'center', null, null);", true);
                _log.CustomWriteOnLog("Registro de usuario", "Correo invalido");
                break;
            case 4:
                //lblMsje.Text = "Contraseña muy corta";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Contraseña muy corta', 'bottom', 'center', null, null);", true);
                _log.CustomWriteOnLog("Registro de usuario", "Contraseña corta");
                break;
            case 5:
                //lblMsje.Text = "DNI [" + u.PK_VU_Dni + "] ya está registrado";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'DNI ya registrado', 'bottom', 'center', null, null);", true);
                _log.CustomWriteOnLog("Registro de usuario", "DNI ya registrado");
                break;
            case 6:
                //lblMsje.Text = "Celular [" + u.IU_Celular + "] ya está registrado";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Celular ya registrado', 'bottom', 'center', null, null);", true);
                _log.CustomWriteOnLog("Registro de usuario", "Celular ya registrado");
                break;
            case 7:
                //lblMsje.Text = "Correo [" + u.VU_Correo + "] ya está registrado";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Correo ya registrado', 'bottom', 'center', null, null);", true);
                _log.CustomWriteOnLog("Registro de usuario", "Correo ya registrado");
                break;
            case 8:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'No se admite MENORES!!!'});", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Correo " + u.VU_Correo + " ya registrado'})</script>");
                break;
            case 77:
                //lblMsje.Text = "REGISTRO EXITOSO!!";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Registro EXITOSO!!!', 'bottom', 'center', null, null);", true);
                _log.CustomWriteOnLog("Registro de usuario", "Registro ");
                break;
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        
    }

    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        txtDNI.Visible = true;
        txtExtranjero.Visible = false;
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        txtExtranjero.Visible = true;
        txtDNI.Visible = false;
    }
}