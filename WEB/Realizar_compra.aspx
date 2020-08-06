    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="Realizar_compra.aspx.cs" Inherits="Realizar_compra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
        .salto {
            width: 430px;
        }
    </style>
    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(200);
                };
                $('#hftxtimg').val("Lleno");
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
    <section class="seccion contenedor clearfix" style="align-items: center">
        <h2>Realizar Compra</h2>
        <div style="text-align: center">
            <asp:Label ID="Label3" runat="server" Text="N° de cuenta a Depositar: XXXXXXXXXX"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Titular de la cuenta: XXXXXXXXXX"></asp:Label>
            <br />
        </div>
        <input type="hidden" runat="server" id="valorObtenidoRBTN" clientidmode="Static" />
        <input type="hidden" runat="server" id="valorCheck" clientidmode="Static" />
        <div class="registrar-cliente">
            <asp:Label ID="lblcosto" runat="server" Text="..." style="font-weight: 700; color: #000000; font-size: xx-large; background-color: #66FF33"></asp:Label>
            <div class="custom-file">
                    Imagen del voucher:<br />
                    &nbsp;<asp:Image ID="Image1" runat="server" class="rounded" />
                    <input type="file" id ="FileUpload1" accept="image/*" runat="server" onchange="ImagePreview(this);" ForeColor="Black" Style="color: transparent" Width="425px" />
                </div>
            <asp:Panel ID="Panel1" runat="server">                
                <div class="form-group form-float">
                    <div class="col-lg-6">
                        <div class="demo-checkbox">
                            <div class="demo-radio-button">
                                <input type="radio" id="rbBoleta" name="pago" value="1" />
                                <label for="rbBoleta">Boleta</label>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="demo-checkbox">
                            <div class="demo-radio-button">
                                <input type="radio" id="rbFactura" name="pago" value="2" />
                                <label for="rbFactura">Factura</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="N°de operación"></asp:Label>
                    <asp:TextBox ID="txtNumOp" name="texto" runat="server" class="form-control" type="text" BackColor="white" BorderColor="Black" Width="100%"></asp:TextBox>
                </div>
                <div class="from-group">
                    <asp:Label ID="Label2" runat="server" Text="Importe:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtImporte" name="texto" runat="server" class="form-control" type="text" step="any" BackColor="white" BorderColor="Black" Width="100%"></asp:TextBox>
                </div>
                <div class="form-group">
                    <div class="col-12" id="RUC" runat="server" hidden clientidmode="Static">
                        <input type="checkbox" id="checkRUC" name="checkRUC" value="3" />
                        <label for="checkRUC">Nuevo RUC</label><br />
                        RUC:<br />
                        <div id="ddlRUCs" runat="server" hidden clientidmode="Static">
                            <asp:DropDownList runat="server" Height="28px" Width="150px" ID="ddlRUC"></asp:DropDownList>
                        </div>
                        <div id="newRUC" runat="server" hidden clientidmode="Static">
                            <asp:TextBox runat="server" Width="150px" type="text" pattern="[0-9]+" MinLength="11" MaxLength="11" ID="txtnewRUC"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button ID="btnCancelar" runat="server" class="btn btn-danger btn-lg" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                        <asp:Button ID="btnEnviar" runat="server" class="btn btn-success btn-lg" Text="Enviar" OnClick="btnEnviar_Click"></asp:Button>
                        <input type="hidden" runat="server" id="hftxtimg" clientidmode="Static" value="vacio"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>
    <script src="js/Aplicacion/UploadFile.js"></script>
    <script src="js/Aplicacion/RealizarCompra.js"></script>
</asp:Content>

