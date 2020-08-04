<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Nosotros.aspx.cs" Inherits="Nosotros" %>

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
    <link href="https://fonts.googleapis.com/css2?family=Arvo&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="css/main.css">

    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.6.0/dist/leaflet.css" />

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
                    <a href="Home.aspx">
                        <img loading="lazy" src="img/logo1.svg" alt="logo decormolduras"></a>
                </div>
                <div class="menu-movil">
                    <span></span>
                    <span></span>
                    <span></span>
                </div>
                <nav class="navegacion-principal clearfix">
                    <div class="btn-group clearfix right" role="group">
                        <a href="Nosotros.html">Nosotros</a>
                        <a href="InspeccionarCatalogoU.aspx">Catalogo</a>
                        <a href="ideas.html">Ideas</a>
                        <a href="Login.aspx">Iniciar Sesion</a>
                    <a href="RegistrarClienteUE_1.aspx">Registrate</a>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </div>
                </nav>
            </div>
            <!--.contenedor-->
        </div>
        <!--.barra-->
        <main class="contenedor">
            <h2>La Empresa</h2>

            <div class="contenido-nosotros">
                <div class="imagen">
                    <img src="img/Nosotros_Imagen_Negocio.jpg" alt="Imagen Sobre Nosotros" height="370px" width="450px">
                </div>
                <div class="texto-nosotros">
                    <p></p>
                    <span>15 Años de Experiencia</span>

                    <p>
                        La empresa Decormolduras & Rosetones S.A.C. y se halla ubicada en la urbanización de San Juan de Miraflores.
                        Es una empresa que se especializa en el rubro de la fabricación de piezas decorativas el cual se dedica a la venta por mayor de las molduras.
                        Actualmente brinda dos servicios. Venta de stock y venta por diseño personalizado. 
                        Esta empresa se diferencia de las otras debido a que fabrica diseños de acuerdo al cliente desee.
                    </p>


                </div>
            </div>
        </main>






        <section class="nosotros contenedor seccion">
            <div class="programa-nosotros"></div>
            <h2>Sobre nosotros</h2>
            <div class="icono-nosotros clearfix">
                <div class="detalle">
                    <i class="fas fa-award"></i>
                    <h3>CALIDAD</h3>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quis aut cupiditate nobis, quia totam dignissimos iusto. Ab, velit! Ab rem fuga repellat hic autem velit harum quibusdam doloribus facilis nulla?</p>
                </div>

                <div class="detalle">
                    <i class="fas fa-hand-holding-usd"></i>
                    <h3>MEJOR PRECIO</h3>
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Cumque iste culpa consequuntur? Iusto molestias
            porro ad excepturi illum nulla quam magni aperiam doloribus, quas veritatis labore laudantium,
            necessitatibus illo culpa.
                    </p>
                </div>

                <div class="detalle">
                    <i class="far fa-clock"></i>
                    <h3>A TIEMPO</h3>
                    <p>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Veritatis a sunt corrupti eius laborum molestias adipisci asperiores! Vero, id corporis dolorem, vitae praesentium saepe, commodi soluta ratione voluptate nobis optio?</p>
                </div>
            </div>
            <!--Icono nosotros-->
            </div><!--Propgrama nosotros-->
        </section>
        <!--Nosotros-->


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

