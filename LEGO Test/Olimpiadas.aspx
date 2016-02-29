<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Olimpiadas.aspx.cs" Inherits="LEGO_Test.Olimpiadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <!-- talves podria ser un slidshow, hay que preguntarle a Alejandra que le gusta más -->

    <div class="container">
        <div class="hidden-xs" style="box-shadow: 0px 10px 7px #888888;">
            <asp:Image ID="imgPresentacion" runat="server" Width="100%" Height="600px" BackColor="LightGray" ImageUrl="~/Images/AprenderHaciendoLogo.png" />
        </div>

        <div class="row " style="margin-top: 80px;">
            <div class="col-md-7 ">
                <h4 class="text-justify" style="margin-top: 4%">
                    <asp:Literal ID="txtPagina" runat="server"></asp:Literal>
                </h4>
            </div>
            <div class="col-md-5 pull-right">
                <div style="box-shadow: 0px 10px 7px #888888;">
                    <asp:Image ID="imgContenido" runat="server" Width="100%" Height="270px" BackColor="LightGray" ImageUrl="~/Images/AprenderHaciendoLogo.png" />
                </div>
            </div>


        </div>


        <div class="row " style="margin-top: 70px;">
            <div class="col-md-3 ">
                <a class="btn btn-primary btn-lg " href="#myModal" data-toggle="modal" data-target="#myModal">Ver Fotos</a>
            </div>
            <div class="col-md-6 col-md-pull-1">
                <br class="visible-xs" />

                <a class="btn btn-success btn-lg" href="#">Saber más sobre las Olimpiadas</a>
            </div>
        </div>
    </div>


    <link rel="stylesheet" href="Content/prettyPhoto.css" type="text/css" media="screen" charset="utf-8" />
    <script src="Scripts/jquery.prettyPhoto.js" type="text/javascript" charset="utf-8"></script>

    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="width: 80%">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Fotos de las Olimpiadas</h4>
                </div>
                <div class="modal-body">


                    <!-- grid de fotos -->
                    <div class="row">

                        <asp:Literal ID="txtFotosP" runat="server"></asp:Literal>

                    </div>


                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-lg" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
