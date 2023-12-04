using Stripe.Checkout;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;


namespace WebTruyen.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        dataDataContext data = new dataDataContext();
        [HttpGet]
       
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCheckoutSession(int gia,FormCollection f)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }
           /* if (Session["SDT"] == null && Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangKy", "User");
            }*/

            DonHang dh = new DonHang();
            NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
            
            dh.MaNguoiDung = ND.MaNguoiDung;
            dh.TongTien = gia;
           
            data.DonHangs.InsertOnSubmit(dh);
            data.SubmitChanges();
            ChiTietDonHang ct = new ChiTietDonHang();
            if (ModelState.IsValid)
            {
               
                ct.MaDonHang = dh.MaDonHang;
                ct.MaTruyen = int.Parse(f["MaTruyen"]);
                data.ChiTietDonHangs.InsertOnSubmit(ct);
                data.SubmitChanges();
            }


                var options = new Stripe.Checkout.SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
        {
          new SessionLineItemOptions
          {
            PriceData = new SessionLineItemPriceDataOptions
            {
              UnitAmount =(gia*100)/24000,
              Currency = "USD",
              ProductData = new SessionLineItemPriceDataProductDataOptions
              {
                Name = "Truyen",
              },

            },
            Quantity = 1,
          },
        },
                Mode = "payment",
                SuccessUrl = "https://localhost:44319/Payment/success",
                CancelUrl = "https://localhost:44319/Payment/cancel",
            };

            var service = new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);

            /*string hoten = ND.Ten.ToString();
            int giatien = dh.TongTien;*/
            string toAddress = ND.Email.ToString();
            /* string mdh = dh.MaDonHang.ToString();*/
            
            /*string subject = "XÁC NHẬN ĐẶT HÀNG";
            string body = "Bạn Đã Được Nâng Cấp Lên Vip";*/
            SendConfirmationEmail(toAddress, dh);
            return new HttpStatusCodeResult(303);
        }
        [HttpPost]
        public ActionResult GetPayment()
        {
            var service = new PaymentIntentService();
            var options = new PaymentIntentCreateOptions
            {
                Amount = 1099,
                SetupFutureUsage = "off_session",
                Currency = "USD",
            };
            var paymentIntent = service.Create(options);
            return Json(paymentIntent);
        }

        public ActionResult success()
        {
            return View();
        }

        public ActionResult cancel()
        {

            return View();
        }

       
        [HttpPost]
        public ActionResult CreateCheckoutSessionVip(int gia, FormCollection f)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }

            DonHangGoiTaiKhoan dhtk = new DonHangGoiTaiKhoan();
            
            NguoiDung ND = (NguoiDung)Session["TaiKhoan"];

            dhtk.MaNguoiDung = ND.MaNguoiDung;
           
            dhtk.MaGoiTaiKhoan = int.Parse(f["MaGoi"]);
          

            data.DonHangGoiTaiKhoans.InsertOnSubmit(dhtk);
            data.SubmitChanges();
            if (ModelState.IsValid)
            {
                var tk = data.NguoiDungs.SingleOrDefault(t => t.MaNguoiDung == ND.MaNguoiDung);

                tk.QuyenTruyCap = "VIP";
                data.SubmitChanges();
            }





            var options = new Stripe.Checkout.SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
        {
          new SessionLineItemOptions
          {
            PriceData = new SessionLineItemPriceDataOptions
            {
              UnitAmount =(gia*100)/24000,
              Currency = "USD",
              ProductData = new SessionLineItemPriceDataProductDataOptions
              {
                Name = "Truyen",
              },

            },
            Quantity = 1,
          },
        },
                Mode = "payment",
                SuccessUrl = "https://localhost:44319/Payment/successVIP",
                CancelUrl = "https://localhost:44319/Payment/cancel",
            };

            var service = new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            string toAddress = ND.Email.ToString();
            string subject = "XÁC NHẬN ĐẶT HÀNG";
            string body = "Bạn Đã Được Nâng Cấp Lên Vip";
            SendConfirmationEmailVIP(toAddress, subject, body);
            return new HttpStatusCodeResult(303);
        }
        public ActionResult successVIP()
        {
            return View();
        }
         public void SendConfirmationEmail(string toAddress, DonHang dh)
         {
            string contentCustomer = System.IO.File.ReadAllText(Server.MapPath("~/Content/Templates/send1.html"));
            contentCustomer = contentCustomer.Replace("{{MaDonHang}}", dh.MaDonHang.ToString());
            contentCustomer = contentCustomer.Replace("{{Hoten}}", dh.NguoiDung.Ten);
            contentCustomer = contentCustomer.Replace("{{TongTien}}", dh.TongTien.ToString());
            contentCustomer = contentCustomer.Replace("{{DiaChi}}", dh.NguoiDung.DiaChi.ToString());
            contentCustomer = contentCustomer.Replace("{{sdt}}", dh.NguoiDung.SDT.ToString());
            contentCustomer = contentCustomer.Replace("{{email}}", dh.NguoiDung.Email);

            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
             {
                 Credentials = new NetworkCredential("bakaminhdang@gmail.com", "khvp wfqd sgdc gbwu"),
                 EnableSsl = true
             };

             var mailMessage = new System.Net.Mail.MailMessage
             {
                 From = new MailAddress("bakaminhdang@gmail.com"),
                 
                /* Body = body,*/
                 IsBodyHtml = true,
             };
            mailMessage.Body = contentCustomer;
             mailMessage.To.Add(toAddress);

             smtpClient.Send(mailMessage);
         }
        public void SendConfirmationEmailVIP(string toAddress, DonHang dh)
        {
            string contentCustomer = System.IO.File.ReadAllText(Server.MapPath("~/Content/Templates/send1.html"));
            contentCustomer = contentCustomer.Replace("{{MaDonHang}}", dh.MaDonHang.ToString());
            contentCustomer = contentCustomer.Replace("{{Hoten}}", dh.NguoiDung.Ten);
            contentCustomer = contentCustomer.Replace("{{TongTien}}", dh.TongTien.ToString());
            contentCustomer = contentCustomer.Replace("{{DiaChi}}", dh.NguoiDung.DiaChi.ToString());
            contentCustomer = contentCustomer.Replace("{{sdt}}", dh.NguoiDung.SDT.ToString());
            contentCustomer = contentCustomer.Replace("{{email}}", dh.NguoiDung.Email);

            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("bakaminhdang@gmail.com", "khvp wfqd sgdc gbwu"),
                EnableSsl = true
            };

            var mailMessage = new System.Net.Mail.MailMessage
            {
                From = new MailAddress("bakaminhdang@gmail.com"),

                /* Body = body,*/
                IsBodyHtml = true,
            };
            mailMessage.Body = contentCustomer;
            mailMessage.To.Add(toAddress);

            smtpClient.Send(mailMessage);
        }
        public void SendConfirmationEmailVIP(string toAddress, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("bakaminhdang@gmail.com", "khvp wfqd sgdc gbwu"),
                EnableSsl = true
            };

            var mailMessage = new System.Net.Mail.MailMessage
            {
                From = new MailAddress("bakaminhdang@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(toAddress);

            smtpClient.Send(mailMessage);
        }


    }
}