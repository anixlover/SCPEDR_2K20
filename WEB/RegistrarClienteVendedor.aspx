<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegistrarClienteVendedor.aspx.cs" Inherits="RegistrarClienteVendedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" Runat="Server">
    
    <link href="../../plugins/bootstrap-datepicker/css/bootstrap-datepicker.css" rel="stylesheet" />
    <form id="form1" runat="server" method="POST">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
        <div class="block-header">
            <h1 id="txtPagina" runat="server"></h1>
        </div>
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <h2>Registrar al cliente
                                <small></small>
                        </h2>
                        <ul class="header-dropdown m-r--5">
                        </ul>
                    </div>
                    <div class="body">
                        <asp:Panel runat="server" ID="PanelO">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <asp:RadioButton ID="RadioButton1" runat="server" Text="DNI" GroupName="documento" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" EnableTheming="True" ForeColor="Black" />
                                                <asp:RadioButton ID="RadioButton2" runat="server" Text="Carnet de Extranjería" GroupName="documento" AutoPostBack="True" OnCheckedChanged="RadioButton2_CheckedChanged" ForeColor="Black" />
                                                <div class="form-line ">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtDNI" class="form-control" runat="server"  type="text" placeholder="DNI" pattern="[0-9]+" MinLength="8" MaxLength="8" ></asp:TextBox>
                                                        <asp:TextBox ID="txtExtranjero" class="form-control" runat="server"  type="text" placeholder="Código de Extranjería" pattern="[0-9]+" MinLength="9" MaxLength="9" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Nombres</label>
                                                <div class="form-line ">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtNombres" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Apellidos </label>
                                                <div class="form-line ">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtApellidos" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <%--<a href="Inicio.aspx">Inicio.aspx</a>--%>
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Celular</label>
                                                <div class="form-line ">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtCelular" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="input-group date" id="bs_datepicker_component_container">
                                                <label class="form-label">Fecha de nacimiento  </label>
                                                <div class="form-line ">
                                                    <span class="input-group-addon">
                                                        <asp:TextBox ID="txtFechaNacimiento" class="form-control date" runat="server"></asp:TextBox>
                                                        <i class="material-icons">date_range</i>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- <div class="input-group date" id="bs_datepicker_component_container">
                                    <div class="form-line">
                                        <input type="text" class="form-control" placeholder="Please choose a date...">
                                    </div>

                                </div>--%>

                                <div class="col-md-6">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Correo </label>
                                                <div class="form-line ">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtCorreo" class="form-control email" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
<%--                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Contraseña</label>
                                                <div class="form-line ">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtContrasenia" class="form-control" runat="server" type="password"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                        </asp:Panel>
                        <div class="row">
                            <div class="col-sm-3 right">

                                <asp:LinkButton ID="btnCancelar" runat="server" CssClass="btn bg-red waves-effect" Style="float: right" Width="100%" Text="Cancelar" OnClick="btnCancelar_Click">
												<i class="material-icons">arrow_back</i>Regresar
                                </asp:LinkButton>

                            </div>
                            <div class="col-sm-3 right">
                                <asp:UpdatePanel ID="upBotonEnviar" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btnGuardar" runat="server" CssClass="btn bg-indigo waves-effect" Style="float: right" Width="100%" Text="Guardar"
                                            OnClick="btnRegistrar_Click">
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
                                        <asp:Image ID="Image2" Height="500px" Width="500px" runat="server" class="rounded" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Descripción :</label>
                                                <div class="form-line ">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtDescripcionModal" class="form-control" runat="server"></asp:TextBox>
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
    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" Runat="Server">
    <!-- Bootstrap Datepicker Plugin Js -->
    <script src="../../plugins/jquery-inputmask/jquery.inputmask.bundle.js"></script>
    <script src="../../plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script>
        $(function () {
            var $demoMaskedInput = $('.demo-masked-input');
            $demoMaskedInput.find('.email').inputmask({ alias: "email" });
            $demoMaskedInput.find('.date').inputmask('dd/mm/yyyy', { placeholder: '__/__/____' });
            $('#bs_datepicker_component_container').datepicker({
                autoclose: true,
                container: '#bs_datepicker_component_container'
            });
        });
    </script>
    <script>
        function showSuccessMessage2() {
            setTimeout(function () {
                swal({
                    title: "Todo guardado",
                    text: "Pulsa el botón y se te redirigirá",
                    type: "success"
                }, function () {
                    window.location = "RealizarVenta_Marcial.aspx";
                });
            }, 1000);
        }

    </script>
    <%--<script src="../../js/pages/forms/basic-form-elements.js"></script>--%>
</asp:Content>

