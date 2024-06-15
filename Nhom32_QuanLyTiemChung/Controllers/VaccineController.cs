using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nhom32_QuanLyTiemChung.Models;

namespace Nhom32_QuanLyTiemChung.Controllers
{
    public class VaccineController : Controller
    {
        private QUANLYTIEMCHUNGEntities db = new QUANLYTIEMCHUNGEntities();

        // GET: Vaccine
        public ActionResult Index()
        {
            return View(db.Vaccines.ToList());
        }

        // GET: Vaccine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = db.Vaccines.Find(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            return View(vaccine);
        }

        // GET: Vaccine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vaccine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVaccine,tenVaccine,nuocSanXuat,nhaSanXuat,moTaBenh,kyTiem,soLuongMuiTiem,soLuongConLai")] Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                db.Vaccines.Add(vaccine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vaccine);
        }

        // GET: Vaccine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = db.Vaccines.Find(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            return View(vaccine);
        }

        // POST: Vaccine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVaccine,tenVaccine,nuocSanXuat,nhaSanXuat,moTaBenh,kyTiem,soLuongMuiTiem,soLuongConLai")] Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vaccine);
        }

        // GET: Vaccine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = db.Vaccines.Find(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            return View(vaccine);
        }

        // POST: Vaccine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaccine vaccine = db.Vaccines.Find(id);
            db.Vaccines.Remove(vaccine);
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
