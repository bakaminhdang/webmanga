using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;
namespace WebTruyen.Areas.Admin.Controllers
{
    public class ChuongImgController : Controller
    {
        
        dataDataContext data = new dataDataContext();
        public ActionResult Index(int id)
        {
            ViewBag.MaChuong = id;
            var items = data.ChuongImgs.Where(x => x.MaChuong == id).ToList();
            return View(items);
        }
        /*[HttpGet]*/
        /*public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        
        public ActionResult AddImage(ChuongImg chuong,int ID, string img)
        {

            if (ModelState.IsValid)
            {
                
                    var imgchuong = new ChuongImg()
                    {
                        MaChuong = chuong.MaChuong,
                        Hinh = img,

                    };
                data.ChuongImgs.InsertOnSubmit(chuong);
                
                
              
                

            }
           
            
            data.SubmitChanges();
            return Json(new { Success = true });
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var nd = data.ChuongImgs.SingleOrDefault(n => n.ID == id);
            if (nd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nd);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, FormCollection f)
        {
            var nd = data.ChuongImgs.SingleOrDefault(n => n.ID == id);
            if (nd == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            data.ChuongImgs.DeleteOnSubmit(nd);
            data.SubmitChanges();
            return View();

        }*/
        [HttpPost]
        public ActionResult AddImage(int ID, string url)
        {
            data.ChuongImgs.InsertOnSubmit(new ChuongImg
            {
                ID= ID,
                Hinh = url,
                IsDefault = false
            });
            data.SubmitChanges();
            return Json(new { Success = true });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = data.ChuongImgs.SingleOrDefault(x => x.ID == id);
            if (item != null)
            {
                data.ChuongImgs.DeleteOnSubmit(item);
                data.SubmitChanges();
                return Json(new { Success = true });
            }
            else
            {
                return Json(new { Success = false });
            }
        }
    }

}