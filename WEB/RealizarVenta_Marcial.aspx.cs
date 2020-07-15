using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using DAO;
using CTR;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ListItem = System.Web.UI.WebControls.ListItem;

public partial class RealizarVenta_Marcial : System.Web.UI.Page
{

    DtoMoldura objDtoMoldura = new DtoMoldura();
    CtrMoldura objCtrMoldura = new CtrMoldura();
    DtoMoldura objdtomoldura = new DtoMoldura();
    DtoUsuario objuser = new DtoUsuario();
    SqlConnection conexion = new SqlConnection(ConexionBD.CadenaConexion);
    Log _log = new Log();
    CtrMolduraxUsuario objCtrMolduraxUsuario = new CtrMolduraxUsuario();
    DataTable dt = new DataTable();

    List<DtoMolduraAgregada> lstDtoMolduraAgregada = new List<DtoMolduraAgregada>();
    DtoMolduraAgregada objDtoMolduraAgregada = new DtoMolduraAgregada();
    DtoMolduraxUsuario objDtoMolduraxUsuario = new DtoMolduraxUsuario();
    DtoSolicitud objDtoSolicitud = new DtoSolicitud();
    Ctr_Solicitud objCtrSolicitud = new Ctr_Solicitud();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (ViewState["Records"] == null)
            {
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Cantidad");
                dt.Columns.Add("Precio");
                dt.Columns.Add("Subtotal");
                ViewState["Records"] = dt;
            }
            OpcionesTipoMoldura();
        }
    }

    protected void ddl_TipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
    {
        _log.CustomWriteOnLog("Realizar venta 1", "valorddl : " + valorObtenidoRBTN.Value);


    }

    protected void btnboleta_Click(object sender, EventArgs e)
    {
        
        objDtoSolicitud.DS_ImporteTotal = double.Parse(txtimporteigv.Text);
        objCtrSolicitud.RegistrarSolicitud_LD2(objDtoSolicitud);
        int ValorDevuelto = objDtoSolicitud.PK_IS_Cod;
        _log.CustomWriteOnLog("Realizar venta 1", "ValorDevuelto = " + ValorDevuelto);

        for (int i = 0; i < gv2.Rows.Count; i++)
        {
            string codigoMoldura = gv2.Rows[i].Cells[1].Text;
            string subtotalMoldura = gv2.Rows[i].Cells[4].Text;
            string cantidadMoldura = gv2.Rows[i].Cells[2].Text;
            _log.CustomWriteOnLog("Realizar venta 1", " txtIdentificadorUsuario.Text = " + txtIdentificadorUsuario.Text);
            _log.CustomWriteOnLog("Realizar venta 1", "codigoMoldura = " + codigoMoldura);
            _log.CustomWriteOnLog("Realizar venta 1", "cantidadMoldura = " + cantidadMoldura);
            _log.CustomWriteOnLog("Realizar venta 1", "subtotalMoldura = " + subtotalMoldura);

            objDtoMolduraxUsuario.FK_VU_Cod = txtIdentificadorUsuario.Text;
            objDtoMolduraxUsuario.FK_IM_Cod = int.Parse(codigoMoldura);
            objDtoMolduraxUsuario.IMU_Cantidad = int.Parse(cantidadMoldura);
            objDtoMolduraxUsuario.DMU_Precio = double.Parse(subtotalMoldura);
            objDtoMolduraxUsuario.FK_IS_Cod = ValorDevuelto;
            
            objCtrMolduraxUsuario.registrarNuevaMoldura2(objDtoMolduraxUsuario);
            _log.CustomWriteOnLog("Realizar venta 1", "Registro moldura : " +codigoMoldura + " para el usuario "+ txtIdentificadorUsuario.Text);

        }
    }

    protected void btnfactura_Click(object sender, EventArgs e)
    {
        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            Document document = new Document(PageSize.A4, 10, 10, 10, 10);

            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            Chunk chunk = new Chunk("Comprobante generado ");
            document.Add(chunk);

            //Phrase phrase = new Phrase("This is from Phrase.");
            //document.Add(phrase);

            Paragraph para = new Paragraph("Generado para : ");
            document.Add(para);

            string text = @"Comprobante generado para el cliente.";
            Paragraph paragraph = new Paragraph();
            paragraph.SpacingBefore = 10;
            paragraph.SpacingAfter = 10;
            paragraph.Alignment = Element.ALIGN_LEFT;
            paragraph.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.GREEN);
            paragraph.Add(text);
            document.Add(paragraph);

            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";

            string pdfName = "User";
            Response.AddHeader("Content-Disposition", "attachment; filename=Boleta.pdf");
            Response.ContentType = "application/pdf";
            Response.Buffer = true;
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
        }
    }

    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string Select = "SELECT * from T_Usuario where PK_VU_Dni = @Dni";

            SqlCommand unComando = new SqlCommand(Select, conexion);

            unComando.Parameters.AddWithValue("@Dni", txtIdentificadorUsuario.Text);
            _log.CustomWriteOnLog("Realizar venta 1", "txtIdentificadorUsuario.Text " + txtIdentificadorUsuario.Text);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                txtNombres.Text = reader["VU_Nombre"].ToString();
                txtapellido.Text = reader["VU_Apellidos"].ToString();
                txtcorreo.Text = reader["VU_Correo"].ToString();
                txttelefono.Text = reader["IU_Celular"].ToString();
            }

            //divBodyResultsDNI.Visible = true;
            conexion.Close();
            updPanel1.Update();
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("Realizar venta 1", "Error  : " + ex.Message);

        }

    }

    protected void Rbboleta_CheckedChanged(object sender, EventArgs e)
    {
    }

    protected void Rbfactura_CheckedChanged(object sender, EventArgs e)
    {
    }

    protected void btnBuscarProducto_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Moldura_x_Codigo_2", conexion);
            command.Parameters.AddWithValue("@codigoMol", txtcodigo.Text);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            daAdaptador.Fill(dt);
            conexion.Close();
            gvdetalle.DataSource = dt;

            updPanelGVDetalle.Update();
            gvdetalle.DataBind();
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("Realizar venta 1", "Error btncalcular_Click  : " + ex.Message);

        }

    }

    protected void btncalcular_Click(object sender, EventArgs e)
    {

        try
        {
            var colsNoVisible = gvdetalle.DataKeys[0].Values;

            int IM_Stock = int.Parse(colsNoVisible[0].ToString());
            double DM_Precio = double.Parse(colsNoVisible[1].ToString());


            int cantidad = int.Parse(txtcantidad.Text);
            double precioAprox = 0;
            _log.CustomWriteOnLog("Realizar venta 1", "STOCK DE MOLDURA  : " + IM_Stock.ToString());
            _log.CustomWriteOnLog("Realizar venta 1", "PRECIO DE MOLDURA    : " + DM_Precio.ToString());
            if (cantidad <= IM_Stock)
            {
                precioAprox = cantidad * DM_Precio;
                _log.CustomWriteOnLog("Realizar venta 1", "PRECIO APROX DE COMPRA   : " + precioAprox.ToString());
                txtsubtotal.Text = precioAprox.ToString();
                updPanelSubTotal.Update();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Subtotal calculado', 'bottom', 'center', null, null);", true);
            }
            else if (cbx_Personalizado.Checked == true)
            {
                txtimporttot.Text = precioAprox.ToString();
                panelImpoTot.Update();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'No se tiene el stock suficiente para proceder', 'bottom', 'center', null, null);", true);
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("Realizar venta 1", "Error btncalcular_Click  : " + ex.Message);

        }
    }

    protected void gvdetalle_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gvdetalle_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnagregar_Click(object sender, EventArgs e)
    {
        try
        {
            double sum = 0;
            var colsNoVisible = gvdetalle.DataKeys[0].Values;
            double DM_Precio2 = double.Parse(colsNoVisible[1].ToString());

            dt = (DataTable)ViewState["Records"];
            dt.Rows.Add(txtcodigo.Text, txtcantidad.Text, DM_Precio2, txtsubtotal.Text);



            gv2.DataSource = dt;
            gv2.DataBind();

            _log.CustomWriteOnLog("Realizar venta 1", " gv2.Rows.Count : " + gv2.Rows.Count);
            for (int i = 0; i < gv2.Rows.Count; i++)
            {
                _log.CustomWriteOnLog("Realizar venta 1", "gv2.Rows[i].Cells[4].Text  : " + gv2.Rows[i].Cells[4].Text);
                sum += int.Parse(gv2.Rows[i].Cells[4].Text);
            }
            _log.CustomWriteOnLog("Realizar venta 1", "sum  : " + sum);
            txtimporttot.Text = sum.ToString();
            txtimporteigv.Text = sum.ToString();
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("Realizar venta 1", "Error btnagregar_Click  : " + ex.Message);
        }
    }

    protected void gv2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            double sum = 0;

            _log.CustomWriteOnLog("Realizar venta 1", "e.RowIndex btnagregar_Click  : " + e.RowIndex);
            int index = Convert.ToInt32(e.RowIndex);
            _log.CustomWriteOnLog("Realizar venta 1", "index : " + index);
            DataTable dt = ViewState["Records"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["Records"] = dt;
            BindGrid();

            _log.CustomWriteOnLog("Realizar venta 1", " gv2.Rows.Count : " + gv2.Rows.Count);
            for (int i = 0; i < gv2.Rows.Count; i++)
            {
                _log.CustomWriteOnLog("Realizar venta 1", "gv2.Rows[i].Cells[4].Text  : " + gv2.Rows[i].Cells[4].Text);
                sum += double.Parse(gv2.Rows[i].Cells[4].Text);
            }
            _log.CustomWriteOnLog("Realizar venta 1", "sum  : " + sum);
            txtimporttot.Text = sum.ToString();
            txtimporteigv.Text = sum.ToString();
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("Realizar venta 1", "Error btnagregar_Click  : " + ex.Message);
        }

    }

    protected void BindGrid()
    {
        gv2.DataSource = ViewState["Records"] as DataTable;
        gv2.DataBind();
    }


    protected void gv2_SelectedIndexChanged(object sender, EventArgs e)
    {

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

    }

    protected void btnCalcularPersonalizado_Click(object sender, EventArgs e)
    {
        double aprox;

        if (ddlTipoMoldura.SelectedValue != "0")
        {
            objDtoMoldura.FK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);
            aprox = objCtrMoldura.Aprox(objDtoMoldura);
            txtpriceaprox.Text = Convert.ToString(aprox);
            if (aprox == 0)
            {
                txtpriceaprox.Text = "";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'No hay Tipo de moldura seleccionado!', 'bottom', 'center', null, null);", true);
                return;
            }
            UpdatePanel2.Update();
        }
    }
}