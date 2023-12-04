using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;
namespace WebTruyen.Areas.Admin.Controllers
{
    public class BinhLuanController : Controller
    {
        // GET: Admin/BinhLuan
        dataDataContext data = new dataDataContext();
            public ActionResult Index(int? page)
            {
                if (Session["Admin"] == null)
                {
                    return RedirectToAction("Login", "Home");
                }
                int iPageNum = (page ?? 1);
                int iPageSize = 7;

                return View(data.BinhLuans.ToList().OrderBy(n => n.MaNguoiDung).ToPagedList(iPageNum, iPageSize));
            }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var nd = data.BinhLuans.FirstOrDefault(n => n.MaNguoiDung == id);
            if (nd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nd);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, FormCollection f)
        {
            var nd = data.BinhLuans.FirstOrDefault(n => n.MaNguoiDung == id);
            if (nd == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            data.BinhLuans.DeleteOnSubmit(nd);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}