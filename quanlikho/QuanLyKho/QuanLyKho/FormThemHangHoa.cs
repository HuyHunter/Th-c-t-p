using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKho.Bus;
using QuanLyKho.Dao;
namespace QuanLyKho
{
    public partial class FormThemHangHoa : Form
    {
        public FormThemHangHoa()
        {
            InitializeComponent();
        }

        private bool edit;
        public void KhoaDieuKhien()
        {
            txtMaHang.Enabled = false;
            txtTenHang.Enabled = false;
            txtTinhTrang.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            cbmMaKho.Enabled = false;
            cbmMaLoaiHang.Enabled = false;
            txtDonGia.Enabled = false;
        }
        public void MoDieuKhien()
        {
            txtMaHang.Enabled = true;
            txtTenHang.Enabled = true;
            txtTinhTrang.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = true;
            cbmMaKho.Enabled = true;
            cbmMaLoaiHang.Enabled = true;
            txtDonGia.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHang.Text = dgvList.CurrentRow.Cells["MaHang"].Value.ToString();
            txtTenHang.Text = dgvList.CurrentRow.Cells["TenHang"].Value.ToString();
            txtTinhTrang.Text = dgvList.CurrentRow.Cells["TinhTrang"].Value.ToString();
            cbmMaLoaiHang.SelectedValue = dgvList.CurrentRow.Cells["MaLoaiHang"].Value.ToString();
            cbmMaKho.SelectedValue = dgvList.CurrentRow.Cells["MaKho"].Value.ToString();
            txtDonGia.Text = dgvList.CurrentRow.Cells["DonGia"].Value.ToString();

            KhoaDieuKhien();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }
        private void FormRefresh()
        {
            txtMaHang.Text = string.Empty;
            txtTenHang.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;
            txtDonGia.Text = string.Empty;
            txtTimKiem.Text = string.Empty;
            cbmMaKho.Text = string.Empty;
            cbmMaLoaiHang.Text = string.Empty;

            KhoaDieuKhien();
        }

        #region Mã tự động
        private string GetCode()
        {
           

            List<string> dsMa = new List<string>();
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                if (row.Index < dgvList.Rows.Count - 1)
                    dsMa.Add(row.Cells["MaHang"].Value.ToString());
            }
            string sub = dsMa[0].Substring(0, dsMa[0].Length - 3);
            int i = 1;
            int count = 0;
            string s = string.Empty;
            while (count <= dsMa.Count)
            {
                s = sub;
                if (i < 10) s =   "00" + i;
                else if (10 <= i && i < 100) s =   "0" + i;
                else if (i >= 100) s =  i.ToString();
                int t = 0;
                for (t = 0; t < dsMa.Count; t++)
                {
                    if (dsMa[t].Contains(s))
                    {
                        break;
                    }
                }
                if (t == dsMa.Count)
                    break;
                else
                {
                    count++;
                    i++;
                }
            }
            return s;
        }
        #endregion

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
                dgvList.DataSource = BusData.HH_select();

            dgvList.DataSource = BusData.HH_search(txtTimKiem.Text,txtTimKiem.Text);
        }

        private void btnHoan_Click(object sender, EventArgs e)
        {
            FormRefresh();
            dgvList.DataSource = BusData.HH_select();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text == "")
                return;
            if (MessageBox.Show("Xóa thông tin Hàng hóa", "Xóa", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int res = BusData.HH_delete(txtMaHang.Text);
                if (res < 0)
                {
                    MessageBox.Show("Thất bại");
                }
                else {
                    MessageBox.Show("Đã xóa");
                    dgvList.DataSource = BusData.HH_select();
                    FormRefresh();
                } 
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            HangHoa_obj hh = new HangHoa_obj()
            {
                mahang = txtMaHang.Text,
                tenhang = txtTenHang.Text,
                tinhtrang = txtTinhTrang.Text,
                makho = cbmMaKho.SelectedValue.ToString(),
                maloaihang = cbmMaLoaiHang.SelectedValue.ToString(),
                dongia = Int32.Parse(txtDonGia.Text),
               
            };

            int res = 0;
            if (edit)
                res = BusData.HH_update(hh);
            else res = BusData.HH_insert(hh);

            if (res < 0)
            {
                MessageBox.Show("Thất bại");
                
            }
            else
            {
                MessageBox.Show("Đã cập nhật");
                dgvList.DataSource = BusData.HH_select();
                FormRefresh();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MoDieuKhien();
            edit = true;
            txtMaHang.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormRefresh();
            MoDieuKhien();
            edit = false;
            txtMaHang.Text = GetCode();
            txtMaHang.Enabled = false;
        }

        private void FormThemHangHoa_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            dgvList.DataSource = BusData.HH_select();
            // load cmb kho hang
            cbmMaKho.DataSource = BusData.KH_select();
            cbmMaKho.ValueMember = "MaKho";
            cbmMaKho.DisplayMember = "TenKho";
            // load cbm ma loai hang
            cbmMaLoaiHang.DataSource = BusData.LHH_select();
            cbmMaLoaiHang.ValueMember = "MaLoaiHang";
            cbmMaLoaiHang.DisplayMember = "MaLoaiHang";
            // load txt tim kiem
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                if (row.Index < dgvList.Rows.Count - 1)
                {
                    txtTimKiem.AutoCompleteCustomSource.Add(row.Cells["MaHang"].Value.ToString());
                    txtTimKiem.AutoCompleteCustomSource.Add(row.Cells["TenHang"].Value.ToString());
                    txtTimKiem.AutoCompleteCustomSource.Add(row.Cells["DonGia"].Value.ToString());
                    txtTimKiem.AutoCompleteCustomSource.Add(row.Cells["TinhTrang"].Value.ToString());
                    txtTimKiem.AutoCompleteCustomSource.Add(row.Cells["MaKho"].Value.ToString());
                    txtTimKiem.AutoCompleteCustomSource.Add(row.Cells["MaLoaiHang"].Value.ToString());
                }
            }

            dgvList.Columns["MaHang"].HeaderText = " Mã hàng ";
            dgvList.Columns["TenHang"].HeaderText = " Tên hàng ";
            dgvList.Columns["DonGia"].HeaderText = " Đơn giá ";
            dgvList.Columns["TinhTrang"].HeaderText = " Tình trạng ";
            dgvList.Columns["MaKho"].HeaderText = " Mã kho ";
            dgvList.Columns["MaLoaiHang"].HeaderText = "   Mã loại hàng   ";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            this.Hide();
            f.ShowDialog();
            
        }

      
    }
}
