<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GestionCatalogo.aspx.cs" Inherits="GestionCatalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
    <script src="../../js/pages/ui/dialogs.js"></script>
    <%--<link href="plugins/bootstrap/css/bootstrap.css" rel="stylesheet" />--%>
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
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <form id="form1" runat="server">
        <div class="block-header">
            <h1>Molduras</h1>
        </div>
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <div class="card">
                            <div class="header">
                                <%--<h2>Programas actuales por sede</h2>--%>
                                <ul class="header-dropdown m-r--5">
                                 
                                </ul>

                                <div class="row">
                                    <div class="col-sm-4">
                                        <asp:DropDownList runat="server" ID="ddl_TipoMoldura" CssClass=" bootstrap-select form-control"></asp:DropDownList>
                                    </div>
                                    
                                    <div class="col-sm-2">
                                        <asp:LinkButton runat="server" ID="btnSearch" CssClass="btn btn-danger btn-circle-lg waves-effect waves-circle waves-float" OnClick="btnSearch_Click">
                                            <i class="material-icons">search</i>
                                        </asp:LinkButton>
                                    </div>

                                    <div class="col-sm-1">
                                        <asp:LinkButton runat="server" CssClass="btn btn-danger btn-circle-lg waves-effect waves-circle waves-float" OnClick="btnRegistrar_Click">
                                                <i class="material-icons">add</i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="body table-responsive ">

                                <asp:GridView ID="gvCatalogo" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IM_Cod,VTM_Nombre" runat="server" OnRowDataBound="gvCatalogo_RowDataBound" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvCatalogo_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="PK_IM_Cod" HeaderText="Codigo" />
                                        <asp:BoundField DataField="VTM_Nombre" HeaderText="Tipo de moldura" />
                                        <asp:BoundField DataField="DM_Medida" HeaderText="Medida" />
                                        <asp:BoundField DataField="VTM_UnidadMetrica" HeaderText="Unidad metrica" />
                                        <asp:BoundField DataField="DM_Precio" HeaderText="Precio" />
                                        <asp:BoundField DataField="IM_estado" HeaderText="Estado" />

                                        <asp:ButtonField ButtonType="button" HeaderText="Detalles" CommandName="Ver" Text="Ver">
                                            <ControlStyle CssClass="btn btn-warning" />
                                        </asp:ButtonField>
                                        <asp:ButtonField ButtonType="button" HeaderText="Actualizar" CommandName="Actualizar" Text="Editar">
                                            <ControlStyle CssClass="btn btn-warning" />
                                        </asp:ButtonField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                    <%--<Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnGuardar" />
                    </Triggers>--%>
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
                                    <div class="text-center">
                                        <asp:Image ID="Image1" Height="500px" Width="500px" runat="server" class="rounded" />
                                    </div>
                                </div>
                                <div class="row">
                                     <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Stock :</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtStockModal" class="form-control" runat="server" ReadOnly="false"></asp:TextBox>
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
                                                        <asp:TextBox ID="txtDescripcionModal" class="form-control" runat="server" ReadOnly="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-link waves-effect" data-dismiss="modal">Cerrar</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
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

