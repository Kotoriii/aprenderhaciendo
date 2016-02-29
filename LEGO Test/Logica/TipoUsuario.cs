using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using LEGO_Test.Models;

namespace LEGO_Test.Logica
{
    internal class TipoUsuario
    {
        internal void crearAdmin()
        {
            /*// Accesa el contexto de la aplicación y crea resultado de variables
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            // Se crea un objeto para que almacene el rol
            // El cual solo puede almacenar objetos de IdentityRole
            var roleStore = new RoleStore<IdentityRole>(context);

            // Crea un RoleManager el cual solo puede almacenar objetos de IdentityRole
            // El RoleManager recibe como parametro al roleStore
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Se crea el rol de administrador si no se ha creado aun
            if (!roleMgr.RoleExists("Administrador"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole("Administrador"));
                if (!IdRoleResult.Succeeded)
                {

                }
            }

            // Crea un objeto de UserManager a base del objeto UserStore
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser()
            {
                UserName = "Admin",
            };
            IdUserResult = userMgr.Create(appUser, "Pa$$word");

            // Si se creo el "Admin" este se agrega al rol de "Administrador"
            if (IdUserResult.Succeeded)
            {
                IdUserResult = userMgr.AddToRole(appUser.Id, "Administrador");
                if (!IdUserResult.Succeeded)
                {

                }
            }
            else
            {

            }*/

        }
    }
}