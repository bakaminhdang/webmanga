using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTruyen.Models;
namespace WebTruyen.Models
{
    public class lstTruyenYeuThich
    {
        dataDataContext data = new dataDataContext();

        public int sMaTruyen { get; set; }
        public string sTacGia { get; set; }


        public string sHinh { get; set; }




        public lstTruyenYeuThich(int MaTruyen)
        {
            sMaTruyen = MaTruyen;
            Truyen Tr = data.Truyens.Single(n => n.MaTruyen == sMaTruyen);
            sTacGia = Tr.TacGia;
            sHinh = Tr.Hinh;



        }


    }
    public class TruyenYeuThichs
    {
        dataDataContext data = new dataDataContext();
        public int MaND { get; set; }
        public int MaTruyen { get; set; }
        public virtual lstTruyenYeuThich lstTruyenYeuThich { get; set; }

        public TruyenYeuThichs(int MaNguoiDung)
        {
            MaND = MaNguoiDung;
            TruyenYeuThich yeuThich = data.TruyenYeuThiches.FirstOrDefault(n => n.MaNguoiDung == MaND);
        }
    }
}