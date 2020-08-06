using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Evaluar_Pedido_Personalizado : System.Web.UI.Page
{
    Ctr_Solicitud objCtrSolicitud = new Ctr_Solicitud();
    DtoSolicitud objDtoSolicitud = new DtoSolicitud();
    DtoSolicitudEstado objDtoSolicitudEstado = new DtoSolicitudEstado();
    Log _log = new Log();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                UpdatePanel.Update();
                gvPersonalizado.DataSource = objCtrSolicitud.Listar_Solicitud_Personalizado();
                gvPersonalizado.DataBind();
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("Evaluar_Pedido_personalizado", "Error = " + ex.Message + "Stac" + ex.StackTrace);
            }
        }
    }

    protected void gvPersonalizado_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="Ver")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvPersonalizado.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                string Nombre = colsNoVisible[1].ToString();
                objDtoSolicitud.PK_IS_Cod = int.Parse(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        else if (e.CommandName=="Cotizar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvPersonalizado.DataKeys[index].Values;
            string id = colsNoVisible[0].ToString();
            Response.Redirect("~/Cotizar_Personalizado.aspx?ID=" + id);
        }
    }
    protected void gvPersonalizado_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}