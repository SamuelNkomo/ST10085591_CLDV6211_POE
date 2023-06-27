using ST10085591_CLDV6211_POE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ST10085591_CLDV6211_POE.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.userAccounts.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register( UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.userAccounts.Add(account);
                    db.SaveChanges();
                }

                ModelState.Clear();
                ViewBag.Message = account.InspectorFirstName + " " + account.InspectorLastName + "Successfully Registered";
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(UserAccount User)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.userAccounts.Single(u=> u.InspectorUserName == User.InspectorUserName && u.Password == User.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserId.ToString();
                    Session["InspectorUserName"] = User.InspectorUserName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is wrong");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
