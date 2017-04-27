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
    [Authorize]
    public class CitasLocalesController : Controller
    {
        private AsesoriaContext db = new AsesoriaContext();

        // GET: CitasLocales
        public ActionResult Index()
        {
            return View(db.Citas_locales.Include(p => p.Cliente).ToList());
        }

        // GET: CitasLocales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas_locales citas_locales = db.Citas_locales.Find(id);
            if (citas_locales == null)
            {
                return HttpNotFound();
            }
            return View(citas_locales);
        }



        //GET: CitasLocales/CL
        public ActionResult CL()
        {
            return View(db.Clientes.ToList());
        }


        // GET: CitasLocales/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Clientes cliente = db.Clientes.Find(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> Motivo = new List<SelectListItem>();
            SelectListItem m0 = new SelectListItem() { Text = "", Value = "0", Selected = true };
            SelectListItem m1 = new SelectListItem() { Text = "Consulta", Value = "Consulta", Selected = false };
            SelectListItem m2 = new SelectListItem() { Text = "DS-160", Value = "DS-160", Selected = false };
            SelectListItem m3 = new SelectListItem() { Text = "Pre-Entrevista", Value = "Pre-Entrevista", Selected = false };
            SelectListItem m4 = new SelectListItem() { Text = "Perfil", Value = "Perfil", Selected = false };
            SelectListItem m5 = new SelectListItem() { Text = "Otros", Value = "Otros", Selected = false };
            Motivo.Add(m0);
            Motivo.Add(m1);
            Motivo.Add(m2);
            Motivo.Add(m3);
            Motivo.Add(m4);
            Motivo.Add(m5);

            ViewBag.Motivo = Motivo;

            ViewData["ClienteID"] = cliente.CLienteID;
            ViewData["ClienteName"] = cliente.Nombre + " " + cliente.Apellido;


            return View();
        }

        // POST: CitasLocales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CitaID,Fecha,Hora,Tipo,Comentario,Estatus,Motivo")] Citas_locales citas_locales, int Cliente_CLienteID)
        {
            if (ModelState.IsValid)
            {
                db.Citas_locales.Add(citas_locales);

                Clientes cliente = db.Clientes.Find(Cliente_CLienteID);
                citas_locales.Cliente = cliente;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(citas_locales);
        }

        // GET: CitasLocales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas_locales citas_locales = db.Citas_locales.Find(id);
            Clientes cliente = db.Clientes.Find(id);

            if (citas_locales == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> Motivo = new List<SelectListItem>();
            SelectListItem m0 = new SelectListItem() { Text = "", Value = "0", Selected = true };
            SelectListItem m1 = new SelectListItem() { Text = "Consulta", Value = "Consulta", Selected = false };
            SelectListItem m2 = new SelectListItem() { Text = "DS-160", Value = "DS-160", Selected = false };
            SelectListItem m3 = new SelectListItem() { Text = "Pre-Entrevista", Value = "Pre-Entrevista", Selected = false };
            SelectListItem m4 = new SelectListItem() { Text = "Perfil", Value = "Perfil", Selected = false };
            SelectListItem m5 = new SelectListItem() { Text = "Otros", Value = "Otros", Selected = false };
            Motivo.Add(m0);
            Motivo.Add(m1);
            Motivo.Add(m2);
            Motivo.Add(m3);
            Motivo.Add(m4);
            Motivo.Add(m5);

            ViewBag.Motivo = Motivo;
            if (citas_locales.Motivo != null)
            {
                (from t in Motivo where (t.Value == citas_locales.Motivo) select t).First().Selected = true;

            }

            ViewData["ClienteID"] = cliente.CLienteID;
            ViewData["ClienteName"] = cliente.Nombre + " " + cliente.Apellido;

            return View(citas_locales);
        }

        // POST: CitasLocales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CitaID,Fecha,Hora,Tipo,Comentario,Estatus,Motivo")] Citas_locales citas_locales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citas_locales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(citas_locales);
        }

        // GET: CitasLocales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas_locales citas_locales = db.Citas_locales.Find(id);
            if (citas_locales == null)
            {
                return HttpNotFound();
            }
            return View(citas_locales);
        }

        // POST: CitasLocales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Citas_locales citas_locales = db.Citas_locales.Find(id);
            db.Citas_locales.Remove(citas_locales);
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
