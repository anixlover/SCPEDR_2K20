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
using System.Web.UI.HtmlControls;

public partial class DescripcionMolduraU : System.Web.UI.Page
{
    CtrMoldura objCtrMoldura = new CtrMoldura();
    CtrMolduraxUsuario objCtrMolduraxUsuario = new CtrMolduraxUsuario();
    CtrTipoMoldura objCtrTipoMoldura = new CtrTipoMoldura();
    DtoMoldura objDtoMoldura = new DtoMoldura();
    DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
    DtoMolduraxUsuario objDtoMolduraxUsuario = new DtoMolduraxUsuario();


    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.Params["Id"] != null)
            {
                Image1.Visible = true;

                obtenerInformacionMoldura(Request.Params["Id"]);

            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("DescripcionMoldura", "Error = " + ex.Message + "Stac" + ex.StackTrace);
            throw;
        }
    }
    public void obtenerInformacionMoldura(string id)
    {
        _log.CustomWriteOnLog("PropiedadMoldura", "-------------------------------------------------- Entro a actualización ----------------------------------------");
        objDtoMoldura.PK_IM_Cod = int.Parse(id);


        objCtrMoldura.ObtenerMoldura(objDtoMoldura, objDtoTipoMoldura);
        _log.CustomWriteOnLog("PropiedadMoldura", "Valores retornados");
        _log.CustomWriteOnLog("PropiedadMoldura", "PK_IM_Cod" + objDtoMoldura.PK_IM_Cod);
        _log.CustomWriteOnLog("PropiedadMoldura", "DM_Medida" + objDtoMoldura.DM_Medida);
        _log.CustomWriteOnLog("PropiedadMoldura", "VTM_UnidadMetrica" + objDtoTipoMoldura.VTM_UnidadMetrica);
        _log.CustomWriteOnLog("PropiedadMoldura", "DM_Precio" + objDtoMoldura.DM_Precio);
        _log.CustomWriteOnLog("PropiedadMoldura", "VM_Descripcion" + objDtoMoldura.VM_Descripcion);
        _log.CustomWriteOnLog("PropiedadMoldura", "PK_ITM_Tipo " + objDtoTipoMoldura.PK_ITM_Tipo);
        _log.CustomWriteOnLog("PropiedadMoldura", "VTM_Nombre" + objDtoTipoMoldura.VTM_Nombre);
        _log.CustomWriteOnLog("PropiedadMoldura", "IM_Estado" + objDtoMoldura.IM_Estado);
        _log.CustomWriteOnLog("PropiedadMoldura", "IM_Stock" + objDtoMoldura.IM_Stock);

        #region ObtenerImagen
        string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramId = new SqlParameter()
            {
                ParameterName = "@Id",
                Value = id
            };
            cmd.Parameters.Add(paramId);
            con.Open();
            byte[] ByteArray = (byte[])cmd.ExecuteScalar();
            con.Close();
            string strbase64 = Convert.ToBase64String(ByteArray);

            Image1.ImageUrl = "data:Image/png;base64," + strbase64;
        }
        #endregion

        //txtCodigo.Text = objDtoMoldura.PK_IM_Cod.ToString();
        //ddlTipoMoldura.SelectedValue = objDtoTipoMoldura.PK_ITM_Tipo.ToString();
        txtmedida.Text = objDtoMoldura.DM_Medida.ToString();
        txtmetrica.Text = objDtoTipoMoldura.VTM_UnidadMetrica.ToString();
        txtprecio.Text = objDtoMoldura.DM_Precio.ToString();
        //txtStock.Text = objDtoMoldura.IM_Stock.ToString();
        //txtMedida.Text = objDtoMoldura.DM_Medida.ToString();
        //ddlEstadoMoldura.SelectedValue = objDtoMoldura.IM_Estado.ToString();
        txtdescripcion.Text = objDtoMoldura.VM_Descripcion;

    }
    public void btn_regresar_click(object sender, EventArgs e)
    {
        Response.Redirect("~/InspeccionarCatalogoU.aspx");
    }

    protected void btnAgregarCompraMoldura_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["DNIUsuario"] == null)
            {
                Response.Cookies.Add(new HttpCookie("returnUrl", Request.Url.PathAndQuery));
                Response.Redirect("Login.aspx");
            }
            else
            {
                _log.CustomWriteOnLog("AgregarCompraMoldura", "moldura" + Request.Params["Id"].ToString());
                objDtoMoldura.PK_IM_Cod = int.Parse(Request.Params["Id"]);
                int stock = objCtrMoldura.StockMoldura_(objDtoMoldura);
                _log.CustomWriteOnLog("AgregarCompraMoldura", "stock: " + stock.ToString());
                int cant = Convert.ToInt32(txtDescripcionModal.Text);

                if (cant < stock)
                {
                    if (txtmetrica.Text == "Mt" && cant < 150 || txtmetrica.Text == "Cm" && cant < 30 || txtmetrica.Text == "M2" && cant < 40)
                    {
                        
                                    objDtoMolduraxUsuario.FK_VU_Cod = Session["DNIUsuario"].ToString();
                                    objDtoMolduraxUsuario.FK_IM_Cod = int.Parse(Request.Params["Id"]);
                                    objDtoMolduraxUsuario.IMU_Cantidad = int.Parse(txtDescripcionModal.Text);
                                    objDtoMolduraxUsuario.DMU_Precio = double.Parse(txtPrecioAprox.Value);

                                    _log.CustomWriteOnLog("AgregarCompraMoldura", " objDtoMolduraxUsuario.FK_VU_Cod = " + objDtoMolduraxUsuario.FK_VU_Cod);
                                    _log.CustomWriteOnLog("AgregarCompraMoldura", " objDtoMolduraxUsuario.FK_IM_Cod = " + objDtoMolduraxUsuario.FK_IM_Cod.ToString());
                                    _log.CustomWriteOnLog("AgregarCompraMoldura", " objDtoMolduraxUsuario.ISM_Cantidad = " + objDtoMolduraxUsuario.IMU_Cantidad.ToString());
                                    _log.CustomWriteOnLog("AgregarCompraMoldura", " objDtoMolduraxUsuario.DSM_Precio = " + objDtoMolduraxUsuario.DMU_Precio.ToString());

                                    objCtrMolduraxUsuario.registrarNuevaMoldura(objDtoMolduraxUsuario);
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#confirmacionmodal').modal('show');</script>", false);
                            
                     }
                    else //tipo baquetones
                    {
                        string m = "cantidad supera el limmite permitido";
                        _log.CustomWriteOnLog("carrito de compra", m);
                        mensaje.InnerText = m;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#confirmacionmodal1').modal('show');</script>", false);
                    }
                }
                else //supera stock
                {
                    string m = "cantidad supera al stock";
                    _log.CustomWriteOnLog("carrito de compra", m);
                    mensaje.InnerText = m;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#confirmacionmodal1').modal('show');</script>", false);
                }
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("AgregarCompraMoldura", "Error en agregar a carrito" + ex.Message + " StackTrace " +ex.StackTrace);

            throw;
        }


    }
    protected void btnAceptarRedirigir_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/CarritoCompras.aspx");

    }

    protected void btnAceptarPP_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/RealizarPedidoPersonalizado.aspx");
    }
}