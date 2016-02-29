<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarCuenta.aspx.cs" Inherits="LEGO_Test.ModificarCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% LEGO_Test.Clases.Usuario usuario = (LEGO_Test.Clases.Usuario)Session["usuario"]; %>
    <div class="container" style="display: block; width: 40%">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Cambiar Inforacion de Cuenta
                </h3>
            </div>
            <div class="panel-body">

                <h3><b><%= usuario.getNombreUsuario()  %></b></h3>
                <br />

                <asp:Label ID="lasa" runat="server" Text="Vieja Contraseña"></asp:Label>
                <div id="contraV">
                    <asp:TextBox CssClass="form-control" Enabled="false" ID="txtContraV" TextMode="Password" runat="server"  OnTextChanged="txtContra_TextChanged"></asp:TextBox>
                </div>
                <br />
                <br />
                <div style="visibility: hidden; position: absolute;" id="contrasN">
                    <asp:Label ID="Labewel1" runat="server" Text="Nueva Contraseña"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="txtContraN" TextMode="Password" runat="server" ></asp:TextBox><br />
                    <asp:Label ID="Label1" runat="server" Text="Repetir Contraseña"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="txtContraN2" TextMode="Password" runat="server" ></asp:TextBox><br />
                </div>
                <asp:Label ID="Label5" runat="server" Text="Correo"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtCorreo1" runat="server"></asp:TextBox><br />

                <asp:Label ID="Label6" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtNombre1" runat="server"></asp:TextBox><br />

                <asp:Label ID="Label7" runat="server" Text="Numero de Telefono"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtNumeroTel1" runat="server"></asp:TextBox><br />

                <asp:Label ID="Label8" runat="server" Text="Direccion"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtDireccion1" TextMode="multiline" Columns="50" Rows="5" runat="server"></asp:TextBox><br />


                <asp:Label ID="Label3" runat="server" Text="Provincia"></asp:Label>
                <asp:DropDownList ID="txtProvincia1" runat="server" CssClass="form-control">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Cartago</asp:ListItem>
                    <asp:ListItem>San Jose</asp:ListItem>
                    <asp:ListItem>Heredia</asp:ListItem>
                    <asp:ListItem>Alajuela</asp:ListItem>
                    <asp:ListItem>Puntarenas</asp:ListItem>
                    <asp:ListItem>Guanacaste</asp:ListItem>
                    <asp:ListItem>Limon</asp:ListItem>
                </asp:DropDownList>

                <br />
                <br />
                <asp:Button ID="BtnIngresar" CssClass="btn btn-success btn-lg" runat="server" Text="Modificar Datos" OnClick="BtnIngresar_Click" />
            </div>
        </div>
    </div>
    <script>
        $('#contraV').click(function () {
            $('#contrasN').css('visibility', 'visible');
            $('#contrasN').css('position', 'static');
        });
      
    </script>
</asp:Content>
