<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarPedidos.aspx.cs" Inherits="AdministrarPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" Runat="Server">

    <form id="form1" runat="server" method="POST">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
        <div class="body table-responsive">
            <div class="header">
                <h2>Administrar Pedidos
                                <small></small>
                </h2>
                <ul class="header-dropdown m-r--5">
                </ul>
            </div>
            <div class="card">
                <div class="body">
                    <asp:UpdatePanel ID="UpdateSolicitudes" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvSolicitudes" DataKeyNames="PK_IS_Cod,V_SE_Nombre,PK_VU_Dni" CssClass="table table-bordered table-hover js-basic-example dataTable" runat="server" AutoGenerateColumns="false" OnRowCommand="gvSolicitudes_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="PK_IS_Cod" ItemStyle-HorizontalAlign="Center" HeaderText="Codigo de solicitud" />
                                    <asp:BoundField DataField="VS_TipoSolicitud" ItemStyle-HorizontalAlign="Center" HeaderText="Tipo" />
                                    <asp:BoundField DataField="PK_VU_Dni" ItemStyle-HorizontalAlign="Center" HeaderText="DNI" />
                                    <asp:BoundField DataField="Cliente" ItemStyle-HorizontalAlign="Center" HeaderText="Cliente" />
                                    <asp:BoundField DataField="V_SE_Nombre" ItemStyle-HorizontalAlign="Center" HeaderText="Estado" />
                                    <asp:TemplateField HeaderText="Detalles">
                                        <ItemTemplate>
                                            <asp:Button runat="server" Text=" Evaluar" ItemStyle-HorizontalAlign="Center"  Visible='<%# ValidacionEstado(Eval("V_SE_Nombre").ToString()) %>' CommandName="Evaluar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning"/>
                                            <asp:Button runat="server" Text=" Ver" ItemStyle-HorizontalAlign="Center" CommandName="Ver detalles" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" Runat="Server">
</asp:Content>

