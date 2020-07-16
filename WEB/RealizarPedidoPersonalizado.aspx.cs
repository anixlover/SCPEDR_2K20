using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using DTO;
using CTR;
using DAO;
using System.Configuration;

using System.Data.SqlClient;
using System.Drawing;

public partial class RealizarPedidoPersonalizado : System.Web.UI.Page
{
    CtrMoldura objCtrMoldura = new CtrMoldura();
    DtoMoldura objDtoMoldura = new DtoMoldura();
    DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
    CtrMolduraxUsuario objCtrMXU = new CtrMolduraxUsuario();
    DtoMolduraxUsuario objDtoMXU = new DtoMolduraxUsuario(); 
    DtoSolicitud objDtoSolicitud = new DtoSolicitud();
    Ctr_Solicitud objCtrSolicitud = new Ctr_Solicitud();

    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {

            OpcionesTipoMoldura();
            _log.CustomWriteOnLog("registrar pedido personalizado", "carga datos por catalogo");
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


            try
            {
                if (Session["DNIUsuario"] != null)
                {
                    objDtoMXU.FK_VU_Cod = Session["DNIUsuario"].ToString();

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("registrar pedido personalizado", ex.Message + "Stac" + ex.StackTrace);
            }
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
        txtimporteaprox.Enabled = false;
        Label12.Visible = true;
        txtcomentariop.Visible = true;
    }

    public void OpcionesTipoMoldura()
    {
        DataSet ds = new DataSet();
        ds = objCtrMoldura.OpcionesTipoMoldura();
        ddlTipoMoldura.DataSource = ds;
        ddlTipoMoldura.DataTextField = "VTM_Nombre";
        ddlTipoMoldura.DataValueField = "PK_ITM_Tipo";
        ddlTipoMoldura.DataBind();
        ddlTipoMoldura.Items.Insert(0, new ListItem("Seleccione", "0"));
        _log.CustomWriteOnLog("registrar pedido personalizado", "Termino de llenar el ddl");

    }

    public void ObtenerMoldura ()
    {
        objDtoMoldura.PK_IM_Cod = int.Parse(txtcodigo.Text);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
                _log.CustomWriteOnLog("registrar pedido personalizado", "entro a busqueda");
                objDtoMoldura.PK_IM_Cod = int.Parse(txtcodigo.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMoldura.PK_IM_Cod : " + objDtoMoldura.PK_IM_Cod);
                objCtrMoldura.ObtenerMoldura(objDtoMoldura, objDtoTipoMoldura);
                txtmedida.Text = objDtoMoldura.DM_Medida.ToString() + objDtoTipoMoldura.VTM_UnidadMetrica.ToString();
            txtunidadmetrica.Value = objDtoTipoMoldura.VTM_UnidadMetrica.ToString();
                _log.CustomWriteOnLog("registrar pedido personalizado", " devolvio objDtoMoldura.DM_Medida y objDtoTipoMoldura.VTM_UnidadMetrica : " + objDtoMoldura.DM_Medida + " " + objDtoTipoMoldura.VTM_UnidadMetrica);
                txtprecio.Text = objDtoMoldura.DM_Precio.ToString();
                _log.CustomWriteOnLog("registrar pedido personalizado", "devolvio objDtoMoldura.DM_Precio : " + objDtoMoldura.DM_Precio);


        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            if (rbCatalogo.Checked == true)
            {
                //REGISTRAR SOLICTUD 
                _log.CustomWriteOnLog("registrar pedido personalizado", "entro a pedido personalizado por catalogo");
                objDtoSolicitud.VS_TipoSolicitud = "Personalizado por catalogo";
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_TipoSolicitud : " + objDtoSolicitud.VS_TipoSolicitud);
                objDtoSolicitud.IS_Cantidad = int.Parse(txtcantidad.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_TipoSolicitud : " + objDtoSolicitud.VS_TipoSolicitud);
                objDtoSolicitud.DS_ImporteTotal = double.Parse(txtimporte.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_TipoSolicitud : " + objDtoSolicitud.DS_ImporteTotal);
                objDtoSolicitud.VS_Comentario = txtarea.Text;
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_TipoSolicitud : " + objDtoSolicitud.VS_Comentario);
                objDtoSolicitud.IS_EstadoPago = 1; //estado pendiente
                

                objCtrSolicitud.RegistrarSolcitud_PC(objDtoSolicitud);
                _log.CustomWriteOnLog("registrar pedido personalizado", "se registro la solicitud");

                //REGISTRAR MOLDURA X USUARIO
                _log.CustomWriteOnLog("registrar pedido personalizado", "Entra a registrar Moldura x Usuario");


                objDtoMXU.FK_IM_Cod = int.Parse(txtcodigo.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.FK_IM_Cod);
                objDtoMXU.IMU_Cantidad = int.Parse(txtcantidad.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.IMU_Cantidad);
                objDtoMXU.DMU_Precio = double.Parse(txtprecio.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.DMU_Precio);
                objDtoMXU.FK_VU_Cod = Session["DNIUsuario"].ToString();
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.FK_VU_Cod);
                objCtrMXU.registrarMXU(objDtoMXU);
                _log.CustomWriteOnLog("registrar pedido personalizado", "se registro la Moldura x Usuario satisfactoriamente");

                //ACTUALIZAR MOLDURA X USUARIO
                _log.CustomWriteOnLog("registrar pedido personalizado", "Entra a actualizacion de la Moldura x Usuario");


                int idMXU = objDtoMXU.PK_IMU_Cod;
                _log.CustomWriteOnLog("registrar pedido personalizado", "El idMXU es: " + idMXU);

                int Nsolicitud =  objDtoSolicitud.PK_IS_Cod;
                _log.CustomWriteOnLog("registrar pedido personalizado", " El PK de solicitud guardado en Nsolicitud es: " + Nsolicitud);

                objDtoMXU.FK_IS_Cod = Nsolicitud;
                _log.CustomWriteOnLog("registrar pedido personalizado", "El Pk de la solcitud se almacena ahora en objDtoMXU.FK_IS_Cod y es: " + objDtoMXU.FK_IS_Cod);

                objCtrMXU.actualizarMXUSol(objDtoMXU);
                _log.CustomWriteOnLog("registrar pedido personalizado", "se actualizado la Moldura x Usuario satisfactoriamente");


            }
            if (rbPropio.Checked == true)
            {
                _log.CustomWriteOnLog("registrar pedido personalizado", "La función es de creación");
                objDtoSolicitud.VS_TipoSolicitud = "Personalizado por diseño propio";
                objDtoSolicitud.DS_Medida = double.Parse(txtmedidap.Text);
                objDtoSolicitud.IS_Cantidad = int.Parse(txtcantidadp.Text);
                objDtoSolicitud.DS_PrecioAprox = double.Parse(txtimporteaprox.Text);
                objDtoSolicitud.VS_Comentario = txtcomentariop.Text;
                objDtoSolicitud.IS_EstadoPago = 1; //estado pendiente
                msjeRegistrar(objDtoSolicitud);
                objCtrSolicitud.RegistrarSolcitud_PP(objDtoSolicitud);

                int Nsolicitud = objDtoSolicitud.PK_IS_Cod;
                Utils.AddScriptClientUpdatePanel(upBotonEnviar,"uploadFileDocumentsSolicitud(" + objDtoSolicitud.PK_IS_Cod + ");");
                Utils.AddScriptClient("showSuccessMessage2()");
                _log.CustomWriteOnLog("registrar pedido personalizado", "PK_IS_Cod valor retornado " + objDtoSolicitud.PK_IS_Cod);
                _log.CustomWriteOnLog("registrar pedido personalizado", "Agregado");
                _log.CustomWriteOnLog("registrar pedido personalizado", "Completado");
            }
            

        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("registrar pedido personalizado", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
        }
        
    }


    protected void btnCalcular_Click(object sender, EventArgs e)
    {

        double aprox;
        _log.CustomWriteOnLog("registrar pedido personalizado", "valor del txtunidadmetrica" + txtunidadmetrica.Value);
        if (rbCatalogo.Checked == true)
        {
            int x = int.Parse(txtcantidad.Text);
            double y = double.Parse(txtprecio.Text);
            double z = x * y;
            int cant = int.Parse(txtcantidad.Text);
            if (txtunidadmetrica.Value == "Mt" && cant > 150 || txtunidadmetrica.Value == "Cm" && cant > 30 || txtunidadmetrica.Value == "M2" && cant > 40)
            {

                double descuento = z - ((z * 5) / 100 );

                txtimporte.Text = Convert.ToString(descuento);
            }
            else
            {
                txtimporte.Text = Convert.ToString(z);
            }
        }
        if (rbPropio.Checked == true)
        {
            
            if (ddlTipoMoldura.SelectedValue != "0")
            {
                //objDtoTipoMoldura.PK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);
                objDtoMoldura.FK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);
                aprox = objCtrMoldura.Aprox(objDtoMoldura);
                //txtimporteaprox.Text = Convert.ToString(objCtrMoldura.PrecioAprox(objDtoMoldura));
                //double precio;
                //txtimporteaprox.Text = Convert.ToString(aprox);

                int cantp = int.Parse(txtcantidadp.Text);
                double a = aprox * cantp;
                txtimporteaprox.Text = Convert.ToString(a);


                if (aprox == 0)
                {
                    txtimporteaprox.Text = "";
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'No hay tipo de moldura seleccionado!!'})</script>");
                    return;
                }
            }
        }

    }
    private void msjeRegistrar(DtoSolicitud objDtoMoldura)
    {
        switch (objDtoMoldura.error)
        {
            
            case 77:
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal('Registro Exitoso!','sOLICITUD enviada!!','success')</script>");
                break;
        }
    }
}