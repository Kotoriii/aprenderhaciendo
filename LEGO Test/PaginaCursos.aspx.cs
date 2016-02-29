using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using LEGO_Test.Clases;

namespace LEGO_Test
{
    public partial class PaginaCursos : System.Web.UI.Page
    {
        Conexion con = Conexion.getConexion();
        int pagina = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //Es importante que estos metodos vaya en este orden!!!
            desplegarTextoPagina();
            cargarImagenesGaleria();
            //cargarImagenesPagina();
        }

        protected void cargarImagenesPagina() {
          //  imgPresentacion.ImageUrl = con.getImagenEstatica(pagina, 1);
          //  imgContenido.ImageUrl = con.getImagenEstatica(pagina, 1);
        }

        protected void desplegarTextoPagina()
        {
            // para evitar problemas, si no se especifica cual es el curso que se quiere ver entonces
            // el curso X default es el de "Maquinas Simples"


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

            txtPagina.Text = con.getTextoPagina(pagina, 1);
            txtNombreCursoMod.Text = Request["curso"];
        }

        protected void cargarImagenesGaleria()
        {
            // para asignarle la categoria correspondiente a la pagina
            /* 
             *  Maquinas simples = 4
             *  WeDo = 5
             *  Mindstorm = 6
             *  
             */
            int categoria = 0;
            switch (pagina)
            {
                case 2:
                    categoria = 5;
                    break;
                case 3:
                    categoria = 6;
                    break;
                case 4:
                    categoria = 7;
                    break;
                default:
                    categoria = 0;
                    break;
            }

            String slcCmd = "SELECT cm.nombreContMedia, cm.URL from contenidoMedia cm where cm.id_categoria='" + categoria + "';";


            SqlCommand ls = new SqlCommand(slcCmd, con.getSQLCon());

            String elementos = "";
            int cant = 0;
            con.getSQLCon().Open();
            SqlDataReader dr = ls.ExecuteReader();
            while (dr.Read())
            {
                cant++;
                String nombre = dr["nombreContMedia"].ToString();
                String url = dr["URL"].ToString();


                elementos += "<div class=\"col-md-3 col-sm-6\">"
                               + "<a href=\"" + url + "\" rel=\"prettyPhoto[pp_gal]\" class=\"thumbnail\">"
                                   + "<img src=\"" + url + "\" alt=\"" + nombre + "\" style=\"height: 100%; width: 100%\" />"
                              + "</a>"
                          + "</div>";

            }

            con.getSQLCon().Close();
            txtFotosP.Text = elementos;

            if (cant < 1)
            {
                txtFotosP.Text = "<h1 style=\"padding: 5%;\">No se han encontrado fotos para este curso</h1>";
            }
          
        }

    }
}