using AssignmentWeek9.Models.ViewModels;
using AssignmentWeek9.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentWeek9.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel user)
        {

            //Register as a user
            if (ModelState.IsValid)
            {

                using (DBModels db = new DBModels())
                {
                    if (db.Users.Any(u => u.username == user.Username))
                    {
                        ModelState.AddModelError("", "Username Already Exists!");
                        return View();
                    }

                   string hashed = Hashing.HashPassword(user.Password);
                    User login = new User()
                    {
                        password = user.Password,
                        username = user.Username
                    };

                    db.Users.Add(login);
                    db.SaveChanges();


                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "Registration Successful.";
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
                return View();
            // use database to validate 
            using (DBModels db = new DBModels())
            {
                var usr = db.Users.FirstOrDefault(u => u.username == user.Username);

                if (usr != null)
                {
                    if (Hashing.ValidatePassword(user.Password, usr.password))
                    {
                        //Set session username for later use
                        Session["username"] = usr.username;

                        return RedirectToAction("Upload", "File");
                    }
                    else
                        ModelState.AddModelError("", "Username or password is wrong.");

                }
                else
                    ModelState.AddModelError("", "Please fill out the form. ");
            }

            return View();
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}