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
            CargarMolduras();
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
    public void CargarMolduras()
    {
        objDtoSolicitud.PK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"]);
        gvMolduras.DataSource = objCtrSolicitud.ListaMolduras(objDtoSolicitud);
        gvMolduras.DataBind();
        if (objCtrSolicitud.LeerSolicitud(objDtoSolicitud))
        {
            lblcosto.Text = objDtoSolicitud.DS_ImporteTotal.ToString();
        }
    }
}