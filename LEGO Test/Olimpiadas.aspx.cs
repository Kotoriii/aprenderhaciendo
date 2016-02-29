using LEGO_Test.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LEGO_Test
{
    public partial class Olimpiadas : System.Web.UI.Page
    {
        Conexion con = Conexion.getConexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            desplegarTexto();
            cargarImagenesGaleria();
            cargarImagenesPagina();
        }
        protected void desplegarTexto()
        {
            txtPagina.Text = con.getTextoPagina(5, 1);
        }
        protected void cargarImagenesPagina()
        {
            imgPresentacion.ImageUrl = "~/"+ con.getImagenEstatica(5, 1);
            imgContenido.ImageUrl = "~/" + con.getImagenEstatica(5, 1);
        }

        protected void cargarImagenesGaleria()
        {
            String slcCmd = "SELECT cm.nombreContMedia, cm.URL from contenidoMedia cm where cm.id_categoria='8';";


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
                txtFotosP.Text = "<h1 style=\"padding: 5%;\">No se han encontrado fotos de las olimpiadas</h1>";
            }

        }
    }


}