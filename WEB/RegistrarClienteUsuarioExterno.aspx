<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistrarClienteUsuarioExterno.aspx.cs" Inherits="RegistrarClienteUsuarioExterno" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>--%>


<!doctype html>
<html class="no-js" lang="">

<head>
    <meta charset="utf-8">
    <title></title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="manifest" href="site.webmanifest">
    <link rel="apple-touch-icon" href="icon.png">
    <!-- Place favicon.ico in the root directory -->

    <link rel="stylesheet" href="css/normalize.css">
    <link rel="stylesheet" href="css/all.css">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Oswald&family=PT+Sans&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="css/main.css">
    <%--<link href="https://kit.fontawesome.com/ce7e303de7.js" rel="stylesheet" />--%>

    <%--<link href="css/stylelogin.css" rel="stylesheet" />--%>
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.6.0/dist/leaflet.css" />

    <link rel="stylesheet" href= "https://kit.fontawesome.com/ce7e303de7.js" />
    <meta name="theme-color" content="#fafafa">
</head>

<body>
    <!--[if IE]>
    <p class="browserupgrade">You are using an <strong>outdated</strong> browser. Please <a href="https://browsehappy.com/">upgrade your browser</a> to improve your experience and security.</p>
  <![endif]-->

    <!-- Add your site or application content here -->
    <form id="form1" runat="server">
        <header class="site-header">
            <div class="hero">
                <div class="contenido-header">
                    <nav class="redes-sociales">
                        <a href="#"><i class="fab fa-facebook-f"></i></a>
                        <a href="#"><i class="fab fa-instagram"></i></a>
                        <a href="#"><i class="fab fa-youtube"></i></a>
                    </nav>
                    <div class="informacion-evento">
                        <div class="clearfix">
                            <p class="fecha"><i class="far fa-calendar-alt"></i>29/05/2020</p>
                            <p class="ciudad"><i class="fas fa-map-marker-alt"></i>Lima, Perú</p>
                        </div>

                        <h1 class="nombre-sitio">Decormolduras & Rosetones S.A.C</h1>
                        <p class="slogan">Los mejores acabados en <span>molduras</span> para realzar los distintos ambientes</p>
                    </div>
                    <!--informacion evento -->
                </div>

            </div>
            <!--,hero-->
        </header>

        <div class="barra">
            <div class="contenedor clearfix">
                <div class="logo">
                    <a href="Home.aspx"><img loading="lazy" src="img/logo1.svg" alt="logo decormolduras"></a>
                </div>
                <div class="menu-movil">
                    <span></span>
                    <span></span>
                    <span></span>
                </div>
                <nav class="navegacion-principal clearfix">
                    <a href="nosotros.html">Nosotros</a>
                    <a href="InspeccionarCatalogo.aspx">Catalogo</a>
                    <a href="ideas.html">Ideas</a>
                    <a href="Login.aspx">Iniciar Sesion</a>
                    <a href="RegistrarClienteUsuarioExterno.aspx">Registrate</a>
                </nav>
            </div>
            <!--.contenedor-->
        </div>
        <!--.barra-->

    <section class="seccion contenedor clearfix">
        <h2>Registrar Cliente</h2>
        <div class="registrar-cliente">

            <div class="formulario">

                <div class="formulario">
                    <div class="entrada">
                        <i class="fas fa-id-card icon"></i>
                        <asp:TextBox ID="txtDNI" required name="texto" runat="server" class="controls" type="text" placeholder="DNI"></asp:TextBox>
                    </div>
                    <div class="entrada">
                        <i class="fas fa-user icon"></i>
                        <asp:TextBox ID="txtNombres" required name="texto" runat="server" class="controls" type="text" placeholder="Nombres"></asp:TextBox>
                    </div>
                    <div class="entrada">
                        <i class="fas fa-user icon"></i>
                        <asp:TextBox ID="txtApellidos" required name="texto" runat="server" class="controls" type="text" placeholder="Apellidos"></asp:TextBox>
                    </div>
                    <div class="entrada">
                        <i class="fas fa-mobile-alt icon"></i>
                        <asp:TextBox ID="txtCelular" required name="texto" runat="server" class="controls" type="number" placeholder="Celular"></asp:TextBox>
                    </div>
                    <div class="entrada">
                        <i class="fas fa-calendar-alt icon"></i>
                        <asp:TextBox ID="txtFechNac" required name="texto" runat="server" class="controls" type="date" placeholder="mm/dd/yyyy"></asp:TextBox>
                    </div>
                    <div class="entrada">
                        <i class="fas fa-envelope icon"></i>
                        <asp:TextBox ID="txtCorreo" required name="texto" runat="server" class="controls" type="text" placeholder="Correo electronico"></asp:TextBox>
                    </div>
                    <div class="entrada">
                        <i class="fas fa-lock icon"></i>
                        <asp:TextBox ID="txtContraseña" required name="texto" runat="server" class="controls" type="password" placeholder="Contraseña"></asp:TextBox>
                    </div>
                    <div class="salto">
                    </div>
                    <div class="salto">

                        <asp:Button ID="Button1" runat="server" class="btn-ghost" Text="Registrar"
                            OnClick="btnRegistrar_Click"></asp:Button>
                        <asp:Button ID="Button2" runat="server" class="btn-ghost" Text="Cancelar" 
                            OnClick="btnCancelar_Click"></asp:Button>
                      
                    </div>
                </div>
            </div>
        </div>
    </section>









    <!--.Registro-->
        
        <footer class="site-footer">
            <div class="contenedor clearfix">
                <div class="footer-informacion">
                    <h3>Sobre <span>decormolduras & rosetones s.a.c.</span></h3>
                    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Iste odit nulla laboriosam quas voluptas nihil? Natus eum exercitationem temporibus facere tenetur quas ab. Sunt aliquid alias, temporibus maiores architecto iste.</p>
                </div>
                <div class="menu">
                    <h3>Redes <span>sociales</span></h3>
                    <nav class="redes-sociales">
                        <a href="#"><i class="fab fa-facebook-f"></i></a>
                        <a href="#"><i class="fab fa-instagram"></i></a>
                        <a href="#"><i class="fab fa-youtube"></i></a>
                    </nav>
                </div>
            </div>

            <p class="copyright">
                Todos los derechos Reservados SCPEDR 2020_1
            </p>


        </footer>

        <!--programa-->


        <script src="js/vendor/modernizr-3.8.0.min.js"></script>
        <script src="https://code.jquery.com/jquery-3.4.1.min.js"
            integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin="anonymous"></script>
        <script>window.jQuery || document.write('<script src="js/vendor/jquery-3.4.1.min.js"><\/script>')</script>
        <script src="js/plugins.js"></script>
        <script src="https://unpkg.com/leaflet@1.6.0/dist/leaflet.js"></script>
        <script src="js/main.js"></script>

        <!-- Google Analytics: change UA-XXXXX-Y to be your site's ID. -->
        <script>
            window.ga = function () { ga.q.push(arguments) }; ga.q = []; ga.l = +new Date;
            ga('create', 'UA-XXXXX-Y', 'auto'); ga('set', 'transport', 'beacon'); ga('send', 'pageview')
        </script>
        <script src="https://www.google-analytics.com/analytics.js" async></script>
    </form>
</body>

</html>

