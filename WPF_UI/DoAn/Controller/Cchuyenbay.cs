using DoAn.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DoAn.Controller
{
    class Cchuyenbay
    {

        QLVeMayBayEntities LT = new QLVeMayBayEntities();
        public ICollectionView CloadcbbMacb { get; set; }
        public ICollectionView CLoadSBtrunggian { get; set; }
        public ICollectionView CLoadSB { get; set; }
        public string sbd { get; set; }
        public string tenSBden, TenSBdi, ngaygio, Thoigianbay, SLghe1, SLghe2;
        // load chuyến bay
        public bool LoadCBBChuyenbay()
        {
            var load = LT.CHUYENBAY.ToList();
            if (load !=null)
            {
                CloadcbbMacb = CollectionViewSource.GetDefaultView(load);
                return true;
            }
            return false;
        }

        // load sân bay trung gian
        public bool LoadSBtrunggian(int str)
        {
            var sql = LT.SANBAYTRUNGGIAN.Where(m => m.MaCB == str);
            if (sql != null)
            {
                var load = sql.ToList();
                CLoadSBtrunggian = CollectionViewSource.GetDefaultView(load);
                return true;
            }
            return false;
        }
        // load sân bay
        public bool LoadSB()
        {
            var sql = LT.SANBAY.ToList();
            if (sql != null)
            {
                var load = sql.ToList();
                CLoadSB = CollectionViewSource.GetDefaultView(load);
                return true;
            }
            return false;
        }
      //  , string ngaygio,string Thoigianbay,string SLghe1,string SLghe2
        //select cbb binding text
        public void bingdingCBB(int macb)
        {
            var query = LT.LICHBAY.Where(m => m.MaCB == macb).FirstOrDefault();
            var sanbaydi = (from lb in LT.LICHBAY
                            from sb in LT.SANBAY
                            where lb.MaSanBayDi == sb.MaSB && lb.MaCB == macb
                            select new { sb.TenSB }).FirstOrDefault();
            var sanbayden = (from lb in LT.LICHBAY
                             from sb in LT.SANBAY
                             where lb.MaSanBayDen == sb.MaSB && lb.MaCB == macb
                             select new { sb.TenSB }).FirstOrDefault();
             if (query != null)
             {
                tenSBden = sanbayden.TenSB.ToString();
                TenSBdi = sanbaydi.TenSB.ToString();
                ngaygio = query.NgayGio.ToString();
                Thoigianbay = query.ThoiGianBay.ToString();
                SLghe1 = query.SoLuongGheHang1.ToString();
                SLghe2 = query.SoLuongGheHang2.ToString();
               
            }
            
              
            

        }

        // DEM SỐ LƯỢNG SÂN BAY TRUNG GIAN
        public int Soluongsanbaytrunggian(int valuecbb)
        {
            int nsb = (from d in LT.SANBAYTRUNGGIAN
                       where d.MaCB == valuecbb
                       select d).Count();
            return nsb;
        }
        // KIÊM TRA TỒN TẠI 
        public int exist(string ID , int valuecbb)
        {
            // Kiểm tra đã tồn tại nêu  >=1 thì chứng tỏ đã tồn tại zồi ok
            int n = (from d in LT.SANBAYTRUNGGIAN
                     where d.MaSBTrungGian == ID && d.MaCB == valuecbb
                     select d).Count();
            return n;
        }
        //THÊM SÂN BAY TRUNG GIAN
        public void themsanbaytrunggian(string ID ,int valuecbb) {
            var query = LT.SANBAY.Where(m => m.MaSB == ID).FirstOrDefault();
            if (query !=null)
            {
                SANBAYTRUNGGIAN l = new SANBAYTRUNGGIAN();
                l.MaCB = valuecbb;
                l.MaSBTrungGian = ID;
                l.TenSB = query.TenSB;
                l.ThoiGianDung = 10;
                LT.SANBAYTRUNGGIAN.Add(l);
                LT.SaveChanges();

            }
            else
            {
                MessageBox.Show("[KHÔNG LÂY ĐƯƠC MÃ SÂN BAY!]");
            }
        }
        // XÓA SÂN BAY TRUNG GIAN
        public void xoasanbaytrunggian(string ID, int valuecbb)
        {
            var xoa = (LT.SANBAYTRUNGGIAN.Where(m => m.MaSBTrungGian == ID && m.MaCB == valuecbb)).SingleOrDefault();
     
            if (xoa != null)
            {
                if (MessageBox.Show("BẠN CHẮC CHƯA?", "            THÔNG BÁO    ", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    LT.SANBAYTRUNGGIAN.Remove(xoa);
                    LT.SaveChanges();
                }
               
            }
            else
            {
                MessageBox.Show("[KHÔNG LÂY ĐƯƠC MÃ SÂN BAY!]");
            }
        }

        // cập nhật sân bay trung gian
        public void capnhatsanbaytrunggian(string ID, int valuecbb)
        {
            var laySBGR = (LT.SANBAYTRUNGGIAN.Where(m => m.MaSBTrungGian == ID && m.MaCB == valuecbb)).SingleOrDefault();
            laySBGR.ThoiGianDung = laySBGR.ThoiGianDung;
            laySBGR.GhiChu = laySBGR.GhiChu;
            if (laySBGR != null)
            {
                LT.SaveChanges();
                MessageBox.Show("done!");
            }
            else
            {
                MessageBox.Show("chưa update được!");
            }

        }
    }
}
