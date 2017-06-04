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
    public partial class FormChinhsuahanghoa : Form
    {
        public FormChinhsuahanghoa()
        {
            InitializeComponent();
        }
        public string Masanpham, Tensanpham, Gianhap, Giaban, Soluong;
        private void FormChinhsuahanghoa_Load(object sender, EventArgs e)
        {
            txtMasanpham.Text = Masanpham;
            txtMasanpham.Enabled = false;
            txtTensanpham.Text = Tensanpham;
            txtGianhap.Text = Gianhap;
            txtGiaban.Text = Giaban;
            txtSoluong.Text = Soluong;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = @"select hh.Masanpham from HANGHOA hh";
            DataTable dt = DataProvider.LoadCSDL(sql);
            int n = dt.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                if (txtMasanpham.Text == dt.Rows[i][0].ToString())
                {
                    if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Thay Đổi Thông Tin Sản Phẩm Này?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            string sqlsua = @"update HANGHOA 
                                          set Tensanpham = N'" + txtTensanpham.Text + "', Gianhap = '" + float.Parse(txtGianhap.Text) + "', Giaban = '" + float.Parse(txtGiaban.Text) + "', Soluong = '" + int.Parse(txtSoluong.Text) + "' where HANGHOA.Masanpham = '"+int.Parse(txtMasanpham.Text)+"'";
                            int ketqua = DataProvider.change(sqlsua);
                            if (ketqua > 0)
                            {
                                MessageBox.Show("Cập Nhật Sản Phẩm Thành Công", "Cập Nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Cập Nhật Thất Bại");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Cập Nhật Thất Bại");
                        }
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = @"select hh.Masanpham from HANGHOA hh";
            DataTable dt = DataProvider.LoadCSDL(sql);
            int n = dt.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                if (txtMasanpham.Text == dt.Rows[i][0].ToString())
                {
                    if (MessageBox.Show("Bạn Có Chắc Chắn Xóa Sản Phẩm Này?", "Xóa Sản Phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            string sqlxoa = @"delete from HANGHOA where HANGHOA.Masanpham = '" + int.Parse(txtMasanpham.Text) + "'";
                            int ketqua = DataProvider.change(sqlxoa);
                            if (ketqua > 0)
                            {
                                MessageBox.Show("Xóa Thành Công", "Xóa Sản Phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Xóa Thất Bại");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Xóa Thất Bại");
                        }
                    }
                    break;
                }
            }
        }
    }
}
