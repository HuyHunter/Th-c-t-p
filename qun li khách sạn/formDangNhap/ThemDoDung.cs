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
    public partial class ThemDoDung : Form
    {
        public ThemDoDung()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DoDung dd = new DoDung();
            this.Hide();
            dd.Show();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
