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
    public partial class ThemKhachThuePhong : Form
    {
        string strConnect = @"Data Source =LATITUDE-PC;Initial Catalog = QL_KhachSan; Integrated Security = True";
        public ThemKhachThuePhong()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KhachThuePhong ktp = new KhachThuePhong();
            this.Hide();
            ktp.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string makh = txtMaKH.Text.Trim();
                string tenkh = txtTenKH.Text.Trim();
                DateTime ngaysinh = DateTime.Parse(dtpNgaysinh.Value.ToString());
                string gioitinh = txtGioiTinh.Text.Trim();
                SqlHelper.ExecuteNonQuery(strConnect,"ADDKhachThuePhong",makh,tenkh,ngaysinh,gioitinh);
                MessageBox.Show("thành công");
            }
            catch(Exception )
            {
                MessageBox.Show("lỗi");
            }
        }
    }
}
