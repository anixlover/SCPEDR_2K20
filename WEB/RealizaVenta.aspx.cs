using CTR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DTO;
using DAO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class RealizaVenta : System.Web.UI.Page
{
  
    DtoUsuario objuser = new DtoUsuario();
    DtoMoldura objdtomoldura = new DtoMoldura();
    SqlConnection conexion = new SqlConnection(ConexionBD.CadenaConexion);
    Log _log = new Log();

    DataTable dt = new DataTable();


    double total=0;
    double x;
    double y;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _log.CustomWriteOnLog("Realizar Venta 1", "_______________________________________________________________________________ENTRO A FUNCION REALIZAR VENTA_____________________________________________________________________");
                txtFactura.Visible = false;
            Rbboleta.Checked = true;

            if (ViewState["Records"] == null)
            {
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Cantidad(u)");
                dt.Columns.Add("Precio(u) S/");
                dt.Columns.Add("Subtotal S/");
                ViewState["Records"] = dt;
            }
        }
    }

    protected void RbBoleta_CheckedChanged(object sender, EventArgs e)
    {
        DropDownList1.Visible = false;
    }

    protected void Rbfactura_CheckedChanged(object sender, EventArgs e)
    {
        DropDownList1.Visible = true;

        cardpay.Visible = false;
        gv2nd.Visible = false;
        subtotal.Visible = false;
    }

    protected void ddl_TipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
    {
        _log.CustomWriteOnLog("Realizar venta 1", "valorddl : " + ddl_TipoComprobante.SelectedValue);
        if (ddl_TipoComprobante.SelectedValue == "1")   //boleta
        {
            txtDNI.Visible = true;
            lbldni.Visible = true;
            lblnombre.Visible = true;
            txtNombres.Visible = true;
            lblapellido.Visible = true;
            txtapellido.Visible = true;
            btnboleta1.Visible = true;

            txtFactura.Visible = false;
            lblruc.Visible = false;
            lbldireccion.Visible = false;
            txtdireccion.Visible = false;
            lbltelefono.Visible = false;
            txttelefono.Visible = false;
            lbldescuento.Visible = false;
            txtdescuento.Visible = false;
            lbldescuento.Visible = false;
            txtdescuento.Visible = false;
            iddecuento.Visible = false;
            btnfactura1.Visible = false;
        }
        if (ddl_TipoComprobante.SelectedValue == "2")  //factura
        {
            txtDNI.Visible = false;
            lbldni.Visible = false;
            lblnombre.Visible = false;
            txtNombres.Visible = false;
            lblapellido.Visible = false;
            txtapellido.Visible = false;
            btnboleta1.Visible = false;


            txtFactura.Visible = true;
            lblruc.Visible = true;
            lbldireccion.Visible = true;
            txtdireccion.Visible = true;
            lbltelefono.Visible = true;
            txttelefono.Visible = true;
            lbldescuento.Visible = true;
            txtdescuento.Visible = true;
            iddecuento.Visible = true;
            btnfactura1.Visible = true;

        }
    }
   
    protected void detalle_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void detalle_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void GridView2_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        //dt.Columns.Add("Cantidad", typeof(int));
        //dt.Columns.Add("Subtotal", typeof(int));
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnbuscar_Click(object sender, EventArgs e)  
    {
        string Select = "SELECT * from T_Usuario where PK_VU_Dni = @Dni";
        SqlCommand unComando = new SqlCommand(Select, conexion);
        unComando.Parameters.AddWithValue("@Dni", txtDNI.Text);
        conexion.Open();
        SqlDataReader reader = unComando.ExecuteReader();
        bool hayRegistros = reader.Read();
        if (hayRegistros)
        {
            txtNombres.Text = reader["VU_Nombre"].ToString();
            txtapellido.Text = reader["VU_Apellidos"].ToString();
            txtcorreo.Text = reader["VU_Correo"].ToString();
        }
        conexion.Close();
    }

    protected void btnBuscarProducto_Click(object sender, EventArgs e)
    {   
        DataTable dt = null;
        conexion.Open();
        SqlCommand command = new SqlCommand("SP_Listar_Moldura_x_Codigo", conexion);
        command.Parameters.AddWithValue("@codigoMol", txtcodigo.Text);
        SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
        command.CommandType = CommandType.StoredProcedure;
        dt = new DataTable();
        daAdaptador.Fill(dt);
        conexion.Close();
        gvdetalle.DataSource = dt;
        gvdetalle.DataBind();
    }

    protected void btnCalcular(object sender, EventArgs e)
    {
        string Select = "SELECT * from T_Moldura where PK_IM_Cod = @codigoMol";
        SqlCommand unComando = new SqlCommand(Select, conexion);
        unComando.Parameters.AddWithValue("@codigoMol", txtcodigo.Text);
        conexion.Open();
        SqlDataReader reader = unComando.ExecuteReader();
        bool hayRegistros = reader.Read();
        if (hayRegistros)
        {
            double a;
            double b;
            double resul;
           string c = reader["DM_Precio"].ToString();
   
            a = double.Parse(txtcantidad.Text);
            b = double.Parse(c);
            resul = (a * b);
            txtsubtotal.Text = resul.ToString();
        }
        conexion.Close();
    }

    protected void btnPagarxFactura(object sender, EventArgs e)
    {

        //vuelto
        double r1;
        double r2;
        double resto;
        r1 = double.Parse(txtmontopagado.Text);
        r2 = double.Parse(txtimporteigv.Text);
        resto = r1 - r2;
        txtvuelto.Text = resto.ToString();
    }

    protected void btnPagarxBoleta(object sender, EventArgs e)
    {
        //trigguer
        //insert
       

        


        //vuelto
        double r1;
        double r2;
        double resto;
        r1 = double.Parse(txtmontopagado.Text);
        r2 = double.Parse(txtimporteigv.Text);
        resto = r1 - r2;
        txtvuelto.Text = resto.ToString();
    }

    protected void btnagregar_Click(object sender, EventArgs e)
    {
        //int[] valueCode;
        //int[] v;
        string Select = "SELECT DM_Precio from T_Moldura where PK_IM_Cod = @codigoMol";
        SqlCommand unComando = new SqlCommand(Select, conexion);
        unComando.Parameters.AddWithValue("@codigoMol", txtcodigo.Text);
        conexion.Open();
        SqlDataReader reader = unComando.ExecuteReader();
        bool hayRegistros = reader.Read();
        if (hayRegistros)
        {
            string c = reader["DM_Precio"].ToString();      
        dt = (DataTable)ViewState["Records"];
        dt.Rows.Add(txtcodigo.Text,txtcantidad.Text, c, txtsubtotal.Text);
            
        gv2.DataSource = dt;
        gv2.DataBind();
        }

            //for (int i==0 ; gv2.Rows.ToString ;int++)
            //{
            //    valueCode.a
            //}
            //v = int.Parse(txtcodigo.Text);






        
            //suma
        x = double.Parse(txtsubtotal.Text);
        y = double.Parse(txtimporttot.Text);
        total = x+y;
        txtimporttot.Text = total.ToString();
        txtimporteigv.Text = total.ToString();
    }



    protected void gv2_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        dt = (DataTable)ViewState["Records"];
        DataRow[] _row = dt.Select("Codigo= "+txtcodigo.Text);
        foreach (DataRow row in _row)
            row.Delete();
            
        dt.AcceptChanges();
        ViewState["Records"] = dt;
        gv2.DataSource = (DataTable)ViewState["Records"];
        gv2.DataBind();

       //restarrr importe total del 

    }
}
//DataTable dt = null;
//conexion.Open();
//SqlCommand command = new SqlCommand("SP_Listar_Moldura_Solicitud", conexion);
//command.Parameters.AddWithValue("@cod", txtcodigo.Text);

//SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
//command.CommandType = CommandType.StoredProcedure;
//dt = new DataTable();
//daAdaptador.Fill(dt);
//conexion.Close();
//gvdetalle2nd.DataSource = dt;
//gvdetalle2nd.DataBind();

//b = Convert.ToInt32(txtcantidad.Text);
//int.TryParse(txtcantidad.Text, out a);
//int.TryParse(c, out b);

//btncalcular
//var a = Convert.ToInt32(txtcantidad);
//var b = objdtomoldura.DM_Precio;
//var c = a * b;
//txtsubtotal.Text = c.ToString();

//conexion.Open();
//SqlCommand command = new SqlCommand("SP_Listar_Moldura_x_Codigo", conexion);
//command.Parameters.AddWithValue("@codigoMol", txtcodigo.Text);
//command.Parameters.AddWithValue("@cantidad", txtcantidad.Text);

//SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
//command.CommandType = CommandType.StoredProcedure;