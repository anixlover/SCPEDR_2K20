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

public partial class CarritoCompras : System.Web.UI.Page
{
    CtrMolduraxUsuario objCtrMXU = new CtrMolduraxUsuario();
    DtoMolduraxUsuario objDtoMXU = new DtoMolduraxUsuario();
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["DNIUsuario"]!=null)
            {
                objDtoMXU.FK_VU_Cod = Session["DNIUsuario"].ToString();
                UpdatePanel.Update();
                gvCarrito.DataSource = objCtrMXU.listarMoldurasxusuario(objDtoMXU);
                gvCarrito.DataBind();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("carrito de compra", ex.Message + "Stac" + ex.StackTrace);

            throw;
        }

    }

    protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvCarrito.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                objDtoMXU.PK_IMU_Cod = int.Parse(id);
                DtoMoldura objDtoMoldura = new DtoMoldura();
                DtoTipoMoldura dtoTipoMoldura = new DtoTipoMoldura();
                objCtrMXU.obtenerMoldura(objDtoMXU, objDtoMoldura, dtoTipoMoldura);

                //_log.CustomWriteOnLog("carrito de compra", "imagen" + objDtoMoldura.VBM_Imagen.ToString());
                _log.CustomWriteOnLog("carrito de compra", "PK_IMU_Cod" + objDtoMXU.PK_IMU_Cod.ToString());
                _log.CustomWriteOnLog("carrito de compra", "descripcion" + objDtoMoldura.VM_Descripcion);
                _log.CustomWriteOnLog("carrito de compra", "tipomoldura" + dtoTipoMoldura.VTM_Nombre);
                _log.CustomWriteOnLog("carrito de compra", "medida" + objDtoMoldura.DM_Medida.ToString());
                _log.CustomWriteOnLog("carrito de compra", "unidad metrica" + dtoTipoMoldura.VTM_UnidadMetrica);
                _log.CustomWriteOnLog("carrito de compra", "cantidad" + objDtoMXU.PK_IMU_Cod.ToString());
                _log.CustomWriteOnLog("carrito de compra", "precio" + objDtoMXU.DMU_Precio.ToString());

                txtcodigoModal.Text = objDtoMXU.PK_IMU_Cod.ToString();
                txtDescripcionModal.Text = objDtoMoldura.VM_Descripcion;
                txtprecior.Value = objDtoMoldura.DM_Precio.ToString();
                txtTMModal.Text = dtoTipoMoldura.VTM_Nombre;
                txtMedidaModal.Text = objDtoMoldura.DM_Medida.ToString();
                txtUMModal.Text = dtoTipoMoldura.VTM_UnidadMetrica;
                txtcantidadModal.Text = objDtoMXU.IMU_Cantidad.ToString();
                txtPrecioModal.Value = objDtoMXU.DMU_Precio.ToString();
                _log.CustomWriteOnLog("carrito de compra", "moldura" + objDtoMoldura.PK_IM_Cod);
                #region ObtenerImagen
                string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramId = new SqlParameter()
                    {
                        ParameterName = "@Id",
                        Value = objDtoMoldura.PK_IM_Cod
                    };
                    _log.CustomWriteOnLog("carrito de compra", "id" + objDtoMoldura.PK_IM_Cod);


                    cmd.Parameters.Add(paramId);
                    _log.CustomWriteOnLog("carrito de compra", "1");

                    con.Open();
                    byte[] bytes = (byte[])cmd.ExecuteScalar();
                    _log.CustomWriteOnLog("carrito de compra", "2");

                    con.Close();
                    string strbase64 = Convert.ToBase64String(bytes);
                    _log.CustomWriteOnLog("carrito de compra", "3");

                    Image1.ImageUrl = "data:Image/png;base64," + strbase64;
                }
                #endregion
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal').modal('show');</script>", false);

            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("carrito de compra", ex.Message + "Stac" + ex.StackTrace);

                throw;
            }
        }
        if (e.CommandName == "Eliminar")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvCarrito.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                objDtoMXU.PK_IMU_Cod = int.Parse(id);

                _log.CustomWriteOnLog("carrito de compra", "eliminar id:" + id);
                _log.CustomWriteOnLog("carrito de compra", "dni:" + Session["DNIUsuario"].ToString());
                objCtrMXU.eliminarMXU(objDtoMXU);
                objDtoMXU.FK_VU_Cod = Session["DNIUsuario"].ToString();
                UpdatePanel.Update();
                gvCarrito.DataSource = objCtrMXU.listarMoldurasxusuario(objDtoMXU);
                gvCarrito.DataBind();
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("carrito de compra", ex.Message + "Stac" + ex.StackTrace);

                throw;
            }
        }
    }


    protected void btnPagar_Click(object sender, EventArgs e)
    {

    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            _log.CustomWriteOnLog("carrito de compra", "Entro a funcion actualizar");
            objDtoMXU.PK_IMU_Cod = Convert.ToInt32(txtcodigoModal.Text);
            objDtoMXU.IMU_Cantidad = Convert.ToInt32(txtcantidadModal.Text);
            objDtoMXU.DMU_Precio = Convert.ToDouble(txtPrecioModal.Value);
            _log.CustomWriteOnLog("carrito de compra", "objDtoMXU.PK_IMU_Cod :" + objDtoMXU.PK_IMU_Cod.ToString());
            _log.CustomWriteOnLog("carrito de compra", "objDtoMXU.IMU_Cantidadr :" + objDtoMXU.IMU_Cantidad.ToString());
            _log.CustomWriteOnLog("carrito de compra", "objDtoMXU.DMU_Precio :" + objDtoMXU.DMU_Precio.ToString());

            objCtrMXU.actualizarMXU(objDtoMXU);
            _log.CustomWriteOnLog("carrito de compra", "Paso funcion :");

            objDtoMXU.FK_VU_Cod = Session["DNIUsuario"].ToString();
            _log.CustomWriteOnLog("carrito de compra", "objDtoMXU.FK_VU_Cod :" + objDtoMXU.FK_VU_Cod);

            UpdatePanel.Update();
            gvCarrito.DataSource = objCtrMXU.listarMoldurasxusuario(objDtoMXU);
            _log.CustomWriteOnLog("carrito de compra", "listarmolduraxusuario paso");
            Utils.AddScriptClientUpdatePanel(UpdatePanel, "showSuccessMessage2()");

            gvCarrito.DataBind();

        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("carrito de compra", ex.Message + "Stac" + ex.StackTrace);
        }
    }
}