using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;


namespace WebTruyen.Areas.Admin.Controllers
{
    public class ChiTietDHController : Controller
    {
        // GET: Admin/ChiTietDH
        dataDataContext data = new dataDataContext();
        public ActionResult Index(int? page)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int iPageNum = (page ?? 1);
            int iPageSize = 7;

            return View(data.ChiTietDonHangs.ToList().OrderBy(n => n.MaDonHang).ToPagedList(iPageNum, iPageSize));
        }
    }
}