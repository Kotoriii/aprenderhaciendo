using LEGO_Test.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LEGO_Test
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = Conexion.getConexion().getSQLCon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                if (Request["usuario"] != null)
                {
                    Response.Redirect("Default.aspx");
                }
               
            }
        }

        protected void BtnIniciarr_Click(object sender, EventArgs e)
        {

            Usuario usuario = Conexion.getConexion().buscarUsuarioBD(TextCorreoIn.Text);
            if (usuario != null && usuario.getContrasenna() == TextContrasena.Text)
            {

                Session["usuario"] = usuario;

                if (usuario.getPermiso() == "admin")
                {
                    
                    Response.Redirect("~/PaginaAdmin.aspx");
                }
                else
                {
                    
                    Response.Redirect("~/Default.aspx");
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('nombre de usuario o contraseña incorrecta, por favor intente de nuevo')</script>");
                TextCorreoIn.Text = "";
                TextContrasena.Text = "";
            }
            con.Close();
        }
        protected void RecuperarContrasenna_Click(object sender, EventArgs e)
        {
            if (con.State == System.Data.ConnectionState.Closed) {
                con.Open();
            }
            string contr = contrasenaAleatoria();
            SqlCommand cmd = new SqlCommand("select * FROM usuario WHERE nombreUsuario='" + TextCorreoIn.Text + "';", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (TextCorreoIn.Text != "")
                {
                    String cmdstr = "update usuario set contrasena='" + contr + "' where correo ='" + TextCorreoIn.Text + "';";
                    SqlDataReader data;
                    using (con)
                    {
                        using (SqlCommand cmd1 = new SqlCommand(cmdstr, con))
                        {
                            
                            data = cmd1.ExecuteReader();

                        }
                        con.Close();
                        EnviarCorreoRecContra(contr, TextCorreoIn.Text);
                        Response.Redirect("Login.aspx");
                    }
                }
                else
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Por favor ingrese su nombre de usuario')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Este nombre de usuario no se encuentra registrado')</script>");
                TextCorreoIn.Text = "";
            }

            con.Close();
        }
        public string contrasenaAleatoria()
        {
            string contrasena = "";
            Random varRan = new Random();
            int num;
            char[] losChar = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            for (int i = 0; i < 7; i++)
            {
                num = varRan.Next(36);
                contrasena += losChar[num];
            }

            return contrasena;
        }
        public void EnviarCorreoRecContra(string contrasena, string correo)
        {
            /*Creamos el objeto para el mensaje*/
            System.Net.Mail.MailMessage Correo = new System.Net.Mail.MailMessage();
            /*La cuenta de correo al que se la vamos a enviar*/
            Correo.To.Add(correo);

            /*Asunto del correo*/
            Correo.Subject = "Contraseña nueva para afiliarse a lego education";
            Correo.SubjectEncoding = System.Text.Encoding.UTF8;

            //Cuerpo del Mensaje
            Correo.Body = "Buenas su contraseña nueva para ingresar al sitio es " + contrasena + " gracias por seguir prefiriendonos";
            Correo.BodyEncoding = System.Text.Encoding.UTF8;
            Correo.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            Correo.From = new System.Net.Mail.MailAddress("proyecto.componentes@gmail.com");

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("proyecto.componentes@gmail.com", "proyectocomponentes");

            cliente.Port = 587;
            cliente.EnableSsl = true;

            cliente.Host = "smtp.gmail.com";

            try
            {
                //Enviamos el mensaje      
                cliente.Send(Correo);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Console.WriteLine("El correo no existe",
                        ex.ToString());
            }

        }
    }
}