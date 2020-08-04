using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

public partial class AdministrarPedidos : System.Web.UI.Page
{
    DtoSolicitud objDtoSolicitud = new DtoSolicitud();
    Ctr_Solicitud objCtrSolicitud = new Ctr_Solicitud();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvSolicitudes.DataSource = objCtrSolicitud.ListaSolicitudes();
            gvSolicitudes.DataBind();
        }
    }
    protected bool ValidacionEstado(string estado)
    {
        return estado == "En revision de pago";
    }

    protected void gvSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        var columna = gvSolicitudes.DataKeys[index].Values;
        int sol = Convert.ToInt32(columna[0].ToString());
        string dni = columna[2].ToString();
        switch (e.CommandName)
        {
            case "Ver detalles":
                Session["clienteDNI"] =dni;
                Session["idSolicitudPago"] = sol;
                Response.Redirect("Detalles_Solicitud.aspx");
                break;
            case "Evaluar":
                Session["idSolicitudPago"] = sol;
                Response.Redirect("EvaluarPagos.aspx");
                break;
        }
    }
}