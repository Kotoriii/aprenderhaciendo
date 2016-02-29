using System;
using System.Text;

namespace LEGO_Test.Clases
{

    /* 
     *  Cambio de algoritmo. De MD5 a BCrypt
     *  
     * Modo de uso es aun mas simple, funciones estaticas entonces
     * no necesita instanciarse la clase
     */
    public class criptografia
    {

        public static string generarHash(string input)
        {
            string hash = BCrypt.HashPassword(input, BCrypt.GenerateSalt(12));
            return hash;
        }

        public static bool sonIguales(String contrasenna, String hash)
        {

            bool iguales = BCrypt.CheckPassword(contrasenna, hash);
            return iguales;
        }

    }
}