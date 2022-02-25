using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemTicket.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InicioSession(string usuario, string password)
        {
            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(password))
            {
                //tbusuario tbusuario = db.tbusuario.Find(usuario);
                //if (tbusuario == null)
                //{
                //    return HttpNotFound();
                //}
                return RedirectToAction("Index", "Home");

                return Json(usuario, password);
            }
            else
            {
                return Json(usuario, password);
            }

        }

        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}