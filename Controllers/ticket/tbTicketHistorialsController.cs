using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemTicket.Models.ticket;

namespace SistemTicket.Controllers.ticket
{
    public class tbTicketHistorialsController : Controller
    {
        private SistemaTicketEntities2 db = new SistemaTicketEntities2();

        // GET: tbTicketHistorials
        public ActionResult Index()
        {
            var tbTicketHistorial = db.tbTicketHistorial.ToList();
            return View(tbTicketHistorial.ToList());
        }

        // GET: tbTicketHistorials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTicketHistorial tbTicketHistorial = db.tbTicketHistorial.Find(id);
            if (tbTicketHistorial == null)
            {
                return HttpNotFound();
            }
            return View(tbTicketHistorial);
        }

        // GET: tbTicketHistorials/Create
        public ActionResult Create()
        {
            ViewBag.id_ticket = new SelectList(db.tbTicket, "id", "asunto");
            return View();
        }

        // POST: tbTicketHistorials/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_usuario,id_ticket,comentario")] tbTicketHistorial tbTicketHistorial)
        {
            if (ModelState.IsValid)
            {
                db.tbTicketHistorial.Add(tbTicketHistorial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_ticket = new SelectList(db.tbTicket, "id", "asunto", tbTicketHistorial.id_ticket);
            return View(tbTicketHistorial);
        }

        // GET: tbTicketHistorials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTicketHistorial tbTicketHistorial = db.tbTicketHistorial.Find(id);
            if (tbTicketHistorial == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_ticket = new SelectList(db.tbTicket, "id", "asunto", tbTicketHistorial.id_ticket);
            return View(tbTicketHistorial);
        }

        // POST: tbTicketHistorials/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_usuario,id_ticket,comentario")] tbTicketHistorial tbTicketHistorial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbTicketHistorial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_ticket = new SelectList(db.tbTicket, "id", "asunto", tbTicketHistorial.id_ticket);
            return View(tbTicketHistorial);
        }

        // GET: tbTicketHistorials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTicketHistorial tbTicketHistorial = db.tbTicketHistorial.Find(id);
            if (tbTicketHistorial == null)
            {
                return HttpNotFound();
            }
            return View(tbTicketHistorial);
        }

        // POST: tbTicketHistorials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbTicketHistorial tbTicketHistorial = db.tbTicketHistorial.Find(id);
            db.tbTicketHistorial.Remove(tbTicketHistorial);
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
