using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MailChimp.Types;
using MailChimp;
using LEGO_Test.Clases;

namespace LEGO_Test
{
    public partial class _Default : Page
    {
        string[] filePaths;
        Conexion con = Conexion.getConexion();
        protected void Page_Load(object sender, EventArgs e)
        {

            //throw new InvalidOperationException("An InvalidOperationException " +
            //"occurred in the Page_Load handler on the Default.aspx page.");
            if (!Page.IsPostBack)
            {
                crearSlideshow();
            }
           // cargarImagenes();
            //cargarTextos();
        }

        protected void cargarImagenes() { 
            String url = con.getImagenEstatica(1,1);
            //imgProductos.Text = "<img class=\"foto-inicio hidden-sm hidden-xs\" src=\"" + url + "\" alt=\"\" />";

            url = con.getImagenEstatica(1, 2);
            //imgCursos.Text = "<img class=\"foto-inicio hidden-sm hidden-xs\" src=\"" + url + "\" alt=\"\" />";

            url = con.getImagenEstatica(1, 3);
           // imgOlimpiadas.Text = "<img class=\"foto-inicio hidden-sm hidden-xs\" src=\"" + url + "\" alt=\"\" />";
        }

        protected void cargarTextos() {
            //txtProductos.Text = con.getTextoPagina(1,1);
            //txtCursos.Text = con.getTextoPagina(1, 2);
            //txtOlimpiadas.Text = con.getTextoPagina(1,3);
            //txtSuscripcionCorreo.Text = con.getTextoPagina(1, 4);
        }

        /** crea el slideshow agarrando las fotos que estan en la carpeta de Images/Slideshow/Pprincipal */
        protected void crearSlideshow()
        {

            filePaths = Directory.GetFiles(Server.MapPath("~/Images/Slideshow/Pprincipal"));
            String active = "active";
            String codSlide = "";
            String codIndicator = "";
            int cont = 0;
            for (int i = 0; i < filePaths.Length; i++)
            {

                /* para agregar captions a la imagen nadmas hay que agregar lo sieguiente despues de 
                 * la declaracion de la imagen
                 * 
                 *    + " <div class=\"carousel-caption\">"
                 * + "   <h3>Primer Slide</h3>"
                 * + "   <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>"
                 * + " </div>"
                 * 
                 */
                codSlide += ""
                    + " <div class=\"item " + active + "\">"
                + " <img src=\"Images/Slideshow/Pprincipal/" + Path.GetFileName(filePaths[i]) + "\"  alt=\"\" style=\"width: 100%; height: 100%;\">"
                + " </div>";

                codIndicator += "<li data-target=\"#carousel-g\" data-slide-to=\"" + cont + "\" class=\"" + active + "\"></li>";
                cont++;
                active = "";
            }

            txtIndicator.Text = codIndicator;
            txtSlides.Text = codSlide;

        }


        protected void btnSuscribir_Click(object sender, EventArgs e)
        {
            String resultado = "";
            try
            {

                const string apiKey = "a3bcf72bb39572c06e9d2a3747cd8eaa-us3";   // Replace it before
                const string listId = "41afc6c854";                      // Replace it before

                var options = new List.SubscribeOptions();
                options.DoubleOptIn = true;
                options.EmailType = List.EmailType.Html;
                options.SendWelcome = false;

                var mergeText = new List.Merges(txtSuscribir.Text, List.EmailType.Text);
                var merges = new List<List.Merges> { mergeText };

                var mcApi = new MCApi(apiKey, false);
                var batchSubscribe = mcApi.ListBatchSubscribe(listId, merges, options);


                if (batchSubscribe.Errors.Count > 0)
                {
                    resultado = "?ress=error";
                    System.Diagnostics.Debug.WriteLine("Error:{0}", batchSubscribe.Errors[0].Message);
                }
                else
                {
                    resultado = "?ress=succ";
                    System.Diagnostics.Debug.WriteLine("Success");
                }



            }
            catch (MailChimp.Types.MCException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                Response.Redirect("Default.aspx" + resultado);
            }
        }
        private void Page_Error(object sender, EventArgs e)
        {
            // Get last error from the server.
            Exception exc = Server.GetLastError();

            // Handle specific exception.
            if (exc is InvalidOperationException)
            {
                // Pass the error on to the error page.
                Server.Transfer("ErrorPage.aspx?handler=Page_Error%20-%20Default.aspx",
                    true);
            }
        }

    }
}