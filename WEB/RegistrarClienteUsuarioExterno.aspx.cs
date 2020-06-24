using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

public partial class RegistrarClienteUsuarioExterno : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        //if (txtDNI.Text == "" | txtNombres.Text == "" | txtApellidos.Text == "" | txtCelular.Text == "" | txtCorreo.Text == "" | txtContraseña.Text == "" | txtFechNac.Text == "")
        //{
        //    lblMsje.Text = "COMPLETE EL FORMULARIO!!";
        //    return;
        //}
        //DtoUsuario objuser = new DtoUsuario(txtDNI.Text, txtNombres.Text, txtApellidos.Text, Convert.ToInt32(txtCelular.Text), Convert.ToDateTime(txtFechNac.Text), txtCorreo.Text, txtContraseña.Text, 1);
        DtoUsuario objuser = new DtoUsuario();
        objuser.PK_VU_Dni = txtDNI.Text;
        objuser.VU_Nombre = txtNombres.Text;
        objuser.VU_Apellidos = txtApellidos.Text;
        objuser.IU_Celular = Convert.ToInt32(txtCelular.Text);
        objuser.DTU_FechaNac = Convert.ToDateTime(txtFechNac.Text);
        objuser.VU_Correo = txtCorreo.Text;
        objuser.VU_Contraseña = txtContraseña.Text;

        CtrUsuario objuserneg = new CtrUsuario();
        objuserneg.RegistrarUsuario(objuser);
        //msjeRegistrar(objuser);
        if (objuser.error == 77)
        {
            txtDNI.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtCelular.Text = "";
            txtCorreo.Text = "";
            txtContraseña.Text = "";
        }



    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Home.aspx");
    }

    //private void msjeRegistrar(DtoUsuario u)
    //{
    //    switch (u.error)
    //    {
    //        case 1:
    //            lblMsje.Text = "Nombre(s) invalido";
    //            break;
    //        case 2:
    //            lblMsje.Text = "Apellido(s) invalido";
    //            break;
    //        case 3:
    //            lblMsje.Text = "Correo invalido";
    //            break;
    //        case 4:
    //            lblMsje.Text = "Contraseña muy corta";
    //            break;
    //        case 5:
    //            lblMsje.Text = "DNI [" + u.PK_VU_Dni + "] ya está registrado";
    //            break;
    //        case 6:
    //            lblMsje.Text = "Celular [" + u.IU_Celular + "] ya está registrado";
    //            break;
    //        case 7:
    //            lblMsje.Text = "Correo [" + u.VU_Correo + "] ya está registrado";
    //            break;
    //        case 77:
    //            lblMsje.Text = "REGISTRO EXITOSO!!";
    //            break;
    //    }
    //}
}