<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RealizaVenta.aspx.cs" Inherits="RealizaVenta" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">



    <form id="form1" runat="server" method="POST">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
        <div class="block-header">
            <h1 id="txtPagina" runat="server">Realizar Venta</h1>
        </div>
        <%--tipo comprobante card--%>
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <div class="card">
                    <div class="header">
                        <h2>Tipo comprobante    
                        </h2>
                    </div>
                    <div class="body">
                        <asp:Panel runat="server" ID="PanelO">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-sm-12">
                                        <div class="form-group form-float">
                                            <asp:DropDownList runat="server" ID="ddl_TipoComprobante" CssClass=" bootstrap-select form-control" OnSelectedIndexChanged="ddl_TipoComprobante_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Text="Seleccionar" Selected="True" />
                                                <asp:ListItem Value="1" Text="Boleta" />
                                                <asp:ListItem Value="2" Text="Factura" />
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>

        <%--datos cliente card--%>
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card ">
                    <div class="header">
                        <h2>Datos cliente</h2>
                    </div>
                    <div class="body">
                        <asp:Panel runat="server" ID="Panel1">
                            <div class="row">
                                <%--dni, ruc--%>
                                <div class="col-md-6">
                                    <div class="col-sm-8">
                                        <div class="form-group form-float">
                                            <asp:Label ID="lbldni" runat="server" class="form-label"><b>DNI</b></asp:Label>
                                            <asp:Label ID="lblruc" runat="server" class="form-label"><b>RUC</b></asp:Label>
                                            <div class="form-line">

                                                <asp:TextBox ID="txtDNI" class="form-control" runat="server" type="text"
                                                    pattern="[0-8]+" MinLength="8" MaxLength="8"></asp:TextBox>

                                                <asp:TextBox ID="txtFactura" class="form-control" runat="server" type="text"
                                                    pattern="[0-11]+" MinLength="11" MaxLength="11"></asp:TextBox>
                                            </div>
                                            <br />
                                            <%--button search user--%>
                                            <asp:LinkButton runat="server" ID="btnbuscar"
                                                CssClass="btn btn-danger btn-circle-lg waves-effect waves-circle waves-float" OnClick="btnbuscar_Click">
                                                    <i class="material-icons">person_search</i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>

                                <%--nombre,direccion--%>
                                <div class="col-md-6">
                                    <div class="col-sm-8">
                                        <div class="form-group form-float">
                                            <asp:Label ID="lblnombre" runat="server" class="form-label"><b>Nombre</b></asp:Label>
                                            <asp:Label ID="lbldireccion" runat="server" class="form-label"><b>Direccion</b></asp:Label>

                                            <div class="form-line ">
                                                <asp:TextBox ID="txtNombres" class="form-control" runat="server"></asp:TextBox>

                                                <asp:TextBox ID="txtdireccion" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%--apellido, telefono--%>
                                        <div class="form-group form-float">
                                            <asp:Label ID="lblapellido" runat="server" class="form-label"><b>Apellido</b></asp:Label>
                                            <asp:Label ID="lbltelefono" runat="server" class="form-label"><b>Telefono</b></asp:Label>


                                            <div class="form-line ">
                                                <asp:TextBox ID="txtapellido" class="form-control" runat="server"></asp:TextBox>

                                                <asp:TextBox ID="txttelefono" class="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%--correo--%>
                                        <div class="form-group form-float">
                                            <label class="form-label">Correo</label>
                                            <div class="form-line ">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtcorreo" class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>

        <%--detalles card--%>
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card ">
                    <div class="header">
                        <h2>Detalle</h2>
                    </div>
                    <div class="body">
                        <asp:Panel runat="server" ID="Panel2">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-sm-8">
                                        <%--radio button catalogo y personalizado--%>
                                        <div class="form-group form-float">

                                            <asp:RadioButton ID="Rbboleta" runat="server" Text="Catalogo" GroupName="documento"
                                                AutoPostBack="True" OnCheckedChanged="RbBoleta_CheckedChanged" EnableTheming="True"
                                                ForeColor="Black" />

                                            <asp:RadioButton ID="RbPersonalizado" runat="server" Text="Personalizado" GroupName="documento"
                                                AutoPostBack="True" OnCheckedChanged="Rbfactura_CheckedChanged"
                                                ForeColor="Black" />

                                        </div>

                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="col-sm-12">
                                                    <div ID="ddl2" class="form-group form-float">
                                                        <asp:DropDownList runat="server" ID="DropDownList1" CssClass=" bootstrap-select form-control" OnSelectedIndexChanged="ddl_TipoComprobante_SelectedIndexChanged" AutoPostBack="True">
                                                            <asp:ListItem Text="Seleccionar" Selected="True" />
                                                            <asp:ListItem Value="1" Text="Catalogo" />
                                                            <asp:ListItem Value="2" Text="Diseño propio" />
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <%--input codigo--%>
                                        <asp:Label ID="txtcodproducto" runat="server" class="form-label"><b>Codigo</b></asp:Label>
                                        <div class="form-group form-float">
                                            <div class="col-sm-10">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtcodigo" class="form-control" runat="server" type="text"
                                                        pattern="[0-8]+" MinLength="8" MaxLength="8"></asp:TextBox>
                                                </div>
                                            </div>
                                            <%--search product button--%>
                                            <div class="col-sm-2 right">
                                                <asp:LinkButton runat="server" ID="btnBuscarProducto" CssClass="btn btn-danger btn-circle-lg waves-effect waves-circle waves-float" OnClick="btnBuscarProducto_Click">
                                                    <i class="material-icons">person_search</i>
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%--input cantidad--%>
                                <div class="col-md-6">
                                    <div class="row clearfix">
                                        <div class="col-sm-8">
                                            <div class="form-group form-float">
                                                <br />
                                                <br />
                                                <label class="form-label">Cantidad(u)</label>
                                                <div class="form-group form-float">
                                                    <div class="col-sm-9">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtcantidad" class="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <%--btn calcular--%>
                                                    <div class="col-sm-3 right">
                                                        <asp:LinkButton runat="server" ID="btncalcular" CssClass="btn bg-indigo waves-effect" Style="float: right" Width="100%" Text="Calcular"
                                                            AutoPostBack="False" OnClick="btnCalcular"> <i class="material-icons">calculated</i> Calcular
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <%--1st gridv--%>
                                <div class="col-md-12">
                                    <div class="body table-responsive ">
                                        <asp:GridView ID="gvdetalle" CssClass="table table-bordered table-hover js-basic-example dataTable" runat="server"
                                            OnRowDataBound="detalle_RowDataBound" OnRowCommand="detalle_RowCommand" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="IM_Stock" HeaderText="Stock(u)" />
                                                <asp:BoundField DataField="DM_Medida" HeaderText="Medida(mt)" />
                                                <asp:BoundField DataField="DM_Precio" HeaderText="Precio(u) S/" />

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                                
                                <%--subtotal--%>
                                <div id="subtotal" runat="server" class="col-md-6">
                                    <div class="col-sm-8">
                                        <div class="form-group form-float">
                                            <asp:Label ID="Label2" runat="server" class="form-label"><b>Subtotal S/</b></asp:Label>
                                            <div class="form-group form-float">
                                                <div class="col-sm-10">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtsubtotal" class="form-control" runat="server" type="text"
                                                            pattern="[0-8]+" MinLength="8" MaxLength="8">
                                                        </asp:TextBox>
                                                    </div>
                                                </div>

                                                <%--btn add--%>
                                                <div class="col-sm-2 right">
                                                    <asp:LinkButton runat="server" ID="btnagregar" CssClass="btn btn-danger btn-circle-lg waves-effect waves-circle waves-float"
                                                        OnClick="btnagregar_Click">
                                                                <i class="material-icons">add</i>
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%--2nd gridv--%>
                                <div id="gv2nd" runat="server" class="col-md-12">
                                    <div class="body table-responsive ">
                                        
                                        <asp:GridView ID="gv2" CssClass="table table-bordered table-hover js-basic-example dataTable" runat="server" OnSelectedIndexChanged="gv2_SelectedIndexChanged" OnRowDeleting="gv2_SelectedIndexChanged">
                                            <Columns>
                                                <asp:ButtonField ButtonType="button" HeaderText="Accion" CommandName="delete" Text="Borrar">
                                                    <ControlStyle CssClass="btn btn-warning" />
                                                </asp:ButtonField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
 
                                <%--importe total--%>
                                <div class="col-md-6">
                                    <div class="col-sm-8">
                                        <div class="form-group form-float">
                                            <asp:Label ID="Label1" runat="server" class="form-label"><b>Importe total S/</b></asp:Label>
                                            <div class="form-group form-float">
                                                <div class="col-sm-10">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtimporttot" class="form-control" runat="server" type="text" Value ="0"
                                                            pattern="[0-8]+" MinLength="8" MaxLength="8">
                                                        </asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="col-sm-8">
                                        <div class="form-group form-float">
                                            <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn bg-indigo waves-effect" 
                                                Style="float: right" Width="100%" Text="Enviar"
                                                AutoPostBack="False" OnClick="btnCalcular"> <i class="material-icons">send</i> Enviar
                                             </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>

        <%--pay card--%>
        <div runat="server" ID="cardpay" class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card ">
                    <div class="header">
                        <h2>Pago</h2>
                    </div>
                    <div class="body">
                        <asp:Panel runat="server" ID="Panel3">
                            <div class="row clearfix ">
                                <div class="col-md-5 ">
                                    <div class="col-sm-8">
                                        <div class="form-group form-float">
                                            <asp:Label ID="lblmontopagado" runat="server" class="form-label"><b>Monto pagado</b></asp:Label>

                                            <div class="form-line ">
                                                <asp:TextBox ID="txtmontopagado" class="form-control" runat="server"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div id="iddecuento" runat="server" class="form-group form-float">
                                            <asp:Label ID="lbldescuento" runat="server" class="form-label"><b>Dsct</b></asp:Label>

                                            <div class="form-line ">
                                                <asp:TextBox ID="txtdescuento" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group form-float">
                                            <asp:Label ID="lblimporteigv" runat="server" class="form-label"><b>Importe total(incluye IGV)</b></asp:Label>

                                            <div class="form-line ">
                                                <asp:TextBox ID="txtimporteigv" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group form-float">
                                            <asp:Label ID="lblvuelto" runat="server" class="form-label"><b>Vuelto</b></asp:Label>

                                            <div class="form-line ">
                                                <asp:TextBox ID="txtvuelto" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%--btn send n pay boleta--%>
                                                <div runat="server" id="btnboleta1" class="col-sm-12 right">
                                                    <asp:LinkButton ID="btnboleta" runat="server" CssClass="btn bg-indigo waves-effect"
                                                        Style="float: right" Width="100%" Text="Pagar e Enviar"
                                                        OnClick="btnPagarxBoleta">  Pagar e Enviar
                                                    </asp:LinkButton>
                                                </div>

                                        

                                        <%--btn send n print factura--%>
                                                <div runat="server" id="btnfactura1" class="col-sm-12 right">
                                                    <asp:LinkButton ID="btnfactura" runat="server" CssClass="btn bg-indigo waves-effect"
                                                        Style="float: right" Width="100%" Text="Pagar e Imprimir"
                                                        OnClick="btnPagarxFactura">  Pagar e Imprimir
                                                    </asp:LinkButton>
                                                </div>
                                    </div>
                                </div>

                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>

    </form>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
    <script src="../../plugins/jquery-datatable/jquery.dataTables.js"></script>
    <script src="../../plugins/jquery-datatable/skin/bootstrap/js/dataTables.bootstrap.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/dataTables.buttons.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.flash.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/jszip.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/pdfmake.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/vfs_fonts.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.html5.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.print.min.js"></script>
    <script src="js/Aplicacion/CustomGestionarCatalogo.js"></script>
</asp:Content>
