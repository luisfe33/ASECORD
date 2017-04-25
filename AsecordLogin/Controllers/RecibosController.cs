using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AsecordLogin.DAL;
using AsecordLogin.Models;

namespace AsecordLogin.Controllers
{
    public class RecibosController : Controller
    {
        private AsesoriaContext db = new AsesoriaContext();

        // GET: Recibos
        public ActionResult Index()
        {
            return View(db.Recibos.ToList());
        }

        // GET: Recibos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibos recibos = db.Recibos.Find(id);
            if (recibos == null)
            {
                return HttpNotFound();
            }
            return View(recibos);
        }

        // GET: Recibos/Create
        public ActionResult Create()
        {

            List<SelectListItem> Forma_pago = new List<SelectListItem>();
            SelectListItem tp1 = new SelectListItem() { Text = "Efectivo", Value = "1", Selected = false };
            SelectListItem tp2 = new SelectListItem() { Text = "Transferencia", Value = "2", Selected = false };
            SelectListItem tp3 = new SelectListItem() { Text = "Cheque", Value = "3", Selected = false };
            SelectListItem tp4 = new SelectListItem() { Text = "Tarjeta", Value = "4", Selected = false };
            SelectListItem tp5 = new SelectListItem() { Text = "Dolares", Value = "5", Selected = false };
            Forma_pago.Add(tp1);
            Forma_pago.Add(tp2);
            Forma_pago.Add(tp3);
            Forma_pago.Add(tp4);
            Forma_pago.Add(tp5);
            ViewData["Forma_pago"] = Forma_pago;

            return View();
        }

        // POST: Recibos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReciboID,Fecha,Concepto,Valor,Forma_pago,Comentario,Estatus")] Recibos recibos)
        {
            if (ModelState.IsValid)
            {
                db.Recibos.Add(recibos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recibos);
        }

        // GET: Recibos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibos recibos = db.Recibos.Find(id);
            if (recibos == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> Forma_pago = new List<SelectListItem>();
            SelectListItem tp1 = new SelectListItem() { Text = "Efectivo", Value = "1", Selected = false };
            SelectListItem tp2 = new SelectListItem() { Text = "Transferencia", Value = "2", Selected = false };
            SelectListItem tp3 = new SelectListItem() { Text = "Cheque", Value = "3", Selected = false };
            SelectListItem tp4 = new SelectListItem() { Text = "Tarjeta", Value = "4", Selected = false };
            SelectListItem tp5 = new SelectListItem() { Text = "Dolares", Value = "5", Selected = false };
            Forma_pago.Add(tp1);
            Forma_pago.Add(tp2);
            Forma_pago.Add(tp3);
            Forma_pago.Add(tp4);
            Forma_pago.Add(tp5);
            ViewData["Forma_pago"] = Forma_pago;

            return View(recibos);
        }

        // POST: Recibos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReciboID,Fecha,Concepto,Valor,Forma_pago,Comentario,Estatus")] Recibos recibos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recibos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recibos);
        }

        // GET: Recibos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibos recibos = db.Recibos.Find(id);
            if (recibos == null)
            {
                return HttpNotFound();
            }
            return View(recibos);
        }

        // POST: Recibos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recibos recibos = db.Recibos.Find(id);
            db.Recibos.Remove(recibos);
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
