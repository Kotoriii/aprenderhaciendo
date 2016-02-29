using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LEGO_Test.Clases;
using System.Data.SqlClient;

namespace LEGO_Test
{
    public partial class Carrito : System.Web.UI.Page
    {
        List<int> carro = new List<int>();
        Conexion con2 = Conexion.getConexion();
        Dictionary<int, int> carro2 = new Dictionary<int, int>(); //cantidad
        int cantidad = 0;
        int items = 1;
        int senditems = 1;
        protected void Page_Load(object sender, EventArgs e)
        {



            inicializarCarrito();

            if (Request["remover"] != null)
            {
                removerProd(Request["remover"]);
            }
            if (Request.QueryString["idProd"] != null)
            {
                agregarProducto(Request.QueryString["idProd"]);

            }


            if (Request["remover"] != null)
            {
                removerProd(Request["remover"]);
            }

            desplegarCarrito();
        }

        protected void inicializarCarrito()
        {
            if ((List<int>)Application["carrito"] == null)
            {
                carro = new List<int>();
                carro2 = new Dictionary<int, int>();

            }
            else
            {
                carro = (List<int>)Application["carrito"];
                carro2 = (Dictionary<int, int>)Application["cantidad"];

            }

        }

        protected void agregarProducto(String id)
        {
            int cantidad = 1;
            if (!carro.Contains(int.Parse(id)) || (!carro2.ContainsKey(int.Parse(id))))
            {
                carro.Add(int.Parse(id));
                carro2.Add(int.Parse(id), cantidad);

            }
            else
            {
                carro2[int.Parse(id)] = carro2[int.Parse(id)] + 1;

            }
        }

        protected String RecorrerLista(List<int> carrito)
        {

            con2.getSQLCon().Open();

            String lista = "";

            String idies = string.Join(" , ", carrito);
            String slcCmd2 = "SELECT prod.id_producto, prod.nombreProducto, prod.descripcion, prod.precioUnitario, cm.URL, tp.descripcion AS catprod FROM Producto prod, contenidoMedia cm, tipoProducto tp WHERE prod.nombreContMedia = cm.nombreContMedia AND prod.id_categoria = tp.id_categoria AND prod.id_producto IN (" + idies + ")";
            SqlCommand ls2 = new SqlCommand(slcCmd2, con2.getSQLCon());
            SqlDataReader dr2 = ls2.ExecuteReader();
            while (dr2.Read())
            {

                int IDp = int.Parse(dr2["id_producto"].ToString());
                String nombre = dr2["nombreProducto"].ToString();
                String URL = dr2["URL"].ToString();
                String descripcion = dr2["descripcion"].ToString();
                String precio = dr2["precioUnitario"].ToString();
                String categoria = dr2["catprod"].ToString();



                lista += "<li class=\"list-group-item\">"
                               + "<div class=\"row\" style=\"margin-top: 2%; margin-left: 2%\">"
                                 + "<div class=\"col-md-4\">"
                                 + "<img src=\"" + URL + "\" alt=\"...\" style=\"width: 75%\" >"
                                 + "</div>"
                                  + "<div class=\"col-md-6\">"
                                  + "<p><b><u>Nombre:</u></b> " + nombre + "</p>"
                                     + "<p><b><u>Descripción:</u></b> " + descripcion + "</p>"
                                      + "<p><b><u>Categoría:</u></b> " + categoria + "</p>"
                                      + "<p><b><u>Precio Unitario:</u></b> " + precio + "</p>"
                                  + "</div>"
                                        + "<!-- /.col-lg-6 -->"
                                       + "<div class=\"col-md-2\">"
                                             + "<div class=\"input-group\">"
                                              + "<p>Cantidad</p>"
                                               + "<input type=\"text\" class=\"form-control\" name=\"" + IDp + "\" value=\"" + carro2[IDp] + "\" placeholder=\"" + carro2[IDp] + "\" onchange=\"Update_Link()\" style=\"width: 50px\" />"
                                             + "</div>"
                                            + "<!-- /input-group -->"
                                         + "</div>"
                                        + "<!-- /.col-lg-6 -->"
                                     + "</div>"
                                    + "<!-- /.row -->"
                      + "<a href=\"Carrito.aspx?remover=" + IDp + "\"><button type=\"button\" ID=\"btnRemover\" class=\"btn btn-default\" style=\"margin-left: 85%; margin-bottom: 50px\">Remover</button></a>"
                   + "</li>";
            }

            ScriptManager.RegisterStartupScript(this, typeof(Carrito), "update()", "function update(" + items + ") {$('#updatelink').attr(\"href\", \"Carrito.aspx?senditems=" + items + "\"); $('#holder')===" + items + ";}", true);
            con2.getSQLCon().Close();

            return lista;
        }



        protected void desplegarCarrito()
        {
            if (((List<int>)Application["carrito"]).Count == 0)
            {
                carritodespliegue.Text = "<h1 style=\"text-align:center; padding: 5%;\"> El carrito está vacío </h1>";
            }
            else
            {
                Session["cantidad"] = carro2;
                Session["carrito"] = carro;


                carritodespliegue.Text = RecorrerLista(carro);
                String botoncomp = "";
                botoncomp = "<a href=\"DatosUsuario.aspx\" id=\"Comprar\" class=\"btn btn-success btn-lg\" style=\"margin-left: 90%\">Comprar</a>";
                botoncomprar.Text = botoncomp;

                desplegarTotal(carro);
            }
        }

        protected void removerProd(String id)
        {
            try
            {
                ((List<int>)Application["carrito"]).Remove(int.Parse(id));
                ((Dictionary<int, int>)Application["cantidad"]).Remove(int.Parse(id));

            }
            catch (Exception e)
            {
            }
        }



        protected void desplegarTotal(List<int> carrito)
        {
            con2.getSQLCon().Open();
            String idies = string.Join(" , ", carrito);
            int total1 = 0;
            String slcCmd2 = "SELECT prod.id_producto, prod.precioUnitario FROM Producto prod, contenidoMedia cm, tipoProducto tp WHERE prod.nombreContMedia = cm.nombreContMedia AND prod.id_categoria = tp.id_categoria AND prod.id_producto IN (" + idies + ")";
            SqlCommand ls2 = new SqlCommand(slcCmd2, con2.getSQLCon());
            SqlDataReader dr2 = ls2.ExecuteReader();
            while (dr2.Read())
            {
                int IDp = int.Parse(dr2["id_producto"].ToString());
                int precio = int.Parse(dr2["precioUnitario"].ToString());
                int cant = carro2[IDp];
                total1 += cant * precio;

            }
            if (((List<int>)Application["carrito"]).Count != 0)
            {
                total.Text = "<p>Precio Total: " + (total1) + "</p>";
            }
            con2.getSQLCon().Close();
        }

        protected void updatelink_ServerClick(object sender, EventArgs e)
        {

            Dictionary<int, int>.KeyCollection keyColl = carro2.Keys;
            Dictionary<int, int> nuevoCarro = new Dictionary<int, int>();
            foreach (int s in keyColl)
            {

                nuevoCarro.Add(s, int.Parse(Request.Form["" + s]));


            }
            Application["cantidad"] = nuevoCarro;

            Response.Redirect("~/Carrito.aspx");
        }

    }
}