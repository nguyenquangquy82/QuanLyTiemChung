
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
    public class ChiTietPhieuNhapController : Controller
    {
        private QUANLYTIEMCHUNGEntities db = new QUANLYTIEMCHUNGEntities();

        // GET: ChiTietPhieuNhap
        public ActionResult Index()
        {
            var chiTietPhieuNhaps = db.ChiTietPhieuNhaps.Include(c => c.PhieuNhap).Include(c => c.Vaccine);
            return View(chiTietPhieuNhaps.ToList());
        }

        // GET: ChiTietPhieuNhap/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhap chiTietPhieuNhap = db.ChiTietPhieuNhaps.Find(id);
            if (chiTietPhieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuNhap);
        }

        // GET: ChiTietPhieuNhap/Create
        public ActionResult Create()
        {
            ViewBag.idPhieuNhap = new SelectList(db.PhieuNhaps, "idPhieuNhap", "idPhieuNhap");
            ViewBag.idVaccine = new SelectList(db.Vaccines, "idVaccine", "idVaccine");
            return View();
        }

        // POST: ChiTietPhieuNhap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPhieuNhap,idVaccine,ngaySanXuat,ngayHetHan,soLuongNhap,loSanXuat")] ChiTietPhieuNhap chiTietPhieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietPhieuNhaps.Add(chiTietPhieuNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPhieuNhap = new SelectList(db.PhieuNhaps, "idPhieuNhap", "idPhieuNhap", chiTietPhieuNhap.idPhieuNhap);
            ViewBag.idVaccine = new SelectList(db.Vaccines, "idVaccine", "idVaccine", chiTietPhieuNhap.idVaccine);
            return View(chiTietPhieuNhap);
        }

        // GET: ChiTietPhieuNhap/Edit/5
        // GET: ChiTietPhieuNhap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhap chiTietPhieuNhap = db.ChiTietPhieuNhaps.Find(id);
            if (chiTietPhieuNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPhieuNhap = new SelectList(db.PhieuNhaps, "idPhieuNhap", "idPhieuNhap", chiTietPhieuNhap.idPhieuNhap);
            ViewBag.idVaccine = new SelectList(db.Vaccines, "idVaccine", "idVaccine", chiTietPhieuNhap.idVaccine);
            return View(chiTietPhieuNhap);
        }

        // POST: ChiTietPhieuNhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idChiTietPhieuNhap,idPhieuNhap,idVaccine,ngaySanXuat,ngayHetHan,soLuongNhap,loSanXuat")] ChiTietPhieuNhap chiTietPhieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietPhieuNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPhieuNhap = new SelectList(db.PhieuNhaps, "idPhieuNhap", "idPhieuNhap", chiTietPhieuNhap.idPhieuNhap);
            ViewBag.idVaccine = new SelectList(db.Vaccines, "idVaccine", "idVaccine", chiTietPhieuNhap.idVaccine);
            return View(chiTietPhieuNhap);
        }


        // GET: ChiTietPhieuNhap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhap chiTietPhieuNhap = db.ChiTietPhieuNhaps.Find(id);
            if (chiTietPhieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuNhap);
        }

        // POST: ChiTietPhieuNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietPhieuNhap chiTietPhieuNhap = db.ChiTietPhieuNhaps.Find(id);
            db.ChiTietPhieuNhaps.Remove(chiTietPhieuNhap);
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
