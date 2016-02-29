<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="LEGO_Test.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="width: 70%">
        <div class="panel panel-default">
            <ul class="list-group">
                <asp:Literal ID="checkoutliteral" runat="server"></asp:Literal>
            </ul>
        </div>
        <asp:Literal ID="checkouttotal" runat="server"></asp:Literal>
        <a href="ComprobarDatos.aspx" id="Avanzar" class="btn btn-success btn-lg" style="margin-left: 90%">Siguiente</a>
    </div>
</asp:Content>
