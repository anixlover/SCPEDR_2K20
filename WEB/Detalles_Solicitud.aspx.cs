using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

public partial class Detalles_Solicitud : System.Web.UI.Page
{
    DtoUsuario user = new DtoUsuario();
    CtrUsuario ctruser = new CtrUsuario();
    DtoSolicitud objDtoSolicitud = new DtoSolicitud();
    Ctr_Solicitud objCtrSolicitud = new Ctr_Solicitud();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarCliente();
            CargarMolduras2();
        }
    }
    public void CargarCliente()
    {
        string dni= Session["clienteDNI"].ToString();
        user.PK_VU_Dni = dni;
        if (ctruser.ExisteUsuario(user))
        {
            lblsol.Text = Session["idSolicitudPago"].ToString();
            lbldni.Text = user.PK_VU_Dni;
            lblnombre.Text = user.VU_Nombre +" "+ user.VU_Apellidos;
            lblcorreo.Text = user.VU_Correo;
        }
    }
    public void CargarMolduras2() 
    {
        objDtoSolicitud.PK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"]);

        if (objCtrSolicitud.leerSolicitudTipo(objDtoSolicitud))
        {
            if (objDtoSolicitud.VS_TipoSolicitud == "Personalizado por catalogo" || objDtoSolicitud.VS_TipoSolicitud == "Catalogo")
            {
                objCtrSolicitud.LeerSolicitud(objDtoSolicitud);
                imgPersonal.Visible = false;
                gvMolduras.Visible = true;
                txtcomentario.Visible = false;
                lblcosto.Text = "S/" + objDtoSolicitud.DS_ImporteTotal.ToString();
                gvMolduras.DataSource = objCtrSolicitud.ListaMolduras(objDtoSolicitud);
                gvMolduras.DataBind();
            }
            if (objDtoSolicitud.VS_TipoSolicitud == "Personalizado por diseño propio")
            {
                objCtrSolicitud.leerSolicitudDiseñoPersonal(objDtoSolicitud);
                gvMolduras.Visible = false;
                imgPersonal.Visible = true;
                txtcomentario.Visible = true;
                lblcosto.Text = "Aproximado: S/"+objDtoSolicitud.DS_PrecioAprox.ToString();
                string imagen = Convert.ToBase64String(objDtoSolicitud.VBS_Imagen);
                imgPersonal.ImageUrl = "data:Image/png;base64," + imagen;
                txtcomentario.Text = objDtoSolicitud.VS_Comentario;
            }
        }
    }
}