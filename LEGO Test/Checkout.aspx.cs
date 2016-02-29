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
    public partial class Checkout : System.Web.UI.Page
    {
        List<int> checkout = new List<int>();
        Conexion con3 = Conexion.getConexion();
        Dictionary<int, int> carro2 = new Dictionary<int, int>();


        protected void Page_Load(object sender, EventArgs e)
        {

            con3.getSQLCon().Open();
            checkout = (List<int>)Application["carrito"];
            desplegarCheckout();
            con3.getSQLCon().Close();
            desplegarTotal(checkout);
        }

        protected String RecorrerCarrito(List<int> carrito)
        {
            String listac = "";

            String idies = string.Join(" , ", carrito);
            carro2 = (Dictionary<int, int>)Session["cantidad"];
            String slcCmd3 = "SELECT prod.id_producto, prod.nombreProducto, prod.descripcion, prod.precioUnitario, cm.URL, tp.descripcion AS catprod FROM Producto prod, contenidoMedia cm, tipoProducto tp WHERE prod.nombreContMedia = cm.nombreContMedia AND prod.id_categoria = tp.id_categoria AND prod.id_producto IN (" + idies + ")";
            SqlCommand ls3 = new SqlCommand(slcCmd3, con3.getSQLCon());
            SqlDataReader dr3 = ls3.ExecuteReader();
            while (dr3.Read())
            {
                int IDp = int.Parse(dr3["id_producto"].ToString());
                String nombre = dr3["nombreProducto"].ToString();
                String descripcion = dr3["descripcion"].ToString();
                String precio = dr3["precioUnitario"].ToString();

                listac += "<li class=\"list-group-item\">"
                        + "<div class=\"row\" style=\"margin-top: 2%; margin-left: 2%\">"
                        + "<div class=\"col-md-6\">"
                        + "<p><b><u>Nombre:</b></u> " + nombre + "</p>"
                        + "<p><b><u>Descripcion:</b></u> " + descripcion + "</p>"
                        + "<p><b><u>Precio Unitario:</b></u> " + precio + "</p>"
                        + "<p><b><u>Cantidad:</b></u> " + carro2[IDp] + "</p>"
                        + "</div>"
                        + "</div>"
                        + "</li>";
            }

            return listac;
        }

        protected void desplegarCheckout()
        {
            Session["carrito"] = checkout;
            String bla = RecorrerCarrito(checkout);
            checkoutliteral.Text = bla;
            Session["checkout"] = bla;
        }

        protected void desplegarTotal(List<int> carrito)
        {

            con3.getSQLCon().Open();
            carro2 = (Dictionary<int, int>)Session["cantidad"];
            String idies = string.Join(" , ", carrito);
            int total1 = 0;
            String slcCmd3 = "SELECT prod.id_producto, prod.precioUnitario FROM Producto prod, contenidoMedia cm, tipoProducto tp WHERE prod.nombreContMedia = cm.nombreContMedia AND prod.id_categoria = tp.id_categoria AND prod.id_producto IN (" + idies + ")";
            SqlCommand ls3 = new SqlCommand(slcCmd3, con3.getSQLCon());
            SqlDataReader dr3 = ls3.ExecuteReader();
            while (dr3.Read())
            {
                int IDp = int.Parse(dr3["id_producto"].ToString());
                int precio = int.Parse(dr3["precioUnitario"].ToString());
                int cant = carro2[IDp];
                total1 += cant * precio;
                Session["total"] = total1;

            }
            if (((List<int>)Application["carrito"]).Count != 0)
            {
                checkouttotal.Text = "<p>Precio Total: " + (total1) + "</p>";
            }
            con3.getSQLCon().Close();
        }
    }
}