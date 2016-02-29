<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="LEGO_Test.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="display: block; width: 40%">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Registrarse
                </h3>
            </div>
            <div class="panel-body">

                <asp:Label ID="Label1" runat="server" Text="Nombre de Usuario"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtNombreUs" runat="server"></asp:TextBox><br />

                <asp:Label ID="Label5" runat="server" Text="Correo"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtCorreo" runat="server"></asp:TextBox><br />

                <asp:Label ID="Label6" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server"></asp:TextBox><br />

                <asp:Label ID="Label7" runat="server" Text="Numero de Telefono"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtNumeroTel" runat="server"></asp:TextBox><br />

                <asp:Label ID="Label8" runat="server" Text="Direccion"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtDireccion" TextMode="multiline" Columns="50" Rows="5" runat="server"></asp:TextBox><br />


                <asp:Label ID="Label3" runat="server" Text="Provincia"></asp:Label>
                <asp:DropDownList ID="txtProvincia" runat="server" CssClass="form-control">
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
                <div style="padding:5%; border-style:solid; border-width: medium; border-color:#eaeaea; max-width: 60%">
                    <h3 style="margin-top:0px"><u>Captcha:</u></h3>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/CImage.aspx" /><br /><br />
                    <asp:TextBox ID="txtimgcode" CssClass="full-width form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <br />
                <asp:Button ID="BtnIngresar" CssClass="btn btn-success btn-lg" runat="server" Text="Registrarse" OnClick="BtnIngresar_Click" />
            </div>
        </div>
    </div>


    <br />
    <br />
    <br />
    <script>
        $('#inicioSes').css('visibility', 'hidden');
    </script>
</asp:Content>
