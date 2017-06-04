using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS_THUCTAP
{
    public partial class QUANLI : Form
    {
        public QUANLI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThem ft = new FormThem();
            this.Hide();
            ft.ShowDialog();
        }

        private void hướngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHuongdan hd = new FormHuongdan();
            this.Hide();
            hd.ShowDialog();
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSua fs = new FormSua();
            this.Hide();
            fs.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormDangnhap dk = new FormDangnhap();
            this.Hide();
            dk.ShowDialog();
        }

        private void thêmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormThemPM tpm = new FormThemPM();
            this.Hide();
            tpm.Show();
        }

        private void QUANLI_Load(object sender, EventArgs e)
        {

        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimkiemNS tkns = new TimkiemNS();
            this.Hide();
            tkns.Show();
        }

        private void tìmKiếmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TimkiemPB tkpb = new TimkiemPB();
            this.Hide();
            tkpb.Show();
        }
    }
}
