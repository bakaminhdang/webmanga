using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;

namespace WebTruyen.Controllers
{
    

    public class TrangChuController : Controller
    {
        dataDataContext data = new dataDataContext();
        private List<Truyen> LayTruyen(int count)
        {
            return data.Truyens.OrderByDescending(a => a.NgayXuatBan).Take(count).ToList();
        }
        private List<Truyen> GetTruyenDeXuat(int count)
        {
            var today = DateTime.Now.Date;
            int seed = Guid.NewGuid().GetHashCode();
            Random random = new Random(seed);

            var allTruyens = data.Truyens.OrderByDescending(a => a.NgayXuatBan).Take(count).ToList();

            var shuffledTruyens = allTruyens.OrderBy(x => random.Next()).ToList();

            return shuffledTruyens.Take(count).ToList();
        }
        public ActionResult Index()
        {
            var listTruyen = LayTruyen(10);
            return View(listTruyen);
        }
        public ActionResult NavPartial()
        {
            return View();
        }
        public ActionResult SliderPartial()
        {
            return PartialView();
        }

        public ActionResult Chitiettruyen(int id)
        {
            var truyen = from s in data.Truyens
                         where s.MaTruyen == id
                         select s;
            return View(truyen.Single());
        }

        public ActionResult TheLoai()
        {
            var item = from c in data.TheLoais select c;
            return PartialView(item);
        }
        public ActionResult TruyenTheoTL(int id)
        {
            var TheLoai = from s in data.Truyens where s.MaTheLoai == id select s;
            return View(TheLoai);

        }
        public ActionResult DropdownChuong(int id)
        {
            var list = data.Chuongs.Where(c => c.MaTruyen == id);

            return PartialView(list);
        }
        public ActionResult DeXuat()
        {
            var listTruyen = GetTruyenDeXuat(6);
            return View(listTruyen);
        }
       

    }
}