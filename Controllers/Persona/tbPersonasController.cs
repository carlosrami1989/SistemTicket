using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemTicket.Models.Persona;

namespace SistemTicket.Controllers.Persona
{
    public class tbPersonasController : Controller
    {
        private SistemaTicketEntities1 db = new SistemaTicketEntities1();

        [HttpGet]
        public JsonResult BuscarCedula(string cedula)

        {
            //return Json("prueba", JsonRequestBehavior.AllowGet);
            var Listacedula = db.tbPersona.Select(p => new { p.id, p.cedula, p.nombres, p.apellidos }).
                Where(p => p.cedula == cedula).ToList();

            return Json(Listacedula.ToList(), JsonRequestBehavior.AllowGet);

           // return View("Create", "tbTickets", Listacedula.ToList()) ;
            //var tbTicket = db.tbTicket.Include(t => t.tbTicketHistorial);
            // return View();
        }
        public ActionResult Index()
        {
            return View(db.tbPersona.ToList());
        }

        // GET: tbPersonas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPersona tbPersona = db.tbPersona.Find(id);
            if (tbPersona == null)
            {
                return HttpNotFound();
            }
            return View(tbPersona);
        }

        // GET: tbPersonas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbPersonas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cedula,nombres,apellidos,user_ingreso,user_modificacion")] tbPersona tbPersona)
        {
            if (ModelState.IsValid)
            {
                db.tbPersona.Add(tbPersona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbPersona);
        }

        // GET: tbPersonas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPersona tbPersona = db.tbPersona.Find(id);
            if (tbPersona == null)
            {
                return HttpNotFound();
            }
            return View(tbPersona);
        }

        // POST: tbPersonas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cedula,nombres,apellidos,user_ingreso,user_modificacion")] tbPersona tbPersona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbPersona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbPersona);
        }

        // GET: tbPersonas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPersona tbPersona = db.tbPersona.Find(id);
            if (tbPersona == null)
            {
                return HttpNotFound();
            }
            return View(tbPersona);
        }

        // POST: tbPersonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbPersona tbPersona = db.tbPersona.Find(id);
            db.tbPersona.Remove(tbPersona);
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
