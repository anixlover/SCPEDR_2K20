﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

public partial class RegistrarClienteUE_1 : System.Web.UI.Page
{
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            RadioButton1.Checked = true;
            txtExtranjero.Visible = false;
        }
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        if (txtNombres.Text == "" | txtApellidos.Text == "" | txtCelular.Text == "" | txtCorreo.Text == "" | txtContraseña.Text == "" | txtFechNac.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'})</script>");
            return;
        }
        if (txtDNI.Text == "" && RadioButton1.Checked == true) 
        {
            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'})</script>");
            return;
        }
        if (txtExtranjero.Text == "" && RadioButton2.Checked == true)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'})</script>");
            return;
        }
        //DtoUsuario objuser = new DtoUsuario(txtDNI.Text, txtNombres.Text, txtApellidos.Text, Convert.ToInt32(txtCelular.Text), Convert.ToDateTime(txtFechNac.Text), txtCorreo.Text, txtContraseña.Text, 1);
        if (RadioButton1.Checked == false & RadioButton2.Checked == false)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Seleccione documento de identidad!!'})</script>");
            return;
        }
        DtoUsuario objuser = new DtoUsuario();
        if (RadioButton1.Checked == true)
        {
            objuser.PK_VU_Dni = txtDNI.Text;
        }
        if (RadioButton2.Checked == true)
        {
            objuser.PK_VU_Dni = txtExtranjero.Text;
        }
        objuser.VU_Nombre = txtNombres.Text;
        objuser.VU_Apellidos = txtApellidos.Text;
        objuser.IU_Celular = Convert.ToInt32(txtCelular.Text);
        objuser.DTU_FechaNac = Convert.ToDateTime(txtFechNac.Text);
        objuser.VU_Correo = txtCorreo.Text;
        objuser.VU_Contraseña = txtContraseña.Text;

        CtrUsuario objuserneg = new CtrUsuario();
        objuserneg.RegistrarUsuario(objuser);
        msjeRegistrar(objuser);
        if (objuser.error == 77)
        {
            txtFechNac.Text = "00/00/00 00:00:00";
            txtExtranjero.Text = "";
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
    private void msjeRegistrar(DtoUsuario u)
    {
        switch (u.error)
        {
            case 1:
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Nombre INVALIDO!!'})</script>");
                break;
            case 2:
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Apellido INVALIDO!!!'})</script>");
                break;
            case 3:
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Correo INVALIDO!!'})</script>");
                break;
            case 4:
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Contraseña muy CORTA!!'})</script>");
                break;
            case 5:
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'DNI " + u.PK_VU_Dni + " ya registrado'})</script>");
                break;
            case 6:
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Celular " + u.IU_Celular + " ya registrado'})</script>"); ;
                break;
            case 7:
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'Correo " + u.VU_Correo + " ya registrado'})</script>");
                break;
            case 77:
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal('Registro Exitoso!','Datos ENVIADOS!','success')</script>");
                break;
        }
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