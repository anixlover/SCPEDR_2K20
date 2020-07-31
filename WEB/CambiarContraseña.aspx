<%@ Page Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="CambiarContraseña.aspx.cs" Inherits="CambiarContraseña" %>

<asp:Content ID="Content" ContentPlaceHolderID="head" runat="Server">
    <link href="css/main.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="header">
            <h2>Cambiar contrase&ntilde;a  
            </h2>
        </div>
        <br />
        <div class="registrar-cliente">
            <%--contraseña input 1st--%>
            <div class="col-10" id="area1" runat="server" clientidmode="Static">
                <asp:HiddenField runat="server" ID="HiddenField1" ClientIDMode="Static" />

                <%--<i class="fas fa-lock icon"></i>--%>
                <asp:Label ID="lblpass" runat="server" class="form-label"><b>Ingrese su contrase&ntilde;a actual</b></asp:Label>
                <br />
         
                <div class="form-line">
                    <asp:TextBox ID="txtpass" class="form-control" runat="server" type="password" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>

            <br />
            <%--cambiar contrasenia y repetir--%>
            <div class="col-12" id="area2" runat="server" clientidmode="Static">
                <asp:HiddenField runat="server" ID="HiddenField4" ClientIDMode="Static" />

                <asp:Label ID="lblcdex" runat="server" class="form-label"><b>Ingrese su nueva contrase&ntilde;a</b></asp:Label>
                <div class="form-line">
                    <asp:TextBox ID="txtpass1" class="form-control" runat="server" type="password" ClientIDMode="Static"></asp:TextBox>
                </div>
                <br />

                <p>
                    <b>Seguridad de la contraseña:</b>
                </p>
                <p>
                    Usa al menos 8 caracteres. No uses una contraseña de otro 
                </p>
                <p>
                    sitio ni algo demasiado obvio, como el nombre de tu mascota.
                </p>
                <br />

                <asp:Label ID="Label1" runat="server" class="form-label"><b>Confirma la nueva contrase&ntilde;a</b></asp:Label>
                <div class="form-line">
                    <asp:TextBox ID="txtpass2" class="form-control" runat="server" type="password" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <br />
            <asp:UpdatePanel ID="updBotonEnviar" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnsiguiente" runat="server" class="btn-ghost" Text="CAMBIAR"
                        OnClick="btnsiguiente_Click"></asp:Button>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


        <%--<asp:Button ID="btnCancelar" runat="server" class="btn-ghost" Text="Cancelar"
                        OnClick="btnCancelar_Click"></asp:Button>--%>
    </section>
    <script src="js/Aplicacion/cambiarcontrasenia.js"></script>
    
    <script>

        function showSuccessMessage1() {
            swal({
                title: "ERROR!",
                text: "La contraseña no coincide!",
                type: "error"
            });
        }
        function showSuccessMessage2() {
            swal({
                title: "ERROR!",
                text: "Contraseña incorrecta!",
                type: "error"
            });
        }
        function showSuccessMessage3() {
            swal({
                title: "CORRECTO!",
                text: "Contraseña cambiada correctamente!",
                type: "success"
            },function (redirect) {
                    if (redirect) {
                        window.location.href = "InspeccionarCatalogoU.aspx"
                    } 
            });
        }
        function showSuccessMessage4() {
            swal({
                title: "ERROR!",
                text: "Completar espacios en blanco!",
                type: "error"
            });
        }
        function showSuccessMessage5() {
            swal({
                title: "ERROR!",
                text: "UPS, Error inesperado!",
                type: "error"
            });
        }
        function showSuccessMessage6() {
            swal({
                title: "ERROR!",
                text: "UPS, La contraseña debe tener mas de 5 caracteres!",
                type: "error"
            });
        }
    </script>
</asp:Content>
