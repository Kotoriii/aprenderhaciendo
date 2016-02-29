using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEGO_Test.Clases
{
    public class Usuario
    {
        string nombreUsuario, contrasena, correo, nombre, direccion, provincia, permiso;
        int numeroTel;

        public Usuario() { }
        public Usuario(String _nombreUsuario, String _contrasenna, String _correo, String _nombre, int _numeroTel, String _direccion, String _provincia, String _permiso) {

            this.nombreUsuario = _nombreUsuario;
            this.contrasena = _contrasenna;
            this.correo = _correo;
            this.nombre = _nombre;
            this.numeroTel = _numeroTel;
            this.direccion = _direccion;
            this.provincia = _provincia;
            this.permiso = _permiso;
        }

        public String getNombreUsuario() { return this.nombreUsuario; }
        public String getContrasenna() { return this.contrasena; }
        public String getCorreo() { return this.correo; }
        public String getNombre() { return this.nombre; }
        public int getNumeroTel() { return this.numeroTel; }
        public String getDireccion() { return this.direccion; }
        public String getProvincia() { return this.provincia; }
        public String getPermiso() { return this.permiso; }

    }
}