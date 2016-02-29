using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LEGO_Test
{
    public partial class ComprobarDatos : System.Web.UI.Page
    {
        int total = 0;
        List<String> datos = new List<String>();

        protected void Page_Load(object sender, EventArgs e)
        {
            total = (int)Session["total"];
            montototal.Text = "<li class=\"list-group-item\"><div class=\"row\" style=\"margin-top: 2%; margin-left: 2%\"><div class=\"col-md-6\"><h3><u>Precio total de su compra: " + total.ToString() + "</b></h3></div></div></li>";
            datosliteral.Text = DesplegarDatos();
        }

        protected String DesplegarDatos()
        {
            String datos2 = "";
            datos = (List<String>)Session["datos"];
            datos2 += "<li class=\"list-group-item\">"
                        + "<div class=\"row\" style=\"margin-top: 2%; margin-left: 2%\">"
                        + "<div class=\"col-md-6\">"
                        + "<h3 style=\"margin-bottom:2%\"><u>Datos Personales</u></h3>"
                        + "<p><b><u>Nombre:</b></u> " + datos[0] + "</p>"
                        + "<p><b><u>Primer Apellido:</b></u> " + datos[1] + "</p>"
                        + "<p><b><u>Segundo Apellido:</b></u> " + datos[2] + "</p>"
                        + "<p><b><u>Teléfono:</b></u> " + datos[3] + "</p>"
                        + "<p><b><u>Celular:</b></u> " + datos[4] + "</p>"
                        + "<p><b><u>Email:</b></u> " + datos[5] + "</p>"
                        + "<p><b><u>Dirección:</b></u> " + datos[6] + "</p>"
                        + "</div>"
                        + "</div>"
                        + "</li>";
            return datos2;
        }





        protected void Siguiente_Click(object sender, EventArgs e) //este codigo va a ir despues de una transaccion aceptada de paypal, lo pongo aqui por ahora
        {
            datos = (List<String>)Session["datos"];
            Random rnd = new Random();
            String numfactura = rnd.Next(0, 999999999).ToString();

            //mail al cliente
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("aprenderhaciendo1@hotmail.com", "Gordo123");
            client.Port = 587;
            client.Host = "smtp-mail.outlook.com";
            client.EnableSsl = true;
            mail.To.Add("aprenderhaciendo1@hotmail.com");
            mail.From = new MailAddress("aprenderhaciendo1@hotmail.com");
            mail.Subject = "Factura";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body += "<h3>Número de Factura: " + numfactura + "</h3>"
                         + "<br />"
                         + "<h4 style=\"margin-left:40%\"> Lista de productos comprados </h4>"
                         + "<br />"
                         + Session["checkout"]
                         + "<br />"
                         + DesplegarDatos()
                         + "<br />"
                         + "<h3>Usted escogió la opción de: " + datos[7] + "</h3>"
                         + "<br />"
                         + "<h4>Gracias por su compra!</h4>";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            client.Send(mail);

            //mail a alejandra

            System.Net.Mail.MailMessage mail2 = new System.Net.Mail.MailMessage();
            SmtpClient client2 = new SmtpClient();
            client2.Credentials = new System.Net.NetworkCredential("aprenderhaciendo2@hotmail.com", "Gordo123");
            client2.Port = 587;
            client2.Host = "smtp-mail.outlook.com";
            client2.EnableSsl = true;
            mail2.To.Add("aprenderhaciendo2@hotmail.com");
            mail2.From = new MailAddress("aprenderhaciendo2@hotmail.com");
            mail2.Subject = "Compra en línea # " + numfactura;
            mail2.SubjectEncoding = System.Text.Encoding.UTF8;
            mail2.Body += "<h2 style=\"margin-left:45\"> Nueva compra en línea </h2>"
                         + "<h3>Número de Factura: " + numfactura + "</h3>"
                         + "<br />"
                         + "<h4 style=\"margin-left:40%\"> Lista de productos comprados </h4>"
                         + "<br />"
                         + Session["checkout"]
                         + "<br />"
                         + "<h4 style=\"margin-left:40%\"> Información del cliente </h4>"
                         + "<br />"
                         + DesplegarDatos()
                         + "<br />"
                         + "<h3>El cliente escogió la opción de: " + datos[7] + "</h3>";
            mail2.BodyEncoding = System.Text.Encoding.UTF8;
            mail2.IsBodyHtml = true;
            client2.Send(mail2);
        }



    }
}