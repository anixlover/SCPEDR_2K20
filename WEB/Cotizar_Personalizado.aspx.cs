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

public partial class Cotizar_Personalizado : System.Web.UI.Page
{
    Ctr_Solicitud objCtrSolicitud = new Ctr_Solicitud();
    DtoSolicitud objDtoSolicitud = new DtoSolicitud();
    DtoSolicitudEstado objDtoSolicitudEstado = new DtoSolicitudEstado();
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        Image1.Visible = false;
        txtPagina.InnerText = "Solicitud #";
        if (!Page.IsPostBack)
        {
            if (Request.Params["Id"] != null)
            {
                Image1.Visible = true;
                txtPagina.InnerText = "Solicitud #" + Request.Params["Id"];

                obtenerInformacionSolicitud(Request.Params["Id"]);

            }
        }
    }
    public void obtenerInformacionSolicitud(string id)
    {
        _log.CustomWriteOnLog("CotizarSolicitud", "-------------------------------------------------- Entro a Cotizacion ----------------------------------------");
        objDtoSolicitud.PK_IS_Cod = int.Parse(id);

        objCtrSolicitud.ObtenerSolicitudPersonalizado(objDtoSolicitud, objDtoSolicitudEstado);
        _log.CustomWriteOnLog("CotizarSolicitud", "Valores retornados");
        _log.CustomWriteOnLog("CotizarSolicitud", "PK_IS_Cod" + objDtoSolicitud.PK_IS_Cod);
        _log.CustomWriteOnLog("CotizarSolicitud", "VS_TipoSolicitud" + objDtoSolicitud.VS_TipoSolicitud);
        _log.CustomWriteOnLog("CotizarSolicitud", "VS_Medida " + objDtoSolicitud.VS_Medida);
        _log.CustomWriteOnLog("CotizarSolicitud", "IS_Cantidad" + objDtoSolicitud.IS_Cantidad);
        _log.CustomWriteOnLog("CotizarSolicitud", "DS_PrecioAprox" + objDtoSolicitud.DS_PrecioAprox);
        _log.CustomWriteOnLog("CotizarSolicitud", "VS_Comentario" + objDtoSolicitud.VS_Comentario);

        //ONTENER IMAGEN

        string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("SP_Detalle_Solicitud_P", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramId = new SqlParameter()
            {
                ParameterName = "@Cod",
                Value = id
            };
            cmd.Parameters.Add(paramId);
            con.Open();
            byte[] ByteArray = (byte[])cmd.ExecuteScalar();
            con.Close();
            string strbase64 = Convert.ToBase64String(ByteArray);
            Image1.ImageUrl = "data:Image/png;base64," + strbase64;
        }
        txt_tipo.Text = objDtoSolicitud.VS_TipoSolicitud.ToString();
        txt_medida.Text = objDtoSolicitud.VS_Medida.ToString();
        txt_cantidad.Text = objDtoSolicitud.IS_Cantidad.ToString();
        txt_precioaprox.Text = objDtoSolicitud.DS_PrecioAprox.ToString();
        txt_comentario.Text = objDtoSolicitud.VS_Comentario.ToString();


    }
    protected void btnrechazar_Click(object sender, EventArgs e)
    {

    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {

    }
    
    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }

}