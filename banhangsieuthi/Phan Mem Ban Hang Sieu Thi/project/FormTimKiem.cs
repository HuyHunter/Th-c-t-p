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
    public partial class FormTimKiem : Form
    {
        public FormTimKiem()
        {
            InitializeComponent();
        }
        public string manhanvien, tennhanvien, diachi, sodienthoai, hesoluong, luongcanban, Ngaysinh;
        public DateTime ngaysinh;
        public int gioitinh, phongban, Thang, Nam; // 0 là nam, 1 là nữ;
        public double Ngay;
        private void FormTimKiem_Load(object sender, EventArgs e)
        {
            dtpNgaysinh.Format = DateTimePickerFormat.Custom;
            dtpNgaysinh.CustomFormat = "yyyy/MM/dd";
            // MessageBox.Show(dtpNgaysinh.Value.ToString() + "dài " + dtpNgaysinh.Value.ToString().Length.ToString());
            dtpNgaysinh.Value.AddDays(Ngay);
            dtpNgaysinh.Value.AddMonths(Thang);
            dtpNgaysinh.Value.AddYears(Nam);

            string sql = @"select * from PHONGBAN";
            DataTable dt = DataProvider.LoadCSDL(sql);
            cmbPhongban.DataSource = dt;
            cmbPhongban.DisplayMember = "Tenphongban";
            cmbPhongban.ValueMember = "Maphongban";
            cmbPhongban.SelectedIndex = phongban - 1;
            txtManhanvien.Text = manhanvien;
            txtManhanvien.Enabled = false;
            txtTennhanvien.Text = tennhanvien;
            txtDiachi.Text = diachi;
            txtPhone.Text = sodienthoai;
            txtLuongcanban.Text = luongcanban;
            if (gioitinh == 1)
            {
                rdbNam.Checked = true;
            }
            else if (gioitinh == 2)
            {
                rdbNu.Checked = true;
            }
            txtHesoluong.Text = hesoluong;
            txtNgaysinh.Text = Ngaysinh;
           // dtpNgaysinh.Value = ngaysinh;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sqlphongban = @"select pb.Maphongban, pb.Soluong from PHONGBAN pb where pb.Maphongban = '" + cmbPhongban.SelectedValue + "'";
            DataTable dtphongban = DataProvider.LoadCSDL(sqlphongban);
            int demsoluongphongban = int.Parse(dtphongban.Rows[0][1].ToString());


            string sql = @"select nv.Manhanvien from NHANVIEN nv";
            DataTable dt = DataProvider.LoadCSDL(sql);
            int n = dt.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                if (txtManhanvien.Text == dt.Rows[i][0].ToString().Trim())
                {
                    if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Xóa Nhân Viên Này?", "Xóa Nhân Viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            string sqlxoa = @"delete NHANVIEN where NHANVIEN.Manhanvien = '" + int.Parse(txtManhanvien.Text) + "'";
                            int ketqua = DataProvider.change(sqlxoa);
                            if (ketqua > 0)
                            {
                                MessageBox.Show("Xóa Thành Công", "Xóa Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                string sqlxoaphongban = @"update PHONGBAN set Soluong = '" + (demsoluongphongban - 1) + "' where PHONGBAN.Maphongban = '" + cmbPhongban.SelectedValue + "'";
                                int ketquathemphongban = DataProvider.change(sqlxoaphongban);
                                if (ketquathemphongban < 0)
                                {
                                    MessageBox.Show("Cập Nhật Số Lượng Phòng Ban Thất Bại");
                                }
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            string gioitinh1 = "";
            if (rdbNam.Checked == true)
            {
                gioitinh1 = "Nam";
            }
            else if (rdbNu.Checked == true)
            {
                gioitinh1 = "Nữ";
            }
            if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Cập Nhật Lại Thông Tin Nhân Viên Này?", "Cập Nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sqlsua = @"update NHANVIEN 
                              set Tennhanvien = N'" + txtTennhanvien.Text + "', Ngaysinh = '" + dtpNgaysinh.Value.ToString("yyyy/MM/dd") + "', Gioitinh = '" + gioitinh1 + "' ,Diachi = N'" + txtDiachi.Text + "', Sodienthoai = '" + txtPhone.Text + "', Maphongban = '" + cmbPhongban.SelectedValue + "', Hesoluong = '" + float.Parse(txtHesoluong.Text) + "', Luongcanban = '" + float.Parse(txtLuongcanban.Text) + "' where NHANVIEN.Manhanvien = '" + int.Parse(txtManhanvien.Text) + "'";
                    int ketqua = DataProvider.change(sqlsua);
                    if (ketqua > 0)
                    {
                        MessageBox.Show("Cập Nhật Thành Công", "Cập Nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
