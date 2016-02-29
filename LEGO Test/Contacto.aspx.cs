using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LEGO_Test.Clases;

namespace LEGO_Test
{
    public partial class Contacto : System.Web.UI.Page
    {
        Conexion con = Conexion.getConexion();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarTextos();
        }

        protected void cargarTextos()
        {
            ltlDireccion.Text = con.getTextoPagina(8, 1);
            ltlTelefono.Text = con.getTextoPagina(8, 2);
            ltlEmail.Text = con.getTextoPagina(8, 3);
        }
    }
}