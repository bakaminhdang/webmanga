using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTruyen.Models;
namespace WebTruyen.Models
{
    public class LichSu
    {
        dataDataContext data = new dataDataContext();
        public int iMaTruyen { get; set; }
        public string sTenTruyen { get; set; }
        public virtual dataTruyen datatruyen { get; set; }
        public LichSu(int MaTruyen)
        {
            iMaTruyen = MaTruyen;
            Lichsu ls = data.Lichsus.Single(n => n.MaTruyen == iMaTruyen);
            
        }


    }
    public class dataTruyen
    {
        dataDataContext data = new dataDataContext();
        public string stentruyen { get; set; }
        public int sMatruyen { get; set; }
        public dataTruyen(int Matruyen)
        {
            sMatruyen= Matruyen;
            Truyen truyen = data.Truyens.Single(n => n.MaTruyen == sMatruyen);
           
        }

    }
}