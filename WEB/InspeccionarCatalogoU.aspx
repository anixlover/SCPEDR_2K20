<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="true" CodeFile="InspeccionarCatalogoU.aspx.cs" Inherits="InspeccionarCatalogoU" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="seccion contenedor clearfix">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
            <h2>Catalogo</h2>
            <div class="contenedor-molduras">
                <div class="categorias" id="categorias">
                    <asp:UpdatePanel runat="server" ID="updOpcionesMolduras">
                        <ContentTemplate>
                            <asp:LinkButton runat="server" ID="btnTodos" OnClick="btnTodos_Click">Todos</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnBaquetonClasico" OnClick="btnBaquetonClasico_Click">Baqueton Clasico</asp:LinkButton>
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
    <script>
        function cargarInformacion(PK_IM_Cod) {

            location.href = `DescripcionMolduraU.aspx?id=${PK_IM_Cod}`;
  
        }
</script>
    <script>
        function cargarListaDeseo(PK_IM_Cod) {
            var deseoList = [];
            var newItem = {
                id: PK_IM_Cod
            };
            console.log(newItem)
            deseoList.push(newItem)
            localStorageDeseoList(deseoList);
        }

        function getDeseoList() {
            var storeList = localStorage.getItem('localDeseoList');
            if (storeList == null) {
                deseoList = [];
            } else {
                deseoList = JSON.parse(storeList);
            }
            return deseoList;
        }
        function localStorageDeseoList(plist) {
            localStorage.setItem('localDeseoList', JSON.stringify((plist)));
        }
    </script>
    <script>
        function saveLista() {
            
        }
    </script>

</asp:Content>
