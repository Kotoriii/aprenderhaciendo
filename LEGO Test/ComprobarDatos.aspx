<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComprobarDatos.aspx.cs" Inherits="LEGO_Test.ComprobarDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="width: 70%">
        <div class="panel panel-default">
            <ul class="list-group">
                 <asp:Literal ID="datosliteral" runat="server"></asp:Literal>
                <asp:Literal ID="montototal" runat="server"></asp:Literal>
                
 

            </ul>
            <script src="https://www.paypalobjects.com/js/external/paypal-button.min.js?merchant=cmackm-facilitator@hotmail.com" 
    data-button="buynow" 
    data-name="Carrito" 
    data-amount="<%= (int)Session["total"] %>" 
    data-currency="USD" 
    data-env="sandbox"
                   
></script>
        </div>
        <asp:Button runat="server" Text="Finalizar Compra" ID="Siguiente" OnClick="Siguiente_Click" class="btn btn-success btn-lg" style="margin-left: 48%; margin-top:5%" />

    </div>
</asp:Content>
