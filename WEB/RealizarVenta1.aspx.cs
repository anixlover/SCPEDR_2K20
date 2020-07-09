using CTR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RealizarVenta1 : System.Web.UI.Page
{
        Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _log.CustomWriteOnLog("Realizar venta", "_______________________________________________________________________________ENTRO A FUNCION REALIZAR VENTA_____________________________________________________________________");
            //ddl_TipoComprobante.SelectedValue = "1";
            TextBox2.Visible = false;

        }
    }

    //protected void ddl_TipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    _log.CustomWriteOnLog("Realizar venta","valorddl : " + ddl_TipoComprobante.SelectedValue);
    //    if (ddl_TipoComprobante.SelectedValue == "1")
    //    {
    //        TextBox1.Visible = true;
    //        TextBox2.Visible = false;

    //    }
    //    if (ddl_TipoComprobante.SelectedValue == "2")
    //    {
    //        TextBox1.Visible = false;
    //        TextBox2.Visible = true;

    //    }
    //}

  

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //_log.CustomWriteOnLog("Realizar venta", "valorddl : " + DropDownList1.SelectedValue);

    }
}