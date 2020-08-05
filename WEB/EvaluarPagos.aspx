<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EvaluarPagos.aspx.cs" Inherits="EvaluarPagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
        .auto-style2 {
            color: #33CC33;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" Runat="Server">
    <form id="form1" runat="server" method="POST">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
        <div class="body table-responsive">
            <div class="header">
                <h2>Pago de la solicitud 
                <asp:Label ID="lblsol" runat="server" Text="..."></asp:Label>
                    <small></small>
                </h2>
                <ul class="header-dropdown m-r--5">
                </ul>
            </div><br />
            
            <div class="form-control row">
                <div class="col-md-6">
                    <asp:Image ID="Imagenvoucher" runat="server" Height="300px" /><br />
                    <span class="auto-style1"><strong>&nbsp;
                    N° de operación:</strong>
                    <asp:Label ID="lbloperacion" runat="server" Text="..."></asp:Label><br />  
                    <strong>&nbsp;  
                    Importe:</strong> <span class="auto-style2"><strong>S/ <asp:Label ID="lblImporte" runat="server" Text="..."></asp:Label>
                    <br />
                    </strong></span></span><br />                    
                </div>
                <div class="col-md-6">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            Observación:<br />
                            <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox><br /><br />
                            <asp:Button ID="btnObservar" runat="server" Text="Mandar Observación" class="btn btn-danger btn-lg" OnClick="btnObservar_Click" />
                            <asp:Button ID="btnRegistrar" runat="server" Text="Aprobar" class="btn btn-success btn-lg" OnClick="btnRegistrar_Click"/>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" Runat="Server">
</asp:Content>

