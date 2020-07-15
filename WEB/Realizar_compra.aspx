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
                        .width(300)
                        .height(300);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <section class="seccion contenedor clearfix" style="align-items:center">
        <h2>Realizar Compra</h2>
         <div style="text-align: center">
             <asp:Label ID="Label3" runat="server" Text="N° de cuenta a Depositar: XXXXXXXXXX"></asp:Label>
             <br />
             <asp:Label ID="Label4" runat="server" Text="Titular de la cuenta: XXXXXXXXXX"></asp:Label>
             <br />
         </div>         
        <div class="registrar-cliente">
            <div class="formulario">                    
                    <div class="entrada" style="align-content: center">                        
                        Imagen del voucher:<br />
                        &nbsp;<asp:Image ID="Image1" runat="server" class="rounded"/>
                            <asp:FileUpload ID="FileUpload1" accept="image/*" runat="server" onchange="ImagePreview(this);" ForeColor="Black" style="color:transparent" Width="152px"/>
                    </div>
                    <div class="entrada" style="text-align: center">
                                                <asp:RadioButton runat="server" Text="Boleta" GroupName="pago" ID="rbBoleta" AutoPostBack="True" OnCheckedChanged="rbBoleta_CheckedChanged"></asp:RadioButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton runat="server" Text="Factura" GroupName="pago" ID="rbFactura" AutoPostBack="True" OnCheckedChanged="rbFactura_CheckedChanged"></asp:RadioButton>
                    </div>
                    <div class="entrada">
                        <asp:Label ID="Label1" runat="server" Text="N°de operación"></asp:Label>
                        <asp:TextBox ID="txtNumOp" name="texto" runat="server" class="controls" type="text"  BackColor="white" BorderColor="Black"></asp:TextBox>
                    </div>
                    <div class="entrada">
                        <asp:Label ID="Label2" runat="server" Text="Importe:                                  "></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtImporte" name="texto" runat="server" class="controls" type="text" step="any" BackColor="white" BorderColor="Black"></asp:TextBox>
                    </div>
                    <div class="entrada"style="text-align: center">
                        <asp:Label ID="lblfecha" runat="server" Text="..."></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                    <div class="entrada" style="align-items:center; text-align: center">
                        <asp:CheckBox runat="server" text="Nuevo RUC" ID="checkboxRUC" AutoPostBack="True" OnCheckedChanged="checkboxRUC_CheckedChanged" ></asp:CheckBox>
                        <br />
                        <asp:Label runat="server" Text="RUC:" ID="lblRUC"></asp:Label>
                        <asp:DropDownList runat="server" Height="28px" Width="150px" ID="ddlRUC"></asp:DropDownList>
                        <asp:TextBox runat="server" Width="150px" type="text" pattern="[0-9]+" MinLength="11" MaxLength="11" ID="txtnewRUC"></asp:TextBox>
                    </div>
                    <div class="salto" style="align-items:center">
                        <asp:Button ID="btnCancelar" runat="server" class="btn-ghost" Text="Cancelar"></asp:Button>  
                        <asp:Button ID="btnEnviar" runat="server" class="btn-ghost" Text="Enviar" OnClick="btnEnviar_Click"></asp:Button>                                            
                    </div> 
                </div>
            </div>
    </section>
</asp:Content>

