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

public partial class Prueba : System.Web.UI.Page
{
    CtrMoldura objCtrMoldura = new CtrMoldura();
    DtoMoldura objDtoMoldura = new DtoMoldura();
    DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
    Log _log = new Log();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        Image1.Visible = false;
        txtPagina.InnerText = "Agregar moldura";
        if (!Page.IsPostBack)
        {
            OpcionesTipoMoldura();
            if (Request.Params["Id"] != null)
            {
                Image1.Visible = true;
                txtPagina.InnerText = "Actualizar moldura";

                obtenerInformacionMoldura(Request.Params["Id"]);

            }
            else
            {
                ddlEstadoMoldura.SelectedValue = "1";
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
        _log.CustomWriteOnLog("PropiedadMoldura", "Termino de llenar el ddl");

    }

    public void obtenerInformacionMoldura(string id)
    {
        _log.CustomWriteOnLog("PropiedadMoldura", "-------------------------------------------------- Entro a actualización ----------------------------------------");
        objDtoMoldura.PK_IM_Cod = int.Parse(id);


        objCtrMoldura.ObtenerMoldura(objDtoMoldura, objDtoTipoMoldura);
        _log.CustomWriteOnLog("PropiedadMoldura", "Valores retornados");
        _log.CustomWriteOnLog("PropiedadMoldura", "PK_IM_Cod" + objDtoMoldura.PK_IM_Cod);
        _log.CustomWriteOnLog("PropiedadMoldura", "VM_Descripcion" + objDtoMoldura.VM_Descripcion);
        _log.CustomWriteOnLog("PropiedadMoldura", "PK_ITM_Tipo " + objDtoTipoMoldura.PK_ITM_Tipo);
        _log.CustomWriteOnLog("PropiedadMoldura", "VTM_Nombre" + objDtoTipoMoldura.VTM_Nombre);
        _log.CustomWriteOnLog("PropiedadMoldura", "DM_Medida" + objDtoMoldura.DM_Medida);
        _log.CustomWriteOnLog("PropiedadMoldura", "VTM_UnidadMetrica" + objDtoTipoMoldura.VTM_UnidadMetrica);
        _log.CustomWriteOnLog("PropiedadMoldura", "IM_Estado" + objDtoMoldura.IM_Estado);
        _log.CustomWriteOnLog("PropiedadMoldura", "IM_Stock" + objDtoMoldura.IM_Stock);
        _log.CustomWriteOnLog("PropiedadMoldura", "DM_Precio" + objDtoMoldura.DM_Precio);

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

        txtCodigo.Text = objDtoMoldura.PK_IM_Cod.ToString();
        ddlTipoMoldura.SelectedValue = objDtoTipoMoldura.PK_ITM_Tipo.ToString();
        txtPrecio.Text = objDtoMoldura.DM_Precio.ToString();
        txtStock.Text = objDtoMoldura.IM_Stock.ToString();
        txtMedida.Text = objDtoMoldura.DM_Medida.ToString();
        ddlEstadoMoldura.SelectedValue = objDtoMoldura.IM_Estado.ToString();
        txtDescripcion.Text = objDtoMoldura.VM_Descripcion;

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        _log.CustomWriteOnLog("PropiedadMoldura", "-------------------------------------------------------------Evento Click-----------------------");
        _log.CustomWriteOnLog("PropiedadMoldura", "Entró a evento de ingreso ");
        try
        {

            if (Request.Params["Id"] != null)
            {
                _log.CustomWriteOnLog("PropiedadMoldura", "La función es de actualización");

                objDtoMoldura.PK_IM_Cod = int.Parse(Request.Params["Id"]);
                _log.CustomWriteOnLog("PropiedadMoldura", "txtTipoMoldura = " + ddlTipoMoldura.SelectedValue);
                _log.CustomWriteOnLog("PropiedadMoldura", "ddlEstadoMoldura = " + ddlEstadoMoldura.SelectedValue);
                _log.CustomWriteOnLog("PropiedadMoldura", "txtStock = " + txtStock.Text);
                _log.CustomWriteOnLog("PropiedadMoldura", "txtPrecio = " + txtPrecio.Text);
                objDtoMoldura.DM_Precio = Double.Parse(txtPrecio.Text);
                objDtoMoldura.IM_Estado = int.Parse(ddlEstadoMoldura.SelectedValue);
                objDtoMoldura.IM_Stock = int.Parse(txtStock.Text);
                objDtoMoldura.FK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);
                objDtoMoldura.VM_Descripcion = txtDescripcion.Text;
                objDtoMoldura.DM_Medida = Double.Parse(txtMedida.Text);
                objCtrMoldura.ActualizarRegistroMoldura(objDtoMoldura);
                _log.CustomWriteOnLog("PropiedadMoldura", "Actualizado");
                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "uploadFileDocuments(" + Request.Params["Id"] + ");");

                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showSuccessMessage2()");

            }
            else
            {
                _log.CustomWriteOnLog("PropiedadMoldura", "La función es de creación");
                objDtoMoldura.DM_Precio = Double.Parse(txtPrecio.Text);
                objDtoMoldura.IM_Estado = int.Parse(ddlEstadoMoldura.SelectedValue);
                objDtoMoldura.IM_Stock = int.Parse(txtStock.Text);
                objDtoMoldura.FK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);
                objDtoMoldura.VM_Descripcion = txtDescripcion.Text;
                objDtoMoldura.DM_Medida = Double.Parse(txtMedida.Text);
                objCtrMoldura.registrarNuevaMoldura(objDtoMoldura);
                int ValorDevuelto = objDtoMoldura.PK_IM_Cod;
                _log.CustomWriteOnLog("PropiedadMoldura", "PK_IM_Cod valor retornado " + objDtoMoldura.PK_IM_Cod);
                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "uploadFileDocuments(" + objDtoMoldura.PK_IM_Cod + ");");
                _log.CustomWriteOnLog("PropiedadMoldura", "Agregado");
                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showSuccessMessage2()");
                _log.CustomWriteOnLog("PropiedadMoldura", "Completado");
            }


        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("PropiedadMoldura", "Error  = " + ex.Message + "posicion" + ex.StackTrace);

            throw;
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/GestionCatalogo.aspx");
    }

    protected void ddlEstadoMoldura_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}