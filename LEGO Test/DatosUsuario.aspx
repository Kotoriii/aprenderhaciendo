<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DatosUsuario.aspx.cs" Inherits="LEGO_Test.DatosUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="width: 70%; border-left-style:solid; border-left-width:medium; border-left-color:#cecece; border-right-style:solid; border-right-width:medium; border-right-color:#cecece">


        <div style="margin-left: 15%;">
            <label style="margin-bottom:4%">Por favor escoja una opción e ingrese sus datos en caso de que desee recibir sus artículos en su casa u oficina</label>
            <asp:Literal runat="server" ID="advertencialiteral" Visible="false"></asp:Literal>
            <br />
            <asp:RadioButton ID="rbntienda" runat="server" GroupName="direccion" /><label>Deseo recoger mis artículos en la tienda</label>
            <br />
            <asp:RadioButton ID="rbndomicilio" runat="server" GroupName="direccion" style="margin-top: 2%"/><label>Deseo que se me entreguen mis artículos a mi domicilio u oficina</label>
            <br />
            <br />
            <br />

            <label for="labelnombre">Nombre</label><br />
            <asp:TextBox ID="nombretxt" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Validatornombre" runat="server" Text=" * Campo requerido" ControlToValidate="nombretxt" Display="Dynamic"></asp:RequiredFieldValidator>

            <br />
            <label for="labelapellido1">Primer Apellido</label><br />
            <asp:TextBox ID="apellido1txt" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Validatorapellido1" runat="server" Text=" * Campo requerido" ControlToValidate="apellido1txt" Display="Dynamic"></asp:RequiredFieldValidator>

            <br />
            <label for="labelapellido2">Segundo Apellido</label><br />
            <asp:TextBox ID="apellido2txt" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Validatorapellido2" runat="server" Text=" * Campo requerido" ControlToValidate="apellido2txt" Display="Dynamic"></asp:RequiredFieldValidator>

            <br />
            <label for="labeltelefono">Teléfono</label><br />
            <asp:TextBox ID="telefonotxt" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="Validatortelefono" runat="server" Text="* Debe incluir solo números" ControlToValidate="telefonotxt" Display="Dynamic" ValidationExpression="^[0-9+\(\)#\.\s\/ext-]+$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="Validatortelefono2" runat="server" Text=" * Campo requerido" ControlToValidate="telefonotxt" Display="Dynamic"></asp:RequiredFieldValidator>

            <br />
            <label for="labelcelular">Celular</label><br />
            <asp:TextBox ID="celulartxt" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="Validatorcelular" runat="server" Text="* Debe incluir solo números" ControlToValidate="celulartxt" Display="Dynamic" ValidationExpression="^[0-9+\(\)#\.\s\/ext-]+$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="Validatorcelular2" runat="server" Text=" * Campo requerido" ControlToValidate="celulartxt" Display="Dynamic"></asp:RequiredFieldValidator> 
            
            <br />
            <label for="labelemail">Email</label><br />
            <asp:TextBox ID="emailtxt" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="Validatoremail1" runat="server" Text="* El formato debe ser xxx@xxx.xx" ControlToValidate="emailtxt" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"></asp:RegularExpressionValidator>
             <asp:RequiredFieldValidator ID="Validatoremail2" runat="server" Text=" * Campo requerido" ControlToValidate="emailtxt" Display="Dynamic"></asp:RequiredFieldValidator>

            <br />
            <label for="labeldireccion">Dirección</label><br />
            <asp:TextBox ID="direcciontxt" runat="server" TextMode="MultiLine" Rows="3" style="width:300px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Validatordireccion" runat="server" Text=" * Campo requerido" ControlToValidate="direcciontxt" Display="Dynamic"></asp:RequiredFieldValidator>
            
            <br />
            <asp:Button runat="server" Text="Siguiente" ID="Siguiente" OnClick="Siguiente_Click" class="btn btn-success btn-lg" style="margin-left: 48%; margin-top:5%" />
        </div>
            

    </div>


</asp:Content>
