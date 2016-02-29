<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaAdmin.aspx.cs" Inherits="LEGO_Test.Admin.PaginaAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- version para compus -->
    <div class="visible-md visible-lg" style="margin-bottom: 10%">

        <div class="container " style="width: 90%">

            <div class="panel-group" id="accordion">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Registrar Administradores
                            </a>
                        </h4>
                    </div>
                    <div id="collapseOne" class="panel-collapse collapse">
                        <div class="panel-body">

                            <div class="panel panel-default" style="margin-left:auto; margin-right:auto;">
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
                                    <asp:TextBox CssClass="form-control" ID="txtNombreAd" runat="server"></asp:TextBox><br />

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

                                    <asp:Button ID="BtnIngresar" CssClass="btn btn-success btn-lg" runat="server" Text="Registrar Administrador" OnClick="BtnIngresar_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Productos
                            </a>
                            <strong><span style="color: blue">
                                <asp:Label ID="lblProducto" runat="server" Text=""></asp:Label></span></strong>
                        </h4>
                    </div>
                    <div id="collapseTwo" class="panel-collapse collapse">
                        <div class="panel-body">

                            <!-- Columna Nuevo Producto -->
                            <div class="row">
                                <div class="col-md-6 pull-left">

                                    <ul class="list-group">
                                        <li class="list-group-item">
                                            <h4><span class="glyphicon glyphicon-barcode"></span>Nuevo Producto</h4>
                                        </li>
                                        <li class="list-group-item">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <h4><span class="glyphicon glyphicon-book"></span>Categoría: </h4>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="categorias" runat="server" CssClass="form-control gris"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Text="* Se requiere de una categoría." ControlToValidate="categorias" InitialValue="---Categoría---" ValidationGroup="newProduct" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="list-group-item">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <h4><span class="glyphicon glyphicon-pencil"></span>Nombre: </h4>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtnombre" runat="server" CssClass="form-control gris" placeholder="Ingrese nombre"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Se requiere el nombre del producto." ControlToValidate="txtnombre" ValidationGroup="newProduct" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="list-group-item">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <h4><span class="glyphicon glyphicon-comment"></span>Descripción: </h4>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtdescripcion" runat="server" CssClass="form-control gris" placeholder="Ingrese descripción"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Se requiere de una descripción." ControlToValidate="txtdescripcion" ValidationGroup="newProduct" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="list-group-item">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <h4><span class="glyphicon glyphicon-tag"></span>Precio: </h4>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtprecio" runat="server" CssClass="form-control gris" placeholder="Ingrese precio"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Se requiere de un precio." ControlToValidate="txtprecio" ValidationGroup="newProduct" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="* Debe ser un precio válido." ControlToValidate="txtprecio" ValidationGroup="newProduct" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="list-group-item">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <h4><span class="glyphicon glyphicon-picture"></span>Imagen: </h4>
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:FileUpload ID="upImage" runat="server" CssClass="btn btn-default" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="* Seleccione una imagen." ControlToValidate="upImage" ValidationGroup="newProduct" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="list-group-item">
                                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Producto" class="btn btn-primary" ValidationGroup="newProduct" CausesValidation="true" OnClick="btnAgregar_Click" />
                                        </li>
                                    </ul>

                                </div>
                                <!-- Termina Columna Nuevo Producto -->

                                <!-- Columna Remover Producto -->
                                <div class="col-md-6">

                                    <ul class="list-group">
                                        <li class="list-group-item">
                                            <h4><span class="glyphicon glyphicon-floppy-remove"></span>Remover Producto</h4>
                                        </li>
                                        <li class="list-group-item">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <h4><span class="glyphicon glyphicon-book"></span>Categoría: </h4>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="categoriasRemover" runat="server" CssClass="form-control gris" OnSelectedIndexChanged="categoriasRemover_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Text="* Se requiere de una categoría." ControlToValidate="categoriasRemover" InitialValue="---Categoría---" ValidationGroup="removeProduct" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="list-group-item">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <h4><span class="glyphicon glyphicon-barcode"></span>Producto: </h4>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="producto" runat="server" CssClass="form-control gris"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Text="* Se requiere de un producto." ControlToValidate="producto" InitialValue="---Producto---" ValidationGroup="removeProduct" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="categoriasRemover" EventName="SelectedIndexChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="list-group-item">
                                            <asp:Button ID="btnRemover" runat="server" Text="Remover Producto" class="btn btn-primary" ValidationGroup="removeProduct" CausesValidation="true" OnClick="btnRemover_Click" />
                                        </li>
                                    </ul>

                                </div>
                                <!-- Termina Columna Remover Producto -->

                            </div>
                            <!-- Termina Columnas -->

                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">Páginas
                            </a>
                            <strong><span style="color: blue">
                                <asp:Label ID="lblTextoImage" runat="server" Text=""></asp:Label></span></strong>
                        </h4>
                    </div>
                    <div id="collapseThree" class="panel-collapse collapse">
                        <div class="panel-body">

                            <!-- Columna Modificar Texto Páginas -->
                            <div class="row">
                                <div class="col-md-6 pull-left">

                                    <ul class="list-group">
                                        <li class="list-group-item">
                                            <h4><span class="glyphicon glyphicon-list-alt"></span>Modificar Texto De Página</h4>
                                        </li>
                                        <li class="list-group-item">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <h4><span class="glyphicon glyphicon-file"></span>Página: </h4>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="dlPaginasTxt" runat="server" CssClass="form-control gris" OnSelectedIndexChanged="paginas_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" Text="* Se requiere de una página." ControlToValidate="dlPaginasTxt" InitialValue="---Página---" ValidationGroup="newText" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </li>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <li class="list-group-item">
                                                    <h4><span class="glyphicon glyphicon-edit"></span>
                                                        <asp:Label ID="lblAct1" runat="server" Text="Editar texto:"></asp:Label></h4>
                                                    <asp:TextBox ID="txtNuevo1" runat="server" CssClass="form-control gris" TextMode="MultiLine" Rows="5" Enabled="false"></asp:TextBox>
                                                </li>
                                                <li class="list-group-item">
                                                    <h4><span class="glyphicon glyphicon-edit"></span>
                                                        <asp:Label ID="lblAct2" runat="server" Text="Editar texto:" Visible="false"></asp:Label></h4>
                                                    <asp:TextBox ID="txtNuevo2" runat="server" CssClass="form-control gris" TextMode="MultiLine" Rows="3" Visible="false"></asp:TextBox>
                                                </li>
                                                <li class="list-group-item">
                                                    <h4><span class="glyphicon glyphicon-edit"></span>
                                                        <asp:Label ID="lblAct3" runat="server" Text="Editar texto:" Visible="false"></asp:Label></h4>
                                                    <asp:TextBox ID="txtNuevo3" runat="server" CssClass="form-control gris" TextMode="MultiLine" Rows="3" Visible="false"></asp:TextBox>
                                                </li>
                                                <li class="list-group-item">
                                                    <h4><span class="glyphicon glyphicon-edit"></span>
                                                        <asp:Label ID="lblAct4" runat="server" Text="Editar texto:" Visible="false"></asp:Label></h4>
                                                    <asp:TextBox ID="txtNuevo4" runat="server" CssClass="form-control gris" TextMode="MultiLine" Rows="3" Visible="false"></asp:TextBox>
                                                </li>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="dlPaginasTxt" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <li class="list-group-item">
                                            <asp:Button ID="btnActTexto" runat="server" Text="Actualizar Texto" class="btn btn-primary" ValidationGroup="newText" CausesValidation="true" OnClick="btnActTexto_Click" />
                                        </li>
                                    </ul>

                                </div>
                                <!-- Termina Columna Modificar Texto Páginas -->

                                <!-- Columna Cambiar Imagenes Páginas -->
                                <div class="col-md-6">

                                    <ul class="list-group">

                                        <!-- Subir Imagen Para Página -->
                                        <li class="list-group-item">
                                            <h4><span class="glyphicon glyphicon-open"></span>Subir Nueva Imagen</h4>
                                        </li>
                                        <li class="list-group-item">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <h4><span class="glyphicon glyphicon-picture"></span>Imagen: </h4>
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:FileUpload ID="upImgPag" runat="server" CssClass="btn btn-default" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="* Seleccione una imagen." ControlToValidate="upImgPag" ValidationGroup="newImg" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="list-group-item">
                                            <asp:Button ID="btnSubirImg" runat="server" Text="Subir Imagen" class="btn btn-primary" Width="150px" ValidationGroup="newImg" CausesValidation="true" OnClick="btnSubirImg_Click" />
                                        </li>
                                        <!-- Termina Subir Imagen Para Página -->

                                        <!-- Selección Imagenes Para Página -->
                                        <li class="list-group-item">
                                            <h4><span class="glyphicon glyphicon-open"></span>Cambiar Imagen De Página</h4>
                                        </li>
                                        <li class="list-group-item">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <h4><span class="glyphicon glyphicon-file"></span>Página: </h4>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="dlPaginasImg" runat="server" CssClass="form-control gris" OnSelectedIndexChanged="paginasImg_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" Text="* Se requiere de una página." ControlToValidate="dlPaginasImg" InitialValue="---Página---" ValidationGroup="updateImg" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </li>
                                        <asp:UpdatePanel ID="updateImages" runat="server">
                                            <ContentTemplate>
                                                <li class="list-group-item">
                                                    <div class="row">
                                                        <div class="col-md-5">
                                                            <asp:Button ID="btnSelectImg1" runat="server" Text="Seleccionar Imagen" class="btn btn-primary" Width="150px" OnClick="selectImg1_Click" Enabled="false" />
                                                        </div>
                                                        <div class="col-md-7">
                                                            <strong><span style="color: blue">
                                                                <asp:Label ID="lblImage1" runat="server" Text=""></asp:Label></span></strong>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="list-group-item">
                                                    <div class="row">
                                                        <div class="col-md-5">
                                                            <asp:Button ID="btnSelectImg2" runat="server" Text="Seleccionar Imagen" class="btn btn-primary" Width="150px" OnClick="selectImg2_Click" Enabled="false" />
                                                        </div>
                                                        <div class="col-md-7">
                                                            <strong><span style="color: blue">
                                                                <asp:Label ID="lblImage2" runat="server" Text=""></asp:Label></span></strong>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="list-group-item">
                                                    <div class="row">
                                                        <div class="col-md-5">
                                                            <asp:Button ID="btnSelectImg3" runat="server" Text="Seleccionar Imagen" class="btn btn-primary" Width="150px" OnClick="selectImg3_Click" Enabled="false" />
                                                        </div>
                                                        <div class="col-md-7">
                                                            <strong><span style="color: blue">
                                                                <asp:Label ID="lblImage3" runat="server" Text=""></asp:Label></span></strong>
                                                        </div>
                                                    </div>
                                                </li>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="dlPaginasImg" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="ItemCommand" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <li class="list-group-item">
                                            <asp:Button ID="btnActImg" runat="server" Text="Actualizar Imagen" class="btn btn-primary" Width="150px" ValidationGroup="updateImg" CausesValidation="true" OnClick="btnActImg_Click" />
                                        </li>
                                    </ul>
                                    <!-- Termina Selección Imagenes Para Página -->

                                </div>
                                <!-- Termina Columna Cambiar Imagenes Páginas -->

                            </div>
                            <!-- Termina Columnas -->

                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseFour">Preguntas Frecuentes
                            </a>
                            <strong><span style="color: blue">
                                <asp:Label ID="lblPregunta" runat="server" Text=""></asp:Label></span></strong>
                        </h4>
                    </div>
                    <div id="collapseFour" class="panel-collapse collapse">
                        <div class="panel-body">

                            <!-- Columna Agregar Pregunta -->
                            <div class="row">
                                <div class="col-md-6">

                                    <ul class="list-group">
                                        <li class="list-group-item">
                                            <h4><span class="glyphicon glyphicon-list-alt"></span>Agregar Pregunta</h4>
                                        </li>
                                        <li class="list-group-item">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <h4><span class="glyphicon glyphicon-pencil"></span>Pregunta: </h4>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtPregunta" runat="server" CssClass="form-control gris" placeholder="Ingrese pregunta"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Text="* Se requiere de una pregunta." ControlToValidate="txtPregunta" ValidationGroup="newQuestion" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="list-group-item">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <h4><span class="glyphicon glyphicon-pencil"></span>Respuesta: </h4>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtRespuesta" runat="server" CssClass="form-control gris" placeholder="Ingrese respuesta"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Text="* Se requiere de una respuesta." ControlToValidate="txtRespuesta" ValidationGroup="newQuestion" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="list-group-item">
                                            <asp:Button ID="btnAgrePreg" runat="server" Text="Agregar Pregunta" class="btn btn-primary" ValidationGroup="newQuestion" CausesValidation="true" OnClick="btnAgrePreg_Click" />
                                        </li>
                                    </ul>

                                </div>
                                <!-- Termina Columna Agregar Pregunta -->

                                <!-- Columna Remover Pregunta -->
                                <div class="col-md-6">

                                    <ul class="list-group">
                                        <li class="list-group-item">
                                            <h4><span class="glyphicon glyphicon-list-alt"></span>Remover Pregunta</h4>
                                        </li>
                                        <li class="list-group-item">
                                            <asp:DropDownList ID="ddlPreguntas" runat="server" CssClass="form-control gris"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Text="* Seleccione una pregunta." ControlToValidate="ddlPreguntas" ValidationGroup="removeQuestion" InitialValue="---Preguntas---" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </li>
                                        <li class="list-group-item">
                                            <asp:Button ID="btnRemPreg" runat="server" Text="Remover Pregunta" class="btn btn-primary" ValidationGroup="removeQuestion" CausesValidation="true" OnClick="btnRemPreg_Click" PostBackUrl="#" />
                                            <asp:Label ID="lblRemPreg" runat="server" Text=""></asp:Label>
                                        </li>
                                    </ul>
                                    <!-- Termina Columna Remover Pregunta -->

                                </div>
                                <!-- Termina Columnas -->
                            </div>

                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseFive">Galería Cursos y Olimpiadas</a>
                            <strong><span style="color: blue">
                                <asp:Label ID="lblTextoGaleria" runat="server" Text=""></asp:Label></span></strong>
                        </h4>
                    </div>
                    <div id="collapseFive" class="panel-collapse collapse">
                        <div class="panel-body">

                            <!-- Columnas -->
                            <div class="row">

                                <!-- Columna Subir Imagen A Galeria -->
                                <div class="col-md-6">
                                    <ul class="group-list">

                                        <li class="list-group-item">
                                            <h4><span class="glyphicon glyphicon-open"></span>Subir Nueva Imagen A Galería</h4>
                                        </li>
                                        <li class="list-group-item">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <h4><span class="glyphicon glyphicon-book"></span>Categoría: </h4>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlGaleria" runat="server" CssClass="form-control gris">
                                                        <asp:ListItem>---Galer&#237;a---</asp:ListItem>
                                                        <asp:ListItem>M&#225;quinas Simples</asp:ListItem>
                                                        <asp:ListItem>WeDo</asp:ListItem>
                                                        <asp:ListItem>Mindstorm</asp:ListItem>
                                                        <asp:ListItem>Olimpiadas</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Text="* Se requiere de una galería." ControlToValidate="ddlGaleria" InitialValue="---Galería---" ValidationGroup="newImgGaleria" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="list-group-item">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <h4><span class="glyphicon glyphicon-picture"></span>Imagen: </h4>
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:FileUpload ID="upImgGaleria" runat="server" CssClass="btn btn-default" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Text="* Seleccione una imagen." ControlToValidate="upImgGaleria" ValidationGroup="newImgGaleria" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="list-group-item">
                                            <asp:Button ID="btnGaleria" runat="server" Text="Subir Imagen" class="btn btn-primary" Width="150px" ValidationGroup="newImgGaleria" CausesValidation="true" OnClick="btnGaleria_Click" />
                                        </li>

                                    </ul>
                                </div>
                                <!-- Columna Subir Imagen A Galeria -->

                            </div>
                            <!-- Terminan Columnas -->

                        </div>
                    </div>
                </div>

            </div>

            <!-- Modal Seleccion Imagen -->
            <div class="modal fade" id="modalImagenes" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg" style="width: 80%">
                    <div class="modal-content">

                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4>Seleccione una imagen</h4>
                        </div>

                        <div class="modal-body">
                            <div class="row">
                                <asp:DataList ID="DataList1" runat="server" DataKeyField="nombreContMedia" DataSourceID="Galeria" RepeatColumns="3" CellPadding="10" OnItemCommand="Galeria_ItemCommand">
                                    <ItemTemplate>
                                        <image src='<%# Eval("URL") %>' runat="server" style="width: 70%; height: 350px" class="thumbnail" />
                                        <h3>
                                            <asp:LinkButton ID="lknImage" Text='<%# Eval("nombreContMedia") %>' runat="server" /></h3>
                                        </br>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                            <asp:SqlDataSource runat="server" ID="Galeria" ConnectionString='<%$ ConnectionStrings:LEGOConnectionString %>' SelectCommand="SELECT [nombreContMedia], [URL], [id_categoria] FROM [contenidoMedia] WHERE ([id_categoria] = @id_categoria)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="4" Name="id_categoria" Type="Int32"></asp:Parameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>

                        <div class="modal-footer">
                            <input id="hiddentest" type="hidden" runat="server" />
                            <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                        </div>

                    </div>
                </div>
            </div>
            <!-- Termina Modal Seleccion Imagen -->

            <!-- Mensaje Producto Agregado/Removido/UpdateTexto Correctamente -->
            <div id="agregadoSi" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="false">
                <div class="modal-dialog">

                    <div class="alert alert-success alert-dismissable" style="max-width: 1000px; box-shadow: 0px 10px 7px #021f10;">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="false">&times;</button>
                        <h3>
                            <asp:Label ID="procesadoSi" runat="server" Text=""></asp:Label>
                        </h3>
                    </div>

                </div>
            </div>
            <!-- Terminado Mensaje Producto Agregado/Removido/UpdateTexto Correctamente -->

            <!-- Mensaje Producto NO Agregado/Removido/FormatoImagen Correctamente -->
            <div id="agregadoNo" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="false">
                <div class="modal-dialog">

                    <div class="alert alert-success alert-dismissable" style="max-width: 1000px; box-shadow: 0px 10px 7px #021f10;">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="false">&times;</button>
                        <h3>
                            <asp:Label ID="falloAgregar" runat="server" Text=""></asp:Label>
                        </h3>
                    </div>

                </div>
            </div>
            <!-- Terminado Mensaje Producto NO Agregado/Removido/FormatoImagen Correctamente -->

            <% String pop = "";
               if (Request["Action"] != null)
               {
                   switch (Request["Action"])
                   {
                       case "nuevaImg":
                       case "existeGal":
                       case "errorForm":
                           pop = "collapseFive";
                           break;
                       case "remQuestion":
                       case "addQuestion":
                           pop = "collapseFour";
                           break;
                       case "updateText":
                       case "addImg":
                       case "updatedImg":
                       case "incorrectoForm":
                       case "existe":
                           pop = "collapseThree";
                           break;
                       case "add":
                       case "remove":
                       case "incorrecto":
                           pop = "collapseTwo";
                           break;

                       //faltan los case para inicio!
                   }
               } %>

            <script type="text/javascript">

                //automaticamente se abre el ultimo panel con el que se interactuo
                $('#<%= pop %>').attr('class', 'panel-collapse collapse in');


                function agregadoS() {
                    $('#agregadoSi').modal('show');
                }
                function agregadoN() {
                    $('#agregadoNo').modal('show');
                }

                function showM(_id) {
                    var id = _id;
                    var hiddentest = '';
                    document.getElementById('<%= hiddentest.ClientID%>').value = id;
                    $('#modalImagenes').modal('show');
                }

                function closeM() {
                    $('#modalImagenes').modal('hide');
                }

            </script>

        </div>
        <!-- termina version de compu -->
    </div>
</asp:Content>
