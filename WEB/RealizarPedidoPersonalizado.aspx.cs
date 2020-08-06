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
    CtrTipoMoldura objctrtipomoldura = new CtrTipoMoldura();
    CtrMolduraxUsuario objCtrMXU = new CtrMolduraxUsuario();
    DtoMolduraxUsuario objDtoMXU = new DtoMolduraxUsuario();
    DtoSolicitud objDtoSolicitud = new DtoSolicitud();
    Ctr_Solicitud objCtrSolicitud = new Ctr_Solicitud();

    Log _log = new Log();

    SqlConnection conexion = new SqlConnection("data source=(Local); initial catalog=BD_SCPEDR; integrated security=SSPI;");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            OpcionesTipoMoldura();
            _log.CustomWriteOnLog("registrar pedido personalizado", "carga datos por catalogo");


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
                //if (Request.Params["idMoldura"] != null)
                //{
                //    objDtoMXU.FK_IM_Cod = Convert.ToInt32(Request.Params["idMoldura"]);
                //    txtcodigo.Text = objDtoMXU.FK_IM_Cod.ToString();
                //}
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("registrar pedido personalizado", ex.Message + "Stac" + ex.StackTrace);
            }
        }
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

    public void ObtenerMoldura()
    {
        objDtoMoldura.PK_IM_Cod = int.Parse(txtcodigo.Text);
    }
    protected void btnBuscarProducto_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtcodigo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Ingrese codigo de moldura!!', type: 'error'});", true);
                
                return;
            }
            _log.CustomWriteOnLog("registrar pedido personalizado", "entro a busqueda");
            objDtoMoldura.PK_IM_Cod = int.Parse(txtcodigo.Text);
            _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMoldura.PK_IM_Cod : " + objDtoMoldura.PK_IM_Cod);
            if (!objCtrMoldura.MolduraExiste(objDtoMoldura))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'La moldura " + objDtoMoldura.PK_IM_Cod + " NO EXISTE!!', type: 'error'});", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'La moldura " + objDtoMoldura.PK_IM_Cod + " NO EXISTE!!'})</script>");
                return;
            }
            //Obtener moldura y unidad metrica
            objCtrMoldura.ObtenerMoldura(objDtoMoldura, objDtoTipoMoldura);
            txt_descripcion.Text = objDtoMoldura.VM_Descripcion.ToString();
            txt_medida.Text = objDtoMoldura.DM_Medida.ToString() + objDtoTipoMoldura.VTM_UnidadMetrica.ToString();
            txtunidadmetrica.Value = objDtoTipoMoldura.VTM_UnidadMetrica.ToString();
            _log.CustomWriteOnLog("registrar pedido personalizado", " devolvio objDtoMoldura.DM_Medida y objDtoTipoMoldura.VTM_UnidadMetrica : " + objDtoMoldura.DM_Medida + " " + objDtoTipoMoldura.VTM_UnidadMetrica);
            txt_precio.Text = objDtoMoldura.DM_Precio.ToString();
            _log.CustomWriteOnLog("registrar pedido personalizado", "devolvio objDtoMoldura.DM_Precio : " + objDtoMoldura.DM_Precio);
            buscar.Update();

        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("registrar pedido personalizado", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {

        try
        {
            if (txtcodigo.Text == "" | txt_cantidad.Text == "" | txtarea.Text == "" | txt_importe.Text == "" | txt_medida.Text == "" | txt_precio.Text == "")
            {
                //Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showSuccessMessage6()");
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal('Registro Exitoso!','Solicitud ENVIADA!!','success')</script>");
                //return;
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("registrar pedido personalizado", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
        }

    }


    protected void btnCalcular_Click(object sender, EventArgs e)
    {

        try
        {
            double y = double.Parse(txt_precio.Text);
            int cant = int.Parse(txt_cantidad.Text);

            double importe = cant * y;
            if (txtunidadmetrica.Value == "Mt" && cant < 150)
            {

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Ingrese mas de 150 unidades!!', type: 'error'});", true);
                return;
            }
            if (txtunidadmetrica.Value == "Cm" && cant < 30)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Ingrese mas de 30 unidades!!', type: 'error'});", true);
                return;
            }
            if (txtunidadmetrica.Value == "M2" && cant < 40)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Ingrese mas de 40 unidades!!', type: 'error'});", true);
                return;
            }




            _log.CustomWriteOnLog("registrar pedido personalizado", "valor del txtunidadmetrica" + txtunidadmetrica.Value);

            if (txt_cantidad.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Ingresar cantidad del producto!!', type: 'error'});", true);

                return;
                //Utils.AddScriptClientUpdatePanel(calcular1, "showSuccessMessage4()");
            }
            if (txtcodigo.Text == "")
            {
                Utils.AddScriptClientUpdatePanel(calcular1, "showSuccessMessage5()");
            }


            if (txtunidadmetrica.Value == "Mt" && cant > 149 || txtunidadmetrica.Value == "Cm" && cant > 29 || txtunidadmetrica.Value == "M2" && cant > 39)
            {

                txt_importe.Text = "S/" + Convert.ToString(importe);
                double descuento = (importe * 5) / 100;
                txt_descuento.Text = "S/" + Convert.ToString(descuento);
                double total = importe - descuento;
                txt_subtotal.Text = "S/" + Convert.ToString(total);

            }
            else
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Llene los datos correctamente!!', type: 'error'});", true);
                //return;
                txt_importe.Text = Convert.ToString(importe);
            }
            calcular1.Update();


        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("registrar pedido personalizado", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
        }


    }
    protected void btnCalcular2_Click(object sender, EventArgs e)
    {
        try
        {

            double aprox;
            if (txtcantidadp.Text == "")
            {
                Utils.AddScriptClientUpdatePanel(UpdatePanel1, "showSuccessMessage4()");
            }
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
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'No hay tipo de moldura seleccionado!!'});", true);
                    //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'No hay tipo de moldura seleccionado!!'})</script>");
                    return;
                }
                calcular2.Update();

            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("registrar pedido personalizado", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
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
    //public void cargarInformacion(object sender, EventArgs e)
    //{
    //    //HtmlAnchor repLink = (HtmlAnchor)e.Item.FindControl("~/DescripcionMoldura.aspx");
    //    //repLink.HRef = "~/DescripcionMoldura.aspx";
    //    Response.Redirect("~/ConsultarEstadoPago.aspx");
    //}

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ConsultarEstadoPago.aspx");
    }
    protected void btnCancelar2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ConsultarEstadoPago.aspx");
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        if (txtcodigo.Text == "" | txt_cantidad.Text == "")
        {
            Utils.AddScriptClientUpdatePanel(UpdatePanel1, "showSuccessMessage6()");
        }

        if (true)
        {

        }

        try
        {
            //if (rbCatalogo.Checked == true)
            //{

            //REGISTRAR SOLICTUD 
            _log.CustomWriteOnLog("registrar pedido personalizado", "entro a pedido personalizado por catalogo");
            objDtoSolicitud.VS_TipoSolicitud = "Personalizado por catalogo";
            _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_TipoSolicitud : " + objDtoSolicitud.VS_TipoSolicitud);
            objDtoSolicitud.IS_Cantidad = int.Parse(txt_cantidad.Text);
            _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_TipoSolicitud : " + objDtoSolicitud.VS_TipoSolicitud);
            objDtoSolicitud.DS_ImporteTotal = double.Parse(txt_importe.Text);
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
            objDtoMXU.IMU_Cantidad = int.Parse(txt_cantidad.Text);
            _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.IMU_Cantidad);
            objDtoMXU.DMU_Precio = double.Parse(txt_precio.Text);
            _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.DMU_Precio);
            objDtoMXU.FK_VU_Cod = Session["DNIUsuario"].ToString();
            _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.FK_VU_Cod);
            objCtrMXU.registrarMXU(objDtoMXU);
            _log.CustomWriteOnLog("registrar pedido personalizado", "se registro la Moldura x Usuario satisfactoriamente");

            //ACTUALIZAR MOLDURA X USUARIO
            _log.CustomWriteOnLog("registrar pedido personalizado", "Entra a actualizacion de la Moldura x Usuario");

            int idMXU = objDtoMXU.PK_IMU_Cod;
            _log.CustomWriteOnLog("registrar pedido personalizado", "El idMXU es: " + idMXU);

            int Nsolicitud = objDtoSolicitud.PK_IS_Cod;
            _log.CustomWriteOnLog("registrar pedido personalizado", " El PK de solicitud guardado en Nsolicitud es: " + Nsolicitud);

            objDtoMXU.FK_IS_Cod = Nsolicitud;
            _log.CustomWriteOnLog("registrar pedido personalizado", "El Pk de la solcitud se almacena ahora en objDtoMXU.FK_IS_Cod y es: " + objDtoMXU.FK_IS_Cod);

            objCtrMXU.actualizarMXUSol(objDtoMXU);
            Utils.AddScriptClientUpdatePanel(UpdatePanel1, "showSuccessMessage3()");
            _log.CustomWriteOnLog("registrar pedido personalizado", "se actualizado la Moldura x Usuario satisfactoriamente");
            //Utils.AddScriptClient("showSuccessMessage2()");
            //Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showSuccessMessage2()");


            //}
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("registrar pedido personalizado", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
        }
    }
    protected void btnRegistrar2_Click(object sender, EventArgs e)
    {
        try
        {
            //REGISTRAR SOLICITUD

            _log.CustomWriteOnLog("registrar pedido personalizado", "La función es de creación");

            _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_TipoSolicitud : " + objDtoSolicitud.VS_TipoSolicitud);
            objDtoSolicitud.VS_TipoSolicitud = "Personalizado por diseño propio";
            _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.DS_Medida : " + objDtoSolicitud.VS_Medida);
            objDtoSolicitud.VS_Medida = double.Parse(txtmedidap.Text);
            _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.IS_Cantidad : " + objDtoSolicitud.IS_Cantidad);
            objDtoSolicitud.IS_Cantidad = int.Parse(txtcantidadp.Text);
            _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.DS_PrecioAprox : " + objDtoSolicitud.DS_PrecioAprox);
            objDtoSolicitud.DS_PrecioAprox = double.Parse(txtimporteaprox.Text);
            _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_Comentario : " + objDtoSolicitud.VS_Comentario);
            objDtoSolicitud.VS_Comentario = txtcomentario2.Text;
            objDtoSolicitud.IS_EstadoPago = 1; //estado pendiente
            msjeRegistrar(objDtoSolicitud);
            objCtrSolicitud.RegistrarSolcitud_PP(objDtoSolicitud);

            int NsolicitudP = objDtoSolicitud.PK_IS_Cod;
            Utils.AddScriptClientUpdatePanel(UpdatePanel2, "uploadFileDocumentsSolicitud(" + objDtoSolicitud.PK_IS_Cod + ");");
            //Utils.AddScriptClient("showSuccessMessage2()");
            _log.CustomWriteOnLog("registrar pedido personalizado", "PK_IS_Cod valor retornado " + objDtoSolicitud.PK_IS_Cod);


            //-------------------

            //REGISTRAR MOLDURA X USUARIO
            _log.CustomWriteOnLog("registrar pedido personalizado", "Entra a registrar Moldura x Usuario");


            objDtoMXU.IMU_Cantidad = int.Parse(txtcantidadp.Text);
            _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.IMU_Cantidad);

            objDtoMXU.FK_VU_Cod = Session["DNIUsuario"].ToString();
            _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.FK_VU_Cod);

            objCtrMXU.registrarMXUP(objDtoMXU);
            _log.CustomWriteOnLog("registrar pedido personalizado", "se registro la Moldura x Usuario satisfactoriamente");

            //ACTUALIZAR MOLDURA X USUARIO
            _log.CustomWriteOnLog("registrar pedido personalizado", "Entra a actualizacion de la Moldura x Usuario");

            int idMXU = objDtoMXU.PK_IMU_Cod;
            _log.CustomWriteOnLog("registrar pedido personalizado", "El idMXU es: " + idMXU);

            _log.CustomWriteOnLog("registrar pedido personalizado", " El PK de solicitud guardado en Nsolicitud es: " + NsolicitudP);

            objDtoMXU.FK_IS_Cod = NsolicitudP;
            _log.CustomWriteOnLog("registrar pedido personalizado", "El Pk de la solcitud se almacena ahora en objDtoMXU.FK_IS_Cod y es: " + objDtoMXU.FK_IS_Cod);

            objCtrMXU.actualizarMXUSolP(objDtoMXU);


            //-------------------

            _log.CustomWriteOnLog("registrar pedido personalizado", "Agregado");
            _log.CustomWriteOnLog("registrar pedido personalizado", "Completado");
            Utils.AddScriptClientUpdatePanel(UpdatePanel2, "showSuccessMessage2()");
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("registrar pedido personalizado", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
        }
    }

    protected void ddlTipoMoldura_SelectedIndexChanged(object sender, EventArgs e)
    {
        objDtoTipoMoldura.PK_ITM_Tipo = Convert.ToInt32(ddlTipoMoldura.SelectedValue);
        objctrtipomoldura.leerUnidadMetrica(objDtoTipoMoldura);
        //unidad.Text = objDtoTipoMoldura.VTM_UnidadMetrica;
    }
}