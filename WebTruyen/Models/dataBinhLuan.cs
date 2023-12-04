using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTruyen.Models;

namespace WebTruyen.Models
{

    public class dataBinhLuan
    {
        dataDataContext data = new dataDataContext();
        public int sMaNguoiDung { get; set; }
        public string sNoiDung { get; set; }
        public virtual dataNguoiDung dataNguoiDung { get; set; }
        public dataBinhLuan(int MaNguoiDung)
        {
            sMaNguoiDung = MaNguoiDung;
            BinhLuan bl = data.BinhLuans.Single(n => n.MaNguoiDung == sMaNguoiDung);
            sNoiDung = bl.NoiDung;
        }
    }
    public class dataNguoiDung
    {
        dataDataContext data = new dataDataContext();
        public string sten { get; set; }
        public int sMaNguoiDung { get; set; }
        public dataNguoiDung(int MaNguoiDung)
        {
            sMaNguoiDung = MaNguoiDung;
            NguoiDung ND = data.NguoiDungs.Single(n => n.MaNguoiDung == sMaNguoiDung);
        }

    }
}