using LEGO_Test.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LEGO_Test
{
    public partial class Registrarse : System.Web.UI.Page
    {
        SqlConnection con = Conexion.getConexion().getSQLCon();
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        public string contrasenaAleatoria()
        {
            string contrasena = "";
            Random varRan = new Random();
            int num;
            char[] losChar = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            for (int i = 0; i < 7; i++)
            {
                num = varRan.Next(20);
                contrasena += losChar[num];
            }

            return contrasena;
        }
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            if (txtCorreo.Text == "" || txtDireccion.Text == "" || txtNombre.Text == "" || txtNombreUs.Text == "" || txtNumeroTel.Text == "" || txtProvincia.SelectedItem.Text == "")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Debe completar todos los espacios')</script>");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * FROM usuario WHERE nombreUsuario = '" + txtNombreUs.Text + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    if (captchaCorrecto())
                    {
                        if (email_bien_escrito(txtCorreo.Text) == true)
                        {
                            string contr = contrasenaAleatoria();
                            SqlCommand cmd1 = new SqlCommand("insert into usuario values ('" + txtNombreUs.Text + "', '" + contr + "', '" + txtCorreo.Text + "', '" + txtNombre.Text + "', '" + int.Parse(txtNumeroTel.Text) + "', '" + txtDireccion.Text + "', '" + txtProvincia.SelectedItem.Text + "', 'usuario');", con);
                            cmd1.ExecuteNonQuery();
                            con.Close();
                            EnviarCorreo(contr, txtCorreo.Text);
                            txtCorreo.Text = "";
                            txtDireccion.Text = "";
                            txtNombre.Text = "";
                            txtNombreUs.Text = "";
                            txtNumeroTel.Text = "";
                            txtProvincia.SelectedIndex = 0;

                        }
                        else
                        {
                            if (email_bien_escrito(txtCorreo.Text) == false)
                            {
                                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('El correo está mal escrito')</script>");
                            }
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('El captcha ingresado es incorreto')</script>");
                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('El nombre de usuario elegido ya se encuentra registrado, favor escoger otro')</script>");
                    txtCorreo.Text = "";
                    txtCorreo.Text = "";
                }

            }
            con.Close();
        }
        public void EnviarCorreo(string contrasena, string correo)
        {
            /*Creamos el objeto para el mensaje*/
            System.Net.Mail.MailMessage Correo = new System.Net.Mail.MailMessage();
            /*La cuenta de correo al que se la vamos a enviar*/
            Correo.To.Add(correo);

            /*Asunto del correo*/
            Correo.Subject = "Contraseña para afiliarse a lego education";
            Correo.SubjectEncoding = System.Text.Encoding.UTF8;

            //Cuerpo del Mensaje
            Correo.Body = "Buenas su contraseña para ingresar al sitio es '" + contrasena + "' gracias por afiliarse a la pagina.";
            Correo.BodyEncoding = System.Text.Encoding.UTF8;
            Correo.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            Correo.From = new System.Net.Mail.MailAddress("proyecto.componentes@gmail.com");

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("cuentasaprenderhaciendo@gmail.com", "Gordo123");

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
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('El correo ingresado no es valido, por favor ingresar otro')</script>");
                txtCorreo.Text = "";
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Gracias por registrarse. La contraseña de su cuenta fue enviada a su correo, podra cambiarla una ves ingresado a la pagina')</script>");
            // Response.Redirect("Login.aspx");

        }

        private bool captchaCorrecto()
        {
            if (this.Session["CaptchaImageText"] != null &&
                this.txtimgcode.Text == this.Session["CaptchaImageText"].ToString())
            {
                txtimgcode.Text = "";
                return true;
            }
            else
            {

                txtimgcode.Text = "";
                return false;
            }
        }

        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}