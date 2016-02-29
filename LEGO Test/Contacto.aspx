<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="LEGO_Test.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <!-- Mapa -->
        <div class="hidden-xs" style="box-shadow: 0px 10px 7px #888888;">
            <iframe width="100%" height="600" src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d3930.0099476190044!2d-84.076942!3d9.933129!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8fa0e366d24d3d1b%3A0x86bd02c7707db21e!2sNational+Theatre+of+Costa+Rica!5e0!3m2!1sen!2scr!4v1415553320602"></iframe>
            <br />
            <!--<small><a href="https://maps.google.com/maps?f=d&amp;source=embed&amp;saddr=Centro+Comercial+V%C3%ADa,+San+Jose,+Costa+Rica&amp;daddr=&amp;hl=en&amp;geocode=FZ84lwAdWhP--iFEZxauzGSCkCmxMkZaYeGgjzFEZxauzGSCkA&amp;aq=&amp;sll=9.910506,-84.014645&amp;sspn=0.00474,0.008256&amp;mra=prev&amp;ie=UTF8&amp;ll=9.910431,-84.012198&amp;spn=0.006295,0.006391&amp;t=m" style="color: #0000FF; text-align: left">Ver mapa completo</a></small>-->
        </div>

        <div class="row">
            <div class="col-md-7 pull-left" style="margin-top: 3%">

                <!-- Iconos e informacion de contacto -->
                <table class="table " style="margin-top: 3%">
                    <tbody>
                        <tr>
                           <td>
                                <h2><span class="glyphicon glyphicon-home"></span></h2>
                            </td>
                            <td>
                                <h4 class="text-justify" style="margin-top: 3%"><strong>Dirección: </strong><asp:Literal ID="ltlDireccion" runat="server"></asp:Literal></h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h2><span class="glyphicon glyphicon-earphone"></span></h2>
                            </td>
                            <td>
                                <h4 class="text-justify" style="margin-top: 3%"><strong>Teléfono: </strong><asp:Literal ID="ltlTelefono" runat="server"></asp:Literal></h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h2><span class="glyphicon glyphicon-envelope"></span></h2>
                            </td>
                            <td>
                                <h4 class="text-justify" style="margin-top: 3%"><strong>Email: </strong><asp:Literal ID="ltlEmail" runat="server"></asp:Literal></h4>
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>

            <!-- Enlace a la pagina de facebook -->
            <div class="col-md-5" style="margin-top: 6%">
                <asp:ImageButton ID="Image1" runat="server" Width="90%" ImageUrl="~/Images/GraficosPagina/visitanosenFacebook.png" OnClientClick="window.open('#')" />

            </div>

        </div>

    </div>

</asp:Content>
