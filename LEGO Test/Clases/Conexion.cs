
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LEGO_Test.Clases
{
    public class Conexion
    {
        static private Conexion conexion = null;
        static SqlConnection con;

        private Conexion()
        {
            con = new SqlConnection("Data Source=SQL5003.Smarterasp.net;Initial Catalog=DB_9B5485_LEGO;User Id=DB_9B5485_LEGO_admin;Password=YOUR_DB_PASSWORD;");
        }
        public SqlConnection getSQLCon()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            } return con;
        }
        static public Conexion getConexion()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }

        private void nonquery(String command)
        {
            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void ExecuteNonQuery(String command)
        {
            nonquery(command);
        }

        public SqlDataReader ExecuteSelect(String command)
        {

            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            con.Close();
            return dr;
        }

        public String getTextoPagina(int idPagina, int idTexto)
        {
            try
            {
                String res;
                String slcCom = "select txt.texto as txt from texto txt,  pagina pag where pag.id_pagina='" + idPagina + "' and txt.id_texto='" + idTexto + "' and pag.id_pagina = txt.id_pagina ;";
                SqlCommand Sqlcom = new SqlCommand(slcCom, getSQLCon());
                getSQLCon().Open();
                res = Sqlcom.ExecuteScalar().ToString();
                getSQLCon().Close();
                return res;
            }
            catch (Exception)
            {

                return "No se ha encontrado el texto id " + idTexto + " en la pagina id " + idPagina + "<br /> Favor revisar que el texto existe <br /> Error ";
            }
        }
        public String getImagenEstatica(int idPagina, int idContenedor)
        {
            try
            {
                String res;
                String slcCom = "select cm.URL from contenedores con, contenidoMedia cm where con.id_contenedores = '" + idContenedor + "' and con.id_pagina = '" + idPagina + "' and con.id_contenidoMedia = cm.nombreContMedia;";
                SqlCommand Sqlcom = new SqlCommand(slcCom, getSQLCon());
                getSQLCon().Open();
                res = Sqlcom.ExecuteScalar().ToString();
                getSQLCon().Close();
                return res;
            }
            catch (Exception)
            {

                return "no hay imagen en el url especificado";
            }
        }

        /** IMOPORTANTE!! no actualiza la sesion */
        public Usuario buscarUsuarioBD(String _nombreUsuario)
        {
            SqlCommand cmd = new SqlCommand("select * FROM usuario WHERE nombreUsuario=@correo;", con);
            cmd.Parameters.AddWithValue("@correo", _nombreUsuario);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Usuario usuario = null;
            if (dt.Rows.Count > 0)
            {
                String nombreUsuario = dt.Rows[0]["nombreUsuario"].ToString();
                String nombre = dt.Rows[0]["nombre"].ToString();
                String contra = dt.Rows[0]["contrasena"].ToString();
                String correo = dt.Rows[0]["correo"].ToString();
                int numeroTel = int.Parse(dt.Rows[0]["numeroTel"].ToString());
                String direccion = dt.Rows[0]["direccion"].ToString();
                String provincia = dt.Rows[0]["provincia"].ToString();
                String permiso = dt.Rows[0]["permiso"].ToString();
                usuario = new Usuario(nombreUsuario, contra, correo, nombre, numeroTel, direccion, provincia, permiso);
             }
            return usuario;
        }
    }
}