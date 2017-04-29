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
    public class ClientesController : Controller
    {
        private AsesoriaContext db = new AsesoriaContext();

        // GET: Clientes
        public ActionResult Index(string searchString)
        {

            var clientes = from c in db.Clientes
                           select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                clientes = clientes.Where(c => c.Nombre.Contains(searchString)
                                         || c.Apellido.Contains(searchString));
            }

            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {

            List<SelectListItem> P1 = new List<SelectListItem>();
            SelectListItem p0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p1 = new SelectListItem() { Text = " Casado", Value = "15", Selected = false };
            SelectListItem p2 = new SelectListItem() { Text = " Union Libre", Value = "7.5", Selected = false };
            SelectListItem p3 = new SelectListItem() { Text = " Soltero", Value = "0", Selected = false };
            P1.Add(p0);
            P1.Add(p1);
            P1.Add(p2);
            P1.Add(p3);
            ViewBag.P1 = P1;

            List<SelectListItem> P2 = new List<SelectListItem>();
            SelectListItem p2_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p2_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p2_2 = new SelectListItem() { Text = " Si", Value = "15", Selected = false };
            P2.Add(p2_0);
            P2.Add(p2_1);
            P2.Add(p2_2);
            ViewBag.P2 = P2;

            List<SelectListItem> P3 = new List<SelectListItem>();
            SelectListItem p3_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p3_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p3_2 = new SelectListItem() { Text = " Prestada", Value = "7.5", Selected = false };
            SelectListItem p3_3 = new SelectListItem() { Text = " Si", Value = "15", Selected = false };
            P3.Add(p3_0);
            P3.Add(p3_1);
            P3.Add(p3_2);
            P3.Add(p3_3);
            ViewBag.P3 = P3;

            List<SelectListItem> P4 = new List<SelectListItem>();
            SelectListItem p4_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p4_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p4_2 = new SelectListItem() { Text = " Si", Value = "10", Selected = false };
            P4.Add(p4_0);
            P4.Add(p4_1);
            P4.Add(p4_2);
            ViewBag.P4 = P4;

            List<SelectListItem> P5 = new List<SelectListItem>();
            SelectListItem p5_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p5_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p5_2 = new SelectListItem() { Text = " Si, Empleado", Value = "15", Selected = false };
            SelectListItem p5_3 = new SelectListItem() { Text = " Independiente Registrado", Value = "15", Selected = false };
            SelectListItem p5_4 = new SelectListItem() { Text = " Independiente Informal", Value = "7.5", Selected = false };
            P5.Add(p5_0);
            P5.Add(p5_1);
            P5.Add(p5_2);
            P5.Add(p5_3);
            P5.Add(p5_4);
            ViewBag.P5 = P5;

            List<SelectListItem> P6 = new List<SelectListItem>();
            SelectListItem p6_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p6_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p6_2 = new SelectListItem() { Text = " Menos de 30,000", Value = "5", Selected = false };
            SelectListItem p6_3 = new SelectListItem() { Text = " De 30,000 a 45,000", Value = "10", Selected = false };
            SelectListItem p6_4 = new SelectListItem() { Text = " Mas de 45,000", Value = "10", Selected = false };
            P6.Add(p6_0);
            P6.Add(p6_1);
            P6.Add(p6_2);
            P6.Add(p6_3);
            P6.Add(p6_4);
            ViewBag.P6 = P6;

            List<SelectListItem> P7 = new List<SelectListItem>();
            SelectListItem p7_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p7_1 = new SelectListItem() { Text = " No", Value = "5", Selected = false };
            SelectListItem p7_2 = new SelectListItem() { Text = " Si", Value = "0", Selected = false };
            P7.Add(p7_0);
            P7.Add(p7_1);
            P7.Add(p7_2);
            ViewBag.P7 = P7;

            List<SelectListItem> P8 = new List<SelectListItem>();
            SelectListItem p8_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p8_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p8_2 = new SelectListItem() { Text = " Si", Value = "5", Selected = false };
            P8.Add(p8_0);
            P8.Add(p8_1);
            P8.Add(p8_2);
            ViewBag.P8 = P8;

            List<SelectListItem> P9 = new List<SelectListItem>();
            SelectListItem p9_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p9_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p9_2 = new SelectListItem() { Text = " Si", Value = "5", Selected = false };
            P9.Add(p9_0);
            P9.Add(p9_1);
            P9.Add(p9_2);
            ViewBag.P9 = P9;

            List<SelectListItem> P10 = new List<SelectListItem>();
            SelectListItem p10_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p10_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p10_2 = new SelectListItem() { Text = " Si", Value = "5", Selected = false };
            P10.Add(p10_0);
            P10.Add(p10_1);
            P10.Add(p10_2);
            ViewBag.P10 = P10;






            List<SelectListItem> TipoDePago = new List<SelectListItem>();
            SelectListItem tp1 = new SelectListItem() { Text = "Efectivo", Value = "1", Selected = false };
            SelectListItem tp2 = new SelectListItem() { Text = "Transferencia", Value = "2", Selected = false };
            SelectListItem tp3 = new SelectListItem() { Text = "Cheque", Value = "3", Selected = false };
            SelectListItem tp4 = new SelectListItem() { Text = "Tarjeta", Value = "4", Selected = false };
            SelectListItem tp5 = new SelectListItem() { Text = "Dolares", Value = "5", Selected = false };
            TipoDePago.Add(tp1);
            TipoDePago.Add(tp2);
            TipoDePago.Add(tp3);
            TipoDePago.Add(tp4);
            TipoDePago.Add(tp5);
            ViewBag.TipoDePago = TipoDePago;

            List<SelectListItem> Estatus_1 = new List<SelectListItem>();
            SelectListItem perfil1 = new SelectListItem() { Text = "No Creado", Value = "0", Selected = false };
            SelectListItem perfil2 = new SelectListItem() { Text = "Creado", Value = "1", Selected = false };
            Estatus_1.Add(perfil1);
            Estatus_1.Add(perfil2);
            ViewBag.Estatus_1 = Estatus_1;

            List<SelectListItem> Estatus_2 = new List<SelectListItem>();
            SelectListItem impu1 = new SelectListItem() { Text = "No Pagado", Value = "0", Selected = false };
            SelectListItem impu2 = new SelectListItem() { Text = "Pagado", Value = "1", Selected = false };
            Estatus_2.Add(impu1);
            Estatus_2.Add(impu2);
            ViewBag.Estatus_2 = Estatus_2;

            List<SelectListItem> Estatus_3 = new List<SelectListItem>();
            SelectListItem cita1 = new SelectListItem() { Text = "No Asignada", Value = "0", Selected = false };
            SelectListItem cita2 = new SelectListItem() { Text = "Asignada", Value = "1", Selected = false };
            Estatus_3.Add(cita1);
            Estatus_3.Add(cita2);
            ViewBag.Estatus_3 = Estatus_3;

            List<SelectListItem> Estatus_4 = new List<SelectListItem>();
            SelectListItem docu1 = new SelectListItem() { Text = "No Entregada", Value = "0", Selected = false };
            SelectListItem docu2 = new SelectListItem() { Text = "Entregada", Value = "1", Selected = false };
            Estatus_4.Add(docu1);
            Estatus_4.Add(docu2);
            ViewBag.Estatus_4 = Estatus_4;

            List<SelectListItem> Estatus_5 = new List<SelectListItem>();
            SelectListItem ds1 = new SelectListItem() { Text = "Incompleto", Value = "0", Selected = false };
            SelectListItem ds2 = new SelectListItem() { Text = "Completo", Value = "1", Selected = false };
            Estatus_5.Add(ds1);
            Estatus_5.Add(ds2);
            ViewBag.Estatus_5 = Estatus_5;

            List<SelectListItem> Estatus_6 = new List<SelectListItem>();
            SelectListItem CCitas1 = new SelectListItem() { Text = "No Entregado", Value = "0", Selected = false };
            SelectListItem CCitas2 = new SelectListItem() { Text = "Entregado", Value = "1", Selected = false };
            Estatus_6.Add(CCitas1);
            Estatus_6.Add(CCitas2);
            ViewBag.Estatus_6 = Estatus_6;

            List<SelectListItem> Estatus_7 = new List<SelectListItem>();
            SelectListItem CDS1 = new SelectListItem() { Text = "No Entregado", Value = "0", Selected = false };
            SelectListItem CDS2 = new SelectListItem() { Text = "Entregado", Value = "1", Selected = false };
            Estatus_7.Add(CDS1);
            Estatus_7.Add(CDS2);
            ViewBag.Estatus_7 = Estatus_7;

            List<SelectListItem> Estatus_8 = new List<SelectListItem>();
            SelectListItem Formu1 = new SelectListItem() { Text = "No Entregado", Value = "0", Selected = false };
            SelectListItem Formu2 = new SelectListItem() { Text = "Entregado", Value = "1", Selected = false };
            Estatus_8.Add(Formu1);
            Estatus_8.Add(Formu2);
            ViewBag.Estatus_8 = Estatus_8;

            List<SelectListItem> Estatus_9 = new List<SelectListItem>();
            SelectListItem pre1 = new SelectListItem() { Text = "No Realizada", Value = "0", Selected = false };
            SelectListItem pre2 = new SelectListItem() { Text = "Realizada", Value = "1", Selected = false };
            Estatus_9.Add(pre1);
            Estatus_9.Add(pre2);
            ViewBag.Estatus_9 = Estatus_9;

            List<SelectListItem> Estatus_10 = new List<SelectListItem>();
            SelectListItem EFinal1 = new SelectListItem() { Text = "No Status", Value = "1", Selected = false };
            SelectListItem EFinal2 = new SelectListItem() { Text = "Proceso Administrativo", Value = "2", Selected = false };
            SelectListItem EFinal4 = new SelectListItem() { Text = "Rechazado", Value = "3", Selected = false };
            SelectListItem EFinal3 = new SelectListItem() { Text = "Aprobado", Value = "4", Selected = false };
            Estatus_10.Add(EFinal1);
            Estatus_10.Add(EFinal2);
            Estatus_10.Add(EFinal3);
            Estatus_10.Add(EFinal4);
            ViewBag.Estatus_10 = Estatus_10;

            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "CLienteID,Nombre,Apellido,Fecha_nacimiento,Cedula,Sexo,Estado_civil,Email,Fecha_ingreso,Pasaporte,Tel_1,Tel_2,Tel_3,Comentario,Estatus_1,Estatus_2,Estatus_3,Estatus_4,Estatus_5,Estatus_6,Estatus_7,Estatus_8,Estatus_9,Estatus_10,TipoDePago,P1,P2,P3,P4,P5,P6,P7,P8,P9,P10,Ocupacion,Empresa_Nombre,Empresa_Dir,Empresa_Tel,Empresa_Labor,Direccion,Codigo_DS")] Clientes clientes
            )
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> P1 = new List<SelectListItem>();
            SelectListItem p0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p1 = new SelectListItem() { Text = " Casado", Value = "15", Selected = false };
            SelectListItem p2 = new SelectListItem() { Text = " Union Libre", Value = "7.5", Selected = false };
            SelectListItem p3 = new SelectListItem() { Text = " Soltero", Value = "0", Selected = false };
            P1.Add(p0);
            P1.Add(p1);
            P1.Add(p2);
            P1.Add(p3);
            ViewBag.P1 = P1;
            if (clientes.P1 != null)
            {
                (from t in P1 where (t.Value == clientes.P1) select t).First().Selected = true;

            }

            List<SelectListItem> P2 = new List<SelectListItem>();
            SelectListItem p2_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p2_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p2_2 = new SelectListItem() { Text = " Si", Value = "15", Selected = false };
            P2.Add(p2_0);
            P2.Add(p2_1);
            P2.Add(p2_2);
            ViewBag.P2 = P2;
            if (clientes.P2 != null)
            {
                (from t in P2 where (t.Value == clientes.P2) select t).First().Selected = true;

            }

            List<SelectListItem> P3 = new List<SelectListItem>();
            SelectListItem p3_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p3_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p3_2 = new SelectListItem() { Text = " Prestada", Value = "7.5", Selected = false };
            SelectListItem p3_3 = new SelectListItem() { Text = " Si", Value = "15", Selected = false };
            P3.Add(p3_0);
            P3.Add(p3_1);
            P3.Add(p3_2);
            P3.Add(p3_3);
            ViewBag.P3 = P3;
            if (clientes.P3 != null)
            {
                (from t in P3 where (t.Value == clientes.P3) select t).First().Selected = true;

            }

            List<SelectListItem> P4 = new List<SelectListItem>();
            SelectListItem p4_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p4_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p4_2 = new SelectListItem() { Text = " Si", Value = "10", Selected = false };
            P4.Add(p4_0);
            P4.Add(p4_1);
            P4.Add(p4_2);
            ViewBag.P4 = P4;
            if (clientes.P4 != null)
            {
                (from t in P4 where (t.Value == clientes.P4) select t).First().Selected = true;

            }

            List<SelectListItem> P5 = new List<SelectListItem>();
            SelectListItem p5_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p5_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p5_2 = new SelectListItem() { Text = " Si, Empleado", Value = "15", Selected = false };
            SelectListItem p5_3 = new SelectListItem() { Text = " Independiente Registrado", Value = "15", Selected = false };
            SelectListItem p5_4 = new SelectListItem() { Text = " Independiente Informal", Value = "7.5", Selected = false };
            P5.Add(p5_0);
            P5.Add(p5_1);
            P5.Add(p5_2);
            P5.Add(p5_3);
            P5.Add(p5_4);
            ViewBag.P5 = P5;
            if (clientes.P5 != null)
            {
                (from t in P5 where (t.Value == clientes.P5) select t).First().Selected = true;

            }

            List<SelectListItem> P6 = new List<SelectListItem>();
            SelectListItem p6_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p6_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p6_2 = new SelectListItem() { Text = " Menos de 30,000", Value = "5", Selected = false };
            SelectListItem p6_3 = new SelectListItem() { Text = " De 30,000 a 45,000", Value = "10", Selected = false };
            SelectListItem p6_4 = new SelectListItem() { Text = " Mas de 45,000", Value = "10", Selected = false };
            P6.Add(p6_0);
            P6.Add(p6_1);
            P6.Add(p6_2);
            P6.Add(p6_3);
            P6.Add(p6_4);
            ViewBag.P6 = P6;
            if (clientes.P6 != null)
            {
                (from t in P6 where (t.Value == clientes.P6) select t).First().Selected = true;

            }

            List<SelectListItem> P7 = new List<SelectListItem>();
            SelectListItem p7_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p7_1 = new SelectListItem() { Text = " No", Value = "5", Selected = false };
            SelectListItem p7_2 = new SelectListItem() { Text = " Si", Value = "0", Selected = false };
            P7.Add(p7_0);
            P7.Add(p7_1);
            P7.Add(p7_2);
            ViewBag.P7 = P7;
            if (clientes.P7 != null)
            {
                (from t in P7 where (t.Value == clientes.P7) select t).First().Selected = true;

            }

            List<SelectListItem> P8 = new List<SelectListItem>();
            SelectListItem p8_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p8_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p8_2 = new SelectListItem() { Text = " Si", Value = "5", Selected = false };
            P8.Add(p8_0);
            P8.Add(p8_1);
            P8.Add(p8_2);
            ViewBag.P8 = P8;
            if (clientes.P8 != null)
            {
                (from t in P8 where (t.Value == clientes.P8) select t).First().Selected = true;

            }

            List<SelectListItem> P9 = new List<SelectListItem>();
            SelectListItem p9_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p9_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p9_2 = new SelectListItem() { Text = " Si", Value = "5", Selected = false };
            P9.Add(p9_0);
            P9.Add(p9_1);
            P9.Add(p9_2);
            ViewBag.P9 = P9;
            if (clientes.P9 != null)
            {
                (from t in P9 where (t.Value == clientes.P9) select t).First().Selected = true;

            }

            List<SelectListItem> P10 = new List<SelectListItem>();
            SelectListItem p10_0 = new SelectListItem() { Text = " ", Value = "0", Selected = true };
            SelectListItem p10_1 = new SelectListItem() { Text = " No", Value = "0", Selected = false };
            SelectListItem p10_2 = new SelectListItem() { Text = " Si", Value = "5", Selected = false };
            P10.Add(p10_0);
            P10.Add(p10_1);
            P10.Add(p10_2);
            ViewBag.P10 = P10;
            if (clientes.P10 != null)
            {
                (from t in P10 where (t.Value == clientes.P10) select t).First().Selected = true;

            }




            List<SelectListItem> TipoDePago = new List<SelectListItem>();
            SelectListItem tp1 = new SelectListItem() { Text = "Efectivo", Value = "1", Selected = false };
            SelectListItem tp2 = new SelectListItem() { Text = "Transferencia", Value = "2", Selected = false };
            SelectListItem tp3 = new SelectListItem() { Text = "Cheque", Value = "3", Selected = false };
            SelectListItem tp4 = new SelectListItem() { Text = "Tarjeta", Value = "4", Selected = false };
            SelectListItem tp5 = new SelectListItem() { Text = "Dolares", Value = "5", Selected = false };
            TipoDePago.Add(tp1);
            TipoDePago.Add(tp2);
            TipoDePago.Add(tp3);
            TipoDePago.Add(tp4);
            TipoDePago.Add(tp5);
            ViewBag.TipoDePago = TipoDePago;
            if (clientes.TipoDePago != null)
            {
                (from t in TipoDePago where (t.Value == clientes.TipoDePago) select t).First().Selected = true;

            }

            List<SelectListItem> Estatus_1 = new List<SelectListItem>();
            SelectListItem perfil1 = new SelectListItem() { Text = "No Creado", Value = "0", Selected = false };
            SelectListItem perfil2 = new SelectListItem() { Text = "Creado", Value = "1", Selected = false };
            Estatus_1.Add(perfil1);
            Estatus_1.Add(perfil2);
            ViewBag.Estatus_1 = Estatus_1;
            (from t in Estatus_1 where (t.Value == clientes.Estatus_1) select t).First().Selected = true;

            List<SelectListItem> Estatus_2 = new List<SelectListItem>();
            SelectListItem impu1 = new SelectListItem() { Text = "No Pagado", Value = "0", Selected = false };
            SelectListItem impu2 = new SelectListItem() { Text = "Pagado", Value = "1", Selected = false };
            Estatus_2.Add(impu1);
            Estatus_2.Add(impu2);
            ViewBag.Estatus_2 = Estatus_2;
            (from t in Estatus_2 where (t.Value == clientes.Estatus_2) select t).First().Selected = true;

            List<SelectListItem> Estatus_3 = new List<SelectListItem>();
            SelectListItem cita1 = new SelectListItem() { Text = "No Asignada", Value = "0", Selected = false };
            SelectListItem cita2 = new SelectListItem() { Text = "Asignada", Value = "1", Selected = false };
            Estatus_3.Add(cita1);
            Estatus_3.Add(cita2);
            ViewBag.Estatus_3 = Estatus_3;
            (from t in Estatus_3 where (t.Value == clientes.Estatus_3) select t).First().Selected = true;

            List<SelectListItem> Estatus_4 = new List<SelectListItem>();
            SelectListItem docu1 = new SelectListItem() { Text = "No Entregada", Value = "0", Selected = false };
            SelectListItem docu2 = new SelectListItem() { Text = "Entregada", Value = "1", Selected = false };
            Estatus_4.Add(docu1);
            Estatus_4.Add(docu2);
            ViewBag.Estatus_4 = Estatus_4;
            (from t in Estatus_4 where (t.Value == clientes.Estatus_4) select t).First().Selected = true;

            List<SelectListItem> Estatus_5 = new List<SelectListItem>();
            SelectListItem ds1 = new SelectListItem() { Text = "Incompleto", Value = "0", Selected = false };
            SelectListItem ds2 = new SelectListItem() { Text = "Completo", Value = "1", Selected = false };
            Estatus_5.Add(ds1);
            Estatus_5.Add(ds2);
            ViewBag.Estatus_5 = Estatus_5;
            if (clientes.Estatus_5 != null)
            {
                (from t in Estatus_5 where (t.Value == clientes.Estatus_5) select t).First().Selected = true;

            }

            List<SelectListItem> Estatus_6 = new List<SelectListItem>();
            SelectListItem CCitas1 = new SelectListItem() { Text = "No Entregado", Value = "0", Selected = false };
            SelectListItem CCitas2 = new SelectListItem() { Text = "Entregado", Value = "1", Selected = false };
            Estatus_6.Add(CCitas1);
            Estatus_6.Add(CCitas2);
            ViewBag.Estatus_6 = Estatus_6;
            (from t in Estatus_6 where (t.Value == clientes.Estatus_6) select t).First().Selected = true;

            List<SelectListItem> Estatus_7 = new List<SelectListItem>();
            SelectListItem CDS1 = new SelectListItem() { Text = "No Entregado", Value = "0", Selected = false };
            SelectListItem CDS2 = new SelectListItem() { Text = "Entregado", Value = "1", Selected = false };
            Estatus_7.Add(CDS1);
            Estatus_7.Add(CDS2);
            ViewBag.Estatus_7 = Estatus_7;
            (from t in Estatus_7 where (t.Value == clientes.Estatus_7) select t).First().Selected = true;

            List<SelectListItem> Estatus_8 = new List<SelectListItem>();
            SelectListItem Formu1 = new SelectListItem() { Text = "No Entregado", Value = "0", Selected = false };
            SelectListItem Formu2 = new SelectListItem() { Text = "Entregado", Value = "1", Selected = false };
            Estatus_8.Add(Formu1);
            Estatus_8.Add(Formu2);
            ViewBag.Estatus_8 = Estatus_8;
            (from t in Estatus_8 where (t.Value == clientes.Estatus_8) select t).First().Selected = true;

            List<SelectListItem> Estatus_9 = new List<SelectListItem>();
            SelectListItem pre1 = new SelectListItem() { Text = "No Realizada", Value = "0", Selected = false };
            SelectListItem pre2 = new SelectListItem() { Text = "Realizada", Value = "1", Selected = false };
            Estatus_9.Add(pre1);
            Estatus_9.Add(pre2);
            ViewBag.Estatus_9 = Estatus_9;
            (from t in Estatus_9 where (t.Value == clientes.Estatus_9) select t).First().Selected = true;

            List<SelectListItem> Estatus_10 = new List<SelectListItem>();
            SelectListItem EFinal1 = new SelectListItem() { Text = "No Status", Value = "1", Selected = false };
            SelectListItem EFinal2 = new SelectListItem() { Text = "Proceso Administrativo", Value = "2", Selected = false };
            SelectListItem EFinal4 = new SelectListItem() { Text = "Rechazado", Value = "3", Selected = false };
            SelectListItem EFinal3 = new SelectListItem() { Text = "Aprobado", Value = "4", Selected = false };
            Estatus_10.Add(EFinal1);
            Estatus_10.Add(EFinal2);
            Estatus_10.Add(EFinal3);
            Estatus_10.Add(EFinal4);
            ViewBag.Estatus_10 = Estatus_10;
            if (clientes.Estatus_10 != null)
            {
                (from t in Estatus_10 where (t.Value == clientes.Estatus_10) select t).First().Selected = true;

            }

            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "CLienteID,Nombre,Apellido,Fecha_nacimiento,Cedula,Sexo,Estado_civil,Email,Fecha_ingreso,Pasaporte,Tel_1,Tel_2,Tel_3,Comentario,Estatus_1,Estatus_2,Estatus_3,Estatus_4,Estatus_5,Estatus_6,Estatus_7,Estatus_8,Estatus_9,Estatus_10,TipoDePago,P1,P2,P3,P4,P5,P6,P7,P8,P9,P10,Ocupacion,Empresa_Nombre,Empresa_Dir,Empresa_Tel,Empresa_Labor,Direccion,Codigo_DS")] Clientes clientes
                )
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
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


        //GET: Clientes/Reportes
        public ActionResult Reportes(string searchString)
        {
            var clientes = from c in db.Clientes
                           select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                clientes = clientes.Where(c => c.Nombre.Contains(searchString)
                                         || c.Apellido.Contains(searchString));
            }


            return View(clientes.ToList());
        }


        // POST: Clientes/Reportes/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reportess()
        {

            return View();
        }
    }
}
