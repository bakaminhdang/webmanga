using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;

namespace WebTruyen.Controllers
{
    public class GoiTKController : Controller
    {
        // GET: GoiTK
        dataDataContext data = new dataDataContext();
        public ActionResult Index()
        {
            GoiTaiKhoan lstGoitk = data.GoiTaiKhoans.FirstOrDefault();
            return View(lstGoitk);
        }
    }
}