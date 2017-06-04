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
    public partial class ThemDichVu : Form
    {
        public ThemDichVu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DichVu dv = new DichVu();
            this.Hide();
            dv.Show();
        }
    }
}
