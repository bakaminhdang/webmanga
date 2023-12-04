using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;

namespace WebTruyen.Controllers
{
    public class BinhLuanController : Controller
    {
        // GET: BinhLuan
        dataDataContext data = new dataDataContext();
        public ActionResult Index(int id)
        {
            var list = data.BinhLuans.Where(c => c.MaTruyen == id);

            return PartialView(list);
        }
        /*[HttpGet]
        public ActionResult AddBinhLuan(int MaTruyen)
        {
            var list = data.BinhLuans.Where(c => c.MaTruyen == MaTruyen);

            return PartialView(list);
        }
        [HttpPost]
        public ActionResult AddBinhLuan(FormCollection f, BinhLuan BL,int MaTruyen)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }

            NguoiDung ND = Session["TaiKhoan"] as NguoiDung;

            var currentUser = data.NguoiDungs.SingleOrDefault(u => u.MaNguoiDung == ND.MaNguoiDung);

            var sNoiDung = f["NoiDung"];
           
            if (currentUser != null)
            {
                if (ModelState.IsValid)
                {

                    MaTruyen = (int)BL.MaTruyen;
                    BL.MaNguoiDung = currentUser.MaNguoiDung;
                    BL.ThoiGian = DateTime.Now;
                    sNoiDung = BL.NoiDung;
                    data.BinhLuans.InsertOnSubmit(BL);
                    data.SubmitChanges();
                }
            }
            return RedirectToAction("Index","TrangChu");
        }*/
        public ActionResult AddBinhLuan(int id, string url)
        {
            BinhLuan bl = new BinhLuan();
            string inputValue = Request.Cookies["nd"]?.Value;

            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }

            NguoiDung ND = Session["TaiKhoan"] as NguoiDung;

            var currentUser = data.NguoiDungs.SingleOrDefault(u => u.MaNguoiDung == ND.MaNguoiDung);

            if (ModelState.IsValid)
            {

                bl.NoiDung = inputValue;
                bl.MaTruyen = id;
                bl.MaNguoiDung = currentUser.MaNguoiDung;
                bl.ThoiGian = DateTime.Now;

                data.BinhLuans.InsertOnSubmit(bl);
                data.SubmitChanges();

            }

            return RedirectToAction("Index", "TrangChu");
        }
    }
}