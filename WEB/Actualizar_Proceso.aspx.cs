using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTO;
using CTR;
using DAO;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;

public partial class Actualizar_Proceso : System.Web.UI.Page
{
    CtrMoldura objCtrMoldura = new CtrMoldura();

    Ctr_Solicitud objCtrSolicitud = new Ctr_Solicitud();
    DtoSolicitud objdtosol = new DtoSolicitud();
    DtoMoldura objDtoMoldura = new DtoMoldura();
    DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            OpcionesTipoMoldura();
            if (Request.Params["Id"] != null)
            {
                //Image1.Visible = true;
                //txtPagina.InnerText = "Actualizar moldura";

                obtenerInformacionSolicitud(Request.Params["Id"]);

            }
            else
            {
                //ddlestadosolicitud.SelectedValue = "1";
            }
        }
    }

    public void OpcionesTipoMoldura()
    {
        DataSet ds = new DataSet();
        //ds = objCtrSolicitud.OpcionesEstadoSolicitud();
        ddlestadosolicitud.DataSource = ds; 
        ddlestadosolicitud.DataTextField = "V_SE_Nombre";
        ddlestadosolicitud.DataValueField = "PK_ISE_Cod";
        ddlestadosolicitud.DataBind();
        ddlestadosolicitud.Items.Insert(0, new ListItem("Seleccione", "0"));
        _log.CustomWriteOnLog("Actualizar_Proceso", "Termino de llenar el ddl");

    }
    public void obtenerInformacionSolicitud(string id)
    {
        _log.CustomWriteOnLog("Actualizar_Proceso", "-------------------------------------------------- Entro a actualización ----------------------------------------");
        objdtosol.PK_IS_Cod = int.Parse(id);
        //objCtrSolicitud.ObtenerSolicitud(objdtosol, objDtoMoldura);

        txtCodigo.Text = objdtosol.PK_IS_Cod.ToString();
        txttiposolicitud.Text = objdtosol.VS_TipoSolicitud;
        txtcantidad.Text = objdtosol.IS_Cantidad.ToString();
        ddlestadosolicitud.SelectedValue = objDtoMoldura.IM_Stock.ToString();
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {

        
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Gestionar_Estado_Pedido.aspx");
    }
}