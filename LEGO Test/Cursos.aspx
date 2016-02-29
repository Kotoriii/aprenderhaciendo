<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="LEGO_Test.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="colm" style="background-image: url(Images/GraficosPagina/fondoPprin.png); background-repeat: no-repeat; background-attachment: fixed; background-position-y: 50%; background-position-x: 40%; background-size: 1900px 100%;">


        <div class="row" style="width: 90%; margin-left: auto; margin-right: auto; ">
            <div class="col-md-4">
                <div class="thumbnail" style="height:auto" >

                    <img src="<%= LEGO_Test.Clases.Conexion.getConexion().getImagenEstatica(9,1) %>" style="width: 98%; background-color: lightgray"  alt="Maquinas Simples" />
                    <div class="caption">
                        <h3>Maquinas Simples</h3>
                        <p style="margin-top: 5%; text-align: justify"><%= LEGO_Test.Clases.Conexion.getConexion().getTextoPagina(9,1) %></p>
                        <p style="margin-top: 10%;"><a href="PaginaCursos.aspx?curso=Máquinas%20Simples" class="btn btn-primary btn-lg" role="button" style="position: relative; bottom: 0;">Ver Más</a> </p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="thumbnail" style="height:auto">
                    <img src="<%= LEGO_Test.Clases.Conexion.getConexion().getImagenEstatica(9,2) %>" style="width: 98%; background-color: lightgray"  alt="WeDo" />
                    <div class="caption">
                        <h3>WeDo</h3>
                        <p style="margin-top: 5%; text-align: justify"><%= LEGO_Test.Clases.Conexion.getConexion().getTextoPagina(9,2) %></p>
                        <p style="margin-top: 10%;"><a href="PaginaCursos.aspx?curso=WeDo" class="btn btn-primary btn-lg" role="button">Ver Más</a> </p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="thumbnail" style="height:auto">
                    <img src="<%= LEGO_Test.Clases.Conexion.getConexion().getImagenEstatica(9,3) %>" style="width: 98%; background-color: lightgray" alt="MindStorm" />
                    <div class="caption">
                        <h3>MindStorm</h3>
                        <p style="margin-top: 5%; text-align: justify"><%= LEGO_Test.Clases.Conexion.getConexion().getTextoPagina(9,1) %></p>
                        <p style="margin-top: 10%;"><a href="PaginaCursos.aspx?curso=MindStorm" class="btn btn-primary btn-lg" role="button">Ver Más</a> </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
