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
    public partial class FormXuatHang : Form
    {
        public FormXuatHang()
        {
            InitializeComponent();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            this.Hide();
            f.ShowDialog();

        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            FormPhieuXuat px = new FormPhieuXuat();
            this.Hide();
            px.ShowDialog();
        }
    }
}
