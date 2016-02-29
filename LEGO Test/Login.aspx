<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LEGO_Test.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container" style="display: block; width:40%">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Login
                </h3>
            </div>
            <div class="panel-body">
               
                <div style="max-width:100%">
                    <h4><u>
                        <asp:Label ID="Label3" runat="server" Text="Nombre de Usuario"></asp:Label></u></h4>
                    <asp:TextBox  CssClass="form-control" ID="TextCorreoIn" runat="server"></asp:TextBox><br />
                   
                    <h4><u>
                        <asp:Label ID="Label4" runat="server" Text="Contraseña"></asp:Label></u></h4>
                    <asp:TextBox CssClass="form-control"  TextMode="Password" ID="TextContrasena" runat="server"></asp:TextBox><br />
                    <br /><br />
                     <asp:Button CssClass="btn blBoot btn-lg full-width" ID="BtnIniciarr" runat="server" Text="Ingresar" OnClick="BtnIniciarr_Click" />
                   <br /> <br />
                    <asp:Button CssClass="btn btn-success btn-lg full-width" ID="RecuperarContrasenna" runat="server" Text="¿Olvido su contraseña?" OnClick="RecuperarContrasenna_Click" /><br />
                    <br />
                </div>
            </div>
        </div>
    </div>
    <script>
        $('#inicioSes').css('visibility','hidden');
    </script>
</asp:Content>
