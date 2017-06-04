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
    public partial class FormNhapHang : Form
    {
        public FormNhapHang()
        {
            InitializeComponent();
        }
        bool edit;
        #region Controls
        private void FormRefresh()
        {
            cbmMaPhieu.Text = string.Empty;
            
            txtMaHang.Text = string.Empty;

            txtTimKiem.Text = string.Empty;
            txtTimKiem.Text = "What can i help you find?";
            // refresh lai dgv List
            dgvList.DataSource = BusData.NH_select();

            // load lai txt Tim kiem
            //   TimKiem();
        }

        private void LockControls()
        {
            txtMaHang.Enabled = false;


            cbmMaPhieu.Enabled = false;


            btnCapNhat.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void UnlockControls()
        {
            if (!edit)
                cbmMaPhieu.Enabled = true;
           
            txtMaHang.Enabled = true;
          
            btnCapNhat.Enabled = true;
        }
        #endregion
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {

        }
        

        private void FormNhapHang_Load(object sender, EventArgs e)
        {
            LockControls();
            dgvList.DataSource = BusData.NH_select();
           
            cbmMaPhieu.DataSource = BusData.PN_select();
            cbmMaPhieu.DisplayMember = "MaPN";
            cbmMaPhieu.ValueMember = "MaPN";
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            FormPhieuNhap f = new FormPhieuNhap();
            f.ShowDialog();
        }


        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHang.Text = dgvList.CurrentRow.Cells["MaHang"].Value.ToString();
            cbmMaPhieu.SelectedValue = dgvList.CurrentRow.Cells["MaPN"].Value.ToString();
        }
        private void btnThemHang_Click(object sender, EventArgs e)
        {
            FormThemHangHoa f = new FormThemHangHoa();
            this.Hide();
            f.ShowDialog();

        }

        #region Them Sua Xoa Luu
        private void toolStripLabel1_Click(object sender, EventArgs e)//Thêm
        {

            FormRefresh();
          //  txtID.Text = GetCode();
            edit = false;

            dgvChon.DataSource = BusData.CHH_select();
            UnlockControls();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Xóa tất cả bản ghi liên quan", "Xóa", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (BusData.NH_delete(cbmMaPhieu.Text) > 0)
                {
                    MessageBox.Show("Đã xóa");
                    FormRefresh();
                    LockControls();
                }
                else MessageBox.Show("Thất bại");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            
           
          

            int res = 0;
            List<ChiTietPhieuNhap_obj> listpn = new List<ChiTietPhieuNhap_obj>();
            if (!edit)
            {
                // load danh sach hang hoa them vao phieu
                foreach (DataGridViewRow row in dgvChon.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells["Chon"] as DataGridViewCheckBoxCell;
                    if ((bool)cell.EditedFormattedValue == true)
                    {

                        listpn.Add(new ChiTietPhieuNhap_obj()
                        {
                            mahang = row.Cells["MaHang"].Value.ToString(),
                            //id = txtID.Text,
                            maphieu = cbmMaPhieu.Text,


                        });
                    }
                }
                if (listpn.Count > 0)
                {
                    foreach (ChiTietPhieuNhap_obj ctpn in listpn)
                    {
                        res = BusData.NH_insert(ctpn);
                        if (res == 0)
                            break;
                    }
                    if (res == 0)
                    {
                        MessageBox.Show("Thất bại");
                        return;
                    }
                }
            }
                if (edit)
                {
                    res = 0;
                    if (txtMaHang.Text != "")
                    {
                        ChiTietPhieuNhap_obj ctpn = new ChiTietPhieuNhap_obj
                        {
                            mahang = txtMaHang.Text,
                            maphieu = cbmMaPhieu.Text,
                            //id = txtID.Text
                        };
                        res = BusData.NH_update(ctpn);
                    }
                    if (res == 0)
                    {
                        MessageBox.Show("Thất bại");
                        return;
                    }



                }
                if (res > 0)
                {
                    MessageBox.Show("Đã cập nhật");
                    FormRefresh();
                     LockControls();
                    dgvList.DataSource = BusData.NH_select();
                    return;
                }
                else
                {
                    MessageBox.Show("Thất bại");
                    return;
                }
            
            #endregion
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            edit = true;
            UnlockControls();
            txtMaHang.Enabled = false;
            cbmMaPhieu.Enabled = true;
           
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            FormHoaDonNhap f = new FormHoaDonNhap();
            this.Hide();
            f.ShowDialog();

        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            this.Hide();
            fm.ShowDialog();
        }
    } }
