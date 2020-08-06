<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Gestionar_Estado_Pedido.aspx.cs" Inherits="Gestionar_Estado_Pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <form id="form1" runat="server">
        <div class="block-header">
            <h1>Estado Pedido</h1>
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

                                    <%--<div class="col-sm-1">
                                        <asp:LinkButton runat="server" CssClass="btn btn-danger btn-circle-lg waves-effect waves-circle waves-float" OnClick="btnRegistrar_Click">
                                                <i class="material-icons">add</i>
                                        </asp:LinkButton>
                                    </div>--%>
                                </div>
                            </div>
                            <div class="body table-responsive ">

                                <asp:GridView ID="gvCatalogo" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IS_Cod,VS_TipoSolicitud,DTS_FechaRegistro,V_SE_Nombre" runat="server" OnRowDataBound="gvCatalogo_RowDataBound" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvCatalogo_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="PK_IS_Cod" HeaderText="Codigo Solicitud" />
                                        <asp:BoundField DataField="VS_TipoSolicitud" HeaderText="Tipo moldura" />
                                        <asp:BoundField DataField="DTS_FechaRegistro" HeaderText="Fecha Registro" />
                                        <asp:BoundField DataField="V_SE_Nombre" HeaderText="Estado Pedido" />
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

                                <%--<div class="row">
                                    <div class="text-center">
                                        <asp:Image ID="Image1" Height="500px" Width="500px" runat="server" class="rounded" />
                                    </div>
                                </div>--%>
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


        <div class="modal fade" id="defaultmodal3" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="modal-header navbar">
                                <h4 class="modal-title" id="H1" runat="server">Detalles</h4>
                            </div>
                            <div class="modal-body">

                                <div class="row">
                                    <br />
                                    <div class="col-md-6">
                                        <div>
                                            <asp:Image ID="Image1" Height="300px" Width="300px" runat="server" class="rounded" />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="col-md-12">
                                            <div class="row clearfix">
                                                <div class="form-group form-float">
                                                    <label class="form-label">Codigo solicitud:</label>
                                                    <div class="form-line focused">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtcodigosolicitud" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="row clearfix">
                                                <div class="form-group form-float">
                                                    <label class="form-label">Tipo solicitud:</label>
                                                    <div class="form-line focused">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txttiposolicitud" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="row clearfix">
                                                <div class="form-group form-float">
                                                    <label class="form-label">Fecha registro:</label>
                                                    <div class="form-line focused">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtfecharegistro" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="row clearfix">
                                                <div class="form-group form-float">
                                                    <label class="form-label">Estado solicitud:</label>
                                                    <div class="form-line focused">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtestadosolicitud" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>


        <div class="modal fade" id="defaultmodal4" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="modal-header navbar">
                                <h4 class="modal-title" id="H2" runat="server">Detalles</h4>
                            </div>
                            <div class="modal-body">

                                <div class="row">
                                    <%--<div class="col-md-6">
                                        <div>
                                            <asp:Image ID="Image2" Height="300px" Width="300px" runat="server" class="rounded" />
                                        </div>
                                    </div>--%>
                                    <br />
                                    <div class="col-md-6">
                                        <div class="col-md-12">
                                            <div class="row clearfix">
                                                <div class="form-group form-float">
                                                    <label class="form-label">Codigo solicitud:</label>
                                                    <div class="form-line focused">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtcod2" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="row clearfix">
                                                <div class="form-group form-float">
                                                    <label class="form-label">Tipo solicitud:</label>
                                                    <div class="form-line focused">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txttiposol2" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="col-md-12">
                                            <div class="row clearfix">
                                                <div class="form-group form-float">
                                                    <label class="form-label">Fecha registro:</label>
                                                    <div class="form-line focused">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtfechareg2" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>--%>
                                        <div class="col-md-12">
                                            <div class="row clearfix">
                                                <div class="form-group form-float">
                                                    <label class="form-label">Estado solicitud:</label>
                                                    <div class="form-line focused">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtestadosol2" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>



    </form>
</asp:Content>
