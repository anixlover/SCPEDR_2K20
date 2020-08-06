using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using DAO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class ConsultarEstadoPago : System.Web.UI.Page
{
    DtoSolicitud objDtoSolicitud = new DtoSolicitud();
    Ctr_Solicitud objCtrSolicitud = new Ctr_Solicitud();
    DtoMolduraxUsuario dtoMolduraxUsuario = new DtoMolduraxUsuario();
    DtoSolicitudEstado objDtoSolicitudEstado = new DtoSolicitudEstado();
    CtrMolduraxUsuario objCtrMolduraxUsuario = new CtrMolduraxUsuario();
    CtrVoucher objCtrVoucher = new CtrVoucher();
    DtoVoucher objvoucherdao = new DtoVoucher();


    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _log.CustomWriteOnLog("consultar estado de pago", "Carga de pagina");
            try
            {
                
                if (Session["DNIUsuario"] != null)
                {
                    //objDtoSolicitud.PK_IS_Cod = 2;
                    OpcionesSolicitudEstado();
                    dtoMolduraxUsuario.FK_VU_Cod = Session["DNIUsuario"].ToString();
                    gvConsultar.DataSource = objCtrSolicitud.TablaConsultaEstado(objDtoSolicitud, dtoMolduraxUsuario);
                    gvConsultar.DataBind();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("consultar estado de pago", ex.Message + "Stac" + ex.StackTrace);
            }
        }

    }

    protected void gvConsultar_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {

                case "Pago":

                    int index = Convert.ToInt32(e.CommandArgument);
                    var columna = gvConsultar.DataKeys[index].Values;
                    int id = Convert.ToInt32(columna[0].ToString());
                    _log.CustomWriteOnLog("consultar estado de pago", "id  " + id);
                    Session["idSolicitudPago"] = id;
                    Response.Redirect("Realizar_compra.aspx");
                    break;

                case "Ver proceso": _log.CustomWriteOnLog("consultar estado pago", "paso");
                    dtoMolduraxUsuario.FK_VU_Cod = Session["DNIUsuario"].ToString();
                    int index2 = Convert.ToInt32(e.CommandArgument);
                    var columna2 = gvConsultar.DataKeys[index2].Values;
                    int id2 = Convert.ToInt32(columna2[0].ToString());
                    dtoMolduraxUsuario.FK_IS_Cod = id2;
                    gvListaxMoldura.DataSource = objCtrMolduraxUsuario.listarMolduraxSxU(dtoMolduraxUsuario);
                    gvListaxMoldura.DataBind();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal1').modal('show');</script>", false);
                    break;

                case "Ver incidencias":
                    dtoMolduraxUsuario.FK_VU_Cod = Session["DNIUsuario"].ToString();
                    int index3 = Convert.ToInt32(e.CommandArgument);
                    var columna3 = gvConsultar.DataKeys[index3].Values;
                    int id3 = Convert.ToInt32(columna3[0].ToString());
                    dtoMolduraxUsuario.FK_IS_Cod = id3;
                    gvListaxMolduraxIncidencia.DataSource = objCtrMolduraxUsuario.listarMolduraxusuarioxincidente(dtoMolduraxUsuario);
                    gvListaxMolduraxIncidencia.DataBind();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal2').modal('show');</script>", false);
                    break;

                case "Ver detalle":
                    //dtoMolduraxUsuario.FK_VU_Cod = Session["DNIUsuario"].ToString();
                    int index4 = Convert.ToInt32(e.CommandArgument);
                    var columna4 = gvConsultar.DataKeys[index4].Values;
                    string id4 = columna4[0].ToString();
                    objDtoSolicitud.PK_IS_Cod = int.Parse(id4);
                    objCtrVoucher.DetallesVoucherSolicitudUsuario(objvoucherdao,objDtoSolicitud,dtoMolduraxUsuario);

                    string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("SP_DVS", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramId = new SqlParameter()
                        {
                            ParameterName = "@idsol",
                            Value = objDtoSolicitud.PK_IS_Cod
                        };
                        cmd.Parameters.Add(paramId);
                        con.Open();
                        byte[] bytes = (byte[])cmd.ExecuteScalar();
                        con.Close();
                        string strbase64 = Convert.ToBase64String(bytes);
                        ImageV.ImageUrl = "data:Image/png;base64," + strbase64;
                    }
                    txtFechaEmision.Text = objDtoSolicitud.DTS_FechaEmicion.ToString();
                    txtNroOpe.Text = objvoucherdao.PK_VV_NumVoucher.ToString();
                    txtImporte.Text = objvoucherdao.DV_ImporteDepositado.ToString();


                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal3').modal('show');</script>", false);
                    break;

                case "Actualizar":
                    ImageVo.Visible = true;
                    
                    int index5 = Convert.ToInt32(e.CommandArgument);
                    var columna5 = gvConsultar.DataKeys[index5].Values;
                    string id5 = columna5[0].ToString();
                    objDtoSolicitud.PK_IS_Cod = int.Parse(id5);
                    objCtrVoucher.DetallesVoucherSolicitudUsuario(objvoucherdao, objDtoSolicitud, dtoMolduraxUsuario);

                    //string ac = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                    //using (SqlConnection con = new SqlConnection(ac))
                    //{
                    //    SqlCommand cmd = new SqlCommand("SP_DVS", con);
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    SqlParameter paramId = new SqlParameter()
                    //    {
                    //        ParameterName = "@idsol",
                    //        Value = objDtoSolicitud.PK_IS_Cod
                    //    };
                    //    cmd.Parameters.Add(paramId);
                    //    con.Open();
                    //    byte[] bytes = (byte[])cmd.ExecuteScalar();
                    //    con.Close();
                    //    string strbase64 = Convert.ToBase64String(bytes);
                    //    ImageVo.ImageUrl = "data:Image/png;base64," + strbase64;
                    //}

                    Utils.AddScriptClientUpdatePanel(UpdatePanelA, "uploadFileDocuments(" + Request.Params["Id"] + ");");


                    txtFechaEmisionA.Text = objDtoSolicitud.DTS_FechaEmicion.ToString();
                    txtNroOpeA.Text = objvoucherdao.PK_VV_NumVoucher.ToString();
                    txtImporteA.Text = objvoucherdao.DV_ImporteDepositado.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal4').modal('show');</script>", false);
                    break;

            }
        }
        catch (Exception ex)
        {

            _log.CustomWriteOnLog("consultar estado de pago", "error = " + ex.Message);
        }

        //switch (e.CommandName){

        //    case "Pago":

        //        int index = Convert.ToInt32(e.CommandArgument);
        //        var columna = gvConsultar.DataKeys[index].Values;
        //        int id = Convert.ToInt32(columna[0].ToString());
        //        _log.CustomWriteOnLog("consultar estado de pago", "id  " + id);
        //        Session["idSolicitudPago"] = id;
        //        Response.Redirect("Realizar_compra.aspx");
        //        break;

        //    case "Ver detalles":
        //        //int index2 = Convert.ToInt32(e.CommandArgument);
        //        //var columna2 = gvConsultar.DataKeys[index2].Values;
        //        //int id2 = Convert.ToInt32(columna2[0].ToString());
        //        //dtoMolduraxUsuario.FK_VU_Cod = Session["DNIUsuario"].ToString();
        //        //dtoMolduraxUsuario.FK_IS_Cod = id2;
        //        //gvListaxMoldura.DataSource= objCtrMolduraxUsuario.listarMolduraxSxU(dtoMolduraxUsuario);
        //        //gvListaxMoldura.DataBind();
        //        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('defaultmodal1').modal('show');</script>", false);
        //        //break;
        //        dtoMolduraxUsuario.FK_VU_Cod = Session["DNIUsuario"].ToString();
        //        int index2 = Convert.ToInt32(e.CommandArgument);
        //        var columna2 = gvConsultar.DataKeys[index2].Values;
        //        int id2 = Convert.ToInt32(columna2[0].ToString());
        //        dtoMolduraxUsuario.FK_IS_Cod = id2;
        //        gvListaxMoldura.DataSource = objCtrMolduraxUsuario.listarMolduraxSxU(dtoMolduraxUsuario);
        //        gvListaxMoldura.DataBind();
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('defaultmodal1').modal('show');</script>", false);
        //        break;





        //}

        //if (e.CommandName == "Pago")
        //{
        //    try
        //    {
        //        int index = Convert.ToInt32(e.CommandArgument);
        //        var columna = gvConsultar.DataKeys[index].Values;
        //        int id = Convert.ToInt32(columna[0].ToString());
        //        _log.CustomWriteOnLog("consultar estado de pago", "id  " + id);
        //        Session["idSolicitudPago"] = id;
        //        Response.Redirect("Realizar_compra.aspx");

        //    }

        //    catch (Exception ex)
        //    {
        //        _log.CustomWriteOnLog("consultar estado de pago", ex.Message + "Stac" + ex.StackTrace);
        //    }
        //}
    }

    public void OpcionesSolicitudEstado()
    {
        DataSet ds = new DataSet();
        ds = objCtrSolicitud.OpcionesSolicitudEstado();
        ddl_SolicitudEstado.DataSource = ds;
        ddl_SolicitudEstado.DataTextField = "V_SE_Nombre";
        ddl_SolicitudEstado.DataValueField = "PK_ISE_Cod";
        ddl_SolicitudEstado.DataBind();
        ddl_SolicitudEstado.Items.Insert(0, new ListItem("Todos", "0"));

    }
    protected void gvConsultar_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvConsultar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }

    protected Boolean ValidacionEstado(string estado)
    {
        return estado == "Pendiente de pago";
    }
    protected Boolean ValidacionEstado2(string estado)
    {
        return estado == "Observada";
    }
    protected Boolean ValidacionEstado3(string estado)
    {
        return estado == "Aprobada";
    }
    protected Boolean ValidacionEstado4(string estado)
    {
        return estado == "En proceso";
    }
    protected Boolean ValidacionEstado5(string estado)
    {
        return estado == "Con retraso";
    }
    



    protected void ddl_SolicitudEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {

        try
        {
            if (ddl_SolicitudEstado.SelectedValue != "0")
            {
                _log.CustomWriteOnLog("ConsultarEstadoPago", "Entro a busqueda");
                
                _log.CustomWriteOnLog("ConsultarEstadoPago", "objDtoTipoMoldura.PK_ITM_Tipo : " + objDtoSolicitudEstado.PK_ISE_Cod);
                //UpdatePanel.Update();
                gvConsultar.CssClass = "table table-bordered table-hover js-basic-example dataTable";
                dtoMolduraxUsuario.FK_VU_Cod = Session["DNIUsuario"].ToString();
                objDtoSolicitudEstado.PK_ISE_Cod = int.Parse(ddl_SolicitudEstado.SelectedValue);
                gvConsultar.DataSource = objCtrSolicitud.ListarSolicitudxEstado(objDtoSolicitud, dtoMolduraxUsuario, objDtoSolicitudEstado);
                gvConsultar.DataBind();
                _log.CustomWriteOnLog("GestionarCatalogo", "Paso");
            }

            else
            {
                //UpdatePanel.Update();
                gvConsultar.CssClass = "table table-bordered table-hover js-basic-example dataTable";
                dtoMolduraxUsuario.FK_VU_Cod = Session["DNIUsuario"].ToString();
                gvConsultar.DataSource = objCtrSolicitud.TablaConsultaEstado(objDtoSolicitud, dtoMolduraxUsuario);
                gvConsultar.DataBind();
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("GestionarCatalogo", "Error busqueda :" + ex.Message);

            throw;
        }
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        

        objDtoSolicitud.PK_IS_Cod= Convert.ToInt32(txtcodSol.Text);
        //objvoucherdao.VBV_Foto = Convert.ToBase64String(ImageVo.ImageUrl);
        //////// Double.Parse(txtMedida.Text);
        ////////Encoding.ASCII.GetBytes(reader[0].ToString());
        //////objvoucherdao.VBV_Foto = Convert.ToBase64String(ImageVo.ImageUrl);/* Encoding.ASCII.GetBytes(reader[0].ToString());*/
        //////ImageVo.ImageUrl = "data:Image/png;base64," + strbase64; 
        objCtrVoucher.ActualizarVoucher(objDtoSolicitud);
        //_log.CustomWriteOnLog("PropiedadMoldura", "Actualizado");
    }
}