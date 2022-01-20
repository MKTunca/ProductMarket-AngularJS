using ProductMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProductMarket.Controllers
{
    public class AdminController : Controller
    {
        ProductsEntities connect = new ProductsEntities();
        public ActionResult Login()
        {
            if (User.Identity.Name != "")
            { FormsAuthentication.SignOut(); }

            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginTable login)
        {
            if (login.Username != null)
            {
                if (login.Password != null)
                {
                    var bilgi = connect.LoginTable.FirstOrDefault(m => m.Username == login.Username && m.Password == login.Password);

                    if (bilgi != null)
                    {
                        FormsAuthentication.RedirectFromLoginPage(bilgi.ID.ToString(), false);
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        ViewBag.uyari = "Bilgilerinizi kontrol ediniz.";
                    }
                }
                else
                {
                    ViewBag.uyari = "Şifrenizi yazınız.";
                }
            }
            else
            {
                ViewBag.uyari = "Kullanıcı adınızı yazınız.";
            }

            return View();
        }
    }
}