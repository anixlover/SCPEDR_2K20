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
using System.Text;
using System.Net.Mail;
using System.Net;


public partial class RealizarVenta_Marcial : System.Web.UI.Page
{

    Ctr_Solicitud objCtrSolicitud = new Ctr_Solicitud();
    CtrMolduraxUsuario objCtrMolduraxUsuario = new CtrMolduraxUsuario();
    CtrMoldura objCtrMoldura = new CtrMoldura();
    CtrUsuario objctrusr = new CtrUsuario();
    SqlConnection conexion = new SqlConnection(ConexionBD.CadenaConexion);
    Log _log = new Log();
    DataTable dt = new DataTable();

    List<DtoMolduraAgregada> lstDtoMolduraAgregada = new List<DtoMolduraAgregada>();
    DtoMoldura objdtomoldura = new DtoMoldura();
    DtoTipoMoldura dtoTipoMoldura = new DtoTipoMoldura();
    DtoMolduraAgregada objDtoMolduraAgregada = new DtoMolduraAgregada();
    DtoMolduraxUsuario objDtoMolduraxUsuario = new DtoMolduraxUsuario();
    DtoSolicitud objDtoSolicitud = new DtoSolicitud();
    DtoMoldura objDtoMoldura = new DtoMoldura();
    DtoUsuario objuser = new DtoUsuario();
    //int NumPedido = objDtoMolduraxUsuario.PK_IMU_Cod;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (ViewState["Records"] == null)
            {
                dt.Columns.Add("Codigo Producto");
                dt.Columns.Add("Cantidad");
                dt.Columns.Add("Precio(u) S/.");
                dt.Columns.Add("Subtotal S/.");
                ViewState["Records"] = dt;
            }
            OpcionesTipoMoldura();
        }


        try
        {
            if (Session["DNIUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("registrar pedido personalizado", ex.Message + "Stac" + ex.StackTrace);
        }
    }

    protected void ddl_TipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
    {
        _log.CustomWriteOnLog("Realizar venta 1", "valorddl : " + valorObtenidoRBTN.Value);
    }
    int pedido;
    protected void btnboleta_Click(object sender, EventArgs e)
    {
        
        int montopagado = int.Parse(txtmontopagado.Text);
        int montototal = int.Parse(txtimporttot.Text);
        if (ddl_TipoComprobante.SelectedValue == "0")
        {
            Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage12()");
            return;
        }
        if (txtIdentificadorUsuario.Text == "" )
        {
            Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage7()");
            return;
        }
        if (montopagado<montototal)
        {
            Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage14()");
            return;
        }

        try
        {
            objDtoSolicitud.DS_ImporteTotal = double.Parse(txtimporteigv.Text);
            objCtrSolicitud.RegistrarSolicitud_LD2(objDtoSolicitud);
            //# de solicitud
            int ValorDevuelto = objDtoSolicitud.PK_IS_Cod;
            _log.CustomWriteOnLog("Realizar venta 1", "ValorDevuelto = " + ValorDevuelto);

            for (int i = 0; i < gv2.Rows.Count; i++)
            {
                string codigoMoldura = gv2.Rows[i].Cells[1].Text;
                string subtotalMoldura = gv2.Rows[i].Cells[4].Text;
                string cantidadMoldura = gv2.Rows[i].Cells[2].Text;
                _log.CustomWriteOnLog("Realizar venta 1", " item moldura : " + i + "---------------------------------");
                _log.CustomWriteOnLog("Realizar venta 1", " txtIdentificadorUsuario.Text = " + txtIdentificadorUsuario.Text);
                _log.CustomWriteOnLog("Realizar venta 1", "codigoMoldura = " + codigoMoldura);
                _log.CustomWriteOnLog("Realizar venta 1", "cantidadMoldura = " + cantidadMoldura);
                _log.CustomWriteOnLog("Realizar venta 1", "subtotalMoldura = " + subtotalMoldura);

                objDtoMoldura.PK_IM_Cod = int.Parse(codigoMoldura);
                _log.CustomWriteOnLog("Realizar venta 1", "obj.PK_IM_Cod  = " + objDtoMoldura.PK_IM_Cod.ToString());
                int valorRetornadoStoc = objCtrMoldura.StockMoldura_(objDtoMoldura);
                _log.CustomWriteOnLog("Realizar venta 1", "valorRetornadoStoc = " + valorRetornadoStoc);

                int nuevostock = valorRetornadoStoc - int.Parse(cantidadMoldura);
                objDtoMoldura.IM_Stock = nuevostock;
                _log.CustomWriteOnLog("Realizar venta 1", "nuevostock = " + nuevostock);

                objDtoMolduraxUsuario.FK_VU_Cod = txtIdentificadorUsuario.Text;
                objDtoMolduraxUsuario.FK_IM_Cod = int.Parse(codigoMoldura);
                objDtoMolduraxUsuario.IMU_Cantidad = int.Parse(cantidadMoldura);
                objDtoMolduraxUsuario.DMU_Precio = double.Parse(subtotalMoldura);
                objDtoMolduraxUsuario.FK_IS_Cod = ValorDevuelto;
                objCtrMolduraxUsuario.registrarNuevaMoldura2(objDtoMolduraxUsuario);
                objCtrMoldura.ActualizarStockxMoldura(objDtoMoldura);
                //# de molduraxu
                int ValorDevuelto2 = objDtoMolduraxUsuario.PK_IMU_Cod;
                pedido = objDtoMolduraxUsuario.PK_IMU_Cod;
                objCtrMolduraxUsuario.actualizarMXUSol(objDtoMolduraxUsuario);

                //Enviar correo con boleta

                //CTRusuario objctrusr
                //dtousuario objuser
                //objuser.PK_VU_Dni = txtIdentificadorUsuario.Text;
                //objDtoMoldura.PK_IM_Cod = Convert.ToInt32(txtcodigop.Text);
                //objctrusr.EnviarBoletaxCorreo(objDtoMoldura,dtoTipoMoldura);

                string Select = "SELECT VU_Correo, VU_Contrasenia, VU_Nombre from T_Usuario where PK_VU_Dni ='"
                + objDtoMolduraxUsuario.FK_VU_Cod + "'";

                SqlCommand unComando = new SqlCommand(Select, conexion);
                conexion.Open();
                SqlDataReader reader = unComando.ExecuteReader();

                if (reader.Read())
                {
                    string senderr = "decormoldurassac@gmail.com";
                    string senderrPass = "decormolduras";
                    string displayName = "DECORMOLDURAS & ROSETONES SAC";

                    var date = DateTime.Now.ToShortDateString();
                    var recipient = reader["VU_Correo"].ToString();
                    //var pass = reader["VU_Contrasenia"].ToString();
                    var nombre = reader["VU_Nombre"].ToString();
                    var nombreproducto = gvdetalle2.Rows[i].Cells[2].Text;
                    var sub = gv2.Rows[i].Cells[4].Text; ;
                    var importetot = objDtoSolicitud.DS_ImporteTotal;
                    var cantidadproducto = gv2.Rows[i].Cells[2].Text;
                    var precioUnitario = gv2.Rows[i].Cells[3].Text;
                    string body =
                                "<div class=row>" +
                                    "<div class=well col-xs-10 col-sm-10 col-md-6 col-xs-offset-1 col-sm-offset-1 col-md-offset-3>" +
                                        "<div class=row>" +
                                            "<div class=col-xs-6 col-sm-6 col-md-6>" +
                                                "<address>" +
                                                    "<strong>Decormolduras & Rosetones</strong>" +
                                                    "<br>" +
                                                   //2135 Sunset Blvd
                                                   " <br>" +
                                                    "Lima Pe, CP 06" +     /*direccion y codigopostal*/
                                                    "<br>" +
                                                    "<abbr title = Phone> Telefono :</abbr>" +
                                                " (213) 484 - 6829" +    /*telefono*/
                                                "</address>" +
                                            "</div>" +
                                            "<div class=col-xs-6 col-sm-6 col-md-6 text-right>" +
                                                "<p>" +
                                                "Fecha: "+date +   //"<em>Date: 1st November, 2013</em>"   /*fecha*/
                                                "</p>" +
                                                "<p>" +
                                                //<em>Receipt #: 34522677W</em>    /*numero de pedido*/
                                                "</p>" +
                                            "</div>" +
                                       " </div>" +
                                        "<div class=row>" +
                                            "<div class=text-center>" +
                                                "<h1>Recibo</h1>" +
                                            "</div>" +
                                            "</span>" +
                                            "<table class=table table-hover>" +
                                                "<thead>" +
                                                    "<tr>" +
                                                        "<th>Producto</th>" +
                                                        "<th>#</th>" +
                                                        "<th class=text-center>Precio</th>" +
                                                       " <th class=text-center>Total</th>" +
                                                    "</tr>" +
                                                "</thead>" +
                                                "<tbody>" +
                                                    "<tr>" +    /*nombre producto, cantidad producto, precio x unidad, subtotal del producto*/
                                                        "<td class=col-md-9><em>" + nombreproducto + "</em></h4></td>" +
                                                        "<td class=col-md-1 style=text-align: center>" + cantidadproducto + "</td>" +
                                                        "<td class=col-md-1 text-center>"+ "S/." + precioUnitario + "</td>" +
                                                        "<td class=col-md-1 text-center>"+ "S/." + sub + "</td>" +
                                                    "</tr>" +
                                                    "<tr>" +
                                                     "<td></td>" +
                                                        "<td></td>" +
                                                        "<td class=text-right>" +
                                                            "<p>" +
                                                                "<strong>Subtotal: </strong>" +
                                                            "</p>" +
                                                            "<p>" +
                                                                "<strong>IGV: </strong>" +
                                                            "</p>" +
                                                        "</td>" +
                                                        "<td class=text-center>" +
                                                            "<p>" +
                                                                "<strong>" +"S/." + importetot + "</strong>" + /*subtotal*/
                                                            "</p>" +
                                                            "<p>" +
                                                             "   <strong>18%</strong>" +
                                                            "</p>" +
                                                        "</td>" +
                                                    "</tr>" +
                                                    "<tr>" +
                                                        "<td></td>" +
                                                        "<td></td>" +
                                                        "<td class=text-right>" +
                                                            "<h4><strong>Total: </strong></h4>" +
                                                        "</td>" +
                                                        "<td class=text-center text-danger>" +
                                                            "<h4><strong>" + "S/." + importetot + "</strong></h4>" +
                                                        "</td>" +
                                                    "</tr>" +
                                                "</tbody>" +
                                            "</table>" +
                                            "</td>" +
                                        "</div>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";


                    MailMessage mail = new MailMessage();
                    mail.Subject = "Confirmacion de compra - SCPEDR";
                    mail.From = new MailAddress(senderr.Trim(), displayName);
                    mail.Body = body;
                    mail.To.Add(recipient.Trim());
                    mail.IsBodyHtml = true;
                    //mail.Priority = MailPriority.Normal;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //smtp.Credentials = new System.Net.NetworkCredential(senderr.Trim(), senderrPass.Trim());
                    NetworkCredential nc = new NetworkCredential(senderr, senderrPass);
                    smtp.Credentials = nc;

                    smtp.Send(mail);
                }



                _log.CustomWriteOnLog("Realizar venta 1", "Registro moldura : " + codigoMoldura + " para el usuario " + txtIdentificadorUsuario.Text);

                Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage2()");
                //Response.Redirect("RealizarVenta_Marcial.aspx");
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("Realizar venta 1", "btnboleta_Click error  : " + ex.Message);
        }
    }

    protected void btnfactura_Click(object sender, EventArgs e)
    {
        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            Document document = new Document(PageSize.A4, 30, 55, 70, 10);
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            //Chunk chunk = new Chunk("Comprobante generado ");
            //document.Add(chunk);

            //titulo
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN,BaseFont.CP1252,BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead,20,1,BaseColor.BLACK);
            Paragraph prgHead = new Paragraph();
            prgHead.SpacingBefore = 30;
            prgHead.SpacingAfter = 5;
            prgHead.Alignment = Element.ALIGN_CENTER;
            prgHead.Add(new Chunk("COMPROBANTE GENERADO",fntHead));
            document.Add(prgHead);

            //Paragraph para = new Paragraph(txtNombres.Text + " " + txtapellido.Text);
            ////document.Add(para);

            //RUC
            Font fntRUC = new Font(bfntHead, 12, 1, BaseColor.BLACK);
            Paragraph prgRUC = new Paragraph();
            prgRUC.SpacingBefore = 30;
            prgRUC.SpacingAfter = 5;
            prgRUC.Alignment = Element.ALIGN_RIGHT;
            prgRUC.Add(new Chunk("R.U.C. 10007456085", fntHead));
            document.Add(prgRUC);

            //Num comprobante
            Font fntNum = new Font(bfntHead, 8, 2, BaseColor.BLACK);
            Paragraph prgNum = new Paragraph();
            prgNum.SpacingBefore = 10;
            prgNum.SpacingAfter = 5;
            prgNum.Alignment = Element.ALIGN_RIGHT;
            prgNum.Add(new Chunk("N° comprobante: 000 - 000020", fntHead));
            document.Add(prgNum);

            //nombre del cliente
            Font fntname = new Font(bfntHead, 16, 1, BaseColor.BLACK);
            Paragraph prgname= new Paragraph();
            prgname.SpacingBefore = 30;
            prgname.SpacingAfter = 5;
            prgname.Add(new Chunk("Sr(a): "+txtNombres.Text + " " + txtapellido.Text, fntHead));
            document.Add(prgname);

            //Cp, telefono,fecha y hora
            string text = "Lima Pe, CP 06";
            string text1 = Environment.NewLine + "Telefono : (213) 484 - 6829";
            string time = Environment.NewLine + "Fecha de emision: "+ Convert.ToString(DateTime.Now.ToShortDateString());
            string direc = Environment.NewLine + "San Juan de Miraflores --- 1025  "; 
            Paragraph paragraph = new Paragraph();
            paragraph.SpacingBefore = 5;
            paragraph.SpacingAfter = 5;
            paragraph.Alignment = Element.ALIGN_LEFT;
            paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12f, BaseColor.BLACK);
            paragraph.Add(text);
            paragraph.Add(text1);
            paragraph.Add(time);
            document.Add(paragraph);

            //line separadora
            Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(line);

            //line
            document.Add(new Chunk("\n",fntHead));

            //contenido
            BaseFont bfnCont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntCont = new Font(bfntHead, 14, 1, BaseColor.BLACK);
            Paragraph prgCont = new Paragraph();
            prgCont.SpacingBefore = 10;
            prgCont.SpacingAfter = 15;
            prgCont.Alignment = Element.ALIGN_CENTER;
            prgCont.Add(new Chunk("Contenido", fntHead));
            document.Add(prgCont);


            //sesion table gv2
            dt = (DataTable)ViewState["Records"];
            //write table
            PdfPTable table = new PdfPTable(dt.Columns.Count);

            //table header
            BaseFont BsColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN,BaseFont.CP1252,BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(BsColumnHeader,10,1,BaseColor.BLACK);
            for (int i=0 ; i < dt.Columns.Count ; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.AddElement(new Chunk(dt.Columns[i].ColumnName.ToUpper(),fntColumnHeader));
                table.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    table.AddCell(dt.Rows[i][j].ToString());
                }
            }
            document.Add(table);

            //import total
            //Font fntImp = new Font(bfntHead, 4, 1, BaseColor.BLACK);
            Paragraph prgImp = new Paragraph();
            prgImp.SpacingBefore = 5;
            prgImp.SpacingAfter = 5;
            prgImp.IndentationLeft = 245;
            //prgImp.Alignment = Element.ALIGN_RIGHT;
            prgImp.Add(new Chunk("Importe total: S/." + txtimporttot.Text  , fntHead));
            document.Add(prgImp);



            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            //string pdfName = "User";
            Response.AddHeader("Content-Disposition", "attachment; filename=Boleta"+ txtIdentificadorUsuario.Text +".pdf");
            Response.ContentType = "application/pdf";
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
            writer.Close();
        }
    }

    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        if (txtIdentificadorUsuario.Text == "")
        {
            Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage4()");
            return;
        }
        try
        {
            objuser.PK_VU_Dni = txtIdentificadorUsuario.Text;
            objctrusr.TraeData(objuser);
            txtNombres.Text = objuser.VU_Nombre;
            txtapellido.Text = objuser.VU_Apellidos;
            txtcorreo.Text = objuser.VU_Correo;
            txttelefono.Text = Convert.ToString(objuser.IU_Celular);
            updPanel1.Update();
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("Realizar venta 1", "Error  search------: " + ex.Message);
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
        if (txtcodigop.Text == "")
        {
            Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage5()");
            return;
        }

        try
        {
            objDtoMoldura.PK_IM_Cod = Convert.ToInt32(txtcodigop.Text);
            gvdetalle.DataSource = objCtrMoldura.ObtenerMoldura2(objDtoMoldura, dtoTipoMoldura);
            updPanelGVDetalle.Update();
            gvdetalle.Visible = true;
            gvdetalle2.Visible = false;
            UpdatePanel1.Update();
            gvdetalle.DataBind();


            //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "muestra1", "muestra1();", true);

            //Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage7()");
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("Realizar venta 1", "Error btncalcular_Click  : " + ex.Message);
        }
    }

    protected void btncalcular_Click(object sender, EventArgs e)
    {
        if (txtcantidad.Text == "")
        {
            Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage6()");
        }
        //gvdetalle
        try
        {
            var colsNoVisible = gvdetalle.DataKeys[0].Values;

            int IM_Stock = int.Parse(colsNoVisible[4].ToString());
            double DM_Precio = double.Parse(colsNoVisible[5].ToString());
            int cantidad = int.Parse(txtcantidad.Text);
            double precioAprox = 0;

            //_log.CustomWriteOnLog("Realizar venta 1", "STOCK DE MOLDURA  : " + IM_Stock.ToString());
            //_log.CustomWriteOnLog("Realizar venta 1", "PRECIO DE MOLDURA    : " + DM_Precio.ToString());

            if (cantidad <= IM_Stock)
            {
                precioAprox = cantidad * DM_Precio;
                _log.CustomWriteOnLog("Realizar venta 1", "PRECIO APROX DE COMPRA   : " + precioAprox.ToString());

                //txtsubtotal.Text = precioAprox.ToString();

                //updPanelSubTotal.Update();

                objDtoMoldura.PK_IM_Cod = Convert.ToInt32(txtcodigop.Text);
                double subtotal = Convert.ToDouble(txtcantidad.Text);
                gvdetalle2.DataSource = objCtrMoldura.CalcularSubtotal(objDtoMoldura, dtoTipoMoldura, subtotal);
                UpdatePanel1.Update();
                gvdetalle.Visible = false;
                gvdetalle2.Visible = true;
                updPanelGVDetalle.Update();
                gvdetalle2.DataBind();

                txtimporttot.Text = precioAprox.ToString();

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Subtotal calculado', 'bottom', 'center', null, null);", true);
            }

            //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "muestra2", "muestra2();", true);


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
        //if (txtsubtotal.Text == "")
        //{
        //    Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage7()");
        //    return;
        //}
        try
        {
            double sum = 0;
            var colsNoVisible = gvdetalle2.DataKeys[0].Values;
            double DM_Precio2 = double.Parse(colsNoVisible[5].ToString());
            double Subtotal = double.Parse(colsNoVisible[6].ToString());

            dt = (DataTable)ViewState["Records"];
            dt.Rows.Add(txtcodigop.Text, txtcantidad.Text, DM_Precio2, Subtotal);
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
            txtcodigop.Text = "";
            txtcantidad.Text = "";
            upcodigo.Update();
            uptxtcantidad.Update();

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Producto agregado', 'bottom', 'center', null, null);", true);

       
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
        if (txtmedidaDP.Text == "")
        {
            Utils.AddScriptClientUpdatePanel(panelCalcPersonalizado, "showSuccessMessage8()");
            return;
        }
        if (txtcantidadDP.Text == "")
        {
            Utils.AddScriptClientUpdatePanel(panelCalcPersonalizado, "showSuccessMessage9()");
            return;
        }
        if (ddlTipoMoldura.SelectedValue == "0")
        {
            Utils.AddScriptClientUpdatePanel(panelCalcPersonalizado, "showSuccessMessage11()");
            return;
        }
        double aprox;
        if (ddlTipoMoldura.SelectedValue != "0")
        {
            objDtoMoldura.FK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);
            aprox = objCtrMoldura.Aprox(objDtoMoldura);
            int cantp = int.Parse(txtcantidadDP.Text);
            double a = aprox * cantp;
            txtpriceaprox.Text = Convert.ToString(a);
            if (aprox == 0)
            {
                txtpriceaprox.Text = "";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'No hay Tipo de moldura seleccionado!', 'bottom', 'center', null, null);", true);
                return;
            }
            UpdatePanel2.Update();
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        if (txtIdentificadorUsuario.Text == "" | txtcodigop.Text == "" | txtcantidad.Text == "")
        {
            Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage7()");
            return;
        }
        try
        {
            if (valorObtenidoRBTN.Value == "2" && ddlPedidoPor.SelectedValue == "1")
            {
                _log.CustomWriteOnLog("valorObtenidoRBTNValue", "valorObtenidoRBTN.Value   : " + valorObtenidoRBTN.Value);
                _log.CustomWriteOnLog("valorObtenidoRBTNValue", "valorObtenidoRBTN.Value   : " + ddlPedidoPor.SelectedValue);


                objDtoSolicitud.VS_TipoSolicitud = "Personalizado por Catalogo";
                objDtoSolicitud.IS_Cantidad = int.Parse(txtcantidad.Text);
                objDtoSolicitud.DS_ImporteTotal = int.Parse(txtimporttot.Text);
                objDtoSolicitud.DTS_FechaRecojo = Calendar1.SelectedDate;
                objCtrSolicitud.RegistrarSolicitud_PxC(objDtoSolicitud);

                for (int i = 0; i < gvdetalle.Rows.Count; i++)
                {
                    string subtotalMoldura = gvdetalle2.Rows[i].Cells[6].Text;
                    _log.CustomWriteOnLog("Realizar venta 1", "subtotalMoldura = " + subtotalMoldura);

                    objDtoMolduraxUsuario.FK_VU_Cod = txtIdentificadorUsuario.Text; //dni
                    objDtoMolduraxUsuario.FK_IM_Cod = int.Parse(txtcodigop.Text);
                    objDtoMolduraxUsuario.IMU_Cantidad = int.Parse(txtcantidad.Text);
                    objDtoMolduraxUsuario.DMU_Precio = double.Parse(subtotalMoldura);
                    objDtoMolduraxUsuario.FK_IS_Cod = 0;
                    objCtrMolduraxUsuario.registrarNuevaMoldura2(objDtoMolduraxUsuario);
                }

                int ValorDevuelto = objDtoMolduraxUsuario.PK_IMU_Cod;
                _log.CustomWriteOnLog("Realizar venta 1", "ValorDevuelto = " + ValorDevuelto);

                int ValorDevuelto2 = objDtoSolicitud.PK_IS_Cod;
                objDtoMolduraxUsuario.FK_IS_Cod = ValorDevuelto2;
                objCtrMolduraxUsuario.actualizarMXUSol(objDtoMolduraxUsuario);
                Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage3()");
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("Realizar venta 1", "btnboleta_Click error  : " + ex.Message);

        }
    }

    protected void btnEnviar1_Click(object sender, EventArgs e)
    {
        if (txtIdentificadorUsuario.Text == "" | txtmedidaDP.Text == "" | txtcantidadDP.Text == "")
        {
            Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage7()");
            return;
        }
        if (FileUpload2.Value == null)
        {
            Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage10()");
            return;
        }
        try
        {
            if (valorObtenidoRBTN.Value == "2" && ddlPedidoPor.SelectedValue == "2")

            {
                _log.CustomWriteOnLog("valorObtenidoRBTNValue", "valorObtenidoRBTN.Value   : " + valorObtenidoRBTN.Value);
                _log.CustomWriteOnLog("valorObtenidoRBTNValue", "valorObtenidoRBTN.Value   : " + ddlPedidoPor.SelectedValue);

                objDtoSolicitud.VS_TipoSolicitud = "Personalizado por Diseño Propio";
                objDtoSolicitud.VS_Medida = int.Parse(txtmedidaDP.Text);
                _log.CustomWriteOnLog("Realizar venta 1", "objDtoSolicitud.DS_Medida " + objDtoSolicitud.VS_Medida);
                objDtoSolicitud.IS_Cantidad = int.Parse(txtcantidadDP.Text);
                _log.CustomWriteOnLog("Realizar venta 1", "objDtoSolicitud.IS_Cantidad " + objDtoSolicitud.IS_Cantidad);
                objDtoSolicitud.DS_PrecioAprox = double.Parse(txtpriceaprox.Text);
                _log.CustomWriteOnLog("Realizar venta 1", "objDtoSolicitud.DS_PrecioAprox" + objDtoSolicitud.DS_PrecioAprox);

                objCtrSolicitud.RegistrarSolicitud_PxDP(objDtoSolicitud);

                //UpdatePaneCustom
                _log.CustomWriteOnLog("Realizar venta 1", "objDtoSolicitud.PK_IS_Cod " + objDtoSolicitud.PK_IS_Cod);
                Utils.AddScriptClientUpdatePanel(UpdatePaneCustom, "uploadFileDocumentsSolVendedor(" + objDtoSolicitud.PK_IS_Cod + ");");
                Utils.AddScriptClient("showSuccessMessage2()");

                //int tamaño = 0;
                //tamaño = FileUpload2.PostedFile.ContentLength;
                //if (tamaño == 0)
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>sweetAlert('Oops...', 'suba la IMAGEN DEL VOUCHER!', 'error');</script>");
                //    return;
                //}
                //byte[] imagen = new byte[tamaño];
                //FileUpload2.PostedFile.InputStream.Read(imagen, 0, tamaño);
                //objDtoSolicitud.VBS_Imagen = imagen;

                Utils.AddScriptClientUpdatePanel(updBotonEnviar, "showSuccessMessage3()");
                //int solicitud = objDtoSolicitud.PK_IS_Cod;
                //Utils.AddScriptClientUpdatePanel(UpdatePaneCustom, "uploadFileDocumentsSolicitud(" + objDtoSolicitud.PK_IS_Cod + ");");
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("Realizar venta 1", "btnEnviar1_Click error  : " + ex.Message);
        }
    }
}