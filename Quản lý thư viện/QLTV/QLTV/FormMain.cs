using Microsoft.ApplicationBlocks.Data;
using QLTV.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void Qlnd1_Click(object sender, EventArgs e)
        {
            UserControl nguoidung = new NguoidungControl();
            nguoidung.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(nguoidung);
        }

        private void Qlnd2_Click(object sender, EventArgs e)
        {
            UserControl nguoidung = new LopControl();
            nguoidung.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(nguoidung);
        }

        private void qls1_Click(object sender, EventArgs e)
        {
            UserControl nguoidung = new SachControl();
            nguoidung.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(nguoidung);
        }


        private void QLND_Click(object sender, EventArgs e)
        {
            qls1.Visible = false;
            qls2.Visible = false;
            qls3.Visible = false;
            qls4.Visible = false;
            Qlnd1.Visible = true;
            Qlnd2.Visible = true;
            qlms1.Visible = false;
            qlms2.Visible = false;
            Qlnd1.Image = QLTV.Properties.Resources.ND;
            Qlnd2.Image = QLTV.Properties.Resources.Lop;
        }

        private void qls2_Click(object sender, EventArgs e)
        {
            UserControl nguoidung = new ControlDausach();
            nguoidung.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(nguoidung);
        }

        private void qls3_Click(object sender, EventArgs e)
        {
            UserControl nguoidung = new TheloaiControl();
            nguoidung.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(nguoidung);
        }

        private void qls4_Click(object sender, EventArgs e)
        {
            UserControl nguoidung = new NXBControl();
            nguoidung.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(nguoidung);
        }

        private void QLS_Click(object sender, EventArgs e)
        {
            qls1.Visible = true;
            qls2.Visible = true;
            qls3.Visible = true;
            qls4.Visible = true;
            Qlnd1.Visible = false;
            Qlnd2.Visible = false;
            qlms1.Visible = false;
            qlms2.Visible = false;
            qls1.Image = QLTV.Properties.Resources.S;
            qls2.Image = QLTV.Properties.Resources.DauSach;
            qls3.Image = QLTV.Properties.Resources.TheLoai;
            qls4.Image = QLTV.Properties.Resources.NXB;
        }

        private void QLMS_Click(object sender, EventArgs e)
        {
            qls1.Visible = false;
            qls2.Visible = false;
            qls3.Visible = false;
            qls4.Visible = false;
            Qlnd1.Visible = false;
            Qlnd2.Visible = false;
            qlms1.Visible = true;
            qlms2.Visible = true;
            qlms1.Image = QLTV.Properties.Resources.PM;
            qlms2.Image = QLTV.Properties.Resources.CTPM;
        }

        private void qlms1_Click(object sender, EventArgs e)
        {
            UserControl nguoidung = new PhieumuonControl();
            nguoidung.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(nguoidung);
        }

        private void qlms2_Click(object sender, EventArgs e)
        {
            UserControl nguoidung = new CTPMControl();
            nguoidung.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(nguoidung);
        }

        private void TK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn thoát??");
            this.Close();
        }
    }
}
