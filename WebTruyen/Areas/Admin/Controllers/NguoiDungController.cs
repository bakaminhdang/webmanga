using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;

namespace WebTruyen.Areas.Admin.Controllers
{
    public class NguoiDungController : Controller
    {
        dataDataContext db = new dataDataContext();
        // GET: Admin/NguoiDung
        public ActionResult Index(int? page)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int iPageNum = (page ?? 1);
            int iPageSize = 7;

            return View(db.NguoiDungs.ToList().OrderBy(n => n.MaNguoiDung).ToPagedList(iPageNum, iPageSize));
        }
        public ActionResult Details(int id)
        {
            var nd = db.NguoiDungs.SingleOrDefault(n => n.MaNguoiDung == id);
            if (nd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nd);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(NguoiDung nguoidung, FormCollection f)
        {
            if (f["sTenNguoiDung"] == null)
            {
                ViewBag.TenNguoiDung = f["sTenNguoiDung"];

                return View();
            }

            else if (f["sDiaChi"] == null)
            {
                ViewBag.DiaChi = f["sDiaChi"];

                return View();
            }

            else if (f["sEmail"] == null)
            {
                ViewBag.Email = f["sEmail"];

                return View();
            }
            else if (f["sSDT"] == null)
            {
                ViewBag.SDT = f["sSDT"];

                return View();
            }
            else if (f["sMatKhau"] == null)
            {
                ViewBag.MatKhau = f["sMatKhau"];

                return View();
            }
            else if (f["sQuyenTruyCap"] == null)
            {
                ViewBag.QuyenTruyCap = f["sQuyenTruyCap"];

                return View();
            }
            else if (f["sTaiKhoan"] == null)
            {
                ViewBag.QuyenTruyCap = f["sTaiKhoan"];

                return View();
            }
            
            else
            {
                if (ModelState.IsValid)
                {

                    nguoidung.Ten = f["sTenNguoiDung"]; 
                    nguoidung.DiaChi = f["sDiaChi"];
                    nguoidung.Email = f["sEmail"];
                    nguoidung.SDT = f["sSDT"];
                    nguoidung.TaiKhoan = f["sTaiKhoan"];
                    nguoidung.MatKhau = f["sMatKhau"];
                     nguoidung.QuyenTruyCap = f["sQuyenTruyCap"];
                    db.NguoiDungs.InsertOnSubmit(nguoidung);
                    db.SubmitChanges();
                    return RedirectToAction("Index");

                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var nd = db.NguoiDungs.SingleOrDefault(n => n.MaNguoiDung == id);
            if (nd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nd);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, FormCollection f)
        {
            var nd = db.NguoiDungs.SingleOrDefault(n => n.MaNguoiDung == id);
            if (nd == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.NguoiDungs.DeleteOnSubmit(nd);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var nd = db.NguoiDungs.SingleOrDefault(n => n.MaNguoiDung == id);
            if (nd == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(nd);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(FormCollection f)
        {
            var nd = db.NguoiDungs.SingleOrDefault(n => n.MaNguoiDung == int.Parse(f["iMaNguoiDung"]));
            if (ModelState.IsValid)
            {

                nd.Ten = f["sTen"];
                nd.TaiKhoan= f["sTaiKhoan"];
                nd.MaNguoiDung = int.Parse(f["iMaNguoiDung"]);
                nd.SDT = f["sSDT"];
                nd.DiaChi = f["sDiaChi"];
                nd.Email = f["sEmail"];
                nd.MatKhau = f["sMatKhau"];
               // nd.QuyenTruyCap = f["sQuyenTruyCap"];
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(nd);
        }
    }
}