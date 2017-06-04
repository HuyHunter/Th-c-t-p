using Microsoft.ApplicationBlocks.Data;
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
    public partial class DichVu : Form
    {
        string strConnect = @"Data Source = JOJO-PC\SQLEXPRESS;Initial Catalog = QL_KhachSan; Integrated Security = True";
        //string strConnect = @"Data Source = PHAMTUNG\SQLEXPRESS;Initial Catalog = QL_KhachSan; Integrated Security = True";
        //string strConnect = @"Data Source=KN-PC\KN;Initial Catalog=QL_KhachSan;Integrated Security=True";

        public DichVu()
        {
            InitializeComponent();
            Load += DichVu_Load;
        }

        private void LoadDichVu()
        {
            dgvHienThi.DataSource = SqlHelper.ExecuteDataset(strConnect, "Select_DichVu").Tables[0];
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string Madv = txtMadv.Text.Trim();
                string Tendv = txtTendv.Text.Trim();
                string Gia = txtGia.Text.Trim();
                string DVT = txtDVT.Text.Trim();
                SqlHelper.ExecuteNonQuery(strConnect, "Insert_Dichvu", Madv, Tendv, Gia, DVT);
                MessageBox.Show("Thêm thành công", "THông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Lỗi");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            fm.Show();
            this.Hide();

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoadDichVu();
        }

        private void DichVu_Load(object sender, EventArgs e)
        {
            LoadDichVu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string MaDV = txtMadv.Text.Trim();
                SqlHelper.ExecuteNonQuery(strConnect, "Delete_Dichvu", MaDV);
                LoadDichVu();
            }
            catch (Exception)
            {
                MessageBox.Show("xóa không thành công");
            }
        }
    }
}
