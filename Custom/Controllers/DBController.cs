using Custom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public class DBController : Controller
    {
        public string Create(string dbCOntext = "No DB Name Provided")
        {
            TCContext db = new TCContext(dbCOntext);
            db.Users.Add(new Models.User() {
                UserName="tcadmin",
                Password="Sync#150",
                UserRole="Admin"
            });
            db.Users.Add(new Models.User()
            {
                UserName = "swagat",
                Password = "Sync#150",
                UserRole = "Consultant"
            });
            db.SaveChanges();
            return dbCOntext;
        }
    }
}