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
    public partial class FormPhieuNhap : Form
    {
        public FormPhieuNhap()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void KhoaDieuKhien()
        {
            txtMaPhieu.Enabled = false;

            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            cbmMaKho.Enabled = false;
            cbmThuKho.Enabled = false;
            cbmMaCC.Enabled = false;
            dtpDate.Enabled = false;
        }
        public void MoDieuKhien()
        {
            txtMaPhieu.Enabled = true;

            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = true;
            cbmMaKho.Enabled = true;
            cbmThuKho.Enabled = true;
            cbmMaCC.Enabled = true;
            dtpDate.Enabled = true;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhieu.Text = dgvList.CurrentRow.Cells["MaPN"].Value.ToString();
            cbmMaCC.SelectedValue = dgvList.CurrentRow.Cells["MaCC"].Value.ToString();
            cbmThuKho.SelectedValue = dgvList.CurrentRow.Cells["MaThuKho"].Value.ToString();
            cbmMaKho.SelectedValue = dgvList.CurrentRow.Cells["MaKho"].Value.ToString();
            dtpDate.Text = dgvList.CurrentRow.Cells["NgayNhap"].Value.ToString();

            KhoaDieuKhien();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }
        private void FormRefresh()
        {
            txtMaPhieu.Text = string.Empty;

            txtTimKiem.Text = string.Empty;
            cbmMaKho.Text = string.Empty;
            cbmThuKho.Text = string.Empty;
            cbmMaCC.Text = string.Empty;

            KhoaDieuKhien();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

           
                if (txtTimKiem.Text == "")
                {
                    dgvList.DataSource = BusData.PN_select();
                }
            dgvList.DataSource = BusData.PN_search(txtTimKiem.Text);
        }

        private void btnHoan_Click(object sender, EventArgs e)
        {
            FormRefresh();
            dgvList.DataSource = BusData.PN_select();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormRefresh();
            MoDieuKhien();
            edit = false;
             txtMaPhieu.Text = GetCode();
            txtMaPhieu.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text == "")
                return;
            if (MessageBox.Show("Xóa thông tin Mã phiếu", "Xóa", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int res = BusData.PN_delete(txtMaPhieu.Text);
                if (res < 0)
                {
                    MessageBox.Show("Thất bại");
                }
                else
                {
                    MessageBox.Show("Đã xóa");
                    dgvList.DataSource = BusData.PN_select();
                    FormRefresh();
                }
            }
        }
        bool edit;

        private void btnLuu_Click(object sender, EventArgs e)
        {
            PhieuNhap_obj pn = new PhieuNhap_obj()
            {
                maphieunhap = txtMaPhieu.Text,
                manhacc = cbmMaCC.SelectedValue.ToString(),

                makho = cbmMaKho.SelectedValue.ToString(),
                mathukho = cbmThuKho.SelectedValue.ToString(),
                ngaynhap = Convert.ToDateTime(dtpDate.Text),

            };

            int res = 0;
            if (edit)
                res = BusData.PN_update(pn);
            else res = BusData.PN_insert(pn);

            if (res < 0)
            {
                MessageBox.Show("Thất bại");

            }
            else
            {
                MessageBox.Show("Đã cập nhật");
                dgvList.DataSource = BusData.PN_select();
                FormRefresh();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MoDieuKhien();
            edit = true;
            txtMaPhieu.Enabled = false;
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
        #region Mã tự động
        private string GetCode()
        {


            List<string> dsMa = new List<string>();
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                if (row.Index < dgvList.Rows.Count - 1)
                    dsMa.Add(row.Cells["MaPN"].Value.ToString());
            }
            string sub = dsMa[0].Substring(0, dsMa[0].Length - 3);
            int i = 1;
            int count = 0;
            string s = string.Empty;
            while (count <= dsMa.Count)
            {
                s = sub;
                if (i < 10) s = "PN"+"00" + i;
                else if (10 <= i && i < 100) s = "PN"+"0" + i;
                else if (i >= 100) s = i.ToString();
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

        private void FormPhieuNhap_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            dgvList.DataSource = BusData.PN_select();
            // load cmb kho hang
            cbmMaKho.DataSource = BusData.KH_select();
            cbmMaKho.ValueMember = "MaKho";
            cbmMaKho.DisplayMember = "TenKho";
            // load cbm ma nha cung cap
            cbmMaCC.DataSource = BusData.NCC_select();
            cbmMaCC.ValueMember = "MaCC";
            cbmMaCC.DisplayMember = "TenCC";
            //load cbm thu kho
            cbmThuKho.DataSource = BusData.TK_select();
            cbmThuKho.ValueMember = "MaThuKho";
            cbmThuKho.DisplayMember = "TenThuKho";
            // load txt tim kiem
           

            dgvList.Columns["MaPN"].HeaderText = " Mã phiếu nhập ";
            dgvList.Columns["MaCC"].HeaderText = " Nhà cung cấp ";
            dgvList.Columns["MaThuKho"].HeaderText = " Mã thủ kho ";
            dgvList.Columns["NgayNhap"].HeaderText = " Ngày nhập ";
            dgvList.Columns["MaKho"].HeaderText = " Mã kho ";

        }
    }
}
