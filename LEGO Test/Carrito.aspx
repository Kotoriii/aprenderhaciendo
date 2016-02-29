<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="LEGO_Test.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="width: 70%">
        <button type="submit" id="updatelink" class="btn btn-success btn-lg" style="margin-left: 85%; margin-bottom:2%" runat="server" onserverclick="updatelink_ServerClick" >Actualizar Carrito</button>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Carrito de compras</h3>
            </div>
            <ul class="list-group">
                <asp:Literal ID="carritodespliegue" runat="server"></asp:Literal>
            </ul>
        
        </div>

         <h3 style="margin-left: 79%"><asp:Literal ID="total" runat="server"></asp:Literal></h3>
         <asp:Literal ID="botoncomprar" runat="server"></asp:Literal>
    </div>
    <input id="cambioCantP" type="hidden" runat="server" />
   
    <script type="text/javascript">

        function Update_Link() {

            $('#updatelink').show();
        }

    </script>

</asp:Content>
