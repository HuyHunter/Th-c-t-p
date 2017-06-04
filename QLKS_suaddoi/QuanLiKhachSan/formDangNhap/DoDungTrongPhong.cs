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
    public partial class DoDungTrongPhong : Form
    {
        public DoDungTrongPhong()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            this.Hide();
            fm.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemDoDungTrongPhong tddvp = new ThemDoDungTrongPhong();
            this.Hide();
            tddvp.Show();
        }
    }
}
