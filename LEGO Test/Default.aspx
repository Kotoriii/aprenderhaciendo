<%@ Page EnableEventValidation="false" Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LEGO_Test._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <div id="carousel-g" class=" carousel slide " style="box-shadow: 0px 10px 7px #888888;" data-ride="carousel">
        <ol class="carousel-indicators">

            <asp:Literal ID="txtIndicator" runat="server"></asp:Literal>

        </ol>


        <div class="carousel-inner">
            <!-- Elementos del slideshow (fotos) que tienen que tener una dimension de 100% 100%  y tambien las "captions"
              que nos son obligatorias y se pueden quitar, me imagino que para nosotros lo mejor sera hacer <a><img/></a>
              ya que tienen que ser links-->



            <asp:Literal ID="txtSlides" runat="server"></asp:Literal>

        </div>
        <!-- Controladores (las flechitas) -->
        <a class="left carousel-control" href="#carousel-g" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span>
        </a>
        <a class="right carousel-control" href="#carousel-g" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right"></span>
        </a>
    </div>
    <!-- Termina el Slider -->

    <!--las columnas -->
    <div class="colm" style="background-image: url(Images/GraficosPagina/fondoPprin.jpg); background-repeat: no-repeat; background-attachment: fixed; background-position-y: 50%; background-position-x: 40%; background-size: 1900px 100%;">
        <div class="container" style="padding-bottom: 1%">
            <div class="row" style="margin-top: 30px; background-color: #f3ca22;">
                <div class="col-md-4">
                    <div class="jumbotron ">
                        <img class="foto-inicio hidden-sm hidden-xs" src="<%= LEGO_Test.Clases.Conexion.getConexion().getImagenEstatica(1,1) %>" alt="" />
                        <h2>Productos</h2>
                        <p style="text-align:justify">
                            <%= LEGO_Test.Clases.Conexion.getConexion().getTextoPagina(1,1) %>
                        </p>
                        <p><a href="Productos.aspx" class="btn btn-primary btn-lg" role="button">Leer Más</a></p>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="jumbotron">
                        <img class="foto-inicio hidden-sm hidden-xs" src="<%= LEGO_Test.Clases.Conexion.getConexion().getImagenEstatica(1,2) %>" alt="" />
                        <h2>Cursos</h2>
                        <p style="text-align:justify">
                            <%= LEGO_Test.Clases.Conexion.getConexion().getTextoPagina(1,2) %>
                        </p>
                        <p><a href="Cursos.aspx" class="btn btn-primary btn-lg" role="button">Leer Más</a></p>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="jumbotron">
                        <img class="foto-inicio hidden-sm hidden-xs" src="<%= LEGO_Test.Clases.Conexion.getConexion().getImagenEstatica(1,3) %>" alt="" />
                        <h2>Olimpiadas</h2>
                        <p style="text-align:justify">
                            <%= LEGO_Test.Clases.Conexion.getConexion().getTextoPagina(1,3) %>
                        </p>
                        <p><a href="Olimpiadas.aspx" class="btn btn-primary btn-lg" role="button">Leer Más</a></p>
                    </div>
                </div>
            </div>
        </div>


        <!-- terminan las columnas -->

        <!-- coso para suscripcion por correo -->


        <div class="bg-primary" style="margin-top: 50px;">

            <div style="padding: 20px; padding-top: 40px;">
                <div class="row">
                    <div class="col-md-2">
                        <h1 style="font-size: 1000%; margin-left: 20%; margin-bottom: -10%; margin-top: -5%"><span class="glyphicon glyphicon-envelope"></span></h1>
                    </div>
                    <div class="col-md-4">
                        <div class="input-group input-group-lg ">
                            <span class="input-group-addon " style="background-color: #d9d8d8;">@</span>
                            <asp:TextBox ID="txtSuscribir" runat="server" CssClass="form-control gris" placeholder="Ingresá tu correo"></asp:TextBox>
                        </div>

                        <br />
                        <br />
                        <div class="pull-right" style="margin-right: 27px;">
                            <asp:Button ID="btnSuscribir" runat="server" Text="Suscríbete" CssClass="btn btn-success btn-lg" OnClick="btnSuscribir_Click" />
                        </div>
                    </div>
                    <div class="col-md-5">
                        <blockquote>
                            <h4>
                                <%= LEGO_Test.Clases.Conexion.getConexion().getTextoPagina(1,4) %>
                            </h4>
                        </blockquote>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div id="s" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="false">
        <div class="modal-dialog">

            <div class="alert alert-success alert-dismissable" style="max-width: 1000px; box-shadow: 0px 10px 7px #021f10;">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="false">&times;</button>
                <h3>Tu correo ha sido añadido exitosamente a la lista. Por favor revisá tu bandeja de entrada.</h3>
            </div>

        </div>
    </div>


    <div id="n" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="false">
        <div class="modal-dialog">

            <div class="alert alert-warning alert-dismissable" style="max-width: 1000px; box-shadow: 0px 10px 7px #021f10;">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="false">&times;</button>
                <h3 style="padding: 5%;">Hubo un error con la solicitud. Revisá que tu dirección de correo esté bien escrita e inténtalo de nuevo. </h3>
            </div>

        </div>
    </div>


    <% String modal = "";
       if (Request["ress"] != null)
       {
           switch (Request["ress"])
           {
               case "error":
                   {
                       modal = "correoN();";
                       break;
                   }
               case "succ":
                   modal = "correoS();";
                   break;
           }
       } %>

    <script type="text/javascript">
        <%= modal %>
        function correoS() {
            $('#s').modal('show');
        }
        function correoN() {
            $('#n').modal('show');
        }
    </script>



</asp:Content>
