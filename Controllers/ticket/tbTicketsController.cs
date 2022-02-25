using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemTicket.Models.ticket;
using SistemTicket.Models.Persona;


namespace SistemTicket.Controllers.ticket
{
    public class tbTicketsController : Controller
    {
        private SistemaTicketEntities2 db = new SistemaTicketEntities2();
        // GET: tbPersonas
        
        // GET: tbTickets
        [HttpGet]
        public ActionResult Carga(string cedula)
        {
            var tbTicket = db.tbTicket.ToList();
           // return ViewData["students"] = tbTicket.ToList();

            return View();
        }
        public ActionResult Index()
        {
            var tbTicket = db.tbTicket.ToList();
            return View(tbTicket.ToList());
        }

        // GET: tbTickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTicket tbTicket = db.tbTicket.Find(id);
            if (tbTicket == null)
            {
                return HttpNotFound();
            }
            return View(tbTicket);
        }

        // GET: tbTickets/Create
        public ActionResult Create()
        {
          //  ViewBag.user_ingreso = new SelectList(db.tbTicketHistorial, "id", "comentario");
            return View();
        }

        // POST: tbTickets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
     
        public JsonResult Create([Bind(Include = "id,id_persona,id_estado_ticket,fecha,asunto,descripcion,user_ingreso,user_modificacion")] tbTicket tbTicket)
        {
            if (ModelState.IsValid)
            {
                tbTicket.fecha = System.DateTime.Now;
                db.tbTicket.Add(tbTicket);
                db.SaveChanges();
                return Json(tbTicket, JsonRequestBehavior.AllowGet);
            }


            return Json(tbTicket,  JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
        }

           // ViewBag.user_ingreso = new SelectList(db.tbTicketHistorial, "id", "comentario", tbTicket.user_ingreso);
           // return View(tbTicket);
       
     

        // GET: tbTickets/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbTicket tbTicket = db.tbTicket.Find(id);
        //    if (tbTicket == null)
        //    {
        //        return HttpNotFound();
        //    }
        //   // ViewBag.user_ingreso = new SelectList(db.tbTicketHistorial, "id", "comentario", tbTicket.user_ingreso);
        //    return View(tbTicket);
        //}

        // POST: tbTickets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,id_persona,id_estado_ticket,fecha,asunto,descripcion,user_ingreso,user_modificacion")] tbTicket tbTicket)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tbTicket).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    //ViewBag.user_ingreso = new SelectList(db.tbTicketHistorial, "id", "comentario", tbTicket.user_ingreso);
        //    return View(tbTicket);
        //}

        // GET: tbTickets/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbTicket tbTicket = db.tbTicket.Find(id);
        //    if (tbTicket == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbTicket);
        //}

        // POST: tbTickets/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    tbTicket tbTicket = db.tbTicket.Find(id);
        //    db.tbTicket.Remove(tbTicket);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
