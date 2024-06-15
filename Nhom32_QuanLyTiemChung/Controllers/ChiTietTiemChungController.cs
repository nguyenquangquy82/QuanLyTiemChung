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
    public class ChiTietTiemChungController : Controller
    {
        private QUANLYTIEMCHUNGEntities db = new QUANLYTIEMCHUNGEntities();

        // GET: ChiTietTiemChung
        public ActionResult Index()
        {
            var chiTietTiemChungs = db.ChiTietTiemChungs.Include(c => c.ThongTinCanBo).Include(c => c.Tre).Include(c => c.Vaccine);
            return View(chiTietTiemChungs.ToList());
        }

        // GET: ChiTietTiemChung/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietTiemChung chiTietTiemChung = db.ChiTietTiemChungs.Find(id);
            if (chiTietTiemChung == null)
            {
                return HttpNotFound();
            }
            return View(chiTietTiemChung);
        }

        // GET: ChiTietTiemChung/Create
        public ActionResult Create()
        {
            ViewBag.idCanBo = new SelectList(db.ThongTinCanBoes, "idCanBo", "idCanBo");
            ViewBag.idTre = new SelectList(db.Tres, "idTre", "idTre");
            ViewBag.idVaccine = new SelectList(db.Vaccines, "idVaccine", "idVaccine");
            return View();
        }

        // POST: ChiTietTiemChung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMuiTiem,idTre,idVaccine,ngayTiem,tinhTrang,thuTuMuiTiem,idCanBo")] ChiTietTiemChung chiTietTiemChung)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietTiemChungs.Add(chiTietTiemChung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCanBo = new SelectList(db.ThongTinCanBoes, "idCanBo", "idCanBo", chiTietTiemChung.idCanBo);
            ViewBag.idTre = new SelectList(db.Tres, "idTre", "idTre", chiTietTiemChung.idTre);
            ViewBag.idVaccine = new SelectList(db.Vaccines, "idVaccine", "idVaccine", chiTietTiemChung.idVaccine);
            return View(chiTietTiemChung);
        }

        // GET: ChiTietTiemChung/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietTiemChung chiTietTiemChung = db.ChiTietTiemChungs.Find(id);
            if (chiTietTiemChung == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCanBo = new SelectList(db.ThongTinCanBoes, "idCanBo", "idCanBo", chiTietTiemChung.idCanBo);
            ViewBag.idTre = new SelectList(db.Tres, "idTre", "idTre", chiTietTiemChung.idTre);
            ViewBag.idVaccine = new SelectList(db.Vaccines, "idVaccine", "idVaccine", chiTietTiemChung.idVaccine);
            return View(chiTietTiemChung);
        }

        // POST: ChiTietTiemChung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMuiTiem,idTre,idVaccine,ngayTiem,tinhTrang,thuTuMuiTiem,idCanBo")] ChiTietTiemChung chiTietTiemChung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietTiemChung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCanBo = new SelectList(db.ThongTinCanBoes, "idCanBo", "idCanBo", chiTietTiemChung.idCanBo);
            ViewBag.idTre = new SelectList(db.Tres, "idTre", "idTre", chiTietTiemChung.idTre);
            ViewBag.idVaccine = new SelectList(db.Vaccines, "idVaccine", "idVaccine", chiTietTiemChung.idVaccine);
            return View(chiTietTiemChung);
        }

        // GET: ChiTietTiemChung/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietTiemChung chiTietTiemChung = db.ChiTietTiemChungs.Find(id);
            if (chiTietTiemChung == null)
            {
                return HttpNotFound();
            }
            return View(chiTietTiemChung);
        }

        // POST: ChiTietTiemChung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietTiemChung chiTietTiemChung = db.ChiTietTiemChungs.Find(id);
            db.ChiTietTiemChungs.Remove(chiTietTiemChung);
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
