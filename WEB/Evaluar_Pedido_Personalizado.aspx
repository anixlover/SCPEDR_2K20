<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Evaluar_Pedido_Personalizado.aspx.cs" Inherits="Evaluar_Pedido_Personalizado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
    <script src="../../js/pages/ui/dialogs.js"></script>
    <link href="../../plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <form id="form1" runat="server">
        <div class="block-header  align-center">
            <h1>EVALUZAR PEDIDO PERSONALIZADO</h1>
        </div>
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <div class="card">
                            <div class="body table-responsive">

                                <asp:GridView ID="gvPersonalizado" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IS_Cod,VS_TipoSolicitud" runat="server" OnRowDataBound="gvPersonalizado_RowDataBound" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvPersonalizado_RowCommand">

                                    <Columns>
                                        <asp:BoundField DataField="PK_IS_Cod" HeaderText="Codigo" />
                                        <asp:BoundField DataField="VS_TipoSolicitud" HeaderText="Tipo Solicitud" />
                                        <asp:BoundField DataField="FK_ISE_Cod" HeaderText="Estado" />

                                        <asp:ButtonField ButtonType="button" HeaderText="Cotizar" CommandName="cotizar" Text="Cotizar">
                                            <%--<i class="material-icons">drafts</i> <span>Cotizar<span>--%>
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

