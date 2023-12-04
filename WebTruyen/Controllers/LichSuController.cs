using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;



namespace WebTruyen.Controllers
{
    public class LichSuController : Controller
    {
        // GET: LichSu
        public dataDataContext data = new dataDataContext();
        public ActionResult LichSuTruyen()
        {


            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }
            NguoiDung ND = Session["TaiKhoan"] as NguoiDung;
            var Lichsu = data.Lichsus.ToList();




            var currentUser = data.NguoiDungs.SingleOrDefault(u => u.MaNguoiDung == ND.MaNguoiDung);
            if (currentUser != null)
            { 
                var lichsu = data.Lichsus.Where(a => a.MaNguoiDung == currentUser.MaNguoiDung).ToList(); ;
                return View(lichsu);
            }
            return View();
        }
        public ActionResult AddLichSuTruyen(int matruyen)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }

            NguoiDung ND = Session["TaiKhoan"] as NguoiDung;

            var currentUser = data.NguoiDungs.SingleOrDefault(u => u.MaNguoiDung == ND.MaNguoiDung);

            if (currentUser != null)
            {
                var LichSu = new Lichsu
                {
                    MaNguoiDung = currentUser.MaNguoiDung,
                    MaTruyen = matruyen,
                     Thoigiandoc = DateTime.Now
                };
                data.Lichsus.InsertOnSubmit(LichSu);
                data.SubmitChanges();
            }



            
            return RedirectToAction("Index", "TrangChu");
        }
    }
}