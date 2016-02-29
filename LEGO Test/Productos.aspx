
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="LEGO_Test.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <!-- barra para buscar -->
    <div class="bg-info" style="margin-bottom: 20px">
        <div style="padding: 0px;">
            <nav class="navbar navbar-default" role="navigation">

                <a href="<%= "link para descargar folleto" %>" class="btn btn-lg" style="margin-left: 2%"><u>Descargar Folleto</u></a>

                <ul class="nav navbar-nav  pull-right" style="margin-right: 1%">

                    <li style="margin-top: 2%; margin-right: 10px;">
                        <asp:TextBox ID="txtBuscar" runat="server" CssClass=" form-control btn-lg g"></asp:TextBox></li>

                    <li>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-default btn-lg" OnClick="btnBuscar_Click" /></li>
                </ul>
            </nav>
        </div>
    </div>



    <!-- version para celulares -->
    <div class="visible-xs visible-sm">

        <div class="container">

            <ul class="nav nav-tabs nav-justified">
                <li><a href="Productos.aspx">Todos</a></li>
                <li><a href="Productos.aspx?categoria=Máquinas%20Simples">Máquinas Simples</a></li>
                <li><a href="Productos.aspx?categoria=WeDo">WeDo</a></li>
                <li><a href="Productos.aspx?categoria=MindStorm">MindStorm</a></li>
            </ul>


            <div class="row">

                <!-- Elementos de los productos -->

                <asp:Literal ID="eletien" runat="server"></asp:Literal>

            </div>
        </div>
    </div>
    <!-- termina version de moviles -->



    <!-- version para compus -->
    <div class="visible-md visible-lg">

        <!-- sidebar -->
        <div class="pull-left" style="width: 15%; height: 100%;">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Categorías: </h3>
                </div>
                <div class="panel-body">
                    <div class="list-group">
                        <!-- span es la cantidad de productos en cada categoria -->
                        <asp:LinkButton ID="btTodosCat" runat="server" OnClick="categorias" CssClass="list-group-item">
                            <h4><span class="badge pull-right">
                                <asp:Literal ID="txtTodos" runat="server"></asp:Literal></span> Todos</h4>
                        </asp:LinkButton>
                        <asp:LinkButton ID="btSimplesCat" runat="server" OnClick="categorias" CssClass="list-group-item">
                            <h4><span class="badge pull-right">
                                <asp:Literal ID="txtMaquinasSimples" runat="server"></asp:Literal></span> Máquinas Simples</h4>
                        </asp:LinkButton>
                        <asp:LinkButton ID="btWedoCat" runat="server" OnClick="categorias" CssClass="list-group-item">
                            <h4><span class="badge pull-right">
                                <asp:Literal ID="txtWeDo" runat="server"></asp:Literal></span> WeDo</h4>
                        </asp:LinkButton>
                        <asp:LinkButton ID="btNXTCat" runat="server" OnClick="categorias" CssClass="list-group-item">
                            <h4><span class="badge pull-right">
                                <asp:Literal ID="txtMindStorm" runat="server"></asp:Literal></span> MindStorm</h4>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>

        </div>

        <!-- termina sidebar -->

        <div class="container" style="width: 85%; margin-left: 20%">
            <div class="row">
                <h1>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal></h1>
                <!-- Elementos de los productos -->
                <asp:Literal ID="elementosTienda" runat="server"></asp:Literal>

            </div>
        </div>
    </div>
    <!-- termina version de compu -->



    <!-- botones para pasar de pagina -->
    <div id="botones" class="container" style="margin-top: 20px; width: 20%">

        <h2 class="pull-left" style="min-width: 140px"><span class="glyphicon glyphicon-chevron-left"></span>
            <asp:Button ID="btnAnterior" runat="server" Text="Anterior" CssClass="btn btn-success btn-lg" OnClick="btnAnterior_Click" /></h2>

        <h2 class="pull-right" style="min-width: 140px">
            <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" CssClass="btn btn-success btn-lg" OnClick="btnSiguiente_Click" />
            <span class="glyphicon glyphicon-chevron-right"></span></h2>
    </div>
    <!-- termina botones para pasar de pagina -->



    <!-- Modal -->
    <div class="modal fade" id="modalProducto" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="width: 80%">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 id="nombre1" class="modal-title" ></h4>
                </div>
                <div class="modal-body">

                    <!-- contenido -->

                    <link rel="stylesheet" href="Content/prettyPhoto.css" type="text/css" media="screen" />
                    <script src="Scripts/jquery.prettyPhoto.js" type="text/javascript" charset="utf-8"></script>

                    <div class="row">
                        <div class="col-md-6">
                            <a id="prettyPHa" href="#producto" rel="prettyPhoto[pp_gal]">
                                <img id="imagen" src="#" alt="" style="width: 40%; margin: 5%; margin-left: 30%" />
                            </a>
                        </div>

                        <div class="col-md-5" style="border-left-color:#808080; border-bottom-color: #808080; border-left-style:solid; border-bottom-style:solid; padding-bottom:5%">
                            <h2 id="nombre2" style="text-decoration:underline"></h2> <br/>
                            <h4 id="descripcion"></h4>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 5%">


                        <div class="col-md-12">

                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th>
                                            <h2>Detalles</h2>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <h4>Precio: <span class="glyphicon glyphicon-euro pull-right"></span></h4>
                                        </td>
                                        <td>
                                            <h4 id="precio"></h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4>Edades: <span class="glyphicon glyphicon-user pull-right"></span></h4>
                                        </td>
                                        <td>
                                            <h4 id="edades"></h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4>Categoría: <span class="glyphicon glyphicon-tag pull-right"></span></h4>
                                        </td>
                                        <td>
                                            <h4 id="categoria"></h4>
                                        </td>
                                    </tr>
                                   
                                </tbody>
                            </table>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <a href="#" id="btCar" class="btn btn-success btn-lg">Añadir al Carrito</a>
                    <button type="button" class="btn btn-default btn-lg" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var minSize = 750

        $(window).resize(ordenarBotones());
        $(document).ready(ordenarBotones());

        function ordenarBotones() {

            //    alert($(window).width());
            if ($(window).width() < minSize) {
                $('#botones').css('width', '100%');
            }
            else {
                $('#botones').css('width', '40%');
            }

        }



        function setId(_id, _nombre, _descripcion, _url, _precio, _categoria) {
            $("#btCar").attr("href", "Carrito.aspx?idProd=" + _id + "");
            $('#nombre1').text(_nombre);
            $('#nombre2').text(_nombre);
            $('#descripcion').text(_descripcion);
            $('#imagen').attr('src', _url);
            $('#imagen').attr('alt', _nombre);
            $('#precio').text(_precio);
            $('#categoria').text(_categoria);
            $('#prettyPHa').attr('href', _url);

            var edad = "Indefinido";
            if (_categoria === "Maquinas Simples") {
                edad = "De 3 a 5 años";
            }
            if (_categoria === "WeDo") {
                edad = "De 6 a 8 años";
            }
            if (_categoria === "robótica NXT") {
                edad = "Edades de 9 en adelante";
            }

            $('#edades').text(edad);

            $('#modalProducto').modal('show');
        }

    </script>

</asp:Content>
