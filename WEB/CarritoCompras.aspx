<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="CarritoCompras.aspx.cs" Inherits="CarritoCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="../../plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
    <script>$(function () {
            $(".dataTable").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "bProcessing": false,
                "bLengthChange": false,
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: "Buscar registros",
                    lengthMenu: "Mostrar _MENU_ registros",
                    paginate: {
                        first: "Primero",
                        last: "&Uacute;ltimo",
                        next: "Siguiente",
                        previous: "Anterior"
                    },

                }, "bLengthChange": false,
                "bFilter": true,
                "bInfo": false,
                "bAutoWidth": false,
                responsive: true
            });
        });</script>
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
                    <div class="body table-responsive">
                        <asp:GridView ID="gvCarrito" CssClass="table table-bordered table-hover js-basic-example dataTable"
                            DataKeyNames="PK_IMU_Cod,VM_Descripcion,VTM_Nombre,IMU_Cantidad,DMU_Precio" runat="server" AutoGenerateColumns="False"
                            EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvCarrito_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="PK_IMU_Cod" HeaderText="Codigo" />
                                <asp:BoundField DataField="VM_Descripcion" HeaderText="Descripcion" />
                                <asp:BoundField DataField="VTM_Nombre" HeaderText="Tipo Moldura" />
                                <asp:BoundField DataField="IMU_Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="DMU_Precio" HeaderText="Precio" />

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
                    <div class="col-sm-6 right">
                        <asp:UpdatePanel ID="upBoton" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="btnPagar" runat="server" CssClass="btn btn-primary nextBtn-2" Style="float: right" Width="100%" Text="Pagar"
                                    OnClick="btnPagar_Click">
                                </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="defaultmodal" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel runat="server" ID="updPanelModal" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="modal-header navbar">
                            <h4 class="modal-title" id="tituloModal" runat="server" style="color: white;"></h4>
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
                                                        <asp:TextBox ID="txtprecior" class="form-control" runat="server"></asp:TextBox>
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
                                                                <input type="text" ID="txtPrecioModal" class="form-control" runat="server" ReadOnly ClientIDMode="Static" />
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
                            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-success btn-group-sm" OnClick="btnActualizar_Click" />
                            <button type="button" class="btn btn-link waves-effect" data-dismiss="modal">Cerrar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script>
        function checkCantidad() {
            var iNum = parseInt($('#txtcantidadModal').val());
            var iNum2 = parseInt($('#txtprecior').text());
            var resultado = iNum * iNum2;
            $('#txtPrecioModal').val(resultado.toString());
        }
    </script>
    <script src="../../plugins/jquery-datatable/jquery.dataTables.js"></script>
    <script src="../../plugins/jquery-datatable/skin/bootstrap/js/dataTables.bootstrap.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/dataTables.buttons.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.flash.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/jszip.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/pdfmake.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/vfs_fonts.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.html5.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.print.min.js"></script>
</asp:Content>

