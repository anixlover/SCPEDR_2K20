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

public partial class GestionCatalogo : System.Web.UI.Page
{
    CtrMoldura objCtrMoldura = new CtrMoldura();
    DtoMoldura objDtoMoldura = new DtoMoldura();
    DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                OpcionesTipoMoldura();
                UpdatePanel.Update();
                gvCatalogo.DataSource = objCtrMoldura.ListaMolduras();
                gvCatalogo.DataBind();
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("GestionCatalogo", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                throw;
            }
        }
    }
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PropiedadMoldura.aspx");
    }
    protected void gvCatalogo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvCatalogo.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                string Nombre = colsNoVisible[1].ToString();
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + Nombre + "', 'bottom', 'center', null, null);", true);
                objDtoMoldura.PK_IM_Cod = int.Parse(id);
                objCtrMoldura.ObtenerImagen_Desc_Moldura(objDtoMoldura);
                _log.CustomWriteOnLog("GestionCatalogo", "ID" + id);
                _log.CustomWriteOnLog("GestionCatalogo", "Descripcion" + objDtoMoldura.VM_Descripcion);
                _log.CustomWriteOnLog("GestionCatalogo", "VBM_Imagen" + objDtoMoldura.VBM_Imagen);
                _log.CustomWriteOnLog("GestionCatalogo", "IM_Stock" + objDtoMoldura.IM_Stock);

                txtDescripcionModal.Text = objDtoMoldura.VM_Descripcion;
                txtStockModal.Text = objDtoMoldura.IM_Stock.ToString();
                tituloModal.InnerText = Nombre.ToString();

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
                    _log.CustomWriteOnLog("GestionCatalogo", "id" + id);


                    cmd.Parameters.Add(paramId);
                    _log.CustomWriteOnLog("GestionCatalogo", "1");

                    con.Open();
                    byte[] bytes = (byte[])cmd.ExecuteScalar();
                    _log.CustomWriteOnLog("GestionCatalogo", "2");

                    con.Close();
                    string strbase64 = Convert.ToBase64String(bytes);
                    _log.CustomWriteOnLog("GestionCatalogo", "3");

                    Image1.ImageUrl = "data:Image/png;base64," + strbase64;
                }
                #endregion
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal').modal('show');</script>", false);

            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("GestionCatalogo", "Error = " + ex.Message + "Stac" + ex.StackTrace);
            }

        }
        else if (e.CommandName == "Actualizar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvCatalogo.DataKeys[index].Values;
            string id = colsNoVisible[0].ToString();
            Response.Redirect("~/PropiedadMoldura.aspx?ID=" + id);
        }
    }
    protected void gvCatalogo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell statusCell = e.Row.Cells[5];
            if (statusCell.Text == "1")
            {
                statusCell.Text = "H";
            }
            if (statusCell.Text == "0")
            {
                statusCell.Text = "D";
            }
        }
    }
    public void OpcionesTipoMoldura()
    {
        DataSet ds = new DataSet();
        ds = objCtrMoldura.OpcionesTipoMoldura();
        ddl_TipoMoldura.DataSource = ds;
        ddl_TipoMoldura.DataTextField = "VTM_Nombre";
        ddl_TipoMoldura.DataValueField = "PK_ITM_Tipo";
        ddl_TipoMoldura.DataBind();
        ddl_TipoMoldura.Items.Insert(0, new ListItem("Seleccione", "0"));
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_TipoMoldura.SelectedValue != "0")
            {
                _log.CustomWriteOnLog("GestionarCatalogo", "Entro a busqueda");
                objDtoTipoMoldura.PK_ITM_Tipo = int.Parse(ddl_TipoMoldura.SelectedValue);
                _log.CustomWriteOnLog("GestionarCatalogo", "objDtoTipoMoldura.PK_ITM_Tipo : "+ objDtoTipoMoldura.PK_ITM_Tipo);
                UpdatePanel.Update();
                gvCatalogo.DataSource = objCtrMoldura.ListarMoldurasByTipoMoldura(objDtoTipoMoldura);
                gvCatalogo.DataBind();
                _log.CustomWriteOnLog("GestionarCatalogo", "Paso");
            }
            else
            {
                UpdatePanel.Update();
                gvCatalogo.CssClass = "table table-bordered table-hover js-basic-example dataTable";
                gvCatalogo.DataSource = objCtrMoldura.ListaMolduras();
                gvCatalogo.DataBind();
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("GestionarCatalogo", "Error busqueda :" +ex.Message);

            throw;
        }
        
    }
    
}