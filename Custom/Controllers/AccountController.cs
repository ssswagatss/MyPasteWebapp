using Custom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Custom.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            List<Tenant> tenants = new List<Tenant>();
            tenants.Add(new Tenant() { Id = 1, Name = "K Force", DbContext = "KforceDB", Email = "swagat.swain@ajatus.co.in" });
            tenants.Add(new Tenant() { Id = 2, Name = "Sudeep Company", DbContext = "SudeepDB", Email = "swagat.swain@ajatus.co.in" });
            ViewData["Tenants"] = (from t in tenants
                                   select new SelectListItem()
                                   {
                                       Text = t.Name,
                                       Value = t.Id.ToString()
                                   }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            List<Tenant> tenants = new List<Tenant>();
            tenants.Add(new Tenant() { Id = 1, Name = "K Force", DbContext = "KforceDB", Email = "swagat.swain@ajatus.co.in" });
            tenants.Add(new Tenant() { Id = 2, Name = "Sudeep Company", DbContext = "SudeepDB", Email = "swagat.swain@ajatus.co.in" });
            string dbCOntext = tenants.Single(x => x.Id == model.TenantId).DbContext;

            TCContext db = new TCContext(dbCOntext);

            User user = db.Users.SingleOrDefault(x => x.UserName == model.UserName);
            if (user != null)
            {
                FormsAuthentication.Initialize();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    user.UserName,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30), // value of time out property
                    model.IsRemember, // Value of IsPersistent property
                    user.UserRole,
                    FormsAuthentication.FormsCookiePath);

                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
            }

            ViewData["Tenants"] = (from t in tenants
                                   select new SelectListItem()
                                   {
                                       Text = t.Name,
                                       Value = t.Id.ToString()
                                   }).ToList();

            return View(model);
        }
    }
}