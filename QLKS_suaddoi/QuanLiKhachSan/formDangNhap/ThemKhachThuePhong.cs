using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formDangNhap
{
    public partial class ThemKhachThuePhong : Form
    {
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
    }
}
