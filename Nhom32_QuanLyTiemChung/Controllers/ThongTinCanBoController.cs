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
    public class ThongTinCanBoController : Controller
    {
        private QUANLYTIEMCHUNGEntities db = new QUANLYTIEMCHUNGEntities();

        // GET: ThongTinCanBo
        public ActionResult Index()
        {
            var thongTinCanBoes = db.ThongTinCanBoes.Include(t => t.ChucVu).Include(t => t.DonVi).Include(t => t.TaiKhoan);
            return View(thongTinCanBoes.ToList());
        }

        // GET: ThongTinCanBo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinCanBo thongTinCanBo = db.ThongTinCanBoes.Find(id);
            if (thongTinCanBo == null)
            {
                return HttpNotFound();
            }
            return View(thongTinCanBo);
        }

        // GET: ThongTinCanBo/Create
        public ActionResult Create()
        {
            ViewBag.idChucVu = new SelectList(db.ChucVus, "idChucVu", "idChucVu");
            ViewBag.idDonVi = new SelectList(db.DonVis, "idDonVi", "idDonVi");
            ViewBag.idTaiKhoan = new SelectList(db.TaiKhoans, "idTK", "idTK");
            return View();
        }

        // POST: ThongTinCanBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCanBo,hoTen,SDT,eMail,CCCD,diaChi,gioiTinh,idChucVu,idTaiKhoan,idDonVi")] ThongTinCanBo thongTinCanBo)
        {
            if (ModelState.IsValid)
            {
                db.ThongTinCanBoes.Add(thongTinCanBo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idChucVu = new SelectList(db.ChucVus, "idChucVu", "idChucVu", thongTinCanBo.idChucVu);
            ViewBag.idDonVi = new SelectList(db.DonVis, "idDonVi", "idDonVi", thongTinCanBo.idDonVi);
            ViewBag.idTaiKhoan = new SelectList(db.TaiKhoans, "idTK", "idTK", thongTinCanBo.idTaiKhoan);
            return View(thongTinCanBo);
        }

        // GET: ThongTinCanBo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinCanBo thongTinCanBo = db.ThongTinCanBoes.Find(id);
            if (thongTinCanBo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idChucVu = new SelectList(db.ChucVus, "idChucVu", "idChucVu", thongTinCanBo.idChucVu);
            ViewBag.idDonVi = new SelectList(db.DonVis, "idDonVi", "idDonVi", thongTinCanBo.idDonVi);
            ViewBag.idTaiKhoan = new SelectList(db.TaiKhoans, "idTK", "idTK", thongTinCanBo.idTaiKhoan);
            return View(thongTinCanBo);
        }

        // POST: ThongTinCanBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCanBo,hoTen,SDT,eMail,CCCD,diaChi,gioiTinh,idChucVu,idTaiKhoan,idDonVi")] ThongTinCanBo thongTinCanBo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongTinCanBo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idChucVu = new SelectList(db.ChucVus, "idChucVu", "idChucVu", thongTinCanBo.idChucVu);
            ViewBag.idDonVi = new SelectList(db.DonVis, "idDonVi", "idDonVi", thongTinCanBo.idDonVi);
            ViewBag.idTaiKhoan = new SelectList(db.TaiKhoans, "idTK", "idTK", thongTinCanBo.idTaiKhoan);
            return View(thongTinCanBo);
        }

        // GET: ThongTinCanBo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinCanBo thongTinCanBo = db.ThongTinCanBoes.Find(id);
            if (thongTinCanBo == null)
            {
                return HttpNotFound();
            }
            return View(thongTinCanBo);
        }

        // POST: ThongTinCanBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongTinCanBo thongTinCanBo = db.ThongTinCanBoes.Find(id);
            db.ThongTinCanBoes.Remove(thongTinCanBo);
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
