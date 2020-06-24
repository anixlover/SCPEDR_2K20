<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InspeccionarCatalogo.aspx.cs" Inherits="Catalogo" %>

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
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Oswald&family=PT+Sans&display=swap"
        rel="stylesheet">
    <link href="css/main.css" rel="stylesheet" />

    <meta name="theme-color" content="#fafafa">
	<link href="plugins/bootstrap/css/bootstrap.css" rel="stylesheet"/>
	<link href="plugins/node-waves/waves.css" rel="stylesheet" />
	<link href="plugins/animate-css/animate.css" rel="stylesheet" />
	<link href="plugins/morrisjs/morris.css" rel="stylesheet" />
	<link href="css/style.css" rel="stylesheet"/>
	<link href="css/themes/all-themes.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
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
            <h2>Catalogo</h2>
            <div class="contenedor-molduras">
                <div class="categorias" id="categorias">
                    <asp:UpdatePanel runat="server" ID="updOpcionesMolduras">
                        <ContentTemplate>
                            <asp:LinkButton runat="server" ID="btnTodos" OnClick="btnTodos_Click">Todos</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnBaquetonClasico" OnClick="btnBaquetonClasico_Click">Baqueton Calsico</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnBaquetonDecorado" OnClick="btnBaquetonDecorado_Click">Baqueton Decorado</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnRosetonClasico" OnClick="btnRosetonClasico_Click">Roseton Clasico</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnRosetonDecorado" OnClick="btnRosetonDecorado_Click">Roseton Decorado</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnCornisaClasica" OnClick="btnCornisaClasica_Click">Cornisa Clasica</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnCornisaDecorada" OnClick="btnCornisaDecorada_Click">Cornisa Decorada</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnPlaca3D" OnClick="btnPlaca3D_Click">Placa 3D</asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <div class="lista-moldura-tipo">


                <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
                    <ContentTemplate>
                        <ul class="lista-moldura-tipo clearfix" id="ListaMoldura" runat="server">
                        </ul>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </section>

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
        <%--<script src="https://code.jquery.com/jquery-3.4.1.min.js"integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin="anonymous"></script>--%>
        
	<script src="plugins/jquery/jquery.min.js"></script>

        	<script src="plugins/jquery/jquery.min.js"></script>

	<!-- Bootstrap Core Js -->
	<script src="plugins/bootstrap/js/bootstrap.js"></script>

	<!-- Select Plugin Js -->
	<script src="plugins/bootstrap-select/js/bootstrap-select.js"></script>

	<!-- Slimscroll Plugin Js -->
	<script src="plugins/jquery-slimscroll/jquery.slimscroll.js"></script>

	<!-- Waves Effect Plugin Js -->
	<script src="plugins/node-waves/waves.js"></script>

	<!-- Jquery CountTo Plugin Js -->
	<script src="plugins/jquery-countto/jquery.countTo.js"></script>

	<!-- Morris Plugin Js -->
	<script src="plugins/raphael/raphael.min.js"></script>
	<script src="plugins/morrisjs/morris.js"></script>

	<!-- ChartJs -->
	<script src="plugins/chartjs/Chart.bundle.js"></script>

	<!-- Flot Charts Plugin Js -->
	<script src="plugins/flot-charts/jquery.flot.js"></script>
	<script src="plugins/flot-charts/jquery.flot.resize.js"></script>
	<script src="plugins/flot-charts/jquery.flot.pie.js"></script>
	<script src="plugins/flot-charts/jquery.flot.categories.js"></script>
	<script src="plugins/flot-charts/jquery.flot.time.js"></script>

	<!-- Sparkline Chart Plugin Js -->
	<script src="plugins/jquery-sparkline/jquery.sparkline.js"></script>

	<!-- Custom Js -->
	<script src="js/admin.js"></script>
	<script src="js/pages/index.js"></script>

	<!-- Demo Js -->
	<script src="js/demo.js"></script>
        <script>
            function cargarInformacion(PK_IM_Cod) {
                //$('#txtMedidaModal').val(medida);
                //$('#txtUnidadMetricaModal').val(unidad);
                //$('#txtPrecioModal').val(precio);
                //$('#txtDescripcionModal').val(descripcion);
                //alert("Informacion del pk " + PK_IM_Cod);

                

                location.href = `DescripcionMoldura.aspx?id=${PK_IM_Cod}`;
                //location.href = "DescripcionMoldura.aspx?id= ";
                //$('#ImageFile').attr("src", imagen);
                //$('#defaultmodal').modal({ show: true });

            }
        </script>

        <script>window.jQuery || document.write('<script src="js/vendor/jquery-3.4.1.min.js"><\/script>')</script>
        <script src="js/plugins.js"></script>
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
