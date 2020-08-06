<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Actualizar_Proceso.aspx.cs" Inherits="Actualizar_Proceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <form id="form1" runat="server" method="POST">
            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
            <div class="block-header">
                <h1 id="txtPagina" runat="server"></h1>
            </div>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>Completa la solicitud
                                <small></small>
                            </h2>
                            <ul class="header-dropdown m-r--5">
                            </ul>
                        </div>
                        <div class="body">

                            <div class="row">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-6">
                                    <%--<div>
                                        <asp:Image ID="Image1" Height="500px" Width="500px" runat="server" class="rounded" />

                                        <input name="fileAnexo" type="file" id="FileUpload1" runat="server" accept=".png,.jpg" class="btn btn-warning" style="width: 100%;" />
                                        <br />
                                    </div>--%>
                                    <div class="center">
                                    </div>
                                </div>
                                <div class="col-sm-3"></div>

                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Codigo</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtCodigo" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <label class="form-label">Estado</label>
                                            <asp:DropDownList ID="ddlestadosolicitud" class="form-control" runat="server" required></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="col-md-4">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Medida</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtMedida" class="form-control" type="number" runat="server" required></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                            <div class="row">
                                <%--<div class="col-md-4">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <label class="form-label">Estado</label>
                                            <asp:DropDownList runat="server" ID="ddlEstadoMoldura" CssClass="form-control" OnSelectedIndexChanged="ddlEstadoMoldura_SelectedIndexChanged" required>
                                                <asp:ListItem Value="">--Seleccione--</asp:ListItem>
                                                <asp:ListItem Value="1">Habilitado</asp:ListItem>
                                                <asp:ListItem Value="0">Deshabilitado</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="col-md-4">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Tipo Solicitud</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txttiposolicitud" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Cantidad</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtcantidad" class="form-control" type="number" runat="server" ReadOnly></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="col-md-4">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Precio S/.</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtPrecio" type="number" class="form-control" runat="server" required></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                            <%--<div class="row">
                                <div class="col-lg-12">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Descripción</label>
                                                <div class="form-line focused">
                                                    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="multiline" Rows="4" class="form-control no-resize" required></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                            <div class="row">
                                <div class="col-sm-3 right">
                                    <asp:LinkButton ID="btnCancelar" runat="server" CssClass="btn bg-red waves-effect" Style="float: right" Width="100%" 
                                        Text="Cancelar" OnClick="btnCancelar_Click">
												<i class="material-icons">arrow_back</i>Regresar
                                    </asp:LinkButton>
                                </div>
                                <div class="col-sm-3 right">
                                    <asp:UpdatePanel ID="upBotonEnviar" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btnGuardar" runat="server" CssClass="btn bg-indigo waves-effect" Style="float: right" Width="100%" Text="Guardar"
                                                OnClick="btnGuardar_Click">
                                                <i class="material-icons">save</i> Guardar
                                            </asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </section>
</asp:Content>
