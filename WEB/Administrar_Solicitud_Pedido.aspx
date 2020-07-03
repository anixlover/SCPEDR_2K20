<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="Administrar_Solicitud_Pedido.aspx.cs" Inherits="Administrar_Solicitud_Pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <div class="card">
                            <div class="header">
                                <ul class="header-dropdown m-r--5">
                                </ul>
                                <div class="row">
                                   
                                </div>
                            </div>
                            <div class="body table-responsive ">

                                <asp:GridView ID="gvCarritoCompras" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IM_Cod,VTM_Nombre" runat="server" OnRowDataBound="gvCarritoCompras_RowDataBound" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvCarritoCompras_RowCommand">
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
                </asp:UpdatePanel>
            </div>
        </div>
</asp:Content>

