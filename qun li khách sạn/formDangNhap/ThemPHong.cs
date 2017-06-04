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
    public partial class ThemPhong : Form
    {
        string strConnect = @"Data Source =LATITUDE-PC;Initial Catalog = QL_KhachSan; Integrated Security = True";
        public ThemPhong()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Phong p = new Phong();
            this.Hide();
            p.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string maP = txtMaPhong.Text.Trim();
                string tenP = txtTenphong.Text.Trim();
                string loaiP = txtLoaiPhong.Text.Trim();
                string tinhtrang = txtTinhTrang.Text.Trim();
                string giaP = txtTinhTrang.Text.Trim();
                SqlHelper.ExecuteNonQuery(strConnect, "ADDPhong",maP,tenP,loaiP,tinhtrang,giaP);
                MessageBox.Show("ok em");
            }
            catch (Exception)
            {
                MessageBox.Show("lỗi");
            }
        }
    }
}
