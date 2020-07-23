<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="ConsultarEstadoPago.aspx.cs" Inherits="ConsultarEstadoPago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>
        <div class="body table-responsive">
            <div class="block-header">
                <h1>Consulta de Estado de Pago</h1>
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

            <asp:GridView ID="gvConsultar" DataKeyNames="PK_IS_Cod,V_SE_Nombre" CssClass="table table-bordered table-hover js-basic-example dataTable" runat="server" AutoGenerateColumns="false" OnRowCommand="gvConsultar_RowCommand" OnSelectedIndexChanged="gvConsultar_SelectedIndexChanged" OnRowDataBound="gvConsultar_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="PK_IS_Cod" HeaderText="Cod solicitud" />
                    <asp:BoundField DataField="DTS_FechaEmicion" HeaderText="Fecha" />
                    <asp:BoundField DataField="VS_TipoSolicitud" HeaderText="Tipo" />
                    <asp:BoundField DataField="DS_ImporteTotal" HeaderText="Importe" />
                    <asp:BoundField DataField="V_SE_Nombre" HeaderText="Estado" />
                   <%-- <asp:ButtonField ButtonType="button" HeaderText="Accion" CommandName="Pago" Text="Pago">
                        <ControlStyle CssClass="btn btn-warning" />
                    </asp:ButtonField>--%>
                    <asp:TemplateField HeaderText="Pago">
                        <ItemTemplate>
                            <asp:Button runat="server" Text="Pago"
                                Visible='<%# ValidacionEstado(Eval("V_SE_Nombre").ToString()) %>'
                                CommandName="Pago" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>
    <%--<script>
            function cargarConsultarEstadoPago(PK_IS_Cod) {

                location.href = `Realizar_Compra.aspx?id=${PK_IS_Cod}`;

            }
        </script>--%>
</asp:Content>

