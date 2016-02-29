using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using LEGO_Test.Logica;

namespace LEGO_Test
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Crea el perfil de administrador y usuario
            TipoUsuario tipoUsuario = new TipoUsuario();
            tipoUsuario.crearAdmin();
            Application["carrito"] = new List<int>();
            Application["cantidad"] = new Dictionary<int, int>();
            Application["total"] = new Int32();
            Application["datos"] = new List<String>(); //donde se guardan los datos de los compradores en sesion, ver lista e indexes en datosusuario.aspx
            Application["checkout"] = "";
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs.

            // Get last error from the server
            Exception exc = Server.GetLastError();

            if (exc is HttpUnhandledException)
            {
                if (exc.InnerException != null)
                {
                    exc = new Exception(exc.InnerException.Message);
                    Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax",
                        true);
                }
            }
        }
    }
}