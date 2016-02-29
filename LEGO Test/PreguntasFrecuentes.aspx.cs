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
    public partial class PreguntasFrecuentes : System.Web.UI.Page
    {
        Conexion con = Conexion.getConexion();

        protected void Page_Load(object sender, EventArgs e)
        {
            desplegarPreguntas();
        }

        protected void desplegarPreguntas()
        {
            String slcCmd;

            slcCmd = "Select * From preguntas";
            SqlCommand ls = new SqlCommand(slcCmd, con.getSQLCon());

            int cantidadPreguntas = 0;
            String preguntas = "";
            if (con.getSQLCon().State == System.Data.ConnectionState.Closed)
            {
                con.getSQLCon().Open();
            }
            SqlDataReader dr = ls.ExecuteReader();
            while (dr.Read())
            {
                cantidadPreguntas++;
                String id = dr["id_preguntas"].ToString();
                String pregunta = dr["pregunta"].ToString();
                String respuesta = dr["respuesta"].ToString();

                preguntas += "<div class= \"panel panel-default\">"
                    + "<div class= \"panel-heading\">"
                    + "<h3 class=\"panel-title\">"
                    + "<strong>P: " + pregunta + "</strong> </h3>"
                    + "</div>"
                    + "<div class=\"panel-body\">"
                    + " R: " + respuesta
                    + "</div>"
                    + "</div>";

            }
            con.getSQLCon().Close();

            ltPreguntas.Text = preguntas;

            if (cantidadPreguntas < 1)
            {
                ltPreguntas.Text = "<div class= \"panel panel-default\">" +
                   "<div class= \"panel-heading\">"
                   + "<h3 class=\"panel-title\">"
                   + "<strong>P: " +"No hay preguntas disponibles"+ "</strong> </h3>"
                   + "</div>"
                  + "</div>";
            }
        }
    }
}