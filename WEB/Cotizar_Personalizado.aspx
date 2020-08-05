<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cotizar_Personalizado.aspx.cs" Inherits="Cotizar_Personalizado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">

    <section>
        <form id="form1" runat="server" method="POST">
            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
            <div class="block-header align-center">
                <h1 id="txtPagina" runat="server"></h1>
            </div>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2 id="solicitud" runat="server"></h2>
                            <small></small>
                            <ul class="header-dropdown m-r--5">
                            </ul>
                        </div>
                        <div class="body">
                            <div class="row">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-6">
                                    <div>

                                        <asp:Image ID="Image1" Height="350px" Width="350px" runat="server" class="rounded" />

                                        <input name="fileAnexo" type="file" id="FileUpload1" runat="server" accept=".png,.jpg" class="btn btn-warning" style="width: 100%;" />
                                        <br />
                                    </div>
                                    <div class="center">
                                    </div>
                                </div>
                                <div class="col-sm-3"></div>
                            </div>
                        </div>
                </div>
            </div>
            </div>


        </form>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
</asp:Content>

