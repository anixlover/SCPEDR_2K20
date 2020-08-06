<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cotizar_Personalizado.aspx.cs" Inherits="Cotizar_Personalizado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">

    <section>
        <form id="form1" runat="server" method="POST">
            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
            <div class="block-header align-center">
                <h1 id="txtPagina" runat="server"></h1>
            </div>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2 id="solicitud" runat="server"></h2>
                            <small></small>
                            <ul class="header-dropdown m-r--5">
                            </ul>
                        </div>
                        <div class="body">
                            <div class="row align-center">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-6">
                                    <div>
                                        <asp:Image ID="Image1" Height="350px" Width="350px" runat="server" class="rounded" />

                                        <%--<input name="fileAnexo" type="file" id="FileUpload1" runat="server" accept=".png,.jpg" class="btn btn-warning" style="width: 100%;" />--%>
                                        <br />
                                    </div>
                                </div>
                                <div class="col-sm-3"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Tipo: </label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txt_tipo" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Medida: </label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txt_medida" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Cantidad: </label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txt_cantidad" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Precio Aprox: </label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txt_precioaprox" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Comentario: </label>
                                                <div class="form-line focused">
                                                    <asp:TextBox ID="txt_comentario" runat="server" TextMode="multiline" Rows="4" class="form-control no-resize" required ReadOnly></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class=" col-md-offset-3 col-md-3 ">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Dias a elavorar:</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txt_dias" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 ">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Importe:</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txt_importe" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-offset-2">
                                    <div class="col-sm-3 ">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btnrechazar" runat="server" CssClass="btn bg-red waves-effect" Style="float: right" Width="100%" Text="RECHAZAR"
                                                OnClick="btnGuardar_Click">
                                                <i class="material-icons">close </i> <span>RECHAZAR</span> 
                                            </asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="upBotonGuardar" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btnGuardar" runat="server" CssClass="btn bg-indigo waves-effect" Style="float: right" Width="100%" Text="GUARDAR"
                                                OnClick="btnGuardar_Click">
                                                <i class="material-icons">save </i> <span>GUARDAR</span> 
                                            </asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                                <div class="col-sm-3">

                                    <asp:LinkButton ID="btnCancelar" runat="server" CssClass="btn bg-grey waves-effect" Style="float: right" Width="100%" Text="CANCELAR" OnClick="btnCancelar_Click">
												<i class="material-icons">arrow_back</i> <span>CANCELAR</span>
                                    </asp:LinkButton>
                                </div>


                            </div>




                        </div>
                    </div>
                </div>
            </div>


        </form>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
</asp:Content>

