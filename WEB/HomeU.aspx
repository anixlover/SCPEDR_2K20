<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="HomeU.aspx.cs" Inherits="HomeU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="seccion contenedor">
        <h2>Los mejores acabados en molduras para realzar los distintos ambientes</h2>
        <p>
            Lorem ipsum dolor, sit amet consectetur adipisicing elit. Facilis, accusantium. Quisquam quibusdam quod
      voluptatem laborum voluptate, provident sint, asperiores reprehenderit cupiditate facere temporibus doloremque,
      explicabo magni? Porro, accusamus vitae. Rem.
           
        </p>
    </section>
    <!--seccion-->
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

    <section class="catalogo contenedor seccion">
        <h2>Catalogo</h2>
        <ul class="lista-moldura clearfix">
            <li>
                <div class="moldura">
                    <img loading="lazy" src="img/RC_1.jpg" alt="imagen roseton" class="tamaño">
                    <p>Roseton Clasico</p>
                </div>
            </li>
            <li>
                <div class="moldura">
                    <img loading="lazy" src="img/CC_1.JPG" alt="imagen roseton" class="tamaño">
                    <p>Cornisa Clasico</p>
                </div>
            </li>
            <li>
                <div class="moldura">
                    <img loading="lazy" src="img/BC_1.JPG" alt="imagen roseton" class="tamaño">
                    <p>Baquetón Clasico</p>
                </div>
            </li>
            <a href="#" class="button float-right">Ver todos</a>
        </ul>
    </section>
    <!--Catalogo-->
    >

 

    <div class="contador parallax">
        <div class="ideas clearfix">
            <h3>¿No sabes donde colocar las molduras?</h3>
            <p>Da clic en el boton para más idea que te oriente en como decorar el hambiente de tu hogar o trabajo.</p>
            <a href="#" class="button float-right">Ideas</a>
        </div>
    </div>
    <!--Parallax-->


    <section class="mapa seccion">

        <h2>Nuestra ubicación</h2>
        <div id="mapa" class="mapa">
        </div>



    </section>
    <!--mapa-->
</asp:Content>

