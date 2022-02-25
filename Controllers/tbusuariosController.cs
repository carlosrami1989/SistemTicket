using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemTicket.Models.Usuario;
 

namespace SistemTicket.Controllers
{
    public class tbusuariosController : Controller
    {
        private SistemaTicketEntities3 db = new SistemaTicketEntities3();

        // GET: tbusuarios
        public ActionResult Index()
        {
            return View(db.tbusuario.ToList());
        }

        // GET: tbusuarios/Details/5

        [HttpPost]
        public ActionResult InicioSession(string usuario, string password)
        {
            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(password))
            {
                // var tbusuario = db.tbusuario.
                var tbusuario = db.tbusuario.Select(u => new { u.id, u.nombre, u.apellidos, u.usuario, u.password })
                    .Where(u =>   u.usuario == usuario && u.password == password ).ToList();
                //tbusuario tbusuario = db.tbusuario.Find(usuario);
               // return Json(tbusuario);
                if (tbusuario == null || tbusuario.Count == 0)
                {
                    return RedirectToAction("Login", "Home", "Contraseña Fail");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
              

               // return Json("est");
            }
            else
            {
                return RedirectToAction("Login", "Home","Contraseña Fail");
            }

        }

        //public ActionResult InicioSession(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbusuario tbusuario = db.tbusuario.Find(id);
        //    if (tbusuario == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbusuario);
        //}

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbusuario tbusuario = db.tbusuario.Find(id);
            if (tbusuario == null)
            {
                return HttpNotFound();
            }
            return View(tbusuario);
        }

        // GET: tbusuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbusuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellidos,usuario,password")] tbusuario tbusuario)
        {
            return Json(tbusuario.nombre);
            if (ModelState.IsValid)
            {
                db.tbusuario.Add(tbusuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbusuario);
        }

        // GET: tbusuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbusuario tbusuario = db.tbusuario.Find(id);
            if (tbusuario == null)
            {
                return HttpNotFound();
            }
            return View(tbusuario);
        }

        // POST: tbusuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellidos,usuario,password")] tbusuario tbusuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbusuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbusuario);
        }

        // GET: tbusuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbusuario tbusuario = db.tbusuario.Find(id);
            if (tbusuario == null)
            {
                return HttpNotFound();
            }
            return View(tbusuario);
        }

        // POST: tbusuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbusuario tbusuario = db.tbusuario.Find(id);
            db.tbusuario.Remove(tbusuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
