<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RealizarVenta_Marcial.aspx.cs" Inherits="RealizarVenta_Marcial" %>

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

                    <div class="card" id="CardTipoComprobante" runat="server" hidden clientidmode="Static">
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
                                                        <asp:DropDownList runat="server" ID="ddl_TipoComprobante" ClientIDMode="Static"
                                                            CssClass=" bootstrap-select form-control" OnSelectedIndexChanged="ddl_TipoComprobante_SelectedIndexChanged">
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









            <%--datos cliente--%>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card ">
                        <div class="header">
                            <h2>Datos cliente</h2>
                        </div>
                        <%--rdb dni, carnet extranjeria--%>
                        <div class="body">

                            <asp:Label ID="Label10" runat="server" class="form-label"><b>Tipo de documento :</b></asp:Label>
                            <input type="hidden" runat="server" id="valorObtenidoRBTN1" clientidmode="Static" />
                            <asp:Panel runat="server" ID="Panel1">
                                <div class="row">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="col-sm-8">
                                                <div class="form-group form-float">
                                                    <div class="col-lg-6">
                                                        <div class="demo-checkbox">
                                                            <div class="demo-radio-button">
                                                                <input type="radio" id="RDB_DNI" name="TipoC" class="radio-col-red" value="1" checked />
                                                                <label for="RDB_DNI">Dni</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="demo-checkbox">
                                                            <div class="demo-radio-button">
                                                                <input type="radio" id="RDB_CEXTRANJERIA" name="TipoC" class="radio-col-red" value="2" />
                                                                <label for="RDB_CEXTRANJERIA">Carnet de Extrajeria</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <%--dni, ruc--%>
                                    <div class="col-md-5">
                                        <div class="col-sm-12">
                                            <div class="col-sm-10">
                                                <div class="form-group form-float">

                                                    <div class="col-12" id="lbldni" runat="server" hidden clientidmode="Static">
                                                        <asp:HiddenField runat="server" ID="HiddenField5" ClientIDMode="Static" />

                                                        <asp:Label ID="lbldniu" runat="server" class="form-label"><b>Ingrese el DNI del cliente</b></asp:Label>
                                                    </div>

                                                    <div class="col-12" id="lblcde" runat="server" hidden clientidmode="Static">
                                                        <asp:HiddenField runat="server" ID="HiddenField4" ClientIDMode="Static" />

                                                        <asp:Label ID="lblcdex" runat="server" class="form-label"><b>Ingrese el Carnet de Extranjeria</b></asp:Label>
                                                    </div>

                                                    <div class="form-line">
                                                        <asp:TextBox placeholder="Ej: 74588841" ID="txtIdentificadorUsuario" class="form-control" runat="server" type="text" ClientIDMode="Static"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />

                                            <%--button search use r--%>
                                            <div class="col-sm-2 right">
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:LinkButton runat="server" ID="btnbuscar"
                                                            CssClass="btn btn-danger btn-circle-lg waves-effect waves-circle waves-float m-l-15"
                                                            OnClick="btnbuscar_Click">
                                                    <i class="material-icons">person_search</i>
                                                        </asp:LinkButton>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                        </div>

                                        <%--ruc input--%>
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

                                            <%--ddl pedido por--%>
                                            <input type="hidden" runat="server" id="valorObtenidoRBTN" clientidmode="Static" />
                                            <asp:Panel runat="server" ID="Panel3">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="col-sm-12">
                                                            <div class="form-group form-float">
                                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="ddlPedidoMuestra" ClientIDMode="Static">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="Label6" runat="server" class="form-label"><b>Por :</b></asp:Label>
                                                                        <asp:DropDownList runat="server" ID="ddlPedidoPor" ClientIDMode="Static"
                                                                            CssClass=" bootstrap-select form-control" OnSelectedIndexChanged="ddl_TipoComprobante_SelectedIndexChanged">
                                                                            <asp:ListItem Text="Seleccionar" Selected="True" />
                                                                            <asp:ListItem Value="1" Text="Catalogo" />
                                                                            <asp:ListItem Value="2" Text="Diseño Propio" />
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


                                <%--ddlTipoMoldura--%>
                                <div class="2" id="idTipoMoldura" runat="server" hidden clientidmode="Static">
                                    <div class="row">
                                        <div class="col-md-6">

                                            <div class="col-sm-12">
                                            <asp:Label ID="Label11" runat="server" class="form-label"><b>Tipo moldura :</b></asp:Label>
                                                <div class="form-group form-float">
                                                    <asp:DropDownList runat="server" ID="ddlTipoMoldura" CssClass=" bootstrap-select form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-sm-12">
                                                <div class="card">
                                                    <div class="header bg-red">
                                                        <h2>Detalle Moldura <small></small>
                                                        </h2>
                                                    </div>
                                                    <%--datos--%>
                                                    <div class="body" runat="server" id="div1">
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <div class="form-group form-float">
                                                                    <asp:Label ID="Label7" runat="server" class="form-label"><b>Medida(mt)</b></asp:Label>
                                                                    <div class="form-line">
                                                                        <asp:TextBox ID="txtmedidaDP" PlaceHolder="Ej: 20" class="form-control" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group form-float">
                                                                    <asp:Label ID="Label8" runat="server" class="form-label"><b>Cantidad(u)</b></asp:Label>
                                                                    <div class="form-line">
                                                                        <asp:TextBox ID="txtcantidadDP" PlaceHolder="Ej: 5" class="form-control" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <%--<div class="form-group form-float">
                                                                    <label class="form-label">Subir Imagen</label>
                                                                    <br />

                                                                    <asp:Image ID="Image1" Height="250px" Width="250px" runat="server" class="rounded" />
                                                                    <input name="fileAnexo" type="file" id="FileUpload2" runat="server" accept=".png,.jpg"
                                                                        class="btn btn-warning" style="width: 50%;" onchange="ImagePreview(this);" />
                                                                </div>--%>

                                                                <div class="form-group form-float">
                                                                    <label class="form-label">Subir Imagen</label>
                                                                    <br />

                                                                    <asp:Image ID="Image1" Height="250px" Width="250px" runat="server" class="rounded" />
                                                                    <input name="fileAnexo" type="file" id="FileUpload2" runat="server" accept=".png,.jpg"
                                                                        class="btn btn-warning" style="width: 50%;" onchange="ImagePreview(this);" />
                                                                </div>
                                                                <div class="form-group form-float">
                                                                    <asp:Label ID="Label9" runat="server" class="form-label"><b>Precio Aprox S/.</b></asp:Label>
                                                                    <div class="form-line">
                                                                        <asp:TextBox ID="txtpriceaprox" class="form-control" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <%--btn calcular--%>
                                                                <div class="form-group form-float">
                                                                    <asp:UpdatePanel ID="panelCalcPersonalizado" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton runat="server" ID="btnCalcularPersonalizado"
                                                                                CssClass="btn bg-indigo waves-effect btn-circle-lg waves-effect waves-circle waves-float"
                                                                                OnClick="btnCalcularPersonalizado_Click"> <i class="material-icons">calculated</i>
                                                                            </asp:LinkButton>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>

                                                                <%--btn send personalizado--%>
                                                                <div class="form-group form-float">
                                                                    <asp:UpdatePanel ID="UpdatePaneCustom" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="btnEnviar1" runat="server" CssClass="btn bg-indigo waves-effect"
                                                                                Style="float: right" Width="100%" Text="Enviar"
                                                                                OnClick="btnEnviar1_Click">  Enviar
                                                                            </asp:LinkButton>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <br />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <%--input codigo--%>
                                <div class="2" id="DivCodigoSubtotal" runat="server" hidden clientidmode="Static">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="col-sm-12">
                                                <div class="form-group form-float">
                                                    <div class="col-sm-10">
                                                        <asp:Label ID="txtcodproducto" runat="server" class="form-label"><b>Codigo Producto</b></asp:Label>
                                                        <div class="form-line">
                                                            <asp:UpdatePanel ID="upcodigo" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtcodigop" placeholder="Ej: 950" class="form-control" runat="server" type="text"
                                                                        pattern="[0-8]+" MinLength="8" MaxLength="8">
                                                                    </asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                    <%--search product button--%>
                                                    <div class="col-sm-2 right">
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>
                                                                <asp:LinkButton runat="server" ID="btnBuscarProducto"
                                                                    CssClass="btn btn-danger btn-circle-lg waves-effect waves-circle waves-float"
                                                                    OnClick="btnBuscarProducto_Click">
                                                                <i class="material-icons">person_search</i>
                                                                </asp:LinkButton>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <%--input cantidad--%>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="col-sm-12">
                                                    <div class="form-group form-float">
                                                        <div class="col-sm-10">
                                                            <label class="form-label">Cantidad(u)</label>
                                                            <div class="form-line">
                                                                <asp:UpdatePanel ID="uptxtcantidad" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtcantidad" placeholder="Ej: 2" class="form-control" runat="server"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
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
                                            </div>
                                        </div>

                                        <%--1st gridv--%>
                                        <div class="col-lg-12">
                                            <div class="col-md-11">
                                                <div class="body table-responsive ">
                                                    <div class="row">
                                                        <asp:UpdatePanel runat="server" ID="updPanelGVDetalle" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="gvdetalle" CssClass="table table-bordered table-hover js-basic-example dataTable" runat="server"
                                                                    DataKeyNames="PK_IM_Cod,VBM_Imagen,VTM_Nombre,MedidaUM,IM_Stock,DM_Precio"
                                                                    OnRowDataBound="gvdetalle_RowDataBound" OnRowCommand="gvdetalle_RowCommand" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="PK_IM_Cod" HeaderText="Codigo" Visible="false" />
                                                                        <asp:BoundField DataField="VBM_Imagen" HeaderText="Imagen" Visible="false" />
                                                                        <asp:BoundField DataField="VTM_Nombre" HeaderText="Tipo Moldura" />
                                                                        <asp:BoundField DataField="MedidaUM" HeaderText="Medida" />
                                                                        <asp:BoundField DataField="IM_Stock" HeaderText="Stock(u)" />
                                                                        <asp:BoundField DataField="DM_Precio" HeaderText="Precio(u) S/" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>

                                                        <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="gvdetalle2" CssClass="table table-bordered table-hover js-basic-example dataTable" runat="server"
                                                                    DataKeyNames="PK_IM_Cod,VBM_Imagen,VTM_Nombre,MedidaUM,IM_Stock,DM_Precio,Subtotal"
                                                                    OnRowDataBound="gvdetalle_RowDataBound" OnRowCommand="gvdetalle_RowCommand" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="PK_IM_Cod" HeaderText="Codigo" Visible="false" />
                                                                        <asp:BoundField DataField="VBM_Imagen" HeaderText="Imagen" Visible="false" />
                                                                        <asp:BoundField DataField="VTM_Nombre" HeaderText="Tipo Moldura" />
                                                                        <asp:BoundField DataField="MedidaUM" HeaderText="Medida" />
                                                                        <asp:BoundField DataField="IM_Stock" HeaderText="Stock(u)" />
                                                                        <asp:BoundField DataField="DM_Precio" HeaderText="Precio(u) S/" />
                                                                        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal S/" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>


                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <%--btn agregar--%>
                                            <div class="col-12" id="btnadd" runat="server" hidden clientidmode="Static">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton runat="server" ID="btnagregar"
                                                            CssClass="btn btn-danger btn-circle-lg waves-effect waves-circle waves-float"
                                                            OnClick="btnagregar_Click">
                                                                            <i class="material-icons">add</i>
                                                        </asp:LinkButton>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                        <%--calendar--%>
                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="col-md-12">
                                                    <div class="col-sm-12" id="IdCalendar" runat="server" clientidmode="Static">
                                                        <asp:Label ID="Label4" runat="server" class="form-label"><b>Fecha de entrega:</b></asp:Label>
                                                        <asp:HiddenField runat="server" ID="HiddenField3" ClientIDMode="Static" />
                                                        <div class="body table-responsive ">
                                                            <asp:Calendar ID="Calendar1" runat="server" TodayDayStyle-BackColor ="Wheat"></asp:Calendar>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <%--subtotal--%>
                                        <div class="col-sm-12" id="divSubAddGv" runat="server" hidden clientidmode="Static">
                                            <asp:HiddenField runat="server" ID="HiddenField2" ClientIDMode="Static" />

                                            <%--       <div class="col-md-6">
                                                <div class="col-sm-8">
                                                    <div class="form-group form-float">
                                                        <div class="form-group form-float">
                                                            <div class="col-sm-10">
                                                                <asp:Label ID="Label2" runat="server" class="form-label"><b>Subtotal S/</b></asp:Label>
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
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>--%>

                                            <%--2nd gridv--%>

                                            <%--producto agregados--%>
                                            <div class="col-md-12">
                                                <asp:Label ID="Label2" runat="server" class="form-label"><b>Productos agregados :</b></asp:Label>
                                                <div class="body table-responsive ">

                                                    <asp:UpdatePanel ID="updPanelGV2" runat="server" UpdateMode="Always">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gv2" CssClass="table table-bordered table-hover js-basic-example dataTable" runat="server"
                                                                OnSelectedIndexChanged="gv2_SelectedIndexChanged" OnRowDeleting="gv2_RowDeleting" DataKeyNames="Codigo Producto,Cantidad,Precio(u) S/.,Subtotal S/.">
                                                                <Columns>
                                                                    <asp:ButtonField ButtonType="button" HeaderText="Accion" CommandName="delete" Text="Borrar">
                                                                        <ControlStyle CssClass="btn btn-warning" />
                                                                    </asp:ButtonField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>

                                        <%--importe total--%>
                                        <div class="col-md-4 right" id="txtimportetotal" runat="server" hidden clientidmode="Static">
                                            <div class="col-sm-12 ">
                                                <div class="form-group form-float">
                                                    <div class="form-group form-float">
                                                        <div class="col-sm-12" >
                                                            <asp:Label ID="Label1" runat="server" class="form-label"><b>Importe total S/</b></asp:Label>
                                                            <div class="form-line">
                                                                <asp:UpdatePanel ID="panelImpoTot" runat="server" UpdateMode="Always">
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
                                        <%--btn enviar only--%>
                                        <div class="col-sm-12" id="idMostrarbtnEnviar" runat="server" hidden clientidmode="Static">
                                            <div class="row">
                                                <div class="col-sm-8">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <div runat="server" id="Divbtn" class="col-sm-6 left">
                                                                <asp:LinkButton ID="btnEnviar" runat="server" CssClass="btn bg-indigo waves-effect"
                                                                    Style="float: right" Width="100%" Text="Enviar"
                                                                    OnClick="btnEnviar_Click">  Enviar
                                                                </asp:LinkButton>
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

            <%--pay card--%>
            <div class="card" id="CardPayment" runat="server" hidden clientidmode="Static">

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
                                            <asp:Label ID="lblmontopagado" runat="server" class="form-label"><b>Monto pagado S/.</b></asp:Label>

                                            <div class="form-line ">
                                                <asp:TextBox type="number" placeholder="Ej: 100" ID="txtmontopagado" class="form-control" runat="server"
                                                    onkeyup="CalcularVuelto()" ClientIDMode="Static"></asp:TextBox>

                                            </div>
                                        </div>

                                        <%--input descuento--%>
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
                                        <asp:UpdatePanel ID="updBotonEnviar" runat="server">
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
            </div>
        </form>
    </section>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">

    <script src="js/Aplicacion/RealizarVenta.js"></script>
    <%--<link href="css/normalize.css" rel="stylesheet" />--%>

    <script>
        function CalcularVuelto() {
            var textboxpago = $('#txtmontopagado').val();
            var textboximporte = $('#txtimporteigv').val();

            var valuevuelto = parseFloat(textboxpago) - parseFloat(textboximporte);
            $('#txtvuelto').val(valuevuelto);

        }

        function showSuccessMessage2() {
            swal({
                title: "Todo guardado",
                text: "Pulsa el botón y se te redirigirá",
                type: "success"
            }, function (redirect) {
                if (redirect) {
                    window.location.href = "RealizarVenta_Marcial.aspx"
                }
            });
        }
        function showSuccessMessage3() {
            swal({
                title: "Enviado Correctamente",
                text: "Pulsa el botón y se te redirigirá",
                type: "success"
            }, function (redirect) {
                if (redirect) {
                    window.location.href = "RealizarVenta_Marcial.aspx"
                }
            });
        }
        function showSuccessMessage4() {
            swal({
                title: "ERROR!",
                text: "Identificar al cliente!!",
                type: "error"
            });
        }
        function showSuccessMessage5() {
            swal({
                title: "ERROR!",
                text: "Ingresar codigo del producto!!",
                type: "error"
            });
        }
        function showSuccessMessage6() {
            swal({
                title: "ERROR!",
                text: "Ingresar cantidad del producto!!",
                type: "error"
            });
        }
        function showSuccessMessage7() {
            swal({
                title: "ERROR!",
                text: "Complete espacios en blanco!!",
                type: "error"
            });
        }
        function showSuccessMessage8() {
            swal({
                title: "ERROR!",
                text: "Ingresar medida!!",
                type: "error"
            });
        }
        function showSuccessMessage9() {
            swal({
                title: "ERROR!",
                text: "Ingresar cantidad!!",
                type: "error"
            });
        }
        function showSuccessMessage10() {
            swal({
                title: "ERROR!",
                text: "Ingresar imagen!!",
                type: "error"
            });
        }
        function showSuccessMessage11() {
            swal({
                title: "ERROR!",
                text: "Seleccionar una moldura!!",
                type: "error"
            });
        }
        function showSuccessMessage12() {
            swal({
                title: "ERROR!",
                text: "Seleccionar tipo de comprobante!!",
                type: "error"
            });
        }
        function showSuccessMessage13() {
            swal({
                title: "ERROR!",
                text: "Monto insuficiente!!",
                type: "error"
            });
        }
        function showSuccessMessage14() {
            swal({
                title: "ERROR!",
                text: "Monto pagado incorrecto!!",
                type: "error"
            });
        }

    </script>

    <script src="js/Aplicacion/UploadFile.js"></script>

    <script type="text/javascript">
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                        .width(250)
                        .height(250);
                };
                reader.readAsDataURL(input.files[0]);
                $.plot($("#placeholder"), data, options);
            }
        }

        function getQueryStringParameter(paramToRetrieve) {
            var params = document.URL.split("?");
            var strParams = "";
            for (var i = 0; i < params.length; i = i + 1) {
                var singleParam = params[i].split("=");
                if (singleParam[0] == paramToRetrieve)
                    return singleParam[1].replace("#", "");
            }
        }
    </script>
</asp:Content>


