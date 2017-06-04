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
    public partial class DoDung : Form
    {
        //string strConnect = @"Data Source = PHAMTUNG\SQLEXPRESS;Initial Catalog = QL_KhachSan; Integrated Security = True";
        string strConnect = @"Data Source=JOJO-PC\SQLEXPRESS;Initial Catalog=QL_KhachSan;Integrated Security=True";
        public DoDung()
        {
            InitializeComponent();
            Load += DodungLoad;
        }

        private void DodungLoad(object sender, EventArgs e)
        {
            LoadDodung();
           
        }
        private void LoadDaTa()
        {
            txtMadd.DataBindings.Clear();
            txtMadd.DataBindings.Add("Text", dgvHienThi.DataSource, "MaDD");
            txtTendd.DataBindings.Clear();
            txtTendd.DataBindings.Add("Text", dgvHienThi.DataSource, "TenDD");
            txtSoluong.DataBindings.Clear();
            txtSoluong.DataBindings.Add("Text", dgvHienThi.DataSource, "SoLuong");
            txtGiamua.DataBindings.Clear();
            txtGiamua.DataBindings.Add("Text", dgvHienThi.DataSource, "DonViTinh");
            txtDVT.DataBindings.Clear();
            txtDVT.DataBindings.Add("Text", dgvHienThi.DataSource, "GiaMua");

        }
            
        private void LoadDodung()
        {
             dgvHienThi.DataSource = SqlHelper.ExecuteDataset(strConnect, "Load_Dodung").Tables[0];
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMadd.Text.Trim();
                string ten = txtTendd.Text.Trim();
                string gia = txtGiamua.Text.Trim();
                string DVT = txtDVT.Text.Trim();
                string SL = txtSoluong.Text.Trim();
                SqlHelper.ExecuteNonQuery(strConnect, "Insert_Dodung", ma, ten, SL, DVT, gia);
                MessageBox.Show("Thêm thành công", "THông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDodung();
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
            try
            {
                string MaDD = txtMadd.Text.Trim();
                string TenDD = txtTendd.Text.Trim();
                string GiaMua = txtGiamua.Text.Trim();
                string DonViTinh = txtDVT.Text.Trim();
                string SoLuong = txtSoluong.Text.Trim();
                SqlHelper.ExecuteNonQuery(strConnect, "Sua_DD", MaDD, TenDD, SoLuong, DonViTinh, GiaMua);
                MessageBox.Show("Sửa Thành Công", "THông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDodung();
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa Lỗi");
            }
        }

        private void DoDung_Load(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtMadd.Enabled = false;
            
        }

        private void dgvHienThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDaTa();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMadd.Text.Trim();
               
                SqlHelper.ExecuteNonQuery(strConnect, "Delete_Dodung", ma);
                MessageBox.Show("Xoá thành công", "THông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDodung();
            }
            catch (Exception)
            {
                MessageBox.Show("Chưa thể xóa!");
            }

        }
    }
}
