using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;

namespace WebTruyen.Controllers
{
    public class TruyenYeuThichController : Controller
    {
        dataDataContext data = new dataDataContext();
        // GET: TruyenYeuThich
        /* public List<lstTruyenYeuThich> LayTruyen()
         {
             NguoiDung ND = Session["user"] as NguoiDung;

             List<lstTruyenYeuThich> lstTruyen = new List<lstTruyenYeuThich>();
             if ( ND!= null)
             {
                 var favoriteBooks = data.TruyenYeuThiches.Where(a => a.MaNguoiDung == ND.MaNguoiDung).ToList();
                 foreach (var p in favoriteBooks)
                 {
                     lstTruyenYeuThich c = new  lstTruyenYeuThich((int)p.MaTruyen);
                     lstTruyen.Add(c);

                 }
             }

             return lstTruyen;
         }*/

        public ActionResult FavoriteBooks()
        {


            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }
            NguoiDung ND = Session["TaiKhoan"] as NguoiDung;
            var TruyenYeuThich = data.TruyenYeuThiches.ToList();




            var currentUser = data.NguoiDungs.SingleOrDefault(u => u.MaNguoiDung == ND.MaNguoiDung);
            if (currentUser != null)
            {

                /*var favoriteBooks = data.TruyenYeuThiches.Where(a => a.MaNguoiDung == currentUser.MaNguoiDung ).ToList();*/
                // Làm việc với danh sách truyện yêu thích tại đây và truyền chúng đến view
                /*
                                var lstTruyenYeuThich = new lstTruyenYeuThich
                                {
                                    truyenYeuThiches = TruyenYeuThich,
                                    Truyens = Truyen
                                };*/
                var favoriteBooks = data.TruyenYeuThiches.Where(a => a.MaNguoiDung == currentUser.MaNguoiDung).ToList(); ;
                return View(favoriteBooks);
            }
            /* List<lstTruyenYeuThich> lst = LayTruyen();

             if (lst.Count > 0)
             {

                 return View(lst);
             }*/
            return View();
        }

        public ActionResult AddTruyenYeuThich(int MaTruyen)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }

            NguoiDung ND = Session["TaiKhoan"] as NguoiDung;

            var currentUser = data.NguoiDungs.SingleOrDefault(u => u.MaNguoiDung == ND.MaNguoiDung);


            if (currentUser != null)
            {
                var truyenYeuThich = new TruyenYeuThich
                {
                    MaNguoiDung = currentUser.MaNguoiDung,
                    MaTruyen = MaTruyen
                };
                data.TruyenYeuThiches.InsertOnSubmit(truyenYeuThich);
                data.SubmitChanges();
            }
            return RedirectToAction("Index", "TrangChu");
        }


        public ActionResult RemoveFromFavorites(int bookid)
        {
            NguoiDung ND = Session["TaiKhoan"] as NguoiDung;



            var favoriteBook = data.TruyenYeuThiches.FirstOrDefault(a => a.MaNguoiDung == ND.MaNguoiDung);
            if (favoriteBook != null)
            {
                data.TruyenYeuThiches.DeleteOnSubmit(favoriteBook);
                data.SubmitChanges();
            }
            else
            {
                return RedirectToAction("Index", "TrangChu");
            }

            // Redirect hoặc trả về view tùy thuộc vào logic ứng dụng của bạn
            return RedirectToAction("FavoriteBooks", "TruyenYeuThich");
        }
    }
}