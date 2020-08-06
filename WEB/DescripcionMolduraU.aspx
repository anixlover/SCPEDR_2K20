<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="DescripcionMolduraU.aspx.cs" Inherits="DescripcionMolduraU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
    <section class="seccion contenedor clearfix">
        <h2>Descripcion</h2>
        <div class="descripcion-moldura">
            <asp:UpdatePanel ID="upBotonEnviar" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Image ID="Image1" Height="370px" Width="450px" runat="server" class="rounded" />

                    <p>Medida:<asp:Label ID="txtmedida" runat="server"></asp:Label></p>
                    <p>
                        <asp:Label ID="txtmetrica" runat="server"></asp:Label>
                    </p>
                    <p>Precio: S./<asp:Label ID="txtprecio" runat="server" ClientIDMode="Static"></asp:Label></p>
                    <p>Descripción:<asp:Label ID="txtdescripcion" runat="server"></asp:Label></p>
                    <asp:Button runat="server" ID="Button1" CssClass="button" Text="Regresar" OnClick="btn_regresar_click" />

                    <a href="#" class="button" onclick="btn_regresar()"><i class="far fa-star"></i></a>

                    <asp:Button runat="server" ID="btnModal" CssClass="button" Text="Agregar a carrito de compra" data-target="#defaultmodal" data-toggle="modal" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="modal fade" id="defaultmodal" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel runat="server" ID="updPanelModal" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group form-float">
                                            <label class="form-label">Cantidad :</label>
                                            <div class="form-line focused">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtDescripcionModal" class="form-control" runat="server" onkeyup="checkLength()" ClientIDMode="Static" type="number"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group form-float">
                                            <label class="form-label">Importe:</label>
                                            <div class="form-line focused">
                                                <div class="form-line">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <input type="text" ID="txtPrecioAprox" class="form-control" runat="server" ReadOnly ClientIDMode="Static" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="Button2" CssClass="button" Text="Agregar a carrito de compra" OnClick="btnAgregarCompraMoldura_Click" />

                                <button type="button" class="btn btn-link waves-effect button" data-dismiss="modal">Cerrar</button>
                            </div>
                         
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="modal fade" id="confirmacionmodal" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="modal-body">
                                <h4>Agregado al carrito</h4>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnAceptarRedirigir" CssClass="button" Text="Ir a mi carrito de compra" OnClick="btnAceptarRedirigir_Click" />

                                <button type="button" class="btn btn-link waves-effect button" data-dismiss="modal">Cerrar</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="modal fade" id="confirmacionmodal1" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="modal-body">
                                <h4 id="mensaje" runat="server"></h4>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnAceptarPP" CssClass="button" Text="Ir a pedido personalizado" OnClick="btnAceptarPP_Click" />

                                <button type="button" class="btn btn-link waves-effect button" data-dismiss="modal">Cerrar</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </section>
    <script>
        function checkLength() {
            var iNum = parseInt($('#txtDescripcionModal').val());
            var iNum2 = parseInt($('#txtprecio').text());
            var resultado = iNum * iNum2;
            $('#txtPrecioAprox').val(resultado.toString());
        }
    </script>
</asp:Content>

