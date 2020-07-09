using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

public partial class RealizarPedidoPersonalizado : System.Web.UI.Page
{
    Log log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            rbCatalogo.Checked = true;
            Label7.Visible = false;
            Image1.Visible = false;
            FileUpload1.Visible = false;
            Label8.Visible = false;
            ddlTipoMoldura.Visible = false;
            Label9.Visible = false;
            txtmedidap.Visible = false;
            Label10.Visible = false;
            txtcantidadp.Visible = false;
            Label11.Visible = false;
            txtimporteaprox.Visible = false;
            Label12.Visible = false;
            txtcomentariop.Visible = false;

        }
    }

    protected void rbCatalogo_CheckedChanged(object sender, EventArgs e)
    {
        Label1.Visible = true;
        txtcodigo.Visible = true;
        btnSearch.Visible = true;
        Label2.Visible = true;
        txtmedida.Visible = true;
        Label3.Visible = true;
        txtprecio.Visible = true;
        Label4.Visible = true;
        txtcantidad.Visible = true;
        Label5.Visible = true;
        txtimporte.Visible = true;
        Label6.Visible = true;
        txtarea.Visible = true;
        Label7.Visible = false;
        Image1.Visible = false;
        FileUpload1.Visible = false;
        Label8.Visible = false;
        ddlTipoMoldura.Visible = false;
        Label9.Visible = false;
        txtmedidap.Visible = false;
        Label10.Visible = false;
        txtcantidadp.Visible = false;
        Label11.Visible = false;
        txtimporteaprox.Visible = false;
        Label12.Visible = false;
        txtcomentariop.Visible = false;
    }

    protected void rbPropio_CheckedChanged(object sender, EventArgs e)
    {
        Label1.Visible = false;
        txtcodigo.Visible = false;
        btnSearch.Visible = false;
        Label2.Visible = false;
        txtmedida.Visible = false;
        Label3.Visible = false;
        txtprecio.Visible = false;
        Label4.Visible = false;
        txtcantidad.Visible = false;
        Label5.Visible = false;
        txtimporte.Visible = false;
        Label6.Visible = false;
        txtarea.Visible = false;
        Label7.Visible = true;
        Image1.Visible = true;
        FileUpload1.Visible = true;
        Label8.Visible = true;
        ddlTipoMoldura.Visible = true;
        Label9.Visible = true;
        txtmedidap.Visible = true;
        Label10.Visible = true;
        txtcantidadp.Visible = true;
        Label11.Visible = true;
        txtimporteaprox.Visible = true;
        Label12.Visible = true;
        txtcomentariop.Visible = true;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {

    }
}