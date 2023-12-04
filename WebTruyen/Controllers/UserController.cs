using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;
using System.Security.Cryptography;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Web.Helpers;
using System.Web.Services.Description;
using Microsoft.Ajax.Utilities;
using GoogleAuthentication.Services;
using Newtonsoft.Json;
using Facebook;
using System.Reflection.Emit;
using System.Collections.ObjectModel;

namespace WebTruyen.Controllers
{
    public class UserController : Controller
    {
        dataDataContext data = new dataDataContext();
        // GET: User
        [HttpGet]
        public ActionResult DangNhap()
        {
            var clientId = "38070444045-7egc4r19gf9vpbffaipreuchgh0s02g7.apps.googleusercontent.com";
            var url = "https://localhost:44319/User/LoginGoogle";
            var response=GoogleAuth.GetAuthUrl(clientId, url);

            ViewBag.response = response;

            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "727275125432274",
                redirect_uri= "https://localhost:44319/User/LoginFacebook",
                scope ="public_profile,email"

          

            }) ;

            ViewBag.Urll = loginUrl;
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            var sTenDN = f["TenDN"];
            var sMatKhau = f["MatKhau"];
            if (String.IsNullOrEmpty(sTenDN))
            {
                ViewData["Err1"] = "Bạn chưa nhập tên đăng nhập (;-;)";

            }
            else if (String.IsNullOrEmpty(sMatKhau))
            {
                ViewData["Err2"] = "Phải nhập mật khẩu ";
            }
            else
            {

                NguoiDung kh = data.NguoiDungs.SingleOrDefault(n => n.TaiKhoan == sTenDN && n.MatKhau == GetMD5(sMatKhau));
                if (kh != null)
                {
                    ViewBag.ThongBao = "dang nhap thanh cong";
                    Session["TaiKhoan"] = kh;
                    Session["SDT"] = kh.SDT;
                    Session["HoTen"] = kh.Ten;
                    Session["email"] = kh.Email;
                    return RedirectToAction("Index", "TrangChu");
                }
                else
                {
                    ViewBag.ThongBao = "ten dang nhap hoac mk k dung";

                }

            }
            Session["XLDangNhap"] = true;
            return View();
        }
        public async Task<ActionResult> LoginGoogle(string code)
        {
            var clientId = "38070444045-7egc4r19gf9vpbffaipreuchgh0s02g7.apps.googleusercontent.com";
            var url = "https://localhost:44319/User/LoginGoogle";
            var clientSecret = "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";
            var token = await GoogleAuth.GetAuthAccessToken(code, clientId, clientSecret,url);
            var userProfile = await GoogleAuth.GetProfileResponseAsync(token.AccessToken.ToString());

            var googleUser = JsonConvert.DeserializeObject<GoogleProfile>(userProfile);
           if(userProfile!=null)
            {
                Session["TaiKhoan"] = userProfile;
                Session["HoTen"] = googleUser.Name;
               
                   
                return RedirectToAction("Index", "TrangChu");
            }
            return View("DangNhap");
        }
        public ActionResult LoginFacebook(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Get("/oauth/access_token", new
            {
                client_id = "727275125432274",
                client_secret = "302d00a951a1e1a80ebd0d342dcbb54e",
                redirect_uri = "https://localhost:44319/User/LoginFacebook",
                code = code

            });
            fb.AccessToken = result.access_token;
            dynamic me = fb.Get("/me?fields=name,email");
            string name = me.name;
           
                Session["TaiKhoan"] = me;
                Session["HoTen"] = name;


                return RedirectToAction("Index", "TrangChu");
           
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index", "TrangChu");
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection f, NguoiDung ND)
        {
            var sHoTen = f["HoTen"];
            var sTaiKhoan = f["TaiKhoan"];
            var sMatKhau = f["MatKhau"];           
            var sDiaChi = f["DiaChi"];
            var sEmail = f["Email"];
            var sSDT = f["SDT"];
            string qtc = "Người dùng";
            if (String.IsNullOrEmpty(sHoTen))


            {
                ViewData["err1"] = "Ho Ten k rong";

            }
           
            else
            {
                ND.Ten = sHoTen;
                ND.TaiKhoan = sTaiKhoan;
                ND.MatKhau = GetMD5(sMatKhau);
               
                ND.Email = sEmail;
                ND.DiaChi = sDiaChi;
                ND.SDT = sSDT;
                ND.QuyenTruyCap = qtc;
                data.NguoiDungs.InsertOnSubmit(ND);
                data.SubmitChanges();
                return RedirectToAction("DangNhap");

            }
            return this.DangKy();
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
        public void SendConfirmationEmail(string toAddress, string resestCode)
        {
            var verifyUrl = "/User/" + "ResetPassword" + "/" + resestCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            string subject = "Đặt lại mật khẩu";
            string body = "Bấm vài link bên dưới để đặt lại mật khẩu" + "<br/><br><a href=" + link + ">Đặt lại mật khẩu</a> ";
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("tam2003hkt@gmail.com", "uliw obgp dqnw eetq"),
                EnableSsl = true
            };

            var mailMessage = new System.Net.Mail.MailMessage
            {
                From = new MailAddress("tam2003hkt@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(toAddress);

            smtpClient.Send(mailMessage);
        }
       
        public ActionResult ForgotPassword()
        {
            return  View();
        }
        [HttpPost]
      
        public ActionResult ForgotPassword(string EmailID)
        {
         
          
          
            string maessage = "";
         
            using (dataDataContext db = new dataDataContext())
            {
                var account = db.NguoiDungs.Where(a => a.Email == EmailID).FirstOrDefault();
                if(account != null)
                {
                    string  resestCode = Guid.NewGuid().ToString();
                    SendConfirmationEmail(account.Email, resestCode);

                    account.ResetCode = resestCode;
                    db.SubmitChanges();
                    return RedirectToAction("GuiEmailThanhCong");
                }
                else
                {
                    maessage = "Khong tim thay tai khoan";
                }
                
            }
            ViewBag.Message = maessage;
            return View();
        }
        public ActionResult ResetPassword(string id)
        {
        
            var user = data.NguoiDungs.Where(a => a.ResetCode == id).FirstOrDefault();
            if (user != null)
            {
                ResetPassword model = new ResetPassword();
             
                model.ResetCode = id;
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult ResetPassword(ResetPassword model, FormCollection f)
            {
            var mk = f["NewPassword"];
            var XNmk = f["ConfirmPassword"];
            var message = "";
            if(ModelState.IsValid)
            {
                var user = data.NguoiDungs.Where(a => a.ResetCode == model.ResetCode).FirstOrDefault();
                if (user != null)
                {
                    user.MatKhau = GetMD5(f["NewPassword"]);
                    user.ResetCode = "";
                    data.SubmitChanges();
                    message = "Doi mat khau thanh cong";
                    return RedirectToAction("DoiMKThanhCong");
                }
                else
                {
                    message = "Khong ton tai";               }
            }
            ViewBag.Message = message;
            return View(model);
            }
        public ActionResult DoiMKThanhCong()
        {
            return View();
        }
        public ActionResult GuiEmailThanhCong()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ThongTinND()
        {
            ViewBag.Title_Header = "THÔNG TIN CÁ NHÂN";
            NguoiDung ND = Session["TaiKhoan"] as NguoiDung;
            var tk = data.NguoiDungs.SingleOrDefault(t => t.MaNguoiDung == ND.MaNguoiDung);
            return View(tk);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThongTinND(FormCollection f)
        {
            ViewBag.Title_Header = "THÔNG TIN CÁ NHÂN";
            NguoiDung ND = Session["TaiKhoan"] as NguoiDung;
            
            var tk = data.NguoiDungs.SingleOrDefault(t => t.MaNguoiDung == ND.MaNguoiDung);
          
      

            if (ModelState.IsValid)
            {
                tk.TaiKhoan = f["sTaiKhoan"];
                tk.Ten = f["sTenKH"];

                tk.TaiKhoan = f["TaiKhoan"];
                tk.DiaChi = f["sDiaChi"];
                tk.Email = f["sEmail"];
                tk.SDT = f["sSDT"];
                data.SubmitChanges();

              
               
                ViewBag.ThongBao = "Cập nhật thông tin thành công!";
                return View(tk);
            }
            ViewBag.ThongBao = "Cập nhật thông tin thất bại!";
            return View(tk);
        }

    }
}