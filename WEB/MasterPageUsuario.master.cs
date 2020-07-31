using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageUsuario : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["id_perfil"] == null)
            {
                perfil_Socio();
                Session.Clear();
            }
            else
            {
                int perfil = int.Parse(Session["id_perfil"].ToString());
                switch (perfil)
                {
                    case 1:
                        perfil_Socio_Logeado();
                        break;
                    case 2:
                        break;
                    default:
                        perfil_Socio();
                        Session.Clear();
                        //Session.Abandon();
                        //Response.Redirect("~/Login.aspx");
                        break;
                }

            }

        }
        catch (Exception ex)
        {
            Session.Clear();
            Session.Abandon();
            //Response.Redirect("~/Login.aspx");
        }
    }
    public void perfil_Socio()
    {
        string html = string.Format(@"
                       <a href='Login.aspx'>Iniciar Sesion</a>
                        <a href='RegistrarClienteUE_1.aspx'>Registrate</a>
                    ");
        this.Literal1.Text = html;
    }
    public void perfil_Socio_Logeado()
    {
        string nombreusuario = Session["NombreUsuario"].ToString();
        string dni = Session["DNIUsuario"].ToString();

        string html = string.Format(@"
                         <div class='btn-group' role='group'>
                        <button type='button' class='btn btnCustomMaster waves-effect dropdown-toggle' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>
                            Hola " + nombreusuario + @"
                                            <span class='caret'></span>
                        </button>
                        <ul class='dropdown-menu bcColor'>
                            <li><a href='RealizarPedidoPersonalizado.aspx' class=' waves-effect waves-block'>Pedidos Personalizados</a></li>
                            <li><a href='ConsultarEstadoPago.aspx' class=' waves-effect waves-block'>Mis pedidos</a></li>
                            <li><a id='btnCarrito' runat='server' onClick='cargarId(" + dni + @")' class=' waves-effect waves-block'>Carrito Compras</a></li>
                            <li><a href='CambiarContraseña.aspx' id='btnCambiarContra' runat='server' onClick='cargarId(" + dni + @")' class=' waves-effect waves-block'>Cambiar contrase&ntilde;a </a></li
                            <li><a id='btnCerrarSesion' runat='server' onserverclick='btnCerrarSesion_ServerClick' class=' waves-effect waves-block'>Cerrar sesión</a></li>
                        </ul>
                    </div>
                    ");
        this.Literal1.Text = html;
    }


    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {

    }
    
    protected void btnCerrarSesion_ServerClick(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Remove("id_perfil");
        Session.Abandon();
        HttpContext.Current.Session.Abandon();
        Session.RemoveAll();
        Session["id_perfil"] = null;
        Response.Redirect("~/Login.aspx");

    }
}
