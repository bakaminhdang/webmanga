using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;
using PagedList;
using System.IO;


namespace WebTruyen.Areas.Admin.Controllers
{
    public class ChuongController : Controller
    {
        // GET: Admin/Chuong
        dataDataContext db = new dataDataContext();
        // GET: Admin/Truyen
        public ActionResult Index(int? page)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int iPageNum = (page ?? 1);
            int iPageSize = 7;

            return View(db.Chuongs.ToList().OrderBy(n => n.MaChuong).ToPagedList(iPageNum, iPageSize));
        }
       [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MaTruyen = new SelectList(db.Truyens.ToList().OrderBy(n => n.MaTruyen), "MaTruyen", "TenTruyen");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Chuong chuong, FormCollection f, HttpPostedFileBase fFileUpload)
        {
            ViewBag.MaTruyen = new SelectList(db.Truyens.ToList().OrderBy(n => n.MaTruyen), "MaTruyen", "TenTruyen");
            if (fFileUpload == null)
            {
                ViewBag.ThongBao = "Hãy chọn ảnh bìa";
              
                ViewBag.MaTheLoai = new SelectList(db.TheLoais.ToList().OrderBy(n => n.MaTheLoai), "MaTruyen", "TenTruyen", int.Parse(f["MaTruyen"]));
                return View();
            }
            else
                if (ModelState.IsValid)
            {
                var sFileName = Path.GetFileName(fFileUpload.FileName);
                var path = Path.Combine(Server.MapPath("~/img"), sFileName);
                if (!System.IO.File.Exists(sFileName))
                {
                    fFileUpload.SaveAs(path);
                }
                chuong.MaTruyen = int.Parse(f["MaTruyen"]);
                chuong.hinh = sFileName;
                    chuong.SoChuong = int.Parse(f["SoChuong"]);
                    chuong.TieuDe = f["TieuDe"];
                    chuong.NoiDung = f["NoiDung"];


                    db.Chuongs.InsertOnSubmit(chuong);
                    db.SubmitChanges();
                    return RedirectToAction("Index");

                }
                  return RedirectToAction("Index");
                }


        public ActionResult Details(int id)
        {
            var sach = db.Chuongs.SingleOrDefault(n => n.MaChuong == id);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var sach = db.Chuongs.SingleOrDefault(n => n.MaChuong == id);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, FormCollection f)
        {
            var sach = db.Chuongs.SingleOrDefault(n => n.MaChuong == id);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
           
            db.Chuongs.DeleteOnSubmit(sach);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var chuong = db.Chuongs.SingleOrDefault(n => n.MaChuong == id);
            if (chuong == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaTruyen = new SelectList(db.Truyens.ToList().OrderBy(n => n.MaTruyen), "MaTruyen", "TenTruyen");
            return View(chuong);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(FormCollection f, HttpPostedFileBase fFileUpload)
        {
            var chuong = db.Chuongs.SingleOrDefault(n => n.MaChuong == int.Parse(f["MaChuong"]));
            ViewBag.MaTruyen = new SelectList(db.Truyens.ToList().OrderBy(n => n.MaTruyen), "MaTruyen", "TenTruyen",chuong.MaChuong);
            if (ModelState.IsValid)
            {
                if (fFileUpload != null)
                {
                    var sFileName = Path.GetFileName(fFileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/img"), sFileName);
                    if (!System.IO.File.Exists(path))
                    {
                        fFileUpload.SaveAs(path);
                    }
                    chuong.hinh = sFileName;

                }
                chuong.NoiDung = f["NoiDung"];
                
                chuong.MaChuong = int.Parse(f["MaChuong"]);
               
                chuong.MaTruyen = int.Parse(f["MaTruyen"]);
                
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(chuong);
        }
    }
}