using MyPasteWebapp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace MyPasteWebapp.Controllers
{
    public class CreateDbController : Controller
    {
        [HttpGet]
        public  string Create(string dbCOntext="No DB Name Provided")
        {
            //Database.SetInitializer<UsersContext> (null);
            //Configuration config = WebConfigurationManager.OpenWebConfiguration(@"/");
            //config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(dbCOntext, "Data Source=.;Initial Catalog=" + dbCOntext + ";Integrated Security=SSPI", "System.Data.SqlClient"));
            //config.Save();


            UsersContext db = new UsersContext(dbCOntext);
            var books=db.Books.ToList();

            WebSecurity.InitializeDatabaseConnection("Data Source=.;Initial Catalog=" + dbCOntext + ";Integrated Security=SSPI", "System.Data.SqlClient", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = System.Web.Security.Roles.Provider;
            roles.CreateRole("admin");
            roles.CreateRole("consultants");

            string userName = "tcadmin";
            string password = "Sync#150";

            if (!WebSecurity.IsConfirmed(userName))
                WebSecurity.CreateUserAndAccount(userName, password);

            if (!roles.IsUserInRole(userName, "admin"))
                roles.AddUsersToRoles(new string[] { userName }, new string[] { "admin" });
            return dbCOntext;
        }


        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
