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
    public class CitasConsularesController : Controller
    {
        private AsesoriaContext db = new AsesoriaContext();

        // GET: CitasConsulares
        public ActionResult Index()
        {
            return View(db.Citas_Consulares.Include(p => p.Cliente).ToList());
        }

        // GET: CitasConsulares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas_consulares citas_consulares = db.Citas_Consulares.Find(id);
            if (citas_consulares == null)
            {
                return HttpNotFound();
            }
            return View(citas_consulares);
        }


        //GET: CitasConsulares/CC
        public ActionResult CC()
        {

            return View(db.Clientes.ToList());
        }

        // GET: CitasConsulares/Create
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

            List<SelectListItem> Lugar = new List<SelectListItem>();
            SelectListItem L0 = new SelectListItem() { Text = "", Value = "0", Selected = true };
            SelectListItem L1 = new SelectListItem() { Text = "G360", Value = "G360", Selected = false };
            SelectListItem L2 = new SelectListItem() { Text = "EUSA", Value = "EUSA", Selected = false };
            Lugar.Add(L0);
            Lugar.Add(L1);
            Lugar.Add(L2);


            ViewBag.Lugar = Lugar;



            ViewData["ClienteID"] = cliente.CLienteID;
            ViewBag.ClienteName = cliente.Nombre + " " + cliente.Apellido;

            return View();
        }

        // POST: CitasConsulares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CitaID,Fecha,Hora,Lugar,Tipo_visa,UID,Formulario,Comentario,Estatus")] Citas_consulares citas_consulares, int Cliente_CLienteID)
        {
            if (ModelState.IsValid)
            {
                db.Citas_Consulares.Add(citas_consulares);

                Clientes cliente = db.Clientes.Find(Cliente_CLienteID);
                citas_consulares.Cliente = cliente;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(citas_consulares);
        }

        // GET: CitasConsulares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas_consulares citas_consulares = db.Citas_Consulares.Find(id);
            if (citas_consulares == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> Lugar = new List<SelectListItem>();
            SelectListItem L0 = new SelectListItem() { Text = "", Value = "0", Selected = true };
            SelectListItem L1 = new SelectListItem() { Text = "G360", Value = "G360", Selected = false };
            SelectListItem L2 = new SelectListItem() { Text = "EUSA", Value = "EUSA", Selected = false };
            Lugar.Add(L0);
            Lugar.Add(L1);
            Lugar.Add(L2);


            ViewBag.Lugar = Lugar;
            if (citas_consulares.Lugar!= null)
            {
                (from t in Lugar where (t.Value == citas_consulares.Lugar) select t).First().Selected = true;

            }

            return View(citas_consulares);
        }

        // POST: CitasConsulares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CitaID,Fecha,Hora,Lugar,Tipo_visa,UID,Formulario,Comentario,Estatus")] Citas_consulares citas_consulares)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citas_consulares).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(citas_consulares);
        }

        // GET: CitasConsulares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas_consulares citas_consulares = db.Citas_Consulares.Find(id);
            if (citas_consulares == null)
            {
                return HttpNotFound();
            }
            return View(citas_consulares);
        }

        // POST: CitasConsulares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Citas_consulares citas_consulares = db.Citas_Consulares.Find(id);
            db.Citas_Consulares.Remove(citas_consulares);
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
