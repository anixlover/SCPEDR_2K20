using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using DAO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class ConsultarEstadoPago : System.Web.UI.Page
{
    DtoSolicitud objDtoSolicitud = new DtoSolicitud();
    Ctr_Solicitud objCtrSolicitud = new Ctr_Solicitud();
    DtoMolduraxUsuario dtoMolduraxUsuario = new DtoMolduraxUsuario();
    DtoSolicitudEstado objDtoSolicitudEstado = new DtoSolicitudEstado();
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
                    OpcionesSolicitudEstado();
                    dtoMolduraxUsuario.FK_VU_Cod = Session["DNIUsuario"].ToString();
                    gvConsultar.DataSource = objCtrSolicitud.TablaConsultaEstado(objDtoSolicitud, dtoMolduraxUsuario);
                    gvConsultar.DataBind();
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

    public void OpcionesSolicitudEstado()
    {
        DataSet ds = new DataSet();
        ds = objCtrSolicitud.OpcionesSolicitudEstado();
        ddl_SolicitudEstado.DataSource = ds;
        ddl_SolicitudEstado.DataTextField = "V_SE_Nombre";
        ddl_SolicitudEstado.DataValueField = "PK_ISE_Cod";
        ddl_SolicitudEstado.DataBind();
        ddl_SolicitudEstado.Items.Insert(0, new ListItem("Todos", "0"));

    }
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

    protected void ddl_SolicitudEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {

        try
        {
            if (ddl_SolicitudEstado.SelectedValue != "0")
            {
                _log.CustomWriteOnLog("GestionarCatalogo", "Entro a busqueda");
                objDtoSolicitudEstado.PK_ISE_Cod = int.Parse(ddl_SolicitudEstado.SelectedValue);
                _log.CustomWriteOnLog("GestionarCatalogo", "objDtoTipoMoldura.PK_ITM_Tipo : " + objDtoSolicitudEstado.PK_ISE_Cod);
                //UpdatePanel.Update();
                //gvConsultar.DataSource = objCtrSolicitud.ListarMoldurasByTipoMoldura(objDtoSolicitudEstado);
                gvConsultar.DataBind();
                _log.CustomWriteOnLog("GestionarCatalogo", "Paso");
            }

            else if (ddl_SolicitudEstado.SelectedValue == "0")
            {

            }

            else
            {
                //UpdatePanel.Update();
                gvConsultar.CssClass = "table table-bordered table-hover js-basic-example dataTable";
                gvConsultar.DataSource = objCtrSolicitud.TablaConsultaEstado(objDtoSolicitud, dtoMolduraxUsuario);
                gvConsultar.DataBind();
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("GestionarCatalogo", "Error busqueda :" + ex.Message);

            throw;
        }
    }
}