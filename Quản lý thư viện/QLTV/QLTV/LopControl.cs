using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace QLTV
{
    public partial class LopControl : UserControl
    {
        public LopControl()
        {
            InitializeComponent();
            Load += loaddgv;
        }
        private void loaddgv(object sender, EventArgs e)
        {
            loaddulieu();
        }

        private void loaddulieu()
        {
            dgvHienthi.DataSource = SqlHelper.ExecuteDataset(QLTV.Class.StrConnect.strConnect(), "loadkhoalop").Tables[0];
        }

        private void btCapnhat_Click(object sender, EventArgs e)
        {
            loaddulieu();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaLop = txtMa.Text.Trim();
                string TenLop = txtTen.Text.Trim();
                string Khoa = txtKhoa.Text.Trim();
                SqlHelper.ExecuteDataset(QLTV.Class.StrConnect.strConnect(), "Lop_Insert", MaLop, TenLop, Khoa);
                loaddulieu();
            }
            catch (Exception)
            {

            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {

            try
            {
                string MaLop = txtMa.Text.Trim();
                string TenLop = txtTen.Text.Trim();
                string Khoa = txtKhoa.Text.Trim();
                SqlHelper.ExecuteDataset(QLTV.Class.StrConnect.strConnect(), "Lop_Update", MaLop, TenLop, Khoa);
                loaddulieu();
            }
            catch (Exception)
            {

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string MaLop = txtMa.Text.Trim();
               
                SqlHelper.ExecuteDataset(QLTV.Class.StrConnect.strConnect(), "Lop_Delete", MaLop);
                loaddulieu();
            }
            catch (Exception)
            {

            }
        }
    }
}
