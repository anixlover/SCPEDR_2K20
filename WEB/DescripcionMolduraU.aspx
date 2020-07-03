<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="DescripcionMolduraU.aspx.cs" Inherits="DescripcionMolduraU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="seccion contenedor clearfix">
    <h2>Descripcion</h2>
    <div class="descripcion-moldura">
        
        <asp:Image ID="Image1" Height="370px" Width="450px" runat="server" class="rounded" />
                    
        <p>Medida:<asp:Label ID="txtmedida" runat="server"></asp:Label></p>
        <p><asp:Label ID="txtmetrica" runat="server"></asp:Label></p>
        <p>Precio: S./<asp:Label ID="txtprecio" runat="server"></asp:Label></p>
        <p>Descripción:<asp:Label ID="txtdescripcion" runat="server"></asp:Label></p>
        <a href="#" class="button" onclick="btn_regresar()">Regresar</a>
        <a href="#" class="button" onclick="btn_regresar()"> <i class="far fa-star"></i></a>
    </div>

</section>
</asp:Content>

