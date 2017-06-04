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
    public partial class ControlDausach : UserControl
    {
        string strConnect = @"Data Source =LATITUDE-PC;Initial Catalog = QL_KhachSan; Integrated Security = True";
        public ControlDausach()
        {
            InitializeComponent();
            this.Load += loaddausach;
        }

        private void loaddausach(object sender, EventArgs e)
        {
            loaddulieu();
        }

        private void loaddulieu()
        {
            dgvHienthi.DataSource = SqlHelper.ExecuteDataset(QLTV.Class.StrConnect.strConnect(), "loaddausach").Tables[0];
        }

        private void btCapnhat_Click(object sender, EventArgs e)
        {
            loaddulieu();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void loadCBBTheLoai()
        {
            DataTable dtdd;
            dtdd = SqlHelper.ExecuteDataset(strConnect, "loadtheloai").Tables[0];
            cbbTheloai.DataSource = dtdd;
            cbbTheloai.DisplayMember = "TenTheLoai";
            cbbTheloai.ValueMember = "MaTheLoai";
        }
        public void loadCBBNXB()
        {
            DataTable dtdd;
            dtdd = SqlHelper.ExecuteDataset(strConnect, "loadNXB").Tables[0];
            cbbNXB.DataSource = dtdd;
            cbbNXB.DisplayMember = "TenNXB";
            cbbNXB.ValueMember = "MaNXB";
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMa.Text.Trim();
                string tacgia = txtTacgia.Text.Trim();
                string soluong = txtSoluong.Text.Trim();
                string nhande = txtNhande.Text.Trim();
                string domat = txtDomat.Text.Trim();
                string ngonngu = txtNgonngu.Text.Trim();
                string theloai =cbbTheloai.SelectedValue.ToString();
                string maNXB = cbbNXB.SelectedValue.ToString();
                SqlHelper.ExecuteNonQuery(strConnect, "ADDTaiLieu", ma, tacgia, soluong,nhande,domat,ngonngu,theloai,maNXB);
                MessageBox.Show("thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("lỗi");
            }
        }
    }
}
