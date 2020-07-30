using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

public partial class RegistrarClienteUE_1 : System.Web.UI.Page
{
    DtoUsuario objuser = new DtoUsuario();
    CtrUsuario objuserneg = new CtrUsuario();
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //RadioButton1.Checked = true;
            //txtExtranjero.Visible = false;     
        }        
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        if (txtNombres.Text == "" | txtApellidos.Text == "" | txtCelular.Text == "" | txtCorreo.Text == "" | txtContraseña.Text == "" | txtFechNac.Text == "")
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'})</script>");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'});", true);
            return;
        }
        if (txtDNI.Text == "" && valorObtenidoRBTN.Value=="1")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'});", true);
            //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'})</script>");
            return;
        }
        if (txtExtranjero.Text == "" && valorObtenidoRBTN.Value == "2")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'});", true);
            //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'})</script>");
            return;
        }
        //DtoUsuario objuser = new DtoUsuario(txtDNI.Text, txtNombres.Text, txtApellidos.Text, Convert.ToInt32(txtCelular.Text), Convert.ToDateTime(txtFechNac.Text), txtCorreo.Text, txtContraseña.Text, 1);
        if (valorObtenidoRBTN.Value != "1" & valorObtenidoRBTN.Value != "2")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'seleccione un DOCUMENTO DE IDENTIDAD!!'});", true);
            //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Seleccione documento de identidad!!'})</script>");
            return;
        }
        if (valorObtenidoRBTN.Value == "1")
        {
            objuser.PK_VU_Dni = txtDNI.Text;
        }
        if (valorObtenidoRBTN.Value == "2")
        {
            objuser.PK_VU_Dni = txtExtranjero.Text;
        }
        objuser.VU_Nombre = txtNombres.Text;
        objuser.VU_Apellidos = txtApellidos.Text;
        objuser.IU_Celular = Convert.ToInt32(txtCelular.Text);
        objuser.DTU_FechaNac = Convert.ToDateTime(txtFechNac.Text);
        objuser.VU_Correo = txtCorreo.Text;
        if (txtContraseña.Text != txtcontra2.Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Confirme su CONTRASEÑA!!'});", true);
        }
        objuser.VU_Contraseña = txtContraseña.Text;

        objuserneg.RegistrarUsuario(objuser);
        msjeRegistrar(objuser);
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Home.aspx");
    }
    private void msjeRegistrar(DtoUsuario u)
    {
        switch (u.error)
        {
            case 1:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Nombre INVALIDO!!'});", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Nombre INVALIDO!!'})</script>");
                break;
            case 2:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Apellido INVALIDO!!'});", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Apellido INVALIDO!!!'})</script>");
                break;
            case 3:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Correo INVALIDO!!'});", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Correo INVALIDO!!'})</script>");
                break;
            case 4:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Contraseña muy CORTA!!'});", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Contraseña muy CORTA!!'})</script>");
                break;
            case 5:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'DNI " + u.PK_VU_Dni + " ya registrado'});", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'DNI " + u.PK_VU_Dni + " ya registrado'})</script>");
                break;
            case 6:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Celular " + u.IU_Celular + " ya registrado'});", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Celular " + u.IU_Celular + " ya registrado'})</script>"); ;
                break;
            case 7:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Correo " + u.VU_Correo + " ya registrado'});", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Correo " + u.VU_Correo + " ya registrado'})</script>");
                break;
            case 8:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'No se admite MENORES!!!'});", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Correo " + u.VU_Correo + " ya registrado'})</script>");
                break;
            case 77:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({title:'Se ha registrado CORRECTAMENTE!',text:'Datos ENVIADOS!',icon:'success'}, function(){window.location.href='Login.aspx'});", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal('Registro Exitoso!','Datos ENVIADOS!','success')</script>");
                break;
        }
    }
}