using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace project
{
    public partial class FormHanghoa : Form
    {
        public FormHanghoa()
        {
            InitializeComponent();
        }

        private void FormHanghoa_Load(object sender, EventArgs e)
        {
            lblThemsoluong.Text = "2.Chức Năng Thêm Số Lượng Một Mặt Hàng Có Trong Kho Nằm Trong Mục Tìm Kiếm";
            Loadsanpham();
           // dgvSanpham.Columns[5].Width = 100;
        }
        void Loadsanpham()
        {
            string sql = @"select hh.Masanpham as 'Mã Sản Phẩm', hh.Tensanpham as 'Tên Sản Phẩm', hh.Gianhap as 'Giá Nhập',hh.Giaban as 'Giá Bán', hh.Soluong as 'Số Lượng' from HANGHOA hh";
            DataTable dt = DataProvider.LoadCSDL(sql);
            dgvSanpham.DataSource = dt;
            dgvSanpham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSanpham.Columns[0].Width = 150;
            dgvSanpham.Columns[1].Width = 258;
            dgvSanpham.Columns[2].Width = 150;
            dgvSanpham.Columns[3].Width = 150;
            dgvSanpham.Columns[4].Width = 120;
        }
        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            bool kiemtranhaplieu = true;
            if (txtMasanpham.Text == "")
            {
                MessageBox.Show("Chưa Nhập Mã Sản Phẩm");
                kiemtranhaplieu = false;
                txtMasanpham.Focus();
            }
            else if (txtTensanpham.Text == "")
            {
                MessageBox.Show("Chưa Nhập Tên Sản Phẩm");
                kiemtranhaplieu = false;
                txtTensanpham.Focus();
            }
            else if (txtGianhap.Text == "")
            {
                MessageBox.Show("Chưa Nhập Giá Nhập");
                kiemtranhaplieu = false;
                txtGianhap.Focus();
            }
            else if (txtGiaban.Text == "")
            {
                MessageBox.Show("Chưa Nhập Giá Bán");
                kiemtranhaplieu = false;
                txtGiaban.Focus();
            }
            else if (txtSoluong.Text == "")
            {
                MessageBox.Show("Chưa Nhập Số Lượng");
                kiemtranhaplieu = false;
                txtSoluong.Focus();
            }
            string sqlma = @"select hh.Masanpham from HANGHOA hh";
            DataTable dtma = DataProvider.LoadCSDL(sqlma);
            int n = dtma.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                if (txtMasanpham.Text == dtma.Rows[i][0].ToString())
                {
                    MessageBox.Show("Mã Sản Phẩm Đã Bị Trùng");
                    kiemtranhaplieu = false;
                    txtMasanpham.Clear();
                    txtMasanpham.Focus();
                }
            }
            if (kiemtranhaplieu == true)
            {
                try
                {
                    string sqlthem = @"insert HANGHOA(Masanpham,Tensanpham,Gianhap,Giaban,Soluong) 
                                   values ('" + int.Parse(txtMasanpham.Text) + "', N'" + txtTensanpham.Text + "', '" + float.Parse(txtGianhap.Text) + "', '" + float.Parse(txtGiaban.Text) + "', '" + int.Parse(txtSoluong.Text) + "')";
                    int ketqua = DataProvider.change(sqlthem);
                    if (ketqua > 0)
                    {
                        MessageBox.Show("Thêm Sản Phẩm Thành Công", "Thêm Sản Phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loadsanpham();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Thất Bại");
                    }
                }
                catch
                {
                    MessageBox.Show("Thêm Thất Bại");
                }
            }
        }

        private void txtMasanpham_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void txtGianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void txtGiaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            FormTimkiemhanghoa frmhanghoa = new FormTimkiemhanghoa();
            frmhanghoa.ShowDialog();
        }
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            Loadsanpham();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMenu frmmenu = new FormMenu();
            this.Hide();
            frmmenu.Closed += (s, args) => this.Close();
            frmmenu.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormNhanVien frmnhanvien = new FormNhanVien();
            this.Hide();
            frmnhanvien.Closed += (s, args) => this.Close();
            frmnhanvien.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Form1 frmhanghoa = new Form1();
            this.Hide();
            frmhanghoa.Closed += (s, args) => this.Close();
            frmhanghoa.ShowDialog();
        }
    }
}
