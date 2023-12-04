using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;

namespace WebTruyen.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        dataDataContext data = new dataDataContext();
        // GET: Admin/DonHang
        public ActionResult Index()
        {
            var Dh= from c in data.DonHangs select c;
         
            return View( Dh);
        }
      
       
    }
}