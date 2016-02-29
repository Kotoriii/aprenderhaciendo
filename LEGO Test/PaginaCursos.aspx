<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaCursos.aspx.cs" Inherits="LEGO_Test.PaginaCursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- la idea con esta pagina es hacerla reutilizable,
        para poder usarla con todos los cursos , hay que encontrar
        una manera para ver si se puede cambiar el url que aparece 
        en la barra del navegador 
        (o deberiamos de hacer una pagina por curso?) -->
    <div class="container">
        <% int pagina = 0;
           switch (Request["curso"])
           {
               case "Máquinas Simples":
                   pagina = 2;
                   break;
               case "WeDo":
                   pagina = 3;
                   break;
               case "MindStorm":
                   pagina = 4;
                   break;
               default:
                   Response.Redirect("~/Cursos.aspx");
                   break;
           }
             %>
        <div class="hidden-xs" style="box-shadow: 0px 10px 7px #888888; width: 90%; margin-right: auto; margin-left: auto">
           <img src="<%= LEGO_Test.Clases.Conexion.getConexion().getImagenEstatica(pagina, 1) %>" alt="imagen curso" style="height:600px; width:100%" />
         </div>
        <div class="container">
            <div class="row " style="margin-top: 80px;">
                <div class="col-md-5">
                    <div style="box-shadow: 0px 10px 7px #888888;">
                        <img src="<%= LEGO_Test.Clases.Conexion.getConexion().getImagenEstatica(pagina, 2) %>" alt="imagenCurso" style="width:100%; height:270px" />
                    </div>
                </div>
                <div class="col-md-7 pull-right">
                <h4 class="text-justify" style="margin-top: 4%">
                    <asp:Literal ID="txtPagina" runat="server"></asp:Literal>
                </h4>
            </div>
            </div>

            
        </div>


        <div class="row pull-right" style="margin-top: 70px;">
            <div class="col-md-3 col-md-pull-3">
                <a class="btn btn-primary btn-lg " href="#myModal" data-toggle="modal" data-target="#myModal">Ver Fotos</a>
            </div>
            <div class="col-md-7 col-md-push-3">
                <br class="visible-xs" />

                <a class="btn btn-success btn-lg" href="Contacto.aspx">Contáctanos</a>
            </div>
        </div>
    </div>



    <link rel="stylesheet" href="Content/prettyPhoto.css" type="text/css" media="screen" />
        <script src="Scripts/jquery.prettyPhoto.js" type="text/javascript" charset="utf-8"></script>

        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true"">
            <div class="modal-dialog modal-lg" style="width: 80%; ">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="myModalLabel">Fotografias del Curso de <asp:Literal ID="txtNombreCursoMod" runat="server"></asp:Literal></h4>
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
