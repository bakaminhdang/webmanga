using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using WebTruyen.Models;
namespace WebTruyen.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        dataDataContext data = new dataDataContext();
        public ActionResult Index(int? page, string strSearch = null)
        {

            ViewBag.Sreach = strSearch;
            if (!string.IsNullOrEmpty(strSearch))
            {
                int iSize = 3;
                int iPageNumber = (page ?? 1);
                var kq = from s in data.Truyens where s.TenTruyen.Contains(strSearch) || s.MoTa.Contains(strSearch) select s;
                return View(kq.ToPagedList(iPageNumber, iSize));
            }
            return View();

        }
    }
}