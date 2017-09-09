using AsecordLogin.DAL;
using AsecordLogin.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsecordLogin.Startup))]
namespace AsecordLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        //en este metodo crearemos el usuario Admin y los roles por defecto
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));



            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (!roleManager.RoleExists("Admin"))
            {
                //first we create Admin role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website
                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "asecordrd@outlook.com";

                string pass = "Asesoria01";

                var chkUser = userManager.Create(user, pass);

                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Asesor"))
            {
                var role = new IdentityRole();
                role.Name = "Asesor";
                roleManager.Create(role);

            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Recepcionista"))
            {
                var role = new IdentityRole();
                role.Name = "Recepcionista";
                roleManager.Create(role);

            }
        }
    }
}
