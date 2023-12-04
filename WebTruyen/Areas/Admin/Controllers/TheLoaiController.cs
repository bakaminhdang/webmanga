using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;

namespace WebTruyen.Areas.Admin.Controllers
{
    public class TheLoaiController : Controller
    {
        // GET: Admin/TheLoai
        dataDataContext db = new dataDataContext();
      
        public ActionResult Index(int? page)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int iPageNum = (page ?? 1);
            int iPageSize = 7;

            return View(db.TheLoais.ToList().OrderBy(n => n.MaTheLoai).ToPagedList(iPageNum, iPageSize));
        }
        public ActionResult Details(int id)
        {
            var tl = db.TheLoais.SingleOrDefault(n => n.MaTheLoai == id);
            if (tl == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tl);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(TheLoai theloai, FormCollection f)
        {
            if (f["sTenTheLoai"] == null)
            {
                ViewBag.TenChuDe = f["sTenTheLoai"];

                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {

                    theloai.TenTheLoai = f["sTenTheLoai"];
                    db.TheLoais.InsertOnSubmit(theloai);
                    db.SubmitChanges();
                    return RedirectToAction("Index");

                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var chude = db.TheLoais.SingleOrDefault(n => n.MaTheLoai == id);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(chude);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(FormCollection f)
        {
            var chude = db.TheLoais.SingleOrDefault(n => n.MaTheLoai == int.Parse(f["iMaTL"]));
            if (ModelState.IsValid)
            {

                chude.TenTheLoai = f["sTenTheLoai"];
                chude.MaTheLoai = int.Parse(f["iMaTL"]);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(chude);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var theloai = db.TheLoais.SingleOrDefault(n => n.MaTheLoai == id);
            if (theloai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(theloai);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, FormCollection f)
        {
            var theloai = db.TheLoais.SingleOrDefault(n => n.MaTheLoai == id);
            if (theloai == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.TheLoais.DeleteOnSubmit(theloai);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}