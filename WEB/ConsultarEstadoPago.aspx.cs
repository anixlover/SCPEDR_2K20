using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using DAO;

public partial class ConsultarEstadoPago : System.Web.UI.Page
{
    DtoSolicitud objDtoSolicitud = new DtoSolicitud();
    Ctr_Solicitud objCtrSolicitud = new Ctr_Solicitud();
    DtoMolduraxUsuario dtoMolduraxUsuario = new DtoMolduraxUsuario();
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _log.CustomWriteOnLog("consultar estado de pago", "Carga de pagina");
            try
            {
                if (Session["DNIUsuario"] != null)
                {
                    //objDtoSolicitud.PK_IS_Cod = 2;
                    dtoMolduraxUsuario.FK_VU_Cod = Session["DNIUsuario"].ToString();
                    gvConsultar.DataSource = objCtrSolicitud.TablaConsultaEstado(objDtoSolicitud, dtoMolduraxUsuario);
                    gvConsultar.DataBind();

                    /** if (gvConsultar.Rows.Count == 0)
                     {
                         btnPago.Visible = false;
                     }*/
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("consultar estado de pago", ex.Message + "Stac" + ex.StackTrace);
            }
        }

    }

    protected void gvConsultar_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        

        if (e.CommandName == "Pago")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var columna = gvConsultar.DataKeys[index].Values;
                int id = Convert.ToInt32(columna[0].ToString());
                _log.CustomWriteOnLog("consultar estado de pago", "id  " + id);
                Session["idSolicitudPago"] = id;
                Response.Redirect("Realizar_compra.aspx");

            }

            catch (Exception ex)
            {
                _log.CustomWriteOnLog("consultar estado de pago", ex.Message + "Stac" + ex.StackTrace);
            }
        }
        

    }

    //public void cargarConsultarEstadoPago(object sender, EventArgs e)
    //{
    //    //HtmlAnchor repLink = (HtmlAnchor)e.Item.FindControl("~/DescripcionMoldura.aspx");
    //    //repLink.HRef = "~/DescripcionMoldura.aspx";
    //    Response.Redirect("~/Realizar_Compra.aspx");
    //}

    protected void gvConsultar_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvConsultar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }

    protected Boolean ValidacionEstado(string estado)
    {
        return estado == "Pendiente de pago";
    }
}