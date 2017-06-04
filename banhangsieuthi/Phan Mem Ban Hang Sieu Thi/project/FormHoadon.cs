using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace project
{
    public partial class FormHoadon : Form
    {
        public FormHoadon()
        {
            InitializeComponent();
        }

        private void FormHoadon_Load(object sender, EventArgs e)
        {
            string sqlhoadon = @"select hd.Mahoadon,nv.Tennhanvien,kh.Tenkhachhang,hh.Tensanpham, hh.Giaban,hd.Ngaymua,hd.Tienthanhtoan
                                 from HOADON hd,NHANVIEN nv, KHACHHANG kh, HANGHOA hh
                                 where nv.Manhanvien = hd.Manhanvien and hd.Makhachhang = kh.Makhachhang and hh.Masanpham = hd.Masanpham";
            DataTable dthoadon = DataProvider.LoadCSDL(sqlhoadon);
            dgvHoadon.DataSource = dthoadon;
            dgvHoadon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
