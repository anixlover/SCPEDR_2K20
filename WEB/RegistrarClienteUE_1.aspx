<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="RegistrarClienteUE_1.aspx.cs" Inherits="RegistrarClienteUE_1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <section class="seccion contenedor clearfix">
        <h2>Registrar Cliente</h2>
        <div class="registrar-cliente">

            <div class="formulario">
                    <div>
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="DNI" GroupName="documento" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" EnableTheming="True" ForeColor="Black" />
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Carnet de Extranjería" GroupName="documento" AutoPostBack="True" OnCheckedChanged="RadioButton2_CheckedChanged" ForeColor="Black" />
                    </div>
                    <div class="entrada">
                        <i class="fas fa-id-card icon"></i>
                        <asp:TextBox ID="txtDNI" name="texto" runat="server" class="controls" type="text" placeholder="DNI" pattern="[0-9]+" MinLength="8" MaxLength="8" BackColor="White"></asp:TextBox>
                        <asp:TextBox ID="txtExtranjero" name="texto" runat="server" class="controls" type="text" placeholder="Código de Extranjería" pattern="[0-9]+" MinLength="9" MaxLength="9" BackColor="White"></asp:TextBox>
                    </div>
                    <div class="entrada">
                        <i class="fas fa-user icon"></i>
                        <asp:TextBox ID="txtNombres" name="texto" runat="server" class="controls" type="text" placeholder="Nombres" BackColor="White" ></asp:TextBox>
                    </div>
                    <div class="entrada">
                        <i class="fas fa-user icon"></i>
                        <asp:TextBox ID="txtApellidos" name="texto" runat="server" class="controls" type="text" placeholder="Apellidos" BackColor="White"></asp:TextBox>
                    </div>
                    <div class="entrada">
                        <i class="fas fa-mobile-alt icon"></i>
                        <asp:TextBox ID="txtCelular"  name="texto" runat="server" class="controls" type="text" placeholder="Celular" pattern="[0-9]+" MinLength="9" BackColor="White"></asp:TextBox>
                    </div>
                    <div class="entrada">
                        <i class="fas fa-calendar-alt icon"></i>
                        <asp:TextBox ID="txtFechNac" name="texto" runat="server" class="controls" type="date" placeholder="mm/dd/yyyy" BackColor="White"></asp:TextBox>
                    </div>
                    <div class="entrada">
                        <i class="fas fa-envelope icon"></i>
                        <asp:TextBox ID="txtCorreo"  name="texto" runat="server" class="controls" type="text" placeholder="Correo electronico" BackColor="White"></asp:TextBox>
                    </div>
                    <div class="entrada">
                        <i class="fas fa-lock icon"></i>
                        <asp:TextBox ID="txtContraseña"  name="texto" runat="server" class="controls" type="password" placeholder="Contraseña" BackColor="White"></asp:TextBox>
                    </div>
                    <div class="salto">
                    </div>
                    <div class="salto">

                        <asp:Button ID="btnRegistrar" runat="server" class="btn-ghost" Text="Registrar"
                            OnClick="btnRegistrar_Click"></asp:Button>
                        <asp:Button ID="btnCancelar" runat="server" class="btn-ghost" Text="Cancelar" 
                            OnClick="btnCancelar_Click"></asp:Button>                      
                    </div>                
        </div>
    </section>
</asp:Content>

