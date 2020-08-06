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


public partial class Gestionar_Estado_Pedido : System.Web.UI.Page
{
    Ctr_Solicitud objctrSolicitud = new Ctr_Solicitud();
    CtrMoldura objCtrMoldura = new CtrMoldura();

    DtoSolicitud objdtosol = new DtoSolicitud();
    DtoMoldura objDtoMoldura = new DtoMoldura();
    DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {
                UpdatePanel.Update();
                gvCatalogo.DataSource = objctrSolicitud.ListaSolicitudesGestion();
                gvCatalogo.DataBind();
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("GestionPedido", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                throw;
            }

        }
       
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

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

                if (Nombre == "Personalizado por Diseño Propio")
                {
                    objdtosol.PK_IS_Cod = Convert.ToInt32(id);
                    objctrSolicitud.ModalPXDP(objdtosol);

                    txtcodigosolicitud.Text = objdtosol.PK_IS_Cod.ToString();
                    txttiposolicitud.Text = objdtosol.VS_TipoSolicitud;
                    //txtfecharegistro.Text = objdtosol.DTS_FechaRegistro.ToString();
                    txtestadosolicitud.Text = objdtosol.VS_Comentario;

                    #region ObtenerImagen
                    string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetImageById2", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramId = new SqlParameter()
                        {
                            ParameterName = "@Id",
                            Value = id
                        };
                        _log.CustomWriteOnLog("GestionPedido", "id" + id);


                        cmd.Parameters.Add(paramId);
                        _log.CustomWriteOnLog("GestionPedido", "1");

                        con.Open();
                        byte[] bytes = (byte[])cmd.ExecuteScalar();
                        _log.CustomWriteOnLog("GestionPedido", "2");

                        con.Close();
                        string strbase64 = Convert.ToBase64String(bytes);
                        _log.CustomWriteOnLog("GestionPedido", "3");

                        Image1.ImageUrl = "data:Image/png;base64," + strbase64;
                    }
                    #endregion

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal3').modal('show');</script>", false);
                }
                else 
                {
                    objdtosol.PK_IS_Cod = Convert.ToInt32(id);
                    objctrSolicitud.ModalAllmDP(objdtosol);

                    txtcod2.Text = objdtosol.PK_IS_Cod.ToString();
                    txttiposol2.Text = objdtosol.VS_TipoSolicitud;
                    //txtfecharegistro.Text = objdtosol.DTS_FechaRegistro.ToString();
                    txtestadosol2.Text = objdtosol.VS_Comentario;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal4').modal('show');</script>", false);


                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("GestionPedido", "Error = " + ex.Message + "Stac" + ex.StackTrace);

            }

        }
        else if (e.CommandName == "Actualizar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvCatalogo.DataKeys[index].Values;
            string id = colsNoVisible[0].ToString();
            Response.Redirect("~/Actualizar_Proceso.aspx?ID=" + id);
        }
    }

    protected void gvCatalogo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}