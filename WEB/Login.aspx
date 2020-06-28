<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="css/stylelogin.css" rel="stylesheet" />

    <%--top tag--%>
    <title>Iniciar Sesion</title>
</head>
<body id="body">
    <%--logo--%>
    <a href="Home.aspx">
        <img src="img/logo2.png" /></a>

        <%--tittle--%>
        <h1 id="tittle">Decormolduras & Rosetones SAC</h1>

        <%--content principal--%>
        <form id="form2" runat="server" class="auto-style1">
            <section id="content">
                <div class="form-id">
                <div class="form-id">
                    <div class="username-input">
                        <label for="exampleInputEmail1" class="label-name">
                            Codigo Usuario
                        </label>
                        <asp:TextBox ID="txtDni" required name="dni" CssClass="form-control" runat="server"></asp:TextBox>

                    </div>
                    <%--input pass--%>
                    <div class="form-group">
                        <label for="exampleInputPassword1" class="label-name2">
                            Contraseña

                        </label>
                        <asp:TextBox ID="txtContraseña" required name="pass" type="password"
                            CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <%--button succes--%>
                <asp:Label ID="mostrarMensaje" runat="server" ForeColor="#CC0000"></asp:Label>
            <div class="button">
                <asp:Button ID="btnLogin" runat="server" Class="Login-button" type="submit"
                    Text="Ingresar" OnClick="btnLogin_Click" />
            </div>
            </section>
        </form>

        <script type="text/javascript">
            function validarInput() {
                document.getElementById("btnLogin").disabled = !document.getElementById("txtDni").value.length;
            }
        </script>



        <script type="text/javascript">
            function solonumeros(n) {
                key = e.keyCode || e.which;
                teclado = Int32Array(key);
                numeros = "0123456789";
                especiales = "8-37-38-46-146";
                teclado_especial = false;
                for (var i in especiales) {
                    if (key == especiales[i]) {
                        teclado_especial = true; break;
                    }
                }
                if (numeros.indexOf(teclado) == -1 && !teclado_especial) {
                    return false;
                }

            }
        </script>
</body>
</html>
