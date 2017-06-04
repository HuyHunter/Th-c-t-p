using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Windows.Forms;


namespace formDangNhap
{
    public partial class DoDungTrongPhong : Form
    {
   
        string strConnect = @"Data Source=JOJO-PC\SQLEXPRESS;Initial Catalog=QL_KhachSan;Integrated Security=True";
        public DoDungTrongPhong()
        {
            InitializeComponent();
            Load += Dodungtrongphong;
        }

        private void Dodungtrongphong(object sender, EventArgs e)
        {
            loadCBBMaPhong();
            loadddtp();
            loadCBBMaDodung();
        }

        private void loadddtp()
        {
            dgvHienThi.DataSource = SqlHelper.ExecuteDataset(strConnect, "Load_Ddtp").Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            this.Hide();
            fm.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = cbb2.SelectedValue.ToString();
                string tinhtrang = txtTinhTrang.Text.Trim();
                string maphong = cbb1.SelectedValue.ToString();
                string DVT = cbb3.SelectedValue.ToString();
                string SL = txtSoluong.Text.Trim();
                SqlHelper.ExecuteNonQuery(strConnect, "Insert_Ddtp", ma,SL,DVT,tinhtrang,maphong);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Lỗi");
            }
        }
        public void loadCBBMaPhong()
        {
            DataTable dthv;
            dthv = SqlHelper.ExecuteDataset(strConnect, "Load_MaPhong").Tables[0];
            cbb1.DataSource = dthv;
            cbb1.DisplayMember = "TenPhong";
            cbb1.ValueMember = "MaPhong";
        }
        public void loadCBBMaDodung()
        {
            DataTable dtdd;
            dtdd = SqlHelper.ExecuteDataset(strConnect, "Load_MaDodung").Tables[0];
            cbb2.DataSource = dtdd;
            cbb2.DisplayMember = "TenDD";
            cbb2.ValueMember = "MaDD";
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            loadddtp();
        }

        private void cbb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtdd;
            string ma = cbb2.SelectedValue.ToString();
            dtdd = SqlHelper.ExecuteDataset(strConnect, "Load_DVTDD", ma).Tables[0];
            cbb3.DataSource = dtdd;
            cbb3.ValueMember = "DonViTinh";
            cbb3.DisplayMember = "DonViTinh";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
        }

        private void DoDungTrongPhong_Load(object sender, EventArgs e)
        {
            loadddtp();
        }
    }
}
