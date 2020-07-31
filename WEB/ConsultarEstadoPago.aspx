<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="ConsultarEstadoPago.aspx.cs" Inherits="ConsultarEstadoPago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <script src="../../plugins/momentjs/moment.js"></script>

    <link href="../../plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
    <div>
        <div class="body table-responsive">
            <div class="block-header">
                <h1>Consulta estado de solicitud</h1>
            </div>

            <%-- <asp:GridView ID="gvConsultar" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IS_Cod" runat="server" OnRowDataBound="gvConsultar_RowDataBound" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvConsultar_RowCommand" OnSelectedIndexChanged="gvConsultar_SelectedIndexChanged">
            
            <Columns>
                <asp:BoundField DataField="PK_IS_Cod" HeaderText="Cod solicitud" />
                <asp:BoundField DataField="DTS_FechaEmicion" HeaderText="Fecha" />
                <asp:BoundField DataField="VS_TipoSolicitud" HeaderText="Tipo" />
                <asp:BoundField DataField="DS_ImporteTotal" HeaderText="Importe" />
                <asp:ButtonField  ButtonType="button" HeaderText="Accion" CommandName="Pago" Text="Pago">
                    <ControlStyle CssClass="btn btn-warning" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>--%>


            <div class="row">
                <div class="col-sm-4">
                    <asp:DropDownList runat="server" ID="ddl_SolicitudEstado" OnSelectedIndexChanged="ddl_SolicitudEstado_SelectedIndexChanged" CssClass=" bootstrap-select form-control"></asp:DropDownList>
                </div>
                <div class="col-sm-2">
                    <asp:LinkButton runat="server" ID="btnSearch" CssClass="btn btn-danger btn-circle-lg waves-effect waves-circle waves-float" OnClick="btnSearch_Click">
                                            <i class="material-icons">search</i>
                    </asp:LinkButton>
                </div>
            </div>
            <br />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                     <asp:GridView ID="gvConsultar" DataKeyNames="PK_IS_Cod,V_SE_Nombre" CssClass="table table-bordered table-hover js-basic-example dataTable" runat="server" AutoGenerateColumns="false" OnRowCommand="gvConsultar_RowCommand" OnSelectedIndexChanged="gvConsultar_SelectedIndexChanged" OnRowDataBound="gvConsultar_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="PK_IS_Cod" ItemStyle-HorizontalAlign="Center" HeaderText="Codigo de solicitud" />
                    <asp:BoundField DataField="DTS_FechaEmicion" ItemStyle-HorizontalAlign="Center" HeaderText="Fecha" />
                    <asp:BoundField DataField="VS_TipoSolicitud" ItemStyle-HorizontalAlign="Center" HeaderText="Tipo" />
                    <asp:BoundField DataField="DS_ImporteTotal" ItemStyle-HorizontalAlign="Center" HeaderText="Importe" />
                    <asp:BoundField DataField="V_SE_Nombre" ItemStyle-HorizontalAlign="Center" HeaderText="Estado" />
                    <%-- <asp:ButtonField ButtonType="button" HeaderText="Accion" CommandName="Pago" Text="Pago">
                        <ControlStyle CssClass="btn btn-warning" />
                    </asp:ButtonField>--%>
                    <asp:TemplateField HeaderText="Accion" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button runat="server" Text="Pago" ItemStyle-HorizontalAlign="Center"
                                Visible='<%# ValidacionEstado(Eval("V_SE_Nombre").ToString()) %>'
                                CommandName="Pago" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                            <asp:Button runat="server" Text="Actualizar" ItemStyle-HorizontalAlign="Center"
                                Visible='<%# ValidacionEstado2(Eval("V_SE_Nombre").ToString()) %>'
                                CommandName="Actualizar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                            <asp:Button runat="server" Text="Ver detalle" ItemStyle-HorizontalAlign="Center"
                                Visible='<%# ValidacionEstado3(Eval("V_SE_Nombre").ToString()) %>'
                                CommandName="Ver detalle" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                            <asp:Button runat="server" Text="Ver proceso" ItemStyle-HorizontalAlign="Center"
                                Visible='<%# ValidacionEstado4(Eval("V_SE_Nombre").ToString()) %>'
                                CommandName="Ver proceso" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                            <asp:Button runat="server" Text="Ver incidencias" ItemStyle-HorizontalAlign="Center"
                                Visible='<%# ValidacionEstado5(Eval("V_SE_Nombre").ToString()) %>'
                                CommandName="Ver incidencias" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
           

            <div class="modal fade" id="defaultmodal1" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel runat="server" ID="updPanelModal" UpdateMode="Always">
                            <ContentTemplate>

                                <div class="modal-header navbar">
                                    <h4 class="modal-title" id="tituloModal1" runat="server">Ver proceso de su pedido</h4>
                                </div>

                                <div class="modal-body">
                                    <asp:GridView ID="gvListaxMoldura" DataKeyNames="VTM_Nombre,IMU_Cantidad,DMU_Precio,VMXUE_Nombre" CssClass="table table-bordered table-hover js-basic-example dataTable" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="VTM_Nombre" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" />
                                            <asp:BoundField DataField="IMU_Cantidad" ItemStyle-HorizontalAlign="Center" HeaderText="Cantidad " />
                                            <asp:BoundField DataField="DMU_Precio" ItemStyle-HorizontalAlign="Center" HeaderText="Precio" />
                                            <asp:BoundField DataField="VMXUE_Nombre" ItemStyle-HorizontalAlign="Center" HeaderText="Estado" />
                                        </Columns>
                                    </asp:GridView>
                                </div>

                                <div class="modal-footer btn-group-sm">
                                   
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            <div class="modal fade" id="defaultmodal2" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
                            <ContentTemplate>

                                <div class="modal-header navbar">
                                    <h4 class="modal-title" id="H1" runat="server">Ver retraso de su pedido</h4>
                                </div>

                                <div class="modal-body">
                                    <asp:GridView ID="gvListaxMolduraxIncidencia" DataKeyNames="VTM_Nombre,IMU_Cantidad,DMU_Precio,VMXUE_Nombre,VMXU_Incidente" CssClass="table table-bordered table-hover js-basic-example dataTable" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="VTM_Nombre" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" />
                                            <asp:BoundField DataField="IMU_Cantidad" ItemStyle-HorizontalAlign="Center" HeaderText="Cantidad " />
                                            <asp:BoundField DataField="DMU_Precio" ItemStyle-HorizontalAlign="Center" HeaderText="Precio" />
                                            <asp:BoundField DataField="VMXUE_Nombre" ItemStyle-HorizontalAlign="Center" HeaderText="Estado" />
                                            <asp:BoundField DataField="VMXU_Incidente" ItemStyle-HorizontalAlign="Center" HeaderText="Incidente" />
                                        </Columns>
                                    </asp:GridView>
                                </div>

                                <div class="modal-footer btn-group-sm">
                                   
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <%--<script>
            function cargarConsultarEstadoPago(PK_IS_Cod) {

                location.href = `Realizar_Compra.aspx?id=${PK_IS_Cod}`;

            }
        </script>--%>
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
</asp:Content>

