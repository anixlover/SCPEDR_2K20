<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageUsuario.master" AutoEventWireup="false" CodeFile="consultarEstadoPedido.aspx.vb" Inherits="consultarEstadoPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <div>
            <div class = "body table-responsive">

        <asp:GridView runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="" HeaderText="Cod solicitud" />
                <asp:BoundField DataField="" HeaderText="Fecha" />
                <asp:BoundField DataField="" HeaderText="Tipo" />
                <asp:BoundField DataField="" HeaderText="Importe" />
                <asp:ButtonField ButtonType="button" HeaderText="Accion" CommandName="Pago" Text="Pago">
                    <ControlStyle CssClass="btn btn-warning" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
          </div>
        </div>
    </form>
</asp:Content>

