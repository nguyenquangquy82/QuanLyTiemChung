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
    public class ChiTietPhieuXuatController : Controller
    {
        private QUANLYTIEMCHUNGEntities db = new QUANLYTIEMCHUNGEntities();

        // GET: ChiTietPhieuXuat
        public ActionResult Index()
        {
            var chiTietPhieuXuats = db.ChiTietPhieuXuats.Include(c => c.PhieuXuat).Include(c => c.Vaccine);
            return View(chiTietPhieuXuats.ToList());
        }

        // GET: ChiTietPhieuXuat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuXuat chiTietPhieuXuat = db.ChiTietPhieuXuats.Find(id);
            if (chiTietPhieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuXuat);
        }

        // GET: ChiTietPhieuXuat/Create
        public ActionResult Create()
        {
            ViewBag.idPhieuXuat = new SelectList(db.PhieuXuats, "idPhieuXuat", "idPhieuXuat");
            ViewBag.idVaccine = new SelectList(db.Vaccines, "idVaccine", "idVaccine");
            return View();
        }

        // POST: ChiTietPhieuXuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPhieuXuat,idVaccine,soLuongXuat")] ChiTietPhieuXuat chiTietPhieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietPhieuXuats.Add(chiTietPhieuXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPhieuXuat = new SelectList(db.PhieuXuats, "idPhieuXuat", "idPhieuXuat", chiTietPhieuXuat.idPhieuXuat);
            ViewBag.idVaccine = new SelectList(db.Vaccines, "idVaccine", "idVaccine", chiTietPhieuXuat.idVaccine);
            return View(chiTietPhieuXuat);
        }

        // GET: ChiTietPhieuXuat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuXuat chiTietPhieuXuat = db.ChiTietPhieuXuats.Find(id);
            if (chiTietPhieuXuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPhieuXuat = new SelectList(db.PhieuXuats, "idPhieuXuat", "idPhieuXuat", chiTietPhieuXuat.idPhieuXuat);
            ViewBag.idVaccine = new SelectList(db.Vaccines, "idVaccine", "idVaccine", chiTietPhieuXuat.idVaccine);
            return View(chiTietPhieuXuat);
        }

        // POST: ChiTietPhieuXuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPhieuXuat,idVaccine,soLuongXuat")] ChiTietPhieuXuat chiTietPhieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietPhieuXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPhieuXuat = new SelectList(db.PhieuXuats, "idPhieuXuat", "idPhieuXuat", chiTietPhieuXuat.idPhieuXuat);
            ViewBag.idVaccine = new SelectList(db.Vaccines, "idVaccine", "idVaccine", chiTietPhieuXuat.idVaccine);
            return View(chiTietPhieuXuat);
        }

        // GET: ChiTietPhieuXuat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuXuat chiTietPhieuXuat = db.ChiTietPhieuXuats.Find(id);
            if (chiTietPhieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuXuat);
        }

        // POST: ChiTietPhieuXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietPhieuXuat chiTietPhieuXuat = db.ChiTietPhieuXuats.Find(id);
            db.ChiTietPhieuXuats.Remove(chiTietPhieuXuat);
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
