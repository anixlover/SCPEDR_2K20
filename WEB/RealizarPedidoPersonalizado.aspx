<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="RealizarPedidoPersonalizado.aspx.cs" Inherits="RealizarPedidoPersonalizado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../../plugins/momentjs/moment.js"></script>
    <link href="../../plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>

    <style type="text/css">
        .auto-style1 {
            position: relative;
            min-height: 1px;
            top: 0px;
            left: 0px;
            float: left;
            width: 41.66666667%;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
    <section>
        <h2>REALIZAR PEDIDO PERSONALIZADO</h2>
        <div>
            <div class="pedido-propio">
                <input type="hidden" runat="server" id="valorObtenidoRBTN" clientidmode="Static" />
                <asp:Panel ID="Panel1" runat="server">
                    <%-- seleccione tipo de pedido personalizado--%>
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                            <div class="cartilla">
                                <div class="header">
                                    <h2>Tipo de Pedido</h2>
                                    <br />
                                </div>
                                <div class="body">
                                    <div class="row ">
                                        <div class="form-group form-float">
                                            <div class="form-group form-float">
                                                <div class="col-lg-4"></div>
                                                <div class="col-lg-3">
                                                    <div class="demo-checkbox">
                                                        <div class="demo-radio-button">
                                                            <input type="radio" id="rbCatalogo" name="documento" class="radio-col-red" value="1" />
                                                            <label for="cbx_Catalogo">Catalogo</label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-5">
                                                    <div class="demo-checkbox">
                                                        <div class="demo-radio-button">
                                                            <input type="radio" id="rbPropio" name="documento" class="radio-col-red" value="2" />
                                                            <label for="cbx_Personalizado">Diseño Propio</label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="cartilla" id="catalogo" runat="server" hidden clientidmode="Static">
                                <div class="header">
                                    <h2>Especificaciones</h2>
                                    <br />
                                </div>
                                <div class="body">

                                    <asp:UpdatePanel runat="server" ID="calcular1">
                                        <ContentTemplate>
                                            <asp:UpdatePanel runat="server" ID="buscar">
                                                                <ContentTemplate>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-sm-24">
                                                        <div class="auto-style1">
                                                            <asp:Label ID="Label1" runat="server" class="form-label"><b>Codigo Producto</b></asp:Label>
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtcodigo" placeholder="Ej: 950" class="form-control" runat="server" pattern="[0-9]+" type="text">
                                                                </asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <%--boton buscar--%>


                                                        <div class="col-sm-13">
                                                            
                                                                    <asp:LinkButton runat="server" ID="btnBuscarProducto"
                                                                        CssClass="busqueda"
                                                                        OnClick="btnBuscarProducto_Click">
                                                    <i class="fas fa-search"></i>
                                                                    </asp:LinkButton>
                                                                    <br />
                                                                    <br />

                                                                    <div class="row">
                                                                        <div class="col-md-6">
                                                                            <div class="col-sm-12">
                                                                                <asp:Label ID="Label14" runat="server" class="form-label"><b>Descripcion: </b></asp:Label>
                                                                                <div class="form-line">
                                                                                    <asp:TextBox ID="txt_descripcion" class="form-control" runat="server" type="text" Rows="4" Width="100%" Height="70px" ReadOnly TextMode="MultiLine"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <div class="col-md-3">
                                                                            <div class="col-sm-6">
                                                                                <asp:Label ID="Label15" runat="server" class="form-label"><b>Medida: </b></asp:Label>
                                                                                <%--<label class="form-label">Cantidad(u)</label>--%>
                                                                                <div class="form-line">
                                                                                    <asp:TextBox ID="txt_medida" placeholder="Ej: 1 Mt" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-3">

                                                                            <div class="col-sm-6">
                                                                                <asp:Label ID="Label16" runat="server" class="form-label"><b>Precio(u):</b></asp:Label>
                                                                                <div class="form-line">
                                                                                    <asp:TextBox ID="txt_precio" placeholder="Ej: S/40.00" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                    </div>



                                                                    <div class="row">
                                                                        <br />
                                                                        <br />
                                                                        <div class="col-md-3">
                                                                            <div class="col-sm-6">
                                                                                <asp:Label ID="Label2" runat="server" class="form-label"><b>Cantidad: </b></asp:Label>
                                                                                <%--<label class="form-label">Cantidad(u)</label>--%>
                                                                                <div class="form-line">
                                                                                    <asp:TextBox ID="txt_cantidad" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <div class="col-sm-6">
                                                                                <asp:Label ID="Label3" runat="server" class="form-label"><b>Importe:</b></asp:Label>
                                                                                <div class="form-line">
                                                                                    <asp:TextBox ID="txt_importe" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <div class="col-sm-6">
                                                                                <asp:Label ID="Label4" runat="server" class="form-label"><b>Descuento:</b></asp:Label>
                                                                                <div class="form-line">
                                                                                    <asp:TextBox ID="txt_descuento" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <div class="col-sm-12">
                                                                                <asp:Label ID="Label5" runat="server" class="form-label"><b>Sub Total:</b></asp:Label>
                                                                                <div class="form-line">
                                                                                    <asp:TextBox ID="txt_subtotal" placeholder="Ej: S/2100.00" class="form-control" ReadOnly runat="server"></asp:TextBox>
                                                                                    <asp:HiddenField runat="server" ID="txtunidadmetrica" />
                                                                                </div>
                                                                            </div>
                                                                            <br />
                                                                            <br />
                                                                            <br />
                                                                            <br />
                                                                            <div class="col-sm-offset-5 right">
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-3 col-md-offset-9">
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-offset-10">
                                                                        <asp:LinkButton runat="server" ID="btnCalcular" CssClass="btn btn-primary waves-effect btn-lg"
                                                                            OnClick="btnCalcular_Click"> <i class="fas fa-calculator"  > </i> Calcular
                                                                        </asp:LinkButton>

                                                                    </div>

                                                        </div>
                                                    </div>
                                                </div>
                                                
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                                <br />
                                <%--comentario--%>
                                <div class="col-md-12">
                                    <div class="col-sm-24">
                                        <asp:Label ID="Label6" runat="server" class="form-label"><b>Comentario:</b></asp:Label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtarea" placeholder="Por favor escribir aqui algun detalle que desee para que el vendedor lo inspeccione..." class="form-control" runat="server" type="text" Rows="4" Width="100%" Height="55px" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <div class="row">
                                    <div class="medio">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Button ID="btnRegistrar" runat="server" class="btn btn-success btn-lg" Text="Registrar" OnClick="btnRegistrar_Click"></asp:Button>
                                                <%--</ContentTemplate>
                                        </asp:UpdatePanel>
                                        </div>

                                        <div class="col-md-3 right">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                --%>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnCancelar" runat="server" class="btn btn-danger btn-lg" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <%--                                        </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                    </div>
                </asp:Panel>
                <div class="row clearfix">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="cartilla" id="personalizado" runat="server" hidden clientidmode="Static">
                            <div class="header">
                                <h2>Especificaciones</h2>
                            </div>
                            <div class="body">
                                <br />
                                <div class="medio">
                                    <asp:Label ID="Label7" runat="server" class="form-label"><b>Subir imagen de la moldura aqui:</b></asp:Label>
                                    <br />
                                    <asp:Image ID="Image1" Height="250px" Width="250px" runat="server" class="rounded" />
                                    <input name="fileAnexo" type="file" id="FileUpload1" runat="server" accept=".png,.jpg"
                                        class="btn btn-warning" style="width: 50%;" onchange="ImagePreview(this);" cssclass="centro" />

                                </div>
                                <br />
                                <asp:UpdatePanel runat="server" ID="calcular2">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="col-sm-12">

                                                    <asp:Label ID="Label8" runat="server" class="form-label"><b>Seleccione tipo de moldura:</b></asp:Label>
                                                    <asp:DropDownList runat="server" ID="ddlTipoMoldura" CssClass=" bootstrap-select form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-3">
                                                <div class="col-sm-6">
                                                    <asp:Label ID="Label9" runat="server" class="form-label"><b>Medida: </b></asp:Label>
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtmedidap" placeholder="Ej: 1 Mt" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="col-sm-6">
                                                    <asp:Label ID="Label10" runat="server" class="form-label"><b>Cantidad:</b></asp:Label>
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtcantidadp" placeholder="Ej: 50" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-5">
                                                <div class="col-sm-8">
                                                    <asp:Label ID="Label11" runat="server" class="form-label"><b>Importe aprox:</b></asp:Label>
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtimporteaprox" placeholder="Ej: S/2100.00" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <%--<div class="col-sm-4 right">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton runat="server" ID="btnCalcular2"  CssClass="btn btn-primary btn-lg"
                                                            OnClick="btnCalcular2_Click"> <i class="material-icons"></i>Calcular
                                                        </asp:LinkButton>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>--%>
                                            </div>
                                            <div class="col-sm-offset-9">
                                                <asp:LinkButton runat="server" ID="btnCalcular2" CssClass="btn btn-primary btn-lg"
                                                    OnClick="btnCalcular2_Click"> <i class="material-icons"></i>Calcular
                                                </asp:LinkButton>
                                            </div>
                                            <div class="col-md-3 col-md-offset-9"></div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <br />
                            <%--comentario--%>
                            <div class="col-md-12">
                                <div class="col-sm-24">
                                    <asp:Label ID="Label12" runat="server" class="form-label"><b>Comentario:</b></asp:Label>
                                    <div class="form-line">
                                        <asp:TextBox ID="txtcomentario2" placeholder="Por favor escribir aqui algun detalle que desee para que el vendedor lo inspeccione..." class="form-control" runat="server" Rows="4" type="text" Width="100%" TextMode="MultiLine" Height="55px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <div class="row">
                                <div class="medio">
                                    <%--                                            <div class="col-md-3">--%>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Button ID="btnRegistrar2" runat="server" class="btn btn-success btn-lg" Text="Registrar" OnClick="btnRegistrar2_Click"></asp:Button>
                                            <%--</ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>--%>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnCancelar2" runat="server" class="btn btn-danger btn-lg" Text="Cancelar" OnClick="btnCancelar2_Click"></asp:Button>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%--</div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>

    <script src="../../plugins/sweetalert/sweetalert.min.js"></script>
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
            }
        }
        function showSuccessMessage2() {
            setTimeout(function () {
                swal({
                    title: "Enviado correctamente",
                    text: "Pulsa el botón y se te redirigirá",
                    type: "success"
                }, function () {
                    window.location = "ConsultarEstadoPago.aspx";
                });
            }, 1000);
        }
        function showSuccessMessage3() {
            setTimeout(function () {
                swal({
                    title: "Todo guardado",
                    text: "Pulsa el botón 'ok' y se te redirigirá a la lista de pedidos",
                    type: "success"
                }, function () {
                    window.location = "ConsultarEstadoPago.aspx";
                });
            }, 1000);
        }
        function showSuccessMessage4() {
            swal({
                title: "ERROR!",
                text: "Ingresar cantidad del producto!!",
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
                text: "Complete todos los campos!!",
                type: "error"
            });
        }
        function showSuccessMessage7() {
            swal({
                title: "ERROR!",
                text: "Codigo de producto no encontrado!!",
                type: "error"
            });
        }


    </script>
    <%--    <script>
        function cargarInformacion(PK_IS_Cod) {

            location.href = `ConsultarEstadoPago.aspx?id=${PK_IS_Cod}`;

        }
</script>--%>

    <script src="js/Aplicacion/UploadFile.js"></script>
    <script src="js/Aplicacion/RealizarPedidoPersonalizado.js"></script>
</asp:Content>

