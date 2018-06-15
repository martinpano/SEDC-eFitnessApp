using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SEDC.eFitnessApplication.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string username, string password)
        {
            if(username == "manager@efitness.com" && password == "admin")
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return new RedirectResult("~/Trainers/Index");
            }
            else
            {
                return new RedirectResult("~/Users/LogIn");
            }
        }

        [HttpGet]
        [Authorize]
        public RedirectResult LogOut()
        {
            FormsAuthentication.SignOut();
            return new RedirectResult("~/Users/LogIn");
        }
    }
}