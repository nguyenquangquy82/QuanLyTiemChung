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
    public class PhieuNhapsController : Controller
    {
        private QUANLYTIEMCHUNGEntities db = new QUANLYTIEMCHUNGEntities();

        // GET: PhieuNhaps
        public ActionResult Index()
        {
            var phieuNhaps = db.PhieuNhaps.Include(p => p.ThongTinCanBo);
            return View(phieuNhaps.ToList());
        }

        // GET: PhieuNhaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhap phieuNhap = db.PhieuNhaps.Find(id);
            if (phieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhap);
        }

        // GET: PhieuNhaps/Create
        public ActionResult Create()
        {
            ViewBag.idCanBo = new SelectList(db.ThongTinCanBoes, "idCanBo", "idCanBo");
            return View();
        }

        // POST: PhieuNhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPhieuNhap,ngayNhap,tongSoLuongNhap,ghiChu,idCanBo")] PhieuNhap phieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.PhieuNhaps.Add(phieuNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCanBo = new SelectList(db.ThongTinCanBoes, "idCanBo", "idCanBo", phieuNhap.idCanBo);
            return View(phieuNhap);
        }

        // GET: PhieuNhaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhap phieuNhap = db.PhieuNhaps.Find(id);
            if (phieuNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCanBo = new SelectList(db.ThongTinCanBoes, "idCanBo", "idCanBo", phieuNhap.idCanBo);
            return View(phieuNhap);
        }

        // POST: PhieuNhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPhieuNhap,ngayNhap,tongSoLuongNhap,ghiChu,idCanBo")] PhieuNhap phieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCanBo = new SelectList(db.ThongTinCanBoes, "idCanBo", "idCanBo", phieuNhap.idCanBo);
            return View(phieuNhap);
        }

        // GET: PhieuNhaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhap phieuNhap = db.PhieuNhaps.Find(id);
            if (phieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhap);
        }

        // POST: PhieuNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuNhap phieuNhap = db.PhieuNhaps.Find(id);
            db.PhieuNhaps.Remove(phieuNhap);
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
