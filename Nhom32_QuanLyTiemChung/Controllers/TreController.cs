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
    public class TreController : Controller
    {
        private QUANLYTIEMCHUNGEntities db = new QUANLYTIEMCHUNGEntities();

        // GET: Tre
        public ActionResult Index()
        {
            var tres = db.Tres.Include(t => t.NguoiGiamHo);
            return View(tres.ToList());
        }

        // GET: Tre/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tre tre = db.Tres.Find(id);
            if (tre == null)
            {
                return HttpNotFound();
            }
            return View(tre);
        }

        // GET: Tre/Create
        public ActionResult Create()
        {
            ViewBag.idNguoiGiamHo = new SelectList(db.NguoiGiamHoes, "idNguoiGiamHo", "idNguoiGiamHo");


            return View();
        }

        // POST: Tre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTre,idNguoiGiamHo,hoTen,ngaySinh,chieuCao,canNang")] Tre tre)
        {
            if (ModelState.IsValid)
            {
                db.Tres.Add(tre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNguoiGiamHo = new SelectList(db.NguoiGiamHoes, "idNguoiGiamHo", "idNguoiGiamHo", tre.idNguoiGiamHo);
            return View(tre);
        }

        // GET: Tre/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tre tre = db.Tres.Find(id);
            if (tre == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNguoiGiamHo = new SelectList(db.NguoiGiamHoes, "idNguoiGiamHo", "idNguoiGiamHo", tre.idNguoiGiamHo);
            return View(tre);
        }

        // POST: Tre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTre,idNguoiGiamHo,hoTen,ngaySinh,chieuCao,canNang")] Tre tre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNguoiGiamHo = new SelectList(db.NguoiGiamHoes, "idNguoiGiamHo", "idNguoiGiamHo", tre.idNguoiGiamHo);
            return View(tre);
        }

        // GET: Tre/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tre tre = db.Tres.Find(id);
            if (tre == null)
            {
                return HttpNotFound();
            }
            return View(tre);
        }

        // POST: Tre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tre tre = db.Tres.Find(id);
            db.Tres.Remove(tre);
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
