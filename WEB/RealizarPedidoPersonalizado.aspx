<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="RealizarPedidoPersonalizado.aspx.cs" Inherits="RealizarPedidoPersonalizado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../../plugins/momentjs/moment.js"></script>
    <link href="../../plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="seccion contenedor clearfix">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
        <%--<div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">--%>
        <div class="pedido-personalizado">

            <h2>Realizar Pedido Personalizado</h2>
            <div class="cartilla">

                <h3>Tipo de Pedido</h3>
                <div class="cuadrado">
                    <%--<asp:RadioButton ID="rbCatalogo" Text="  Catalogo" runat="server" />
                <asp:RadioButton ID="rbDiseño" Text="  Diseño Propio" runat="server" />--%>
                    <asp:RadioButton ID="rbCatalogo" runat="server" Text="Catalogo" GroupName="pedido" AutoPostBack="True" OnCheckedChanged="rbCatalogo_CheckedChanged" EnableTheming="True" ForeColor="Black" />
                    <asp:RadioButton ID="rbPropio" runat="server" Text="Diseño Propio" GroupName="pedido" AutoPostBack="True" OnCheckedChanged="rbPropio_CheckedChanged" ForeColor="Black" />
                </div>
            </div>
            <div class="cartilla">
                <h3>Especificaciones</h3>

                <%--Catalogo--%>
                <div class="conteniendo">
                <div class="conteniendo-separacion">
                    <asp:Label ID="Label1" runat="server" Text="Codigo: "></asp:Label><asp:TextBox ID="txtcodigo" name="texto" runat="server" pattern="[0-9]+" TextMode="Number" Width="150px"></asp:TextBox>
                &nbsp;
                <asp:LinkButton runat="server" ID="btnSearch" CssClass="busqueda" OnClick="btnSearch_Click" style="width: 100px"> 
                                            <i class="fas fa-search"></i>
                </asp:LinkButton>
                </div>
                    </div>
                <br />
                <br />

                <asp:Label ID="Label2" runat="server" Text="Medida: "></asp:Label><asp:TextBox ID="txtmedida" runat="server" Width="160px" Enabled="False"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Precio(u): "></asp:Label><asp:TextBox ID="txtprecio" runat="server" Width="160px" Enabled="False"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Cantidad: "></asp:Label><asp:TextBox ID="txtcantidad" runat="server" TextMode="Number" Width="160px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <asp:HiddenField runat="server" ID="txtunidadmetrica" />
                <%--brn calcular--%>
                <asp:LinkButton runat="server" ID="LinkButton1" CssClass="calcular" OnClick="btnCalcular_Click"> 
                                            <i class="fas fa-calculator"></i> calcular
                </asp:LinkButton>
                <br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="Importe: "></asp:Label><asp:TextBox ID="txtimporte" runat="server" Width="154px" Enabled="False"></asp:TextBox>
                
                <br />
                <br />
                <asp:Label ID="Label6" runat="server" Text="Comentario: "></asp:Label><asp:TextBox ID="txtarea" runat="server" Height="64px" Width="856px" TextMode="MultiLine"></asp:TextBox>
                
                <br />

                <%--personalizado--%>
                <div class="medio">
                <asp:Label ID="Label7" runat="server" Text="Imagen de la moldura"></asp:Label>

                <br />

                <asp:Image ID="Image1" Height="250px" Width="250px" runat="server" class="rounded" />
                    <br />  
                <input name="fileAnexo" type="file" id="FileUpload1" runat="server" accept=".png,.jpg" class="btn btn-warning" style="width: 50%;" onchange="ImagePreview(this);" />
                    <br />  
</div>
                <asp:Label ID="Label8" runat="server" Text="Tipo de moldura: "></asp:Label><asp:DropDownList ID="ddlTipoMoldura" class="form-control" runat="server" required Width="278px"></asp:DropDownList>

                <br />

                <asp:Label ID="Label9" runat="server" Text="Medida: "></asp:Label><asp:TextBox ID="txtmedidap" runat="server"></asp:TextBox>
                <asp:Label ID="Label10" runat="server" Text="Cantidad: "></asp:Label><asp:TextBox ID="txtcantidadp" runat="server" TextMode="Number"></asp:TextBox>
                <asp:Label ID="Label11" runat="server" Text="Importe Aprox: "></asp:Label>
                <asp:TextBox ID="txtimporteaprox" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" ID="LinkButton2" CssClass="calcular" OnClick="btnCalcular_Click"> 
                                            <i class="fas fa-calculator"></i> calcular
                </asp:LinkButton>
                <asp:Label ID="Label12" runat="server" Text="Comercio: "></asp:Label><asp:TextBox ID="txtcomentariop" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:UpdatePanel ID="upBotonEnviar" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton runat="server" ID="btnenviar" CssClass="enviar" OnClick="btnEnviar_Click"> 
                                            <i class="far fa-envelope"></i> Enviar
                        </asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <%--                <asp:Button ID="btnenviar" runat="server" CssClass="enviar" Text="Enviar" <i class="far fa-envelope"></i>/>--%>
            </div>
        </div>
    </section>

    <script src="../../plugins/sweetalert/sweetalert.min.js"></script>
    <script type="text/javascript">
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                        .width(250)
                        .height(250);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <script src="js/Aplicacion/UploadFile.js"></script>
</asp:Content>

