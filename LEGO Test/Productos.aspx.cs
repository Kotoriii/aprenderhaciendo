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
    public partial class Productos : System.Web.UI.Page
    {
        Conexion con = Conexion.getConexion();

        int pagina;
        int cont;
        protected void Page_Load(object sender, EventArgs e)
        {

            desplegarProductos();
            actualizarSidebar();
        }
        protected void actualizarSidebar()
        {
            String slcCom;
            SqlCommand Sqlcom;
            int WeDo = 0;
            int MindStorm = 0;
            int MaquinasS = 0;

            slcCom = "select count(prod.id_producto) as id from producto prod, tipoProducto tp where prod.id_categoria = tp.id_categoria and tp.descripcion ='WeDo';";
            Sqlcom = new SqlCommand(slcCom, con.getSQLCon());
            con.getSQLCon().Open();
            WeDo = int.Parse(Sqlcom.ExecuteScalar().ToString());
            con.getSQLCon().Close();

            slcCom = "select count(prod.id_producto) as id from producto prod, tipoProducto tp where prod.id_categoria = tp.id_categoria and tp.descripcion ='Máquinas Simples';";
            Sqlcom = new SqlCommand(slcCom, con.getSQLCon());
            con.getSQLCon().Open();
            MaquinasS = int.Parse(Sqlcom.ExecuteScalar().ToString());
            con.getSQLCon().Close();

            slcCom = "select count(prod.id_producto) as id from producto prod, tipoProducto tp where prod.id_categoria = tp.id_categoria and tp.descripcion ='MindStorm';";
            Sqlcom = new SqlCommand(slcCom, con.getSQLCon());
            con.getSQLCon().Open();
            MindStorm = int.Parse(Sqlcom.ExecuteScalar().ToString());
            con.getSQLCon().Close();

            txtTodos.Text = (WeDo + MaquinasS + MindStorm).ToString();
            txtWeDo.Text = WeDo.ToString();
            txtMindStorm.Text = MindStorm.ToString();
            txtMaquinasSimples.Text = MaquinasS.ToString();

        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (pagina != 0)
            {
                pagina--;
            }
            redicc();
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            pagina++;
            redicc();
        }

        protected void redicc()
        {
            if (Request["buscar"] != null && Request["categoria"] == null)
            {
                Response.Redirect("~/Productos.aspx?pagina=" + pagina + "&buscar=" + Request["buscar"]);
            }
            if (Request["buscar"] == null && Request["categoria"] != null)
            {
                Response.Redirect("~/Productos.aspx?pagina=" + pagina + "&categoria=" + Request["categoria"]);
            }
            if (Request["buscar"] != null && Request["categoria"] != null)
            {
                Response.Redirect("~/Productos.aspx?pagina=" + pagina + "&categoria=" + Request["categoria"] + "&buscar=" + Request["buscar"]);
            }
            if (Request["buscar"] == null && Request["categoria"] == null)
            {
                Response.Redirect("~/Productos.aspx?pagina=" + pagina);
            }
        }
        protected void recibirCont()
        {
            if (Request.QueryString["pagina"] == null)
            {
                pagina = 0;
                cont = 0;
            }
            else
            {


                pagina = int.Parse(Request.QueryString["pagina"]);
                cont = pagina * 20;
            }

            if (cont == 0)
            {
                btnAnterior.Enabled = false;
            }
            else
            {
                btnAnterior.Enabled = true;
            }
        }

        protected void desplegarProductos()
        {
            recibirCont();
            String slcCmd;
            if (Request["categoria"] != null)
            {
                slcCmd = "SELECT prod.id_producto, prod.nombreProducto, prod.descripcion, prod.precioUnitario, cm.URL, tp.descripcion AS catprod FROM Producto prod, contenidoMedia cm, tipoProducto tp where prod.nombreContMedia = cm.nombreContMedia and tp.descripcion= '" + Request["categoria"] + "' and prod.id_categoria = tp.id_categoria ORDER BY id_producto OFFSET " + cont + " ROWS FETCH NEXT 20 ROWS ONLY ;";
            }
            else if (Request["buscar"] != null)
            {
                slcCmd = "SELECT prod.id_producto, prod.nombreProducto, prod.descripcion, prod.precioUnitario, cm.URL, tp.descripcion AS catprod FROM Producto prod, contenidoMedia cm, tipoProducto tp where prod.nombreContMedia = cm.nombreContMedia and  prod.nombreProducto= '" + Request["buscar"] + "' and prod.id_categoria = tp.id_categoria ORDER BY id_producto OFFSET " + cont + " ROWS FETCH NEXT 20 ROWS ONLY ;";
            }
            else
            {
                slcCmd = "SELECT prod.id_producto, prod.nombreProducto, prod.descripcion, prod.precioUnitario, cm.URL, tp.descripcion AS catprod FROM Producto prod, contenidoMedia cm, tipoProducto tp where prod.nombreContMedia = cm.nombreContMedia and prod.id_categoria = tp.id_categoria ORDER BY id_producto OFFSET " + cont + " ROWS FETCH NEXT 20 ROWS ONLY ;";
            }

            SqlCommand ls = new SqlCommand(slcCmd, con.getSQLCon());

            int cantidadEl = 0;

            String elementos = "";
            if (con.getSQLCon().State == System.Data.ConnectionState.Closed)
            {
                con.getSQLCon().Open();
            }
            SqlDataReader dr = ls.ExecuteReader();
            while (dr.Read())
            {
                cantidadEl++;
                String id = dr["id_producto"].ToString();
                String nombre = dr["nombreProducto"].ToString();
                String URL = dr["URL"].ToString();
                String descripcion = dr["descripcion"].ToString();
                String precio = dr["precioUnitario"].ToString();
                String categoria = dr["catprod"].ToString();

                //descripcion de mas de 207 se sale
                elementos += "<div class=\"col-md-3 \" >"
          + "<div class=\"thumbnail\" style=\"height:500px\">"
                + "<div class=\"outerProd\" >"
                + "<div class=\"innerProd\">"
              + " <img src=\"" + URL + "\" alt=\"" + nombre + "\" class=\"imgProd\" > "
              + "</div>"
              + "</div>"
              + " <div class=\"caption\" sty>"
                 + "  <h3>" + nombre + "</h3>"
                 + "  <p><b><u>Precio:</b></u> " + precio + " $</p>"
                 + "  <p style=\"text-align:justify;\"><b><u>Descripción:</b></u> " + descripcion + "</p>"
                 + "  <p><b><u>Categoría:</b></u> " + categoria + "</p>"
               
              + " </div>"
                + "  <p style=\"position:absolute; bottom:0; margin-bottom:50px; margin-left: 10px;\"><a href=\"#\" class=\"btn btn-primary\" onclick=\"setId(" + id + ", '" + nombre + "', '" + descripcion + "', '" + URL + "', " + precio + ", '" + categoria
                 + "')\" >Ver</a><a  href=\" Carrito.aspx?idProd=" + id + "\" class=\"btn btn-default\" )\">Agregar al Carrito</a></p>"
          + " </div>"
          + "</div>";

            }

            con.getSQLCon().Close();

            eletien.Text = elementos;
            elementosTienda.Text = elementos;

            if (cantidadEl < 1)
            {
                btnSiguiente.Enabled = false;
                Literal1.Text = "No se han encontrado productos";
                eletien.Text = "<h1>No se han encontrado productos</h1>";
            }
            if (cantidadEl > 1 && cantidadEl < 20)
            {
                btnSiguiente.Enabled = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Productos.aspx?buscar=" + txtBuscar.Text);
        }

        protected void categorias(object sender, EventArgs e)
        {
            //le de el valor de la categoria a Request["categoria"], osea manda un 
            // parametro de nombre "categoria"
            String ID = ((LinkButton)sender).ID;


            if ("btTodosCat".Equals(ID))
            {
                Response.Redirect("~/Productos.aspx");
            }
            if ("btSimplesCat".Equals(ID))
            {
                Response.Redirect("~/Productos.aspx?categoria=Máquinas%20Simples");
            }
            if ("btWedoCat".Equals(ID))
            {
                Response.Redirect("~/Productos.aspx?categoria=WeDo");
            }
            if ("btNXTCat".Equals(ID))
            {
                Response.Redirect("~/Productos.aspx?categoria=MindStorm");
            }

        }


    }
}