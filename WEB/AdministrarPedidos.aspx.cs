using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Data.SqlClient;
using System.Data;

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
            OpcionesSolicitudEstado();
        }
    }
    protected bool ValidacionEstado(string estado)
    {
        return estado == "En revision de pago";
    }
    protected bool ValidacionEstado2(string estado)
    {
        return estado == "Por asignar fecha";
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
            case "asignar fecha":
                objDtoSolicitud.PK_IS_Cod = sol;               
                break;
        }
    }

    //protected void btnasignar_Click(object sender, EventArgs e)
    //{
    //    DateTime fecha = Convert.ToDateTime(txtfecha.Text);
    //    string fechareal = fecha.Month.ToString() + "/" + fecha.Day.ToString() + "/" + fecha.Year.ToString();
    //    objDtoSolicitud.DTS_FechaRecojo = Convert.ToDateTime(fechareal);
    //    objCtrSolicitud.actualizarEstadoFecha(objDtoSolicitud);
    //    mostrarmsj(objDtoSolicitud);
        
    //}
    public void mostrarmsj(DtoSolicitud p)
    {
        switch (p.error)
        {
            case 2:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({title:'Observación  HECHA!',text:'Datos ENVIADOS!',type:'success'}, function(){window.location.href='AdministrarPedidos.aspx'});", true);
                break;
            case 77:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({title:'Pago APORBADO!',text:'Datos ENVIADOS!',type:'success'}, function(){window.location.href='AdministrarPedidos.aspx'});", true);
                break;
        }
    }
    public void OpcionesSolicitudEstado()
    {
        DataSet ds = new DataSet();
        ds = objCtrSolicitud.OpcionesSolicitudEstado();
        ddltipo.DataSource = ds;
        ddltipo.DataTextField = "V_SE_Nombre";
        ddltipo.DataValueField = "V_SE_Nombre";
        ddltipo.DataBind();
        ddltipo.Items.Insert(0, new ListItem("Todos", "Todos"));

    }

    protected void ddltipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        string tipo = ddltipo.Text;
        if (tipo == "Todos")
        {
            gvSolicitudes.DataSource = objCtrSolicitud.ListaSolicitudes();
            gvSolicitudes.DataBind();
        }
        else
        gvSolicitudes.DataSource = objCtrSolicitud.Listar_Solicitud_tipo(tipo);
        gvSolicitudes.DataBind();
    }
}