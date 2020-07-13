﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RealizarVenta_Marcial.aspx.cs" Inherits="RealizarVenta_Marcial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
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
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updPanelddl" ClientIDMode="Static">
                                                    <ContentTemplate>
                                                        <asp:DropDownList runat="server" ID="ddl_TipoComprobante" ClientIDMode="Static" CssClass=" bootstrap-select form-control" OnSelectedIndexChanged="ddl_TipoComprobante_SelectedIndexChanged">
                                                            <asp:ListItem Text="Seleccionar" Selected="True" />
                                                            <asp:ListItem Value="1" Text="Boleta" />
                                                            <asp:ListItem Value="2" Text="Factura" />
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
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
                                    <div class="col-md-5">

                                        <div class="col-sm-12">
                                            <asp:HiddenField runat="server" ID="valorObtenidoRBTN" ClientIDMode="Static" />
                                            <div class="col-sm-10">
                                                <div class="form-group form-float">
                                                    <asp:Label ID="lbldni" runat="server" class="form-label"><b>Ingrese el DNI del cliente</b></asp:Label>
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtIdentificadorUsuario" class="form-control" runat="server" type="text" ClientIDMode="Static"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <br />
                                            <%--button search use r--%>
                                            <div class="col-sm-1">
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:LinkButton runat="server" ID="btnbuscar"
                                                            CssClass="btn btn-danger btn-circle-lg waves-effect waves-circle waves-float m-l-15" OnClick="btnbuscar_Click">
                                                    <i class="material-icons">person_search</i>
                                                        </asp:LinkButton>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                        </div>
                                        <div class="col-sm-12" id="divRUCHide" runat="server" hidden clientidmode="Static">
                                            <asp:HiddenField runat="server" ID="HiddenField1" ClientIDMode="Static" />
                                            <div class="col-sm-12">
                                                <div class="form-group form-float">
                                                    <asp:Label ID="Label5" runat="server" class="form-label"><b>Ingrese el RUC para añadir al comprobante</b></asp:Label>
                                                    <div class="form-line">
                                                        <asp:TextBox ID="TextBox1" class="form-control" runat="server" type="text" ClientIDMode="Static" MinLength="11" MaxLength="11"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <br />
                                            <%--button search use r--%>
                                        </div>
                                    </div>

                                    <%--nombre,direccion--%>
                                    <div class="col-md-7">
                                        <div class="col-sm-12">
                                            <div class="card">
                                                <div class="header bg-red">
                                                    <h2>Resultados de la busqueda <small></small>
                                                    </h2>
                                                </div>
                                                <div class="body" runat="server" id="divBodyResultsDNI">
                                                    <asp:UpdatePanel ID="updPanel1" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <div class="form-group form-float">
                                                                <asp:Label ID="lblnombre" runat="server" class="form-label"><b>Nombre</b></asp:Label>
                                                                <div class="form-line">
                                                                    <asp:TextBox ID="txtNombres" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group form-float">
                                                                <asp:Label ID="lblapellido" runat="server" class="form-label"><b>Apellido</b></asp:Label>
                                                                <div class="form-line">
                                                                    <asp:TextBox ID="txtapellido" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group form-float">
                                                                <asp:Label ID="lbltelefono" runat="server" class="form-label"><b>Telefono</b></asp:Label>
                                                                <div class="form-line">
                                                                    <asp:TextBox ID="txttelefono" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group form-float">
                                                                <label class="form-label">Correo</label>
                                                                <div class="form-line ">
                                                                    <asp:TextBox ID="txtcorreo" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
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
                                            <asp:Label ID="Label3" runat="server" class="form-label"><b>El pedido es :</b></asp:Label>

                                            <div class="form-group form-float">
                                                <div class="col-lg-6">
                                                    <div class="demo-checkbox">
                                                        <div class="demo-radio-button">
                                                            <input type="radio" id="cbx_Catalogo" name="TipoPedido" class="radio-col-red" value="1" />
                                                            <label for="cbx_Catalogo">Catalogo</label>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="demo-checkbox">
                                                        <div class="demo-radio-button">
                                                            <input type="radio" id="cbx_Personalizado" name="TipoPedido" class="radio-col-red" value="2" />
                                                            <label for="cbx_Personalizado">Personalizado</label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <%--input codigo--%>
                                    <div class="col-md-6">

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
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton runat="server" ID="btnBuscarProducto" CssClass="btn btn-danger btn-circle-lg waves-effect waves-circle waves-float" OnClick="btnBuscarProducto_Click">
                                                    <i class="material-icons">person_search</i>
                                                        </asp:LinkButton>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                    <%--input cantidad--%>
                                    <div class="col-md-6">
                                        <label class="form-label">Cantidad(u)</label>
                                        <div class="form-group form-float">
                                            <div class="col-sm-10">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtcantidad" class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <%--btn calcular--%>
                                            <div class="col-sm-2 right">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton runat="server" ID="btncalcular" CssClass="btn bg-indigo waves-effect btn-circle-lg waves-effect waves-circle waves-float"
                                                            OnClick="btncalcular_Click"> <i class="material-icons">calculated</i>
                                                        </asp:LinkButton>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                    </div>

                                    <%--1st gridv--%>
                                    <div class="col-md-12">
                                        <div class="body table-responsive ">
                                            <asp:UpdatePanel runat="server" ID="updPanelGVDetalle" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvdetalle" CssClass="table table-bordered table-hover js-basic-example dataTable" runat="server" DataKeyNames="IM_Stock,DM_Precio,DM_Medida,PK_IM_Cod"
                                                        OnRowDataBound="gvdetalle_RowDataBound" OnRowCommand="gvdetalle_RowCommand" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:BoundField DataField="PK_IM_Cod" HeaderText="Codigo" Visible="false" />
                                                            <asp:BoundField DataField="IM_Stock" HeaderText="Stock(u)" />
                                                            <asp:BoundField DataField="DM_Precio" HeaderText="Precio(u) S/" />
                                                            <asp:BoundField DataField="DM_Medida" HeaderText="Medida(mt)" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                        </div>
                                    </div>

                                    <%--subtotal--%>
                                    <div class="col-md-6">
                                        <div class="col-sm-8">
                                            <div class="form-group form-float">
                                                <asp:Label ID="Label2" runat="server" class="form-label"><b>Subtotal S/</b></asp:Label>
                                                <div class="form-group form-float">
                                                    <div class="col-sm-10">
                                                        <div class="form-line">
                                                            <asp:UpdatePanel runat="server" ID="updPanelSubTotal" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtsubtotal" class="form-control" runat="server" type="text"
                                                                        pattern="[0-8]+" MinLength="8" MaxLength="8">
                                                                    </asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>

                                                        </div>
                                                    </div>

                                                    <%--btn add--%>
                                                    <div class="col-sm-2 right">
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>
                                                                <asp:LinkButton runat="server" ID="btnagregar" CssClass="btn btn-danger btn-circle-lg waves-effect waves-circle waves-float"
                                                                    OnClick="btnagregar_Click">
                                                                <i class="material-icons">add</i>
                                                                </asp:LinkButton>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--2nd gridv--%>
                                    <div class="col-md-12">
                                        <div class="body table-responsive ">
                                            <asp:UpdatePanel ID="updPanelGV2" runat="server" UpdateMode="Always">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gv2" CssClass="table table-bordered table-hover js-basic-example dataTable" runat="server" OnSelectedIndexChanged="gv2_SelectedIndexChanged" OnRowDeleting="gv2_RowDeleting" DataKeyNames="Codigo,Cantidad,Precio,Subtotal">
                                                        <Columns>

                                                            <%-- <asp:BoundField DataField="Cantidad" HeaderText="Cantidad (u)" />
                                                            <asp:BoundField DataField="Precio" HeaderText="Precio (u) S/." />
                                                                 <asp:BoundField DataField="SubTotal" HeaderText="Subtotal S/." />--%>
                                                            <asp:ButtonField ButtonType="button" HeaderText="Accion" CommandName="delete" Text="Borrar">
                                                                <ControlStyle CssClass="btn btn-warning" />
                                                            </asp:ButtonField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
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
                                                            <asp:UpdatePanel runat="server" UpdateMode="Always">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtimporttot" class="form-control" runat="server" type="text" Value="0"
                                                                        pattern="[0-8]+" ReadOnly>
                                                                    </asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>

                                                        </div>
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

            <%--pay card--%>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card ">
                        <div class="header">
                            <h2>Pago</h2>
                        </div>
                        <div class="body">
                            <div class="row ">
                                <div class="col-sm-8">
                                    <div class="form-group form-float">
                                        <asp:Label ID="lblmontopagado" runat="server" class="form-label"><b>Monto pagado</b></asp:Label>

                                        <div class="form-line ">
                                            <input type="number" id="txtmontopagado" class="form-control" runat="server" onkeyup="CalcularVuelto()" clientidmode="Static" />
                                        </div>

                                    </div>

                                    <div id="iddecuento" runat="server" class="form-group form-float" clientidmode="Static">
                                        <asp:Label ID="lbldescuento" runat="server" class="form-label"><b>Dsct</b></asp:Label>

                                        <div class="form-line ">
                                            <asp:TextBox ID="txtdescuento" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:UpdatePanel runat="server" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="form-group form-float">
                                                <asp:Label ID="lblimporteigv" runat="server" class="form-label"><b>Importe total</b></asp:Label>
                                                <div class="form-line ">
                                                    <asp:TextBox ID="txtimporteigv" class="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="form-group form-float">
                                        <asp:Label ID="lblvuelto" runat="server" class="form-label"><b>Vuelto</b></asp:Label>

                                        <div class="form-line ">
                                            <input type="text" id="txtvuelto" class="form-control" runat="server" clientidmode="Static" readonly />
                                        </div>
                                    </div>
                                    <%--btn send n pay boleta--%>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div runat="server" id="btnboleta1" class="col-sm-12 right">
                                                <asp:LinkButton ID="btnboleta" runat="server" CssClass="btn bg-indigo waves-effect"
                                                    Style="float: right" Width="100%" Text="Pagar y enviar a verificación"
                                                    OnClick="btnboleta_Click">  Pagar y enviar a verificación
                                                </asp:LinkButton>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <%--btn send n print factura--%>
                                    <div runat="server" id="btnfactura1" class="col-sm-12 right">
                                        <asp:LinkButton ID="btnfactura" runat="server" CssClass="btn bg-indigo waves-effect"
                                            Style="float: right" Width="100%" Text="Imprimir"
                                            OnClick="btnfactura_Click">
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>



        </form>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
    <script src="js/Aplicacion/RealizarVenta.js"></script>
    <script>
        function CalcularVuelto() {
            var textboxpago = $('#txtmontopagado').val();
            var textboximporte = $('#txtimporteigv').val();
            var valuevuelto = parseFloat(textboxpago) - parseFloat(textboximporte);
            $('#txtvuelto').val(valuevuelto);

        }
    </script>
</asp:Content>

