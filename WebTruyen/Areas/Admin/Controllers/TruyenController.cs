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
    public class TruyenController : Controller
    {
        dataDataContext db = new dataDataContext();
        // GET: Admin/Truyen
        public ActionResult Index(int? page)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int iPageNum = (page ?? 1);
            int iPageSize =7;

            return View(db.Truyens.ToList().OrderBy(n => n.MaTruyen).ToPagedList(iPageNum, iPageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MaTheLoai = new SelectList(db.TheLoais.ToList().OrderBy(n => n.MaTheLoai), "MaTheLoai", "TenTheLoai");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Truyen truyen, FormCollection f, HttpPostedFileBase fFileUpload)
        {
            ViewBag.MaTheLoai = new SelectList(db.TheLoais.ToList().OrderBy(n => n.MaTheLoai), "MaTheLoai", "TenTheLoai");
            if (fFileUpload == null)
            {
                ViewBag.ThongBao = "Hãy chọn ảnh bìa";
                ViewBag.TenTruyen = f["TenTruyen"];
                ViewBag.TacGia = f["TacGia"];
                ViewBag.MoTa = f["MoTa"];
                ViewBag.TrangThai = f["TrangThai"];
                ViewBag.MaTheLoai = f["MaTheLoai"];
                ViewBag.NgayXuatBan = f["NgayXuatBan"];
                ViewBag.SoLuotXem = f["SoLuotXem"];
                ViewBag.DiemDanhGia = f["DiemDanhGia"];
                ViewBag.GiaTruyen = f["GiaTruyen"];
                ViewBag.SoLuongTon = f["SoLuongTon"];
                ViewBag.SoLuongBan = f["SoLuongBan"];
                ViewBag.MaTheLoai = new SelectList(db.TheLoais.ToList().OrderBy(n => n.MaTheLoai), "MaTheLoai", "TenTheLoai", int.Parse(f["MaChuDe"]));
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var sFileName = Path.GetFileName(fFileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/img"), sFileName);

                    if (!System.IO.File.Exists(sFileName))
                    {
                        fFileUpload.SaveAs(path);
                    }
                    truyen.TenTruyen = f["TenTruyen"];
                    truyen.TacGia = f["TacGia"];
                    truyen.MoTa = f["MoTa"];
                    truyen.TrangThai = f["TrangThai"];
                    truyen.MaTheLoai = int.Parse(f["MaTheLoai"]);
                    truyen.NgayXuatBan = Convert.ToDateTime(f["NgayXuatBan"]);
                    truyen.Hinh = sFileName;
                    truyen.SoLuotXem = int.Parse(f["SoLuotXem"]);
                    truyen.DiemDanhGia = int.Parse(f["DiemDanhGia"]);
                    truyen.GiaTruyen = int.Parse(f["GiaTruyen"]);
                    truyen.SoLuongTon = int.Parse(f["SoLuongTon"]);
                    truyen.SoLuongBan = int.Parse(f["SoLuongBan"]);

                    db.Truyens.InsertOnSubmit(truyen);
                    db.SubmitChanges();
                    return RedirectToAction("Index");

                }
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            var sach = db.Truyens.SingleOrDefault(n => n.MaTruyen == id);
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
            var sach = db.Truyens.SingleOrDefault(n => n.MaTruyen == id);
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
            var sach = db.Truyens.SingleOrDefault(n => n.MaTruyen == id);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var ctdh = db.ChiTietDonHangs.Where(ct => ct.MaTruyen == id);
            if (ctdh.Count() > 0)
            {
                ViewBag.ThongBao = "Sách này đã có trong chi tiết đặt hàng <br>" + "Nếu muốn xóa thì phải xoa hết mã sách này trong bảng chi tiết đặt hàng";
                return View(sach);
            }
            db.Truyens.DeleteOnSubmit(sach);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sach = db.Truyens.SingleOrDefault(n => n.MaTruyen == id);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaTheLoai = new SelectList(db.TheLoais.ToList().OrderBy(n => n.MaTheLoai), "MaTheLoai", "TenTheLoai");
            return View(sach);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(FormCollection f, HttpPostedFileBase fFileUpload)
        {
            var truyen = db.Truyens.SingleOrDefault(n => n.MaTruyen == int.Parse(f["MaTruyen"]));
            ViewBag.MaTheLoai = new SelectList(db.TheLoais.ToList().OrderBy(n => n.MaTheLoai), "MaTheLoai", "TenTheLoai",truyen.MaTruyen);
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
                    truyen.Hinh = sFileName;

                }
                truyen.TenTruyen = f["TenTruyen"];
                truyen.TacGia = f["TacGia"];
                truyen.MoTa = f["MoTa"];
                truyen.TrangThai = f["TrangThai"];
                truyen.MaTheLoai = int.Parse(f["MaTheLoai"]);
                truyen.NgayXuatBan = Convert.ToDateTime(f["NgayXuatBan"]);
                truyen.SoLuotXem = int.Parse(f["iSoLuotXem"]);
                truyen.DiemDanhGia = int.Parse(f["iDiemDanhGia"]);
                truyen.GiaTruyen = int.Parse(f["iGiaTruyen"]);
                truyen.SoLuongTon = int.Parse(f["iSoLuongTon"]);
                truyen.SoLuongBan = int.Parse(f["iSoLuongBan"]);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(truyen);
        }
    }
}