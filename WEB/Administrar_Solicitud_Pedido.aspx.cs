using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

public partial class Administrar_Solicitud_Pedido : System.Web.UI.Page
{
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    protected void gvCarritoCompras_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gvCarritoCompras_RowCommand(object sender, GridViewCommandEventArgs e)
    {
          if (e.CommandName == "Ver")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvCarritoCompras.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                string Nombre = colsNoVisible[1].ToString();
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + Nombre + "', 'bottom', 'center', null, null);", true);
                //objDtoMoldura.PK_IM_Cod = int.Parse(id);
                //objCtrMoldura.ObtenerImagen_Desc_Moldura(objDtoMoldura);
                //_log.CustomWriteOnLog("GestionCatalogo", "ID" + id);
                //_log.CustomWriteOnLog("GestionCatalogo", "Descripcion" + objDtoMoldura.VM_Descripcion);
                //_log.CustomWriteOnLog("GestionCatalogo", "VBM_Imagen" + objDtoMoldura.VBM_Imagen);
                //_log.CustomWriteOnLog("GestionCatalogo", "IM_Stock" + objDtoMoldura.IM_Stock);

                //txtDescripcionModal.Text = objDtoMoldura.VM_Descripcion;
                //txtStockModal.Text = objDtoMoldura.IM_Stock.ToString();
                //tituloModal.InnerText = Nombre.ToString();

                //#region ObtenerImagen
                //string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                //using (SqlConnection con = new SqlConnection(cs))
                //{
                //    SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    SqlParameter paramId = new SqlParameter()
                //    {
                //        ParameterName = "@Id",
                //        Value = id
                //    };
                //    _log.CustomWriteOnLog("GestionCatalogo", "id" + id);


                //    cmd.Parameters.Add(paramId);
                //    _log.CustomWriteOnLog("GestionCatalogo", "1");

                //    con.Open();
                //    byte[] bytes = (byte[])cmd.ExecuteScalar();
                //    _log.CustomWriteOnLog("GestionCatalogo", "2");

                //    con.Close();
                //    string strbase64 = Convert.ToBase64String(bytes);
                //    _log.CustomWriteOnLog("GestionCatalogo", "3");

                //    Image1.ImageUrl = "data:Image/png;base64," + strbase64;
                //}
                //#endregion
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal').modal('show');</script>", false);

            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("GestionCatalogo", "Error = " + ex.Message + "Stac" + ex.StackTrace);

            }

        }
    }
}