using LEGO_Test.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LEGO_Test
{
    public partial class DatosUsuario : System.Web.UI.Page
    {
        List<String> datos = new List<String>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                cargarDatos();
            }
        }

        protected void cargarDatos() {
            if (Session["usuario"] != null) {
                Usuario usuario = (Usuario)Session["usuario"];

                this.nombretxt.Text = usuario.getNombre();
                this.telefonotxt.Text = usuario.getNumeroTel().ToString();
                this.emailtxt.Text = usuario.getCorreo();
                this.direcciontxt.Text = usuario.getDireccion();
            }
        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {
            if (rbntienda.Checked == false && rbndomicilio.Checked == false)
            {
                advertencialiteral.Visible = true;
                advertencialiteral.Text = "<p style=\"color:red\"> Debe escoger una opción de entrega antes de seguir </p>";
            }

            else
            {
                if (Page.IsValid)
                {
                    String entrega = "";

                    datos.Add(nombretxt.Text); //0
                    datos.Add(apellido1txt.Text);  //1
                    datos.Add(apellido2txt.Text); //2
                    datos.Add(telefonotxt.Text); //3
                    datos.Add(celulartxt.Text); //4
                    datos.Add(emailtxt.Text); //5
                    datos.Add(direcciontxt.Text); //6
                    if (rbntienda.Checked == true)
                    {
                        entrega = "Recibir su compra en la tienda";

                    }
                    else if (rbndomicilio.Checked == true)
                    {
                        entrega = "Recibir su compra en la dirección ingresada";

                    }
                    datos.Add(entrega); //7
                    Session["datos"] = datos;
                    Response.Redirect("Checkout.aspx");
                }

            }
        }
    }
}