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
        Label5.Text = "71257736";
        if (!IsPostBack)
        {
            txtnewRUC.Visible = false;
            ddlRUC.Visible = false;
            checkboxRUC.Visible = false;
            lblRUC.Visible = false;
            rbBoleta.Checked = true;
            lblfecha.Text = DateTime.Today.Date.ToString();
            CargarRUCS();
        }
    }

    protected void rbBoleta_CheckedChanged(object sender, EventArgs e)
    {
        checkboxRUC.Visible = false;
        ddlRUC.Visible = false;
        lblRUC.Visible = false;
        txtnewRUC.Visible = false;
    }

    protected void checkboxRUC_CheckedChanged(object sender, EventArgs e)
    {
        if (checkboxRUC.Checked == false)
        {
            ddlRUC.Visible = true;
            txtnewRUC.Visible = false;
        }
        if (checkboxRUC.Checked == true)
        {
            ddlRUC.Visible = false;
            txtnewRUC.Visible = true;
        }
    }

    protected void rbFactura_CheckedChanged(object sender, EventArgs e)
    {
        checkboxRUC.Visible = true;
        ddlRUC.Visible = true;
        lblRUC.Visible = true;
    }
    public void CargarRUCS()
    {
        string select = "select VDF_RUC from T_DatoFactura where FK_VU_Dni='" + Label5.Text + "'";
        SqlCommand unComando = new SqlCommand(select, conexion);
        conexion.Open();
        ddlRUC.DataSource = unComando.ExecuteReader();
        ddlRUC.DataTextField = "VDF_RUC";
        ddlRUC.DataValueField = "VDF_RUC";
        ddlRUC.DataBind();
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            objpago = new DtoPago();
            objpagoneg = new CtrPago();
            if (txtImporte.Text == null | txtNumOp.Text == null | txtnewRUC.Text == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>Swal.fire({icon: 'error',title: 'ERROR!',text: 'Espacios en BLANCO!!'})</script>");
                return;
            }
            if (rbFactura.Checked == true && checkboxRUC.Checked == true)
            {
                objfacturaneg = new CtrDatoFactura();
                objfactura = new DtoDatoFactura();
                int ultimo = objfacturaneg.ultimo();
                objfactura.PK_IDF_Cod = ultimo + 1;
                objfactura.VDF_RazonSocial = "";
                objfactura.IDF_RUC = txtnewRUC.Text;
                objfactura.FK_VU_DNI = Label5.Text;
                objpago.IP_TipoCertificado = 2;
                objpago.VP_RUC = txtnewRUC.Text;
                objfacturaneg.RegistrarDatoFactura(objfactura);
            }
            if (rbFactura.Checked == true && checkboxRUC.Checked == false)
            {
                objpago.VP_RUC = ddlRUC.Text;
                objpago.IP_TipoCertificado = 2;
            }
            if (rbBoleta.Checked == true)
            {
                objpago.VP_RUC = "";
                objpago.IP_TipoCertificado = 1;
            }
            objpago.FK_IS_Cod = 1;
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
            objsol.PK_IS_Cod = 1;

            objvou = new DtoVoucher();
            objvouneg = new CtrVoucher();
            int tamaño = FileUpload1.PostedFile.ContentLength;
            byte[] imagen = new byte[tamaño];
            FileUpload1.PostedFile.InputStream.Read(imagen, 0, tamaño);
            objvou.PK_VV_NumVoucher = txtNumOp.Text;
            objvou.VBV_Foto = imagen;
            objvou.DV_ImporteDepositado = Convert.ToDouble(txtImporte.Text);
            objvou.VV_Comentario = "";
            objpagoneg.RegistrarPago(objpago);
            objsolneg.ActualizarEstado(objsol);
            objvouneg.RegistrarVoucher(objvou);
            mostrarmsjPAGO(objpago);
            mostrarmsjFACTURA(objfactura);
            CargarRUCS();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void mostrarmsjPAGO(DtoPago p) 
    {
        switch (p.error)
        {
            case 3:
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>Swal.fire({icon: 'error',title: 'ERROR!',text: 'Importe INSUFICIENTE!!'})</script>");
                break;
            case 4:
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>Swal.fire({icon: 'error',title: 'ERROR!',text: 'Importe INVALIDO!!'})</script>");
                break;
            case 77:
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>Swal.fire('Registro Exitoso!','Pago REGISTRADO!!','success')</script>");
                break;
        }
    }
    public void mostrarmsjFACTURA(DtoDatoFactura d)
    {
        switch (d.error)
        {
            case 2:
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>Swal.fire({icon: 'error',title: 'ERROR!',text: 'RUC DUPLICADA para este usuario!! pero...'})</script>");
                break;
        }
    }
}