using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;

namespace WebTruyen.Controllers
{
    
    public class TruyenController : Controller
    {
        dataDataContext data = new dataDataContext();
        // GET: Truyen


        public ActionResult Index(int id, int id2)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }

            if (KiemTraTaiKhoan(id))
            {

                Chuong model = data.Chuongs.FirstOrDefault(c => c.MaTruyen == id && c.MaChuong == id2);
                return View(model);
            }
            else
            {
               
                return View("PurchaseRequired");
            }
        }
        public ActionResult Chuong(int id)
        {

            var item = from c in data.Chuongs where c.MaTruyen == id select c;

           
            return PartialView(item);
        }
        public ActionResult ChuyenChuong(int id, int id2, bool nextChapter)
        {
            // Sử dụng LINQ để lấy thông tin về chương tiếp theo hoặc chương trước đó
            var targetChapter = nextChapter
                ? data.Chuongs
                    .Where(c => c.MaTruyen == id && c.MaChuong > id2)
                    .OrderBy(c => c.MaChuong)
                    .FirstOrDefault()
                : data.Chuongs
                    .Where(c => c.MaTruyen == id && c.MaChuong < id2)
                    .OrderByDescending(c => c.MaChuong)
                    .FirstOrDefault();

            return View("Index", targetChapter);
        }
        private bool KiemTraTaiKhoan(int storyId)
        {

            
            NguoiDung ND = Session["TaiKhoan"] as NguoiDung;
            var currentUser = data.NguoiDungs.SingleOrDefault(u => u.MaNguoiDung == ND.MaNguoiDung);
            var tk = data.NguoiDungs.SingleOrDefault(t => t.MaNguoiDung == ND.MaNguoiDung);

            if (ND != null && tk.QuyenTruyCap == "VIP")
            {
                // Nếu là người dùng VIP, cho phép đọc mọi truyện
                return true;
            }
            else
            {
                // Kiểm tra xem người dùng đã mua truyện này chưa
                // Kiểm tra xem người dùng đã mua truyện này chưa
                int userId = ND.MaNguoiDung; // Lấy id của người dùng
                bool hasPurchased = data.ChiTietDonHangs
                    .Join(data.DonHangs, od => od.MaDonHang, o => o.MaDonHang, (od, o) => new { od, o })
                    .Any(join => join.o.MaNguoiDung == userId && join.od.MaTruyen == storyId);

                return hasPurchased;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                data.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult DownloadChapter(int storyId, int chapterId)
        {
            var chapter = data.Chuongs.SingleOrDefault(c => c.MaTruyen == storyId && c.MaChuong == chapterId);

            

            if (chapter == null)
            {
                // Xử lý trường hợp ảnh không tồn tại
                return HttpNotFound();
            }

            string imagePath = Server.MapPath("~/img/truyen/" + chapter.hinh);

            // Đọc tệp thành mảng byte
            byte[] fileBytes = System.IO.File.ReadAllBytes(imagePath);

            var fileName = $"{storyId}_Chapter_{chapterId}.jpg";

            return File(fileBytes, "image/jpeg", fileName);
        }
    }
}
