using Problema6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Problema6.Controllers
{
    public class AccountController : Controller
    {
        private Gestiune_Telefoane db = new Gestiune_Telefoane();
        // GET: Login
        public ActionResult Index()
        {
            using (Gestiune_Telefoane db = new Gestiune_Telefoane())
            {
                return View(db.UserAccount.ToList());
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (Gestiune_Telefoane db = new Gestiune_Telefoane())

                {
                    db.UserAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.User + "  creat";
            }

            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (Gestiune_Telefoane db = new Gestiune_Telefoane())

            {
               //var usr = db.UserAccount.Single(u => u.User == user.User && u.Parola == user.Parola);
                var usr = db.UserAccount.Where(u => u.User == user.User && u.Parola == user.Parola);

                if (usr != null)
                {
                    Session["Mesaj"] = "Autentificare reusita!";
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Utilizatorul sau parola sunt gresite");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["Mesaj"] != null)
                return View();
            else
                return RedirectToAction("Login");
        }
    }
}