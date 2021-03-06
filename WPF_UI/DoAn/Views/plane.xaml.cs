﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoAn.Views
{
    /// <summary>
    /// Interaction logic for plane.xaml
    /// </summary>
    public partial class plane : UserControl
    {
        DangNhap dn  = new DangNhap();
        //lich chuyen bay
        chuyenbay cb = new chuyenbay();
        banve bv     = new banve();
        TraCuu tc    = new TraCuu();
        DSChuyenBay dscb = new DSChuyenBay();
        BaoCao bc = new BaoCao();
        ThemSanBay tsb = new ThemSanBay();
        Thaydoiquydinh qd = new Thaydoiquydinh();
        public plane()
        {
            InitializeComponent();

            LoaiAnime.Children.Add(dn);
        }

        private void btnTheLoai_Click(object sender, RoutedEventArgs e)
        {
            var t = sender as Button;
            //ResetOpacity();
            //txtTitle.Text = t.Content.ToString();
            //subAnime = new SubAnime(t.Tag.ToString());
            //subAnime.XemAnime += new SubAnime.PassData(SubAnime_XemAnime);
            //UcSub.Children.Clear();
            //hp = new HomePage();
            //UcSub.Children.Add(hp);
            //UcSub.Children.Add(subAnime);
            //linkSpeak.Spreak("");
            //LoaiAnime.Children.Add(dn);

        }

        private void btnchuyenbay_Click(object sender, RoutedEventArgs e)
        {
            container.Children.Clear();
            container.Children.Add(cb);
            hideCN();
        }

        private void btnbanve_Click(object sender, RoutedEventArgs e)
        {
            container.Children.Clear();
            container.Children.Add(bv);
            hideCN();
        }
        // Come BACK
        void Back_Share(string i)
        {
            if (i == "1")//cancel
            {
                container.Children.Clear();
                showCN();
            }
            if (i=="2")
            {
                container.Children.Clear();
                //showCN();
                container.Children.Add(tsb);
            }
            if (i == "3")// lui từ them san bay sang chuyến bay nhá
            {
                container.Children.Clear();
                //showCN();
                container.Children.Add(cb);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cb.DataCB += new chuyenbay.PassData(Back_Share);//truyen lai cho window chuyenbay
            bv.DataCB += new banve.PassData(Back_Share);//truyen lai cho window chuyenbay
            tc.DataTC += new TraCuu.PassData(Back_Share);
            dscb.DataDSCB += new DSChuyenBay.PassData(Back_Share);
            bc.DataDSBC += new BaoCao.PassData(Back_Share);
            tsb.DataTSB += new ThemSanBay.PassData(Back_Share);
            qd.DataTDQD += new Thaydoiquydinh.PassData(Back_Share);
        }


        private void btntracuu_Click(object sender, RoutedEventArgs e)
        {
            container.Children.Clear();
            container.Children.Add(tc);
            hideCN();
        }
        private void hideCN()
        {
            btnbanve.Visibility = Visibility.Collapsed;
            btnbaocao.Visibility = Visibility.Collapsed;
            btnchuyenbay.Visibility = Visibility.Collapsed;
            btnDSCB.Visibility = Visibility.Collapsed;
            btnthaydoiquydinh.Visibility = Visibility.Collapsed;
            btntracuu.Visibility = Visibility.Collapsed;
            btnGNdatve.Visibility = Visibility.Collapsed;
            txtchuyenbay.Visibility = Visibility.Collapsed;
            txtbanve.Visibility = Visibility.Collapsed;
            txtGNdatve.Visibility = Visibility.Collapsed;
            txtdscb.Visibility = Visibility.Collapsed;
            txttracuu.Visibility = Visibility.Collapsed;
            txtthongtin.Visibility = Visibility.Collapsed;
            txtbaocao.Visibility = Visibility.Collapsed;

        }
        private void showCN()
        {

            btnbanve.Visibility = Visibility.Visible;
            btnbaocao.Visibility = Visibility.Visible;
            btnchuyenbay.Visibility = Visibility.Visible;
            btnDSCB.Visibility = Visibility.Visible;
            btnthaydoiquydinh.Visibility = Visibility.Visible;
            btntracuu.Visibility = Visibility.Visible;
            btnGNdatve.Visibility = Visibility.Visible;
            txtchuyenbay.Visibility = Visibility.Visible;
            txtbanve.Visibility = Visibility.Visible;
            txtGNdatve.Visibility = Visibility.Visible;
            txtdscb.Visibility = Visibility.Visible;
            txttracuu.Visibility = Visibility.Visible;
            txtthongtin.Visibility = Visibility.Visible;
            txtbaocao.Visibility = Visibility.Visible;
        }

        private void btnDSCB_Click(object sender, RoutedEventArgs e)
        {
            container.Children.Clear();
            container.Children.Add(dscb);
            hideCN();
        }

        private void btnbaocao_Click(object sender, RoutedEventArgs e)
        {
            container.Children.Clear();
            container.Children.Add(bc);
            hideCN();
        }

        private void btnthaydoiquydinh_Click(object sender, RoutedEventArgs e)
        {
            container.Children.Clear();
            container.Children.Add(qd);
            hideCN();
        }
    }
}
