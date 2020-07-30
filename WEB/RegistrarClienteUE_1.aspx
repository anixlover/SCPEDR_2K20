<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="RegistrarClienteUE_1.aspx.cs" Inherits="RegistrarClienteUE_1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
     <section>
        <h2>Registrar Cliente</h2>
         <div>
             <div class="registrar-cliente">
                 <input type="hidden" runat="server" id="valorObtenidoRBTN" clientidmode="Static" />
                 <asp:Panel ID="Panel1" runat="server">
                     <div class="form-group form-float">
                         <%--<asp:RadioButton ID="RadioButton1" runat="server" Text="DNI" GroupName="documento" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" EnableTheming="True" ForeColor="Black" />
                         <asp:RadioButton ID="RadioButton2" runat="server" Text="Carnet de Extranjería" GroupName="documento" AutoPostBack="True" OnCheckedChanged="RadioButton2_CheckedChanged" EnableTheming="True" ForeColor="Black" />--%>
                         <div class="form-group form-float">
                             <div class="col-lg-6">
                                 <div class="demo-checkbox">
                                     <div class="demo-radio-button">
                                         <input type="radio" id="rbdni" name="documento" class="radio-col-red" value="1"/>
                                         <label for="rbdni">DNI</label>
                                     </div>
                                 </div>
                             </div>
                             <div class="col-lg-6">
                                 <div class="demo-checkbox">
                                     <div class="demo-radio-button">
                                         <input type="radio" id="rbcarnet" name="documento" class="radio-col-red" value="2" />
                                         <label for="rbcarnet">Carnet de Extranjeria</label>
                                     </div>
                                 </div>
                             </div>
                         </div>
                     </div>
                     <div class="form-group">
                         <div class="col-12" id="DNI" runat="server" hidden clientidmode="Static">
                             <i class="fas fa-id-card icon">N°de DNI</i>
                             <br />
                             <asp:TextBox ID="txtDNI" name="texto" runat="server" class="form-control" type="text" placeholder="DNI" pattern="[0-9]+" MinLength="8" MaxLength="8" BackColor="White" Width="100%"></asp:TextBox>
                         </div>
                         <div class="col-12" id="Extranjero" runat="server" hidden clientidmode="Static">
                             <i class="fas fa-id-card icon">N° de Carnet de Extranjería</i>
                             <br />
                             <asp:TextBox ID="txtExtranjero" name="texto" runat="server" class="form-control" type="text" placeholder="Código de Extranjería" pattern="[0-9]+" MinLength="9" MaxLength="9" BackColor="White" Width="100%"></asp:TextBox>
                         </div>
                     </div>             
                     <div class="row">
                         <div class="col-md-6">
                             <i class="fas fa-user icon">Nombres</i>
                             <asp:TextBox ID="txtNombres" name="texto" runat="server" class="form-control" type="text" placeholder="Nombres" BackColor="White" Width="100%"></asp:TextBox>
                         </div>
                         <div class="col-md-6">
                             <i class="fas fa-user icon">Apellidos</i>
                             <asp:TextBox ID="txtApellidos" name="texto" runat="server" class="form-control" type="text" placeholder="Apellidos" BackColor="White" Width="100%"></asp:TextBox>
                         </div>
                     </div><br />
                     <div class="form-group">
                         <i class="fas fa-mobile-alt icon">Celular</i>
                         <asp:TextBox ID="txtCelular" name="texto" runat="server" class="form-control" type="text" placeholder="Celular" pattern="[0-9]+" MinLength="9" BackColor="White" Width="100%"></asp:TextBox>
                     </div>
                     <div class="form-group">
                         <i class="fas fa-calendar-alt icon">Fecha de nacimiento</i>
                         <asp:TextBox ID="txtFechNac" name="texto" runat="server" class="form-control" type="date" placeholder="mm/dd/yyyy" BackColor="White" Width="100%"></asp:TextBox>
                     </div>
                     <div class="form-group">
                         <i class="fas fa-envelope icon">Correo Electrónico</i>
                         <asp:TextBox ID="txtCorreo" name="texto" runat="server" class="form-control" type="mail" placeholder="Correo electronico" BackColor="White" Width="100%"></asp:TextBox>
                     </div>
                     <div class="form-group">
                         <i class="fas fa-lock icon">Contraseña</i>
                         <asp:TextBox ID="txtContraseña" name="texto" runat="server" class="form-control" type="password" placeholder="Contraseña" BackColor="White" Width="100%"></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Las Contraseñas deben  ser IGUALES!!!" ControlToCompare="txtContraseña" ControlToValidate="txtcontra2" ForeColor="Red"></asp:CompareValidator>
                         <asp:TextBox ID="txtcontra2" name="texto" runat="server" class="form-control" type="password" placeholder="Confirmar Contraseña" BackColor="White" Width="100%"></asp:TextBox>
                     </div>
                 </asp:Panel>
                 <div >
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                         <ContentTemplate>
                             <asp:Button ID="btnRegistrar" runat="server" class="btn btn-success btn-lg" Text="Registrar" OnClick="btnRegistrar_Click"></asp:Button>
                             <asp:Button ID="btnCancelar" runat="server" class="btn btn-danger btn-lg" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                 </div>
             </div>
         </div>
    </section>
    <script src="js/Aplicacion/RegistrarClienteUE1.js"></script>
</asp:Content>

