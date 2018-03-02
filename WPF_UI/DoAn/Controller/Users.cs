using DoAn.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace DoAn.Controller
{
    public class Users
    {
        public ICollectionView Loadinfomation { get; set; }
        ObservableCollection<TaiKhoan> listUC { get; set; }
        public string IDUser { get; set; }
        public string User { get; set; }
        public string getpasswor { get; set; }
        public BitmapImage sc { get; set; }

        // CONNECT DATABSE
        QLVeMayBayEntities LT = new QLVeMayBayEntities();

        // LOGIN
        public bool login_uc(string Name, string Pass)
        {

            var ok = (from n in LT.TaiKhoan
                      where n.IdNguoiDung == Name && n.PassND == Pass
                      select n).FirstOrDefault();

            if (ok == null)
            {
                return false;
            }
            IDUser = ok.IdNguoiDung;
            return true;
        }
        //Check username already exists
        public bool exists(string str)
        {
            int DK = LT.TaiKhoan.Where(m => m.IdNguoiDung == str).Count();
            if (DK > 0)
            {
                return true;// already exists
            }
            return false;
        }
        // registration
        public bool regis(string errormessage, string Username, string password, string lastname, string email, string address)
        {
            var TK = new TaiKhoan { IdNguoiDung = Username, PassND = password, HoTen = lastname, Email = email, DiaChi = address, MaLoaiTK = 0 };
            if (exists(TK.IdNguoiDung) == true)
            {
                errormessage = "Username is Exist";
            }
            else
            {
                LT.TaiKhoan.Add(TK);
                if (LT.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        //VIEW info users
        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
        public bool load_info_user(string txtID)
        {
            var info = (from h in LT.TaiKhoan
                        where h.IdNguoiDung == txtID
                        select h);
            if (info != null)
            {
                var load = info.ToList();
                Loadinfomation = CollectionViewSource.GetDefaultView(load);
                return true;
            }
            return false;
        }
        public bool LoadInfo(string txtID)// load avatar user
        {
            byte[] b = (from h in LT.TaiKhoan
                        where h.IdNguoiDung == txtID
                        select h.Avatar).Single();
            if (b != null)
            {
                sc = ToImage(b);
                return true;
            }
            return false;
        }
        // Update info user
        public bool Update_info(string txtID, string email, string sex, string Hoten, string diachi, string sdt, DateTime SinhNhat, string DuongDan)
        {
            var mh = LT.TaiKhoan.Where(m => m.IdNguoiDung == txtID).Single() as TaiKhoan;
            if (mh == null)
            {
                return false;
            }
            else
            {
                mh.Email = email;
                mh.GioiTinh = sex;
                mh.HoTen = Hoten;
                mh.DiaChi = diachi;
                mh.SoDT = sdt;
                mh.NgaySinh = SinhNhat;
                if (File.Exists(DuongDan))
                {
                    FileStream Stream = new FileStream(DuongDan, FileMode.Open, FileAccess.Read);
                    StreamReader Reader = new StreamReader(Stream);
                    Byte[] ImgData = new Byte[Stream.Length - 1];
                    Stream.Read(ImgData, 0, (int)Stream.Length - 1);
                    mh.Avatar = ImgData;
                }
                if (LT.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return true;
        }

        // CHANGE PASSWOrD
        public void getPass(string txtID)
        {
            var password = (from h in LT.TaiKhoan
                            where h.IdNguoiDung == txtID
                            select h.PassND).SingleOrDefault();
            getpasswor = password;
        }

        public bool Update_pass(string txtID, string newpass)
        {
            var mh = LT.TaiKhoan.Where(m => m.IdNguoiDung == txtID).Single() as TaiKhoan;
            if (mh == null)
            {
                return false;
            }
            else
            {
                mh.PassND = newpass;
                if (LT.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return true;
        }
    }
}
