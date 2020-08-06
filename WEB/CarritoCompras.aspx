<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="CarritoCompras.aspx.cs" Inherits="CarritoCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script src="../../plugins/jquery/jquery.min.js"></script>--%>
    <%--<script src="../../plugins/jquery-datatable/jquery.dataTables.js"></script>--%>
    <script src="../../plugins/momentjs/moment.js"></script>
    <link href="../../plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
    <%--<link href="../../plugins/sweetalert/sweetalert.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="block-header">
        <h1>Carrito de compras</h1>
    </div>

    <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <div class="card">
                        <div class="header">
                        </div>
                    </div>
                    <div>
                        <asp:GridView ID="gvCarrito" CssClass="table table-bordered table-hover js-basic-example dataTable"
                            DataKeyNames="PK_IMU_Cod,VM_Descripcion,VTM_Nombre,IMU_Cantidad,DMU_Precio" runat="server" AutoGenerateColumns="False"
                            EmptyDataText="No existen registros, agreguen molduras a su carrito" ShowHeaderWhenEmpty="True" OnRowCommand="gvCarrito_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="PK_IMU_Cod" HeaderText="Codigo" />
                                <asp:BoundField DataField="VM_Descripcion" HeaderText="Descripcion" />
                                <asp:BoundField DataField="VTM_Nombre" HeaderText="Tipo Moldura" />
                                <asp:BoundField DataField="IMU_Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="DMU_Precio" HeaderText="Precio" />
                                <asp:TemplateField HeaderText="Country" ItemStyle-Width="150" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("PK_IMU_Cod") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Country" ItemStyle-Width="150" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrecioItems" runat="server" Text='<%# Eval("DMU_Precio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Agregar al carrito de compras">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" CssClass="checkbox" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField ButtonType="button" HeaderText="Detalles" CommandName="Ver" Text="Ver">
                                    <ControlStyle CssClass="btn btn-warning" />
                                </asp:ButtonField>
                                <asp:ButtonField ButtonType="button" HeaderText="Eliminar" CommandName="Eliminar" Text="Eliminar">
                                    <ControlStyle CssClass="btn btn-warning" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-sm-6"></div>

                </ContentTemplate>
            </asp:UpdatePanel>
            <button type="button" class="btn btn-primary" style="float: right" data-toggle="modal" id="btncrear" data-target="#exampleModal" runat="server">
                Crear solicitud
            </button>
            <div class="col-sm-6 right">
                <asp:UpdatePanel ID="upBoton" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <%--<asp:Button runat="server" ID="btnPagar" CssClass="btn btn-primary nextBtn-2" Style="float: right" Width="100%" Text="Crear solicitud de compra" OnClick="btnPagar_Click1" />--%>
                        <%--<asp:LinkButton ID="btnPagar" runat="server" CssClass="btn btn-primary nextBtn-2" Style="float: right" Width="100%" Text="Pagar"
                            OnClick="btnPagar_Click">
                        </asp:LinkButton>--%>
                    </ContentTemplate>
                    <Triggers>
                        <%--<asp:AsyncPostBackTrigger ControlID="btnPagar" EventName="Click" />--%>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

 <%--   MODAL--%>

    <div class="modal fade" id="defaultmodal" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel runat="server" ID="updPanelModal" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="modal-header navbar">
                            <h4 class="modal-title" id="tituloModal" runat="server">Detalles y actualización</h4>
                        </div>
                        <div class="modal-body">

                            <div class="row">
                                <div class="col-md-6">
                                    <div>
                                        <asp:Image ID="Image1" Height="300px" Width="300px" runat="server" class="rounded" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Codigo :</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtcodigoModal" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                        <asp:TextBox ID="txtcodM" class="form-control" runat="server" Visible="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Descripción :</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtDescripcionModal" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                        <input id="txtprecior" class="form-control" runat="server" clientidmode="Static" type="hidden" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Tipo Moldura :</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtTMModal" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">medida :</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtMedidaModal" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">unidad metrica :</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtUMModal" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Cantidad :</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtcantidadModal" class="form-control" runat="server" onkeyup="checkCantidad()" ClientIDMode="Static" type="number"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Precio:</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>
                                                                <input type="text" id="txtPrecioModal" class="form-control" runat="server" readonly clientidmode="Static" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer btn-group-sm">
                            <asp:UpdatePanel ID="UpdatePanelA" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-success btn-group-sm" OnClick="btnActualizar_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <button type="button" class="btn btn-link waves-effect" data-dismiss="modal">Cerrar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Crear la solicitud</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Está seguro de crear la solicitud? Esto eliminará las molduras escogidas de su carrito de compra
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary nextBtn-2" Style="float: right" Text="Crear solicitud de compra" OnClick="btnPagar_Click1" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
     <div class="modal fade" id="confirmacionmodal" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="modal-body">
                                <h4 id="mensaje" runat="server"></h4>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnAceptarRedirigir" CssClass="button" Text="Ir a pedido personalizado" OnClick="btnAceptarRedirigir_Click" />

                                <button type="button" class="btn btn-link waves-effect button" data-dismiss="modal">Cerrar</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

    <script src="../../plugins/sweetalert/sweetalert.min.js"></script>


    <%--<script src="../../plugins/jquery-datatable/jquery.dataTables.js"></script>--%>
    <script src="../../plugins/jquery-datatable/jquery.dataTables.js"></script>
    <script src="../../plugins/jquery-datatable/skin/bootstrap/js/dataTables.bootstrap.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/dataTables.buttons.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.flash.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/jszip.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/pdfmake.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/vfs_fonts.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.html5.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.print.min.js"></script>
    <script src="../../plugins/sweetalert/sweetalert.min.js"></script>
    <%--<script src="../../js/pages/ui/dialogs.js"></script>--%>
    <script>$(function () {
            $(".dataTable").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "bProcessing": false,
                "bLengthChange": false,
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: "Buscar registros",
                    lengthMenu: "Mostrar _MENU_ registros",
                    paginate: false,

                },
                "paging": false,
                "info": false,
                responsive: true
            });
        });
    </script>
    <script>
        function checkCantidad() {
            var iNum = parseInt($('#txtcantidadModal').val());
            var iNum2 = parseInt($('#txtprecior').val());
            var resultado = iNum * iNum2;
            $('#txtPrecioModal').val(resultado.toString());
        };
    </script>
    <script>
        function showSuccessMessage2() {
            $('#defaultmodal').modal('hide');
            swal(
                'Excelente',
                'Todo Actualizado!',
                'success'
            );
        };
    </script>
    <script>
        function showCancelMessage() {
            swal({
                title: "Todo completado",
                text: "Pronto nos estaremos comunicando con usted, esperamos su pago",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Si quiero ir a mis solicitudes",
                cancelButtonText: "No, quiero seguir comprando",
                closeOnConfirm: false,
                closeOnCancel: true
            }, function (isConfirm) {
                if (isConfirm) {
                    window.location.href = "ConsultarEstadoPago.aspx";
                } else {
                    $('#exampleModal').modal('hide');
                }
            });
        }
    </script>
    <script>
        function showStockMessage(mensaje, id) {
            swal({
                title: "Stock Invalido",
                text: mensaje,
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "solicitar pedido personalizado",
                cancelButtonText: "cancelar",
                closeOnConfirm: false,
                closeOnCancel: true
            }, function (isConfirm) {
                if (isConfirm) {
                    window.location.href = `RealizarPedidoPersonalizado.aspx?id=${id}`;
                    _log.CustomWriteOnLog("carrito de compra", "Valor ID enviada :  " + id);
                } else {
                    $('#defaultmodal').modal('hide');
                }
            });
        }
    </script>
</asp:Content>

