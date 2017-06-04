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
    public partial class ThemDoDungTrongPhong : Form
    {
        public ThemDoDungTrongPhong()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoDungTrongPhong ddtp = new DoDungTrongPhong();
            this.Hide();
            ddtp.Show();
        }
    }
}
