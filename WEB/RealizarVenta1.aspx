<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RealizarVenta1.aspx.cs" Inherits="RealizarVenta1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function name(e) {
            var nametxt = document.getElementById("lblselected");
            var namevalue = e.options[e.selectedIndex].value;
            if (namevalue > 0) {
                var selectedtex = e.options[e.selectedIndex].Text;
                lblselected.innerHTML = "Seleccionaste : " + selectedtex;
            }
        }
    </script>
</head>
<body>
    <form id="form2" runat="server">
        <div class="blocRealizar Venta">
        </div>
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="header">
                    <ul class="header-dropdown m-r--5">
                    </ul>
                    <div class="row">
                        <div class="col-sm-4">
                               <%-- <asp:DropDownList runat="server" ID="ddl_TipoComprobante" CssClass=" bootstrap-select form-control" OnSelectedIndexChanged="ddl_TipoComprobante_SelectedIndexChanged1">
                                    <asp:ListItem Text="Seleccionar" Selected="True" />
                                    <asp:ListItem Value="1" Text="Boleta" />
                                    <asp:ListItem Value="2" Text="Factura" />
                                </asp:DropDownList>--%>

                            <asp:Label ID="lblselected" runat="server">a </asp:Label>

                        </div>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <div class="card">

                            <div id="boleta" class="body table-responsive ">
                                <asp:TextBox placeHolder="dni" ID="TextBox1" runat="server"></asp:TextBox>
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            </div>

                            <div id="factura" class="body table-responsive ">
                                <asp:TextBox placeHolder="ruc" ID="TextBox2" runat="server"></asp:TextBox>
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

                            </div>



                        </div>
                    </ContentTemplate>

                </asp:UpdatePanel>


               


            </div>
        </div>
    </form>



</body>
</html>

<%--<script type="text/javascript" src="js/jquery.js"></script>--%>
<%-- <script type="text/javascript">
        function tipo() {
            if (id == "boleta") {
                $("#boleta").show();
                $("#factura").hide();
            }
            if (id == "factura") {
                $("#boleta").hide();
                $("#factura").show();
            }
        }
    </script>--%>