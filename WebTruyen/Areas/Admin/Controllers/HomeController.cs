using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebTruyen.Models;

namespace WebTruyen.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        dataDataContext db = new dataDataContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {         
            var sTaiKhoan = f["TaiKhoan"];
            var sMatKhau = f["Password"];         
            NguoiDung ad = db.NguoiDungs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau && n.QuyenTruyCap=="Admin");
            if (ad != null)
            {
                Session["Admin"] = ad;
                Session["HoTen"] = ad.Ten;
                return RedirectToAction("Index");
            }
            else 
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng+</br>+"+" hoặc tài khoản không có quyền truy cập trang này!";
            }          
           
            return View();
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }
        public ActionResult DangXuat()
        {
            Session["Admin"] = null;
            return Redirect("Index");
        }
    }
}