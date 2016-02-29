using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using LEGO_Test.Clases;
using System.Data;
using System.Text.RegularExpressions;

namespace LEGO_Test.Admin
{
    public partial class PaginaAdmin : System.Web.UI.Page
    {
        Conexion con = Conexion.getConexion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (((Usuario)Session["usuario"]).getPermiso() != "admin")
            {
                Response.Redirect("~/Default.aspx");
            }
            desplegarCategorias();
            desplegarPaginas();
            desplegarPreguntas();

            string productAction = Request.QueryString["Action"];
            if (productAction == "add")
            {
                lblProducto.Text = "   - Se ha agregado el nuevo producto correctamente";
                lblTextoImage.Text = "";
                lblPregunta.Text = "";
            }

            if (productAction == "remove")
            {
                lblProducto.Text = "   - El producto se ha eliminado correctamente";
                lblTextoImage.Text = "";
                lblPregunta.Text = "";
                lblTextoGaleria.Text = "";
            }

            if (productAction == "updateText")
            {
                lblTextoImage.Text = "   - Se ha actualizado el texto correctamente";
                lblPregunta.Text = "";
                lblProducto.Text = "";
                lblTextoGaleria.Text = "";
            }

            if (productAction == "addImg")
            {
                lblTextoImage.Text = "   - Se ha agregado la imagen correctamente";
                lblPregunta.Text = "";
                lblProducto.Text = "";
                lblTextoGaleria.Text = "";
            }

            if (productAction == "addQuestion")
            {
                lblPregunta.Text = "   - Se ha agregado la nueva pregunta correctamente";
                lblProducto.Text = "";
                lblTextoImage.Text = "";
                lblTextoGaleria.Text = "";
            }

            if (productAction == "remQuestion")
            {
                lblPregunta.Text = "   - La pregunta se ha eliminado correctamente";
                lblProducto.Text = "";
                lblTextoImage.Text = "";
                lblTextoGaleria.Text = "";
            }

            if (productAction == "incorrecto")
            {
                lblPregunta.Text = "";
                lblProducto.Text = "  - El formato de la imagen no es permitido";
                lblTextoImage.Text = "";
                lblTextoGaleria.Text = "";
            }

            if (productAction == "incorrectoForm")
            {
                lblPregunta.Text = "";
                lblProducto.Text = "";
                lblTextoImage.Text = "  - El formato de la imagen no es permitido";
                lblTextoGaleria.Text = "";
            }

            if (productAction == "updatedImg")
            {
                lblPregunta.Text = "";
                lblProducto.Text = "";
                lblTextoImage.Text = "  - Se han actualizado las imágenes correctamente";
                lblTextoGaleria.Text = "";
            }

            if (productAction == "existe")
            {
                lblPregunta.Text = "";
                lblProducto.Text = "";
                lblTextoImage.Text = "  - La imagen ya existe, seleccione una nueva imagen";
                lblTextoGaleria.Text = "";
            }

            if (productAction == "nuevaImg")
            {
                lblPregunta.Text = "";
                lblProducto.Text = "";
                lblTextoImage.Text = "";
                lblTextoGaleria.Text = "  - Se ha agregado la imagen correctamente";
            }

            if (productAction == "existeGal")
            {
                lblPregunta.Text = "";
                lblProducto.Text = "";
                lblTextoImage.Text = "";
                lblTextoGaleria.Text = "  - La imagen ya existe, seleccione una nueva imagen";
            }

            if (productAction == "errorForm")
            {
                lblPregunta.Text = "";
                lblProducto.Text = "";
                lblTextoImage.Text = "";
                lblTextoGaleria.Text = "  - El formato de la imagen no es permitido";
            }
        }

        protected void desplegarCategorias()
        {
            String slcCmd = "SELECT descripcion FROM tipoProducto";
            SqlCommand ls = new SqlCommand(slcCmd, con.getSQLCon());

            if (con.getSQLCon().State == ConnectionState.Closed)
            {
                con.getSQLCon().Open();
            }
            SqlDataReader dr = ls.ExecuteReader();
            while (dr.Read())
            {
                String nombre = dr["descripcion"].ToString();
                categorias.Items.Add(nombre);
                categoriasRemover.Items.Add(nombre);
            }
            dr.Close();
            con.getSQLCon().Close();

            categorias.Items.Insert(0, new ListItem("---Categoría---", "---Categoría---"));
            categoriasRemover.Items.Insert(0, new ListItem("---Categoría---", "---Categoría---"));
        }

        protected void categoriasRemover_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoria = 0;

            if (categoriasRemover.SelectedItem.ToString().Equals("Máquinas Simples"))
                categoria = 1;
            else if (categoriasRemover.SelectedItem.ToString().Equals("WeDo"))
                categoria = 2;
            else if (categoriasRemover.SelectedItem.ToString().Equals("MindStorm"))
                categoria = 3;

            producto.Items.Clear();

            String slcCmd = "SELECT nombreProducto FROM Producto WHERE id_categoria=" + categoria + "";
            SqlCommand ls = new SqlCommand(slcCmd, con.getSQLCon());

            con.getSQLCon().Open();
            SqlDataReader dr = ls.ExecuteReader();
            while (dr.Read())
            {
                String nomProducto = dr["nombreProducto"].ToString();
                producto.Items.Add(nomProducto);
            }
            dr.Close();
            con.getSQLCon().Close();

            producto.Items.Insert(0, new ListItem("---Producto---", "---Producto---"));
        }

        protected void desplegarPaginas()
        {
            String slcCmd = "SELECT descripcion FROM pagina";
            SqlCommand ls = new SqlCommand(slcCmd, con.getSQLCon());

            con.getSQLCon().Open();
            SqlDataReader dr = ls.ExecuteReader();
            while (dr.Read())
            {
                String nombre = dr["descripcion"].ToString();
                dlPaginasTxt.Items.Add(nombre);
                dlPaginasImg.Items.Add(nombre);
            }
            dr.Close();
            con.getSQLCon().Close();

            dlPaginasTxt.Items.Insert(0, new ListItem("---Página---", "---Página---"));
            dlPaginasImg.Items.Insert(0, new ListItem("---Página---", "---Página---"));
        }

        protected void textoLabels(int idPagina)
        {
            switch (idPagina)
            {
                case 1:
                    lblAct2.Visible = true;
                    lblAct3.Visible = true;
                    lblAct4.Visible = true;
                    lblAct1.Text = "Editar texto Productos:";
                    lblAct2.Text = "Editar texto Cursos:";
                    lblAct3.Text = "Editar texto Olimpiadas:";
                    lblAct4.Text = "Editar texto Suscripción:";
                    txtNuevo1.Enabled = true;
                    txtNuevo2.Visible = true;
                    txtNuevo3.Visible = true;
                    txtNuevo4.Visible = true;
                    break;
                case 2:
                    lblAct2.Visible = false;
                    lblAct3.Visible = false;
                    lblAct4.Visible = false;
                    lblAct1.Text = "Editar texto curso Máquinas Simples:";
                    txtNuevo1.Enabled = true;
                    txtNuevo2.Visible = false;
                    txtNuevo3.Visible = false;
                    txtNuevo4.Visible = false;
                    break;
                case 3:
                    lblAct2.Visible = false;
                    lblAct3.Visible = false;
                    lblAct4.Visible = false;
                    lblAct1.Text = "Editar texto curso WeDo:";
                    txtNuevo1.Enabled = true;
                    txtNuevo2.Visible = false;
                    txtNuevo3.Visible = false;
                    txtNuevo4.Visible = false;
                    break;
                case 4:
                    lblAct2.Visible = false;
                    lblAct3.Visible = false;
                    lblAct4.Visible = false;
                    lblAct1.Text = "Editar texto curso Mindstorm:";
                    txtNuevo1.Enabled = true;
                    txtNuevo2.Visible = false;
                    txtNuevo3.Visible = false;
                    txtNuevo4.Visible = false;
                    break;
                case 5:
                    lblAct2.Visible = false;
                    lblAct3.Visible = false;
                    lblAct4.Visible = false;
                    lblAct1.Text = "Editar texto Olimpiadas:";
                    txtNuevo1.Enabled = true;
                    txtNuevo2.Visible = false;
                    txtNuevo3.Visible = false;
                    txtNuevo4.Visible = false;
                    break;
                case 8:
                    lblAct2.Visible = true;
                    lblAct3.Visible = true;
                    lblAct4.Visible = false;
                    lblAct1.Text = "Editar texto Dirección:";
                    lblAct2.Text = "Editar texto Teléfono:";
                    lblAct3.Text = "Editar texto Email:";
                    txtNuevo1.Enabled = true;
                    txtNuevo2.Visible = true;
                    txtNuevo3.Visible = true;
                    txtNuevo4.Visible = false;
                    break;
                case 9:
                    lblAct2.Visible = true;
                    lblAct3.Visible = true;
                    lblAct4.Visible = false;
                    lblAct1.Text = "Editar texto curso Máquinas Simples:";
                    lblAct2.Text = "Editar texto curso WeDo:";
                    lblAct3.Text = "Editar texto curso Mindstorm:";
                    txtNuevo1.Enabled = true;
                    txtNuevo2.Visible = true;
                    txtNuevo3.Visible = true;
                    txtNuevo4.Visible = false;
                    break;
                default:
                    lblAct2.Visible = false;
                    lblAct3.Visible = false;
                    lblAct4.Visible = false;
                    lblAct1.Text = "Editar texto:";
                    txtNuevo1.Text = "";
                    txtNuevo1.Enabled = false;
                    txtNuevo2.Visible = false;
                    txtNuevo3.Visible = false;
                    txtNuevo4.Visible = false;
                    break;
            }
        }

        protected void paginas_SelectedIndexChanged(object sender, EventArgs e)
        {
            textoLabels(paginaSeleccionada(dlPaginasTxt.SelectedItem.ToString()));

            String slcCmd = "SELECT texto, id_texto FROM texto WHERE id_pagina=" + paginaSeleccionada(dlPaginasTxt.SelectedItem.ToString()) + "";
            SqlCommand ls = new SqlCommand(slcCmd, con.getSQLCon());

            con.getSQLCon().Open();
            SqlDataReader dr = ls.ExecuteReader();
            while (dr.Read())
            {
                String idTexto = dr["id_texto"].ToString();
                String texto = dr["texto"].ToString();

                switch (idTexto)
                {
                    case "1":
                        txtNuevo1.Text = texto;
                        break;
                    case "2":
                        txtNuevo2.Text = texto;
                        break;
                    case "3":
                        txtNuevo3.Text = texto;
                        break;
                    case "4":
                        txtNuevo4.Text = texto;
                        break;
                }
            }

            dr.Close();
            con.getSQLCon().Close();
        }

        public void agregarProducto(String filename)
        {
            int categoria = 0;

            if (categorias.SelectedItem.ToString().Equals("Máquinas Simples"))
                categoria = 1;
            else if (categorias.SelectedItem.ToString().Equals("WeDo"))
                categoria = 2;
            else
                categoria = 3;

            con.getSQLCon().Open();

            String agregar = "INSERT INTO Producto VALUES(@id_categoria,@nombreContMedia,@nombreProducto,@descripcion,@precioUnitario)";
            SqlCommand ls = new SqlCommand(agregar, con.getSQLCon());

            ls.Parameters.AddWithValue("id_categoria", categoria);
            ls.Parameters.AddWithValue("nombreContMedia", filename);
            ls.Parameters.AddWithValue("nombreProducto", txtnombre.Text);
            ls.Parameters.AddWithValue("descripcion", txtdescripcion.Text);
            ls.Parameters.AddWithValue("precioUnitario", txtprecio.Text);

            ls.ExecuteNonQuery();

            con.getSQLCon().Close();
        }

        public bool agregarImagen(String filename)
        {
            String img = "Images/GraficosPagina/" + filename;

            SqlCommand cmd = new SqlCommand("select * FROM contenidoMedia WHERE nombreContMedia=@nombreContMedia", con.getSQLCon());
            cmd.Parameters.AddWithValue("@nombreContMedia", filename);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                String agregar = "INSERT INTO contenidoMedia VALUES(@nombreContMedia,@id_categoria,@URL)";
                SqlCommand ls = new SqlCommand(agregar, con.getSQLCon());

                con.getSQLCon().Open();

                ls.Parameters.AddWithValue("nombreContMedia", filename);
                ls.Parameters.AddWithValue("id_categoria", 1);
                ls.Parameters.AddWithValue("URL", img);

                ls.ExecuteNonQuery();
            }

            con.getSQLCon().Close();
            return true;
        }

        public bool verificarImagen(bool hasFile, String name)
        {
            Boolean fileOK = false;
            if (hasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(name).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }
            return fileOK;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            String filename = "";
            String path = Server.MapPath("~/Images/GraficosPagina/");

            if (verificarImagen(upImage.HasFile, upImage.FileName))
            {
                try
                {
                    // Save to Images folder.
                    upImage.PostedFile.SaveAs(path + upImage.FileName);
                    filename = upImage.FileName;
                    // Save to Images/Thumbs folder.
                    //upImage.PostedFile.SaveAs(path + "Thumbs/" + upImage.FileName);
                }
                catch (Exception ex)
                {
                    falloAgregar.Text = ex.Message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString("N"), "agregadoN();", true);
                }

                // Add product data to DB.
                bool addSuccess = agregarImagen(filename);

                if (addSuccess)
                {
                    // Reload the page.
                    agregarProducto(filename);
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Action=add");
                }
                else
                {
                    falloAgregar.Text = "No se ha agregado el nuevo producto.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString("N"), "agregadoN();", true);
                }
            }
            else
            {
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=incorrecto");
            }
        }

        public void updateTexto(String texto, int idpagina, int idTexto)
        {
            String update = "UPDATE texto SET texto='" + texto + "'WHERE id_pagina=" + idpagina + " and id_texto=" + idTexto + "";
            SqlCommand ls = new SqlCommand(update, con.getSQLCon());

            con.getSQLCon().Open();
            ls.ExecuteNonQuery();
            con.getSQLCon().Close();
        }

        protected int paginaSeleccionada(String paginaSelect)
        {
            int idpagina = 0;
            if (paginaSelect.Equals("Principal"))
            {
                idpagina = 1;
            }
            else if (paginaSelect.Equals("Máquinas Simples"))
            {
                idpagina = 2;
            }
            else if (paginaSelect.Equals("WeDo"))
            {
                idpagina = 3;
            }
            else if (paginaSelect.Equals("MindStorm"))
            {
                idpagina = 4;
            }
            else if (paginaSelect.Equals("Olimpiadas"))
            {
                idpagina = 5;
            }
            else if (paginaSelect.Equals("Contactos"))
            {
                idpagina = 8;
            }
            else if (paginaSelect.Equals("Cursos"))
            {
                idpagina = 9;
            }
            else
            {
                idpagina = 0;
            }
            return idpagina;
        }

        protected void btnActTexto_Click(object sender, EventArgs e)
        {
            int idPagina = paginaSeleccionada(dlPaginasTxt.SelectedItem.ToString());
            if (idPagina == 1)
            {
                updateTexto(txtNuevo1.Text, idPagina, 1);
                updateTexto(txtNuevo2.Text, idPagina, 2);
                updateTexto(txtNuevo3.Text, idPagina, 3);
                updateTexto(txtNuevo4.Text, idPagina, 4);
            }
            else if (idPagina == 9 || idPagina == 8)
            {
                updateTexto(txtNuevo1.Text, idPagina, 1);
                updateTexto(txtNuevo2.Text, idPagina, 2);
                updateTexto(txtNuevo3.Text, idPagina, 3);
            }
            else
            {
                updateTexto(txtNuevo1.Text, idPagina, 1);
            }
            string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
            Response.Redirect(pageUrl + "?Action=updateText");
        }

        protected void eliminarProducto()
        {
            String delete = "DELETE FROM Producto WHERE nombreProducto='" + producto.SelectedItem.ToString() + "'";
            SqlCommand ls = new SqlCommand(delete, con.getSQLCon());

            con.getSQLCon().Open();
            ls.ExecuteNonQuery();
            con.getSQLCon().Close();
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            eliminarProducto();
            string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
            Response.Redirect(pageUrl + "?Action=remove");
        }

        protected void agregarPregunta()
        {
            con.getSQLCon().Open();

            String agregar = "INSERT INTO preguntas VALUES(@pregunta, @respuesta)";
            SqlCommand ls = new SqlCommand(agregar, con.getSQLCon());

            ls.Parameters.AddWithValue("pregunta", txtPregunta.Text);
            ls.Parameters.AddWithValue("respuesta", txtRespuesta.Text);

            ls.ExecuteNonQuery();

            con.getSQLCon().Close();
        }

        protected void btnAgrePreg_Click(object sender, EventArgs e)
        {
            agregarPregunta();
            string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
            Response.Redirect(pageUrl + "?Action=addQuestion");
        }

        protected void desplegarPreguntas()
        {
            String slcCmd = "SELECT pregunta FROM preguntas";
            SqlCommand ls = new SqlCommand(slcCmd, con.getSQLCon());

            con.getSQLCon().Open();
            SqlDataReader dr = ls.ExecuteReader();
            while (dr.Read())
            {
                String pregunta = dr["pregunta"].ToString();

                ddlPreguntas.Items.Add(pregunta);
            }
            dr.Close();
            con.getSQLCon().Close();

            ddlPreguntas.Items.Insert(0, new ListItem("---Preguntas---", "---Preguntas---"));
        }

        protected void removerPregunta()
        {
            String delete = "DELETE FROM preguntas WHERE pregunta='" + ddlPreguntas.SelectedItem.ToString() + "'";
            SqlCommand ls = new SqlCommand(delete, con.getSQLCon());
            con.getSQLCon().Open();
            ls.ExecuteNonQuery();
            con.getSQLCon().Close();
        }

        protected void btnRemPreg_Click(object sender, EventArgs e)
        {
            removerPregunta();
            string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
            Response.Redirect(pageUrl + "?Action=remQuestion");
        }

        protected bool agregarImgPagina(String filename)
        {
            String img = "Images/ImgsPaginas/" + filename;

            con.getSQLCon().Open();
            SqlCommand cmd = new SqlCommand("select * FROM contenidoMedia WHERE nombreContMedia=@nombreContMedia", con.getSQLCon());
            cmd.Parameters.AddWithValue("@nombreContMedia", filename);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                String agregar = "INSERT INTO contenidoMedia VALUES(@nombreContMedia,@id_categoria,@URL)";
                SqlCommand ls = new SqlCommand(agregar, con.getSQLCon());

                ls.Parameters.AddWithValue("nombreContMedia", filename);
                ls.Parameters.AddWithValue("id_categoria", 4);
                ls.Parameters.AddWithValue("URL", img);

                ls.ExecuteNonQuery();
                con.getSQLCon().Close();
                return true;
            }
            else
            {
                con.getSQLCon().Close();
                return false;
            }
        }

        protected void btnSubirImg_Click(object sender, EventArgs e)
        {
            String path = Server.MapPath("~/Images/ImgsPaginas/");

            if (verificarImagen(upImgPag.HasFile, upImgPag.FileName))
            {
                try
                {
                    // Save to Images folder.
                    upImgPag.PostedFile.SaveAs(path + upImgPag.FileName);
                }
                catch (Exception ex)
                {
                    lblTextoImage.Text = ex.Message;
                }

                // Add image to DB.
                bool img = agregarImgPagina(upImgPag.FileName);
                if (img)
                {
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Action=addImg");
                }
                else
                {
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Action=existe");
                }
            }
            else
            {
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=incorrectoForm");
            }
        }

        protected void updateImagenPag(int pagina, String nombContMed, int idCont)
        {
            String update = "UPDATE contenedores SET id_contenidoMedia='" + nombContMed + "'WHERE id_pagina=" + pagina + " and id_contenedores=" + idCont + "";
            SqlCommand ls = new SqlCommand(update, con.getSQLCon());

            con.getSQLCon().Open();
            ls.ExecuteNonQuery();
            con.getSQLCon().Close();
        }

        protected void paginasImg_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pagSelected = paginaSeleccionada(dlPaginasImg.SelectedItem.ToString());
            if (pagSelected == 0)
            {
                btnSelectImg1.Enabled = false;
                btnSelectImg2.Enabled = false;
                btnSelectImg3.Enabled = false;
                btnSelectImg1.Text = "Seleccionar Imagen";
                btnSelectImg2.Text = "Seleccionar Imagen";
                btnSelectImg3.Text = "Seleccionar Imagen";

            }
            else if (pagSelected == 1)
            {
                btnSelectImg1.Enabled = true;
                btnSelectImg2.Enabled = true;
                btnSelectImg3.Enabled = true;
                btnSelectImg1.Text = "Productos";
                btnSelectImg2.Text = "Cursos";
                btnSelectImg3.Text = "Olimpiadas";
            }
            else if (pagSelected == 9)
            {
                btnSelectImg1.Enabled = true;
                btnSelectImg2.Enabled = true;
                btnSelectImg3.Enabled = true;
                btnSelectImg1.Text = "Máquinas Simples";
                btnSelectImg2.Text = "WeDo";
                btnSelectImg3.Text = "Mindstormn";
            }
            else
            {
                btnSelectImg1.Enabled = true;
                btnSelectImg2.Enabled = true;
                btnSelectImg3.Enabled = false;
                btnSelectImg1.Text = "Principal";
                btnSelectImg2.Text = "Secundaria";
                btnSelectImg3.Text = "Seleccionar Imagen";
            }

            lblImage1.Text = "";
            lblImage2.Text = "";
            lblImage3.Text = "";
        }

        protected void Galeria_ItemCommand(object source, DataListCommandEventArgs e)
        {
            String id = hiddentest.Value;

            LinkButton Image = (LinkButton)e.Item.FindControl("lknImage");

            if (id.Equals("1"))
                lblImage1.Text = Image.Text;
            else if (id.Equals("2"))
                lblImage2.Text = Image.Text;
            else if (id.Equals("3"))
                lblImage3.Text = Image.Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString("N"), "closeM();", true);
        }

        protected void selectImg1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString("N"), "showM(1);", true);
        }

        protected void selectImg2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString("N"), "showM(2);", true);
        }

        protected void selectImg3_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString("N"), "showM(3);", true);
        }

        protected void btnActImg_Click(object sender, EventArgs e)
        {
            int idPagina = paginaSeleccionada(dlPaginasImg.SelectedItem.ToString());
            if (lblImage1.Text.Equals("") && lblImage2.Text.Equals("") && lblImage3.Text.Equals(""))
            {
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl);
            }
            else
            {
                if (idPagina == 1 || idPagina == 9)
                {
                    if (!lblImage1.Text.Equals("") && !lblImage2.Text.Equals("") && !lblImage3.Text.Equals(""))
                    {
                        updateImagenPag(idPagina, lblImage1.Text, 1);
                        updateImagenPag(idPagina, lblImage2.Text, 2);
                        updateImagenPag(idPagina, lblImage3.Text, 3);
                    }
                    else if (!lblImage1.Text.Equals("") && !lblImage2.Text.Equals("") && lblImage3.Text.Equals(""))
                    {
                        updateImagenPag(idPagina, lblImage1.Text, 1);
                        updateImagenPag(idPagina, lblImage2.Text, 2);
                    }
                    else if (!lblImage1.Text.Equals("") && lblImage2.Text.Equals("") && !lblImage3.Text.Equals(""))
                    {
                        updateImagenPag(idPagina, lblImage1.Text, 1);
                        updateImagenPag(idPagina, lblImage3.Text, 3);
                    }
                    else if (lblImage1.Text.Equals("") && !lblImage2.Text.Equals("") && !lblImage3.Text.Equals(""))
                    {
                        updateImagenPag(idPagina, lblImage2.Text, 2);
                        updateImagenPag(idPagina, lblImage3.Text, 3);
                    }
                    else if (!lblImage1.Text.Equals("") && lblImage2.Text.Equals("") && lblImage3.Text.Equals(""))
                    {
                        updateImagenPag(idPagina, lblImage1.Text, 1);
                    }
                    else if (lblImage1.Text.Equals("") && !lblImage2.Text.Equals("") && lblImage3.Text.Equals(""))
                    {
                        updateImagenPag(idPagina, lblImage2.Text, 2);
                    }
                    else if (lblImage1.Text.Equals("") && lblImage2.Text.Equals("") && !lblImage3.Text.Equals(""))
                    {
                        updateImagenPag(idPagina, lblImage3.Text, 3);
                    }
                }
                else
                {
                    if (!lblImage1.Text.Equals("") && !lblImage2.Text.Equals(""))
                    {
                        updateImagenPag(idPagina, lblImage1.Text, 1);
                        updateImagenPag(idPagina, lblImage2.Text, 2);
                    }
                    else if (!lblImage1.Text.Equals("") && lblImage2.Text.Equals(""))
                        updateImagenPag(idPagina, lblImage1.Text, 1);
                    else if (lblImage1.Text.Equals("") && !lblImage2.Text.Equals(""))
                        updateImagenPag(idPagina, lblImage2.Text, 2);
                }

                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=updatedImg");

            }
        }

        protected bool agregarImagenGaleria(String filename, int idCategoria)
        {
            String img = "Images/GraficosPagina/" + filename;

            SqlCommand cmd = new SqlCommand("select * FROM contenidoMedia WHERE nombreContMedia=@nombreContMedia", con.getSQLCon());
            cmd.Parameters.AddWithValue("@nombreContMedia", filename);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                String agregar = "INSERT INTO contenidoMedia VALUES(@nombreContMedia,@id_categoria,@URL)";
                SqlCommand ls = new SqlCommand(agregar, con.getSQLCon());

                con.getSQLCon().Open();

                ls.Parameters.AddWithValue("nombreContMedia", filename);
                ls.Parameters.AddWithValue("id_categoria", idCategoria);
                ls.Parameters.AddWithValue("URL", img);

                ls.ExecuteNonQuery();

                con.getSQLCon().Close();
                return true;
            }
            else
            {
                con.getSQLCon().Close();
                return false;
            }
        }

        protected void btnGaleria_Click(object sender, EventArgs e)
        {
            int idGaleria = 0;
            if (ddlGaleria.Text.Equals("Máquinas Simples"))
                idGaleria = 5;
            else if (ddlGaleria.Text.Equals("WeDo"))
                idGaleria = 6;
            else if (ddlGaleria.Text.Equals("Mindstorm"))
                idGaleria = 7;
            else if (ddlGaleria.Text.Equals("Olimpiadas"))
                idGaleria = 8;

            String path = Server.MapPath("~/Images/GraficosPagina/");

            if (verificarImagen(upImgGaleria.HasFile, upImgGaleria.FileName))
            {
                try
                {
                    // Save to Images folder.
                    upImgGaleria.PostedFile.SaveAs(path + upImgGaleria.FileName);
                }
                catch (Exception ex)
                {
                    lblTextoGaleria.Text = ex.Message;
                }

                // Add image to DB.
                bool img = agregarImagenGaleria(upImgGaleria.FileName, idGaleria);
                if (img)
                {
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Action=nuevaImg");
                }
                else
                {
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Action=existeGal");
                }
            }
            else
            {
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=errorForm");
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        ///Registrar administradores
        ///
        public string contrasenaAleatoria()
        {
            string contrasena = "";
            Random varRan = new Random();
            int num;
            char[] losChar = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            for (int i = 0; i < 7; i++)
            {
                num = varRan.Next(20);
                contrasena += losChar[num];
            }

            return contrasena;
        }
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (con.getSQLCon().State == System.Data.ConnectionState.Closed)
            {
                con.getSQLCon().Open();
            }
            if (txtCorreo.Text == "" || txtDireccion.Text == "" || txtNombreAd.Text == "" || txtNombreUs.Text == "" || txtNumeroTel.Text == "" || txtProvincia.SelectedItem.Text == "")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Debe completar todos los espacios')</script>");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * FROM usuario WHERE nombreUsuario = '" + txtNombreUs.Text + "';", con.getSQLCon());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {

                    if (email_bien_escrito(txtCorreo.Text) == true)
                    {
                        string contr = contrasenaAleatoria();
                        SqlCommand cmd1 = new SqlCommand("insert into usuario values ('" + txtNombreUs.Text + "', '" + contr + "', '" + txtCorreo.Text + "', '" + txtNombreAd.Text + "', '" + int.Parse(txtNumeroTel.Text) + "', '" + txtDireccion.Text + "', '" + txtProvincia.SelectedItem.Text + "', 'usuario');", con.getSQLCon());
                        cmd1.ExecuteNonQuery();
                        con.getSQLCon().Close();
                        EnviarCorreo(contr, txtCorreo.Text);
                        txtCorreo.Text = "";
                        txtNombreAd.Text = "";
                        txtNombreUs.Text = "";

                    }
                    else
                    {
                        if (email_bien_escrito(txtCorreo.Text) == false)
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('El correo está mal escrito')</script>");
                        }
                    }


                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('El nombre de usuario elegido ya se encuentra registrado, favor escoger otro')</script>");
                    txtCorreo.Text = "";
                    txtNombreUs.Text = "";
                    txtNumeroTel.Text = "";
                    txtDireccion.Text = "";
                    txtProvincia.SelectedValue = "";
                }

            }
            con.getSQLCon().Close();
        }
        public void EnviarCorreo(string contrasena, string correo)
        {
            /*Creamos el objeto para el mensaje*/
            System.Net.Mail.MailMessage Correo = new System.Net.Mail.MailMessage();
            /*La cuenta de correo al que se la vamos a enviar*/
            Correo.To.Add(correo);

            /*Asunto del correo*/
            Correo.Subject = "Contraseña para afiliarse a lego education";
            Correo.SubjectEncoding = System.Text.Encoding.UTF8;

            //Cuerpo del Mensaje
            Correo.Body = "Buenas su contraseña para ingresar al sitio es '" + contrasena + "'. Una ves ingresado al sitio podra cambiarla libremente.";
            Correo.BodyEncoding = System.Text.Encoding.UTF8;
            Correo.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            Correo.From = new System.Net.Mail.MailAddress("proyecto.componentes@gmail.com");

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("cuentasaprenderhaciendo@gmail.com", "Gordo123");

            cliente.Port = 587;
            cliente.EnableSsl = true;

            cliente.Host = "smtp.gmail.com";

            try
            {
                //Enviamos el mensaje      
                cliente.Send(Correo);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('El correo ingresado no es valido, por favor ingresar otro')</script>");
                txtCorreo.Text = "";
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Administrador registrado con éxito')</script>");
            // Response.Redirect("Login.aspx");

        }



        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}