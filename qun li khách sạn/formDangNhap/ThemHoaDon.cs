using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
namespace formDangNhap
{
    public partial class ThemHoaDon : Form
    {
        string strConnect = @"Data Source =JOJO-PC\SQLEXPRESS;Initial Catalog = QL_KhachSan; Integrated Security = True";
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
            try
            {
                string maHD = txtMaHd.Text.Trim();
                string maKH = txtMaKH.Text.Trim();
                string nglap = TxtNguoiLap.Text.Trim();
                string tongtien = txtTongTien.Text.Trim();
                DateTime tgMuon = DateTime.Parse(dtpTGmuon.Value.ToString());
                DateTime tgTra = DateTime.Parse(dtpTGtra.Value.ToString());
                SqlHelper.ExecuteNonQuery(strConnect, "ThemHD",maHD,maKH,nglap,tongtien,tgMuon,tgTra);
                MessageBox.Show("ok babe");
            }
            catch (Exception)
            {
                MessageBox.Show("lỗi");
            }
        }
    }
}
