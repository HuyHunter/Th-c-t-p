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
    public partial class NXBControl : UserControl
    {
        public NXBControl()
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
            dgvHienthi.DataSource = SqlHelper.ExecuteDataset(QLTV.Class.StrConnect.strConnect(), "loadNXB").Tables[0];
        }

        private void btCapnhat_Click(object sender, EventArgs e)
        {
            loaddulieu();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNXB = txtMa.Text.Trim();
                string TenNXB = txtTen.Text.Trim();
                string QuocGia = txtQuocgia.Text.Trim();
                string Email = txtEmail.Text.Trim();
                string DiaChi = txtDiachi.Text.Trim();
                string DienThoai = txtDienthoai.Text.Trim();
                SqlHelper.ExecuteNonQuery(QLTV.Class.StrConnect.strConnect(), "NXB_Insert", MaNXB, TenNXB, QuocGia, Email, DiaChi, DienThoai);
                loaddulieu();


            }
            catch(Exception) {
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNXB = txtMa.Text.Trim();
                string TenNXB = txtTen.Text.Trim();
                string QuocGia = txtQuocgia.Text.Trim();
                string Email = txtEmail.Text.Trim();
                string DiaChi = txtDiachi.Text.Trim();
                string DienThoai = txtDienthoai.Text.Trim();
                SqlHelper.ExecuteNonQuery(QLTV.Class.StrConnect.strConnect(), "NXB_Update", MaNXB, TenNXB, QuocGia, Email, DiaChi, DienThoai);
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
                string MaNXB = txtMa.Text.Trim();
                SqlHelper.ExecuteNonQuery(QLTV.Class.StrConnect.strConnect(), "NXB_Delete", MaNXB);
                loaddulieu();
            }
            catch (Exception)
            {

            }
        }
    }
}
