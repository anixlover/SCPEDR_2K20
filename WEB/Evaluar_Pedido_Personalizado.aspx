<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Evaluar_Pedido_Personalizado.aspx.cs" Inherits="Evaluar_Pedido_Personalizado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
    <script src="../../plugins/momentjs/moment.js"></script>
    <link href="../../plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="block-header  align-center">
            <h1>EVALUAR PEDIDO PERSONALIZADO</h1>
            <ul class="header-dropdown m-r--5">
            </ul>
        </div>

        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <div class="card">
                            <div class="body table-responsive">

                                <asp:GridView ID="gvPersonalizado" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IS_Cod,VS_TipoSolicitud" runat="server" OnRowDataBound="gvPersonalizado_RowDataBound" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvPersonalizado_RowCommand">

                                    <Columns>
                                        <asp:BoundField DataField="PK_IS_Cod" HeaderText="Codigo" />
                                        <asp:BoundField DataField="VS_TipoSolicitud" HeaderText="Tipo Solicitud" />
                                        <asp:BoundField DataField="V_SE_Nombre" HeaderText="Estado" />

                                        <asp:ButtonField ButtonType="button" HeaderText="Ver" CommandName="Ver" Text="Ver">
                                            <%--<i class="material-icons">drafts</i> <span>Cotizar<span>--%>
                                            <ControlStyle CssClass="btn btn-warning" />
                                        </asp:ButtonField>
                                        <%--<asp:TemplateField HeaderText="Cotizar">
                                            <ItemTemplate>
                                                <asp:LinkButton Text="Cotizar" ButtonType="button" CommandName="Cotizar" runat="server"><i class="material-icons">drafts</i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:ButtonField ButtonType="button" runat="server" HeaderText="Cotizar"  CommandName="Cotizar" Text="Cotizar">
                                        <ControlStyle CssClass="btn btn-warning" />
                                        </asp:ButtonField>
                                    </Columns>

                                </asp:GridView>

                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <%--MODAL--%>

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
                                        <asp:Image ID="Image1" Height="400px" Width="400px" runat="server" class="rounded" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Tipo: </label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txt_tipo" class="form-control" runat="server" ReadOnly="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Medida: </label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txt_medida" class="form-control" runat="server" ReadOnly="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Cantidad: </label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="TextBox1" class="form-control" runat="server" ReadOnly="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-link waves-effect" data-dismiss="modal">Registrar</button>
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
    <script src="../../plugins/sweetalert/sweetalert.min.js"></script>


    <script src="js/Aplicacion/CustomGestionarCatalogo.js"></script>
</asp:Content>

