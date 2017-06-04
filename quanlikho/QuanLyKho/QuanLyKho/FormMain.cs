using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            FormNhapHang fn = new FormNhapHang();
            this.Hide();
            fn.ShowDialog();
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            FormKhoHang fkh = new FormKhoHang();
            this.Hide();
            fkh.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin lg = new FormLogin();
            this.Hide();
            lg.ShowDialog();
        }

        private void btnKiemKe_Click(object sender, EventArgs e)
        {
            FormBaoCao bc = new FormBaoCao();
            this.Hide();
            bc.ShowDialog();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FormKhachHang kh = new FormKhachHang();
            this.Hide();
            kh.ShowDialog();
        }

        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            FormXuatHang xh = new FormXuatHang();
            this.Hide();
            xh.ShowDialog();
        }
    }
}
