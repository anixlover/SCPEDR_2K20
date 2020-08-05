using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Realizar_compra : System.Web.UI.Page
{
    CtrDatoFactura objfacturaneg;
    CtrPago objpagoneg;
    Ctr_Solicitud objsolneg;
    CtrVoucher objvouneg;
    DtoDatoFactura objfactura;
    DtoPago objpago;
    DtoSolicitud objsol;
    DtoVoucher objvou;
    Log _log = new Log();
    SqlConnection conexion = new SqlConnection("data source=(Local); initial catalog=BD_SCPEDR; integrated security=SSPI;");
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
        }

        if (Session["DNIUsuario"] != null & Session["idSolicitudPago"] != null)
        {
            CargarRUCS();
        }
        else
        { Response.Redirect("Login.aspx"); }
    }
    public void CargarRUCS()
    {
        string select = "select VDF_RUC from T_DatoFactura where FK_VU_Dni='" + Session["DNIUsuario"].ToString() + "'";
        SqlCommand unComando = new SqlCommand(select, conexion);
        conexion.Open();
        ddlRUC.DataSource = unComando.ExecuteReader();
        ddlRUC.DataTextField = "VDF_RUC";
        ddlRUC.DataValueField = "VDF_RUC";
        ddlRUC.DataBind();
        conexion.Close();
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        Log _Log = new Log();
        try
        {
            if (valorObtenidoRBTN.Value != "1" && valorObtenidoRBTN.Value != "2")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Seleccione BOLETA o FACTURA!!'});", true);
                return;
            }
            if (txtImporte.Text == "" | txtNumOp.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'});", true);
                return;
            }
            if (txtnewRUC.Text == "" && valorCheck.Value == "3" && valorObtenidoRBTN.Value == "2")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'});", true);
                return;
            }
            if (ddlRUC.Text == "" && valorObtenidoRBTN.Value == "2" && valorCheck.Value != "3")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'});", true);
                return;
            }
            
            objpago = new DtoPago();
            objpagoneg = new CtrPago();

            if (valorObtenidoRBTN.Value == "2" && valorCheck.Value == "3")
            {
                objfacturaneg = new CtrDatoFactura();
                objfactura = new DtoDatoFactura();
                int ultimo = objfacturaneg.ultimo();
                objfactura.PK_IDF_Cod = ultimo + 1;
                objfactura.VDF_RazonSocial = "";
                objfactura.IDF_RUC = txtnewRUC.Text;
                objfactura.FK_VU_DNI = Session["DNIUsuario"].ToString();
                objpago.IP_TipoCertificado = 2;
                objpago.VP_RUC = txtnewRUC.Text;
                objfacturaneg.RegistrarDatoFactura(objfactura);
                mostrarmsjFACTURA(objfactura);
            }
            if (valorObtenidoRBTN.Value == "2" && valorCheck.Value != "3")
            {
                objpago.VP_RUC = ddlRUC.Text;
                objpago.IP_TipoCertificado = 2;
            }
            if (valorObtenidoRBTN.Value == "1")
            {
                objpago.VP_RUC = "";
                objpago.IP_TipoCertificado = 1;
            }
            objpago.FK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"].ToString());
            objpago.DP_ImportePagado = Convert.ToDouble(txtImporte.Text);
            double costo = objpagoneg.Costo(objpago);

            objpago.DP_ImporteRestante = costo - Convert.ToDouble(txtImporte.Text);

            if (Convert.ToDouble(txtImporte.Text) == (costo / 2))
            {
                objpago.IP_TipoPago = 1;
            }
            if (Convert.ToDouble(txtImporte.Text) > (costo / 2) | Convert.ToDouble(txtImporte.Text) == costo)
            {
                objpago.IP_TipoPago = 2;
            }
            objsol = new DtoSolicitud();
            objsolneg = new Ctr_Solicitud();
            objsol.PK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"].ToString());

            objvou = new DtoVoucher();
            objvouneg = new CtrVoucher();

            objvou.PK_VV_NumVoucher = txtNumOp.Text;
            //objvou.VBV_Foto = imagen;
            objvou.DV_ImporteDepositado = Convert.ToDouble(txtImporte.Text);
            objvou.VV_Comentario = "";
            //Utils.AddScriptClientUpdatePanel(UpdatePanel1, " ValidacionImagenVoucher();");
            if (hftxtimg.Value == "vacio")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'suba la IMAGEN!!'});", true);
                return;
            }
            else
            {
                _Log.CustomWriteOnLog("ImagenGuardada", "EL CAMPO ESTA LLENO");
            }
            objpagoneg.RegistrarPago(objpago);
            mostrarmsjPAGO(objpago);

            if (objpago.error == 77)
            {
                _Log.CustomWriteOnLog("RealizarCompra.cs", "1");
                objvouneg.RegistrarVoucher(objvou);
                _Log.CustomWriteOnLog("RealizarCompra.cs", "2");
                Utils.AddScriptClientUpdatePanel(UpdatePanel1, "uploadFileImagenVoucher('" + objvou.PK_VV_NumVoucher + "');");
                _Log.CustomWriteOnLog("RealizarCompra.cs", "3");
                objsolneg.ActualizarEstado(objsol);
            }
        }
        catch (Exception ex)
        {
            _Log.CustomWriteOnLog("RealizarCompra.cs", "error   "+ex.Message);

        }
    }
    public void mostrarmsjPAGO(DtoPago p) 
    {
        switch (p.error)
        {
            case 3:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Importe INSUFICIENTE!!!'});", true);
                break;
            case 4:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Importe INVALIDO!!!'});", true);
                break;
            case 77:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({title:'Pago registrado CORRECTAMENTE!',text:'Datos ENVIADOS!',icon:'success'}, function(){window.location.href='ConsultarEstadoPago.aspx'});", true);
                break;
        }
    }
    public void mostrarmsjFACTURA(DtoDatoFactura d)
    {
        switch (d.error)
        {
            case 2:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'RUC DUPLICADA!!!'});", true);
                break;
            case 3:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'No tiene el tamaño CORRECTO!!!'});", true);
                break;
            case 4:
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'El RUC no admite LETRAS!!!'});", true);
                break;
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConsultarEstadoPago.aspx");
    }
}