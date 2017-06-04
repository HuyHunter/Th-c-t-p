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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            this.Hide();
            hd.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DoDung dd = new DoDung();
            this.Hide();
            dd.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DichVu dv = new DichVu();
            this.Hide();
            dv.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            DoDungTrongPhong ddtp = new DoDungTrongPhong();
            this.Hide();
            ddtp.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Phong p = new Phong();
            this.Hide();
            p.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            KhachThuePhong ktp = new KhachThuePhong();
            this.Hide();
            ktp.Show();
        }
    }
}
