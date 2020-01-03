using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SuperHeroStories.Models;

[assembly: OwinStartupAttribute(typeof(SuperHeroStories.Startup))]
namespace SuperHeroStories
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }
        //In this method we will create default User roles and Admin user for login
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //In Startup I am creating first Admin Role and creatina default Admin user
            if (!roleManager.RoleExists("Admin"))
            {
                //First we create Admin roll
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super use who will maintain the website

                var user = new ApplicationUser();
                user.UserName = "adamn";
                user.Email = "nobsadam@gmail.com";

                string userPassWord = "123456789";

                var chkUser = UserManager.Create(user, userPassWord);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }

            }

            //Creating Creating Manager role
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

            }

            //Creating Creating Employee role
            if (!roleManager.RoleExists("Employee"))
            {

                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);
            }
        }
    }
}
