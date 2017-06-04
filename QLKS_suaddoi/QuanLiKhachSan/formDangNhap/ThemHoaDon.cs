using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using formDangNhap.Class;

namespace formDangNhap
{
    public partial class ThemHoaDon : Form
    {
        public ThemHoaDon()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            this.Hide();
            hd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HoaDonObj hd = new HoaDonObj();
            hd.MAHD = txtMaHd.Text;
            hd.MAKH = txtMaKH.Text;
            hd.NGUOILAP = TxtNguoiLap.Text;
            hd.TGMUON = dtpTGmuon.Value;
            hd.TGTRA = dtpTGtra.Value;
            hd.TONGTIEN = float.Parse(txtTongTien.Text);
            HoaDonBus h = new HoaDonBus();
            int ret;
            ret = h.insert(hd);
            if(ret<0)
            {
                MessageBox.Show("lưu ko thành công");
            }
            else
            {
                MessageBox.Show("lưu thành công");

            }
            h.close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtMaHd.Clear();
            txtMaKH.Clear();
            TxtNguoiLap.Clear();
            txtTongTien.Clear();
        }
    }
}
