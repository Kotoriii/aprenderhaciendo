using LEGO_Test.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LEGO_Test
{
    public partial class ModificarCuenta : System.Web.UI.Page
    {
        bool cambContra = false;
        SqlConnection con = Conexion.getConexion().getSQLCon();
        Usuario usuario = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                usuario = (Usuario)Session["usuario"];
            }
            if (!IsPostBack)
            {
                txtCorreo1.Text = usuario.getCorreo();
                txtDireccion1.Text = usuario.getDireccion();
                txtNombre1.Text = usuario.getNombre();
                txtNumeroTel1.Text = usuario.getNumeroTel().ToString();
                txtProvincia1.SelectedValue = usuario.getProvincia();
                txtContraV.Enabled = true;
            }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (txtCorreo1.Text == "" || txtDireccion1.Text == "" || txtNombre1.Text == "" || txtNumeroTel1.Text == "" || txtProvincia1.SelectedItem.Text == "")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Debe completar todos los espacios')</script>");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * FROM usuario WHERE nombreUsuario = '" + ((Usuario)Session["usuario"]).getNombreUsuario() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    if (email_bien_escrito(txtCorreo1.Text))
                    {
                        if (cambContra)
                        {
                            if (viejaContraValida())
                            {
                                if (contrasenasIguales())
                                {

                                    SqlCommand cmd1 = new SqlCommand("update usuario set contrasena='" + txtContraN.Text + "', correo='" + txtCorreo1.Text + "', nombre='" + txtNombre1.Text + "', numeroTel='" + int.Parse(txtNumeroTel1.Text) + "', direccion='" + txtDireccion1.Text + "', provincia='" + txtProvincia1.SelectedItem.Text + "' where nombreUsuario='" + usuario.getNombreUsuario() + "';", con);
                                    cmd1.ExecuteNonQuery();
                                    con.Close();
                                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Sus datos fueron cambiados exitosamente')</script>");

                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Las contraseñas no son iguales')</script>");
                                }

                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('La contraseña es incorrecta')</script>");

                            }
                        }

                        if (!cambContra)
                        {
                            SqlCommand cmd1 = new SqlCommand("update usuario set correo='" + txtCorreo1.Text + "', nombre='" + txtNombre1.Text + "', numeroTel='" + int.Parse(txtNumeroTel1.Text) + "', direccion='" + txtDireccion1.Text + "', provincia='" + txtProvincia1.SelectedItem.Text + "' where nombreUsuario='" + usuario.getNombreUsuario() + "';", con);
                            cmd1.ExecuteNonQuery();
                            con.Close();
                            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Sus datos fueron cambiados exitosamente')</script>");

                        }
                    }
                    else
                    {
                        if (email_bien_escrito(txtCorreo1.Text) == false)
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('El correo está mal escrito')</script>");
                        }
                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Hubo un error al procesar su solicitud, por favor intentelo más tarde')</script>");

                }

            }

            //para actualizar la instancia de usaurio que esta en la sesion
            this.usuario = Conexion.getConexion().buscarUsuarioBD(usuario.getNombreUsuario());
            Session["usuario"] = this.usuario;

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

        protected bool viejaContraValida()
        {
            return (usuario.getContrasenna() == txtContraV.Text);
        }
        protected bool contrasenasIguales()
        {
            return (txtContraN.Text == txtContraN2.Text);
        }

        protected void txtContra_TextChanged(object sender, EventArgs e)
        {
            if (txtContraV.Enabled)
            {
                cambContra = true;
            }
            else {
                txtContraV.Enabled = true;
            }
        }
    }
}
