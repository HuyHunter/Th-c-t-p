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
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanvien();
        }
        void LoadNhanvien()
        {
            string sql = @"select nv.Manhanvien as 'Mã NV',nv.Tennhanvien as 'Tên Nhân Viên',nv.Ngaysinh as 'Ngày Sinh',nv.Gioitinh as 'Giới Tính',
                            nv.Diachi as 'Địa Chỉ',nv.Sodienthoai as 'Số Điện Thoại',pb.Tenphongban as 'Phòng Ban', nv.Hesoluong as 'HS Lương',nv.Luongcanban as 'Lương Căn Bản'
                           from NHANVIEN nv, PHONGBAN pb
                           where nv.Maphongban = pb.Maphongban";
            DataTable dt = DataProvider.LoadCSDL(sql);
            dgvNhanVien.DataSource = dt;
            dgvNhanVien.Columns[0].Width = 70;
            dgvNhanVien.Columns[1].Width = 155;
            dgvNhanVien.Columns[2].Width = 100;
            dgvNhanVien.Columns[3].Width = 80;
            dgvNhanVien.Columns[4].Width = 120;
            dgvNhanVien.Columns[5].Width = 100;
            dgvNhanVien.Columns[6].Width = 100;
            dgvNhanVien.Columns[7].Width = 50;
            dgvNhanVien.Columns[8].Width = 100;

            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.RowHeadersVisible = false;
            dtpNgaysinh.Format = DateTimePickerFormat.Custom;
            dtpNgaysinh.CustomFormat = "yyyy/MM/dd";
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            string sql2 = @"select * from PHONGBAN";
            DataTable dt2 = DataProvider.LoadCSDL(sql2);
            cmbPhongban.DataSource = dt2;
            cmbPhongban.DisplayMember = "Tenphongban";
            cmbPhongban.ValueMember = "Maphongban";
        }
        string timkiemnangcao;
        private void txtTimkiem_KeyUp(object sender, KeyEventArgs e)
        {
            timkiemnangcao = txtTimkiem.Text;
            TimkiemNangCao();
        }
        void TimkiemNangCao()
        {
            dgvNhanVien.DataSource = null;
            string sql = @"select nv.Manhanvien, nv.Tennhanvien,nv.Ngaysinh,nv.Gioitinh, nv.Diachi,nv.Sodienthoai,pb.Tenphongban, nv.Hesoluong,nv.Luongcanban
                           from NHANVIEN nv, PHONGBAN pb
                           where nv.Maphongban = pb.Maphongban";
            DataTable dt = DataProvider.LoadCSDL(sql);
            int n = dt.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                string tennhanvien = dt.Rows[i][1].ToString();
                if (dt.Rows[i][1].ToString().ToLower().Contains(timkiemnangcao.ToLower()))
                {
                    try
                    {
                        string sql2 = @"select nv.Manhanvien as 'Mã NV',nv.Tennhanvien as 'Tên Nhân Viên',nv.Ngaysinh as 'Ngày Sinh',nv.Gioitinh as 'Giới Tính',
                            nv.Diachi as 'Địa Chỉ',nv.Sodienthoai as 'Số Điện Thoại',pb.Tenphongban as 'Phòng Ban', nv.Hesoluong as 'HS Lương',nv.Luongcanban as 'Lương Căn Bản'
                           from NHANVIEN nv, PHONGBAN pb
                           where nv.Maphongban = pb.Maphongban and nv.Tennhanvien = N'" + tennhanvien + "'";
                        DataTable dt2 = DataProvider.LoadCSDL(sql2);
                        dgvNhanVien.DataSource = dt2;
                        dgvNhanVien.Columns[0].Width = 70;
                        dgvNhanVien.Columns[1].Width = 160;
                        dgvNhanVien.Columns[2].Width = 100;
                        dgvNhanVien.Columns[3].Width = 80;
                        dgvNhanVien.Columns[4].Width = 120;
                        dgvNhanVien.Columns[5].Width = 100;
                        dgvNhanVien.Columns[6].Width = 100;
                        dgvNhanVien.Columns[7].Width = 50;
                        dgvNhanVien.Columns[8].Width = 100;
                    }
                    catch
                    {
                        MessageBox.Show("Không Thành Công");
                    }
                }
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            string sql2 = @"select nv.Manhanvien as 'Mã NV',nv.Tennhanvien as 'Tên Nhân Viên',nv.Ngaysinh as 'Ngày Sinh',nv.Gioitinh as 'Giới Tính',
                            nv.Diachi as 'Địa Chỉ',nv.Sodienthoai as 'Số Điện Thoại',pb.Tenphongban as 'Phòng Ban', nv.Hesoluong as 'HS Lương',nv.Luongcanban as 'Lương Căn Bản'
                           from NHANVIEN nv, PHONGBAN pb
                           where nv.Maphongban = pb.Maphongban";
            DataTable dt2 = DataProvider.LoadCSDL(sql2);
            dgvNhanVien.DataSource = dt2;
            dgvNhanVien.Columns[0].Width = 70;
            dgvNhanVien.Columns[1].Width = 150;
            dgvNhanVien.Columns[2].Width = 100;
            dgvNhanVien.Columns[3].Width = 80;
            dgvNhanVien.Columns[4].Width = 120;
            dgvNhanVien.Columns[5].Width = 100;
            dgvNhanVien.Columns[6].Width = 100;
            dgvNhanVien.Columns[7].Width = 50;
            dgvNhanVien.Columns[8].Width = 100;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            bool kiemtranhaplieu = true;
            if (txtManhanvien.Text == "")
            {
                MessageBox.Show("Chưa Nhập Mã Nhân Viên");
                kiemtranhaplieu = false;
                txtManhanvien.Focus();
            }
            else if (txtTennhanvien.Text == "")
            {
                MessageBox.Show("Chưa Nhập Tên Nhân Viên");
                kiemtranhaplieu = false;
                txtTennhanvien.Focus();
            }
            else if (txtDiachi.Text == "")
            {
                MessageBox.Show("Chưa Nhập Địa Chỉ");
                kiemtranhaplieu = false;
                txtDiachi.Focus();
            }
            else if (rdbNam.Checked == false && rdbNu.Checked == false)
            {
                MessageBox.Show("Chưa Chọn Giới Tính");
                kiemtranhaplieu = false;
            }
            else if (txtPhone.Text == "")
            {
                MessageBox.Show("Chưa Nhập Số Điện Thoại");
                kiemtranhaplieu = false;
                txtPhone.Focus();
            }
            else if (txtHesoluong.Text == "")
            {
                MessageBox.Show("Chưa Nhập Hệ Số Lương");
                kiemtranhaplieu = false;
                txtHesoluong.Focus();
            }
            else if (txtLuongcanban.Text == "")
            {
                MessageBox.Show("Chưa Nhập Lương Căn Bản");
                kiemtranhaplieu = false;
                txtLuongcanban.Focus();
            }
            else
            {
                string sqlmaso = @"select nv.Manhanvien from NHANVIEN nv";
                DataTable dtmaso = DataProvider.LoadCSDL(sqlmaso);
                int n = dtmaso.Rows.Count;
                try
                {
                    int maso = int.Parse(txtManhanvien.Text);
                    for (int i = 0; i < n; i++)
                    {
                        if (maso == int.Parse(dtmaso.Rows[i][0].ToString()))
                        {
                            MessageBox.Show("Mã Nhân Viên Đã Bị Trùng");
                            kiemtranhaplieu = false;
                            txtManhanvien.Focus();
                            break;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Mã Nhân Viên Không Hợp Lệ");
                    kiemtranhaplieu = false;
                    txtManhanvien.Focus();
                }
            }
            bool kiemtradaydu = true;
            if (kiemtranhaplieu == true)
            {
                try
                {
                    float hesoluong = float.Parse(txtHesoluong.Text);
                }
                catch
                {
                    MessageBox.Show("Hệ Số Lương Không Hợp Lệ");
                    kiemtradaydu = false;
                    txtHesoluong.Focus();
                }
                try
                {
                    float luongcanban = float.Parse(txtLuongcanban.Text);
                }
                catch
                {
                    MessageBox.Show("Lương Căn Bản Không Hợp Lệ");
                    kiemtradaydu = false;
                    txtLuongcanban.Focus();
                }
            }
            string gioitinh = "";
            if (rdbNam.Checked == true)
            {
                gioitinh = "Nam";
            }
            else if (rdbNu.Checked == true)
            {
                gioitinh = "Nữ";
            }
            string sqlphongban = @"select pb.Maphongban, pb.Soluong from PHONGBAN pb where pb.Maphongban = '"+cmbPhongban.SelectedValue+"'";
            DataTable dtphongban = DataProvider.LoadCSDL(sqlphongban);
            int demsoluongphongban = int.Parse(dtphongban.Rows[0][1].ToString());
            if (kiemtradaydu == true)
            {
                try
                {
                    string sqlthem = @"insert NHANVIEN(Manhanvien,Tennhanvien,Ngaysinh,Gioitinh,Diachi,Sodienthoai,Maphongban,Hesoluong,Luongcanban)
                                   values ('" + int.Parse(txtManhanvien.Text) + "', N'" + txtTennhanvien.Text + "', '" + dtpNgaysinh.Value.ToString("yyyy/MM/dd") + "', N'" + gioitinh + "', N'" + txtDiachi.Text + "', '" + txtPhone.Text + "', '" + cmbPhongban.SelectedValue + "', '" + float.Parse(txtHesoluong.Text) + "', '" + float.Parse(txtLuongcanban.Text) + "')";
                    int ketqua = DataProvider.change(sqlthem);
                    if (ketqua > 0)
                    {
                        MessageBox.Show("Thêm Mới Nhân Viên Thành Công","Thêm Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // thêm số lượng nhân viên vào phòng ban
                        string sqlthemphongban = @"update PHONGBAN set Soluong = '"+(demsoluongphongban + 1)+"' where PHONGBAN.Maphongban = '"+cmbPhongban.SelectedValue+"'";
                        int ketquathemphongban = DataProvider.change(sqlthemphongban);
                        if (ketquathemphongban < 0)
                        {
                            MessageBox.Show("Thêm Số Lượng Phòng Ban Thất Bại");
                        }
                        LoadNhanvien();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Nhân Viên Thất Bại!");
                    }
                }
                catch
                {
                    MessageBox.Show("Thêm Nhân Viên Thất Bại");
                }
            }


        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true; // chặn nhập từ bàn phím
            }
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            FormTimkiemthaoma frmtimkiemthaoma = new FormTimkiemthaoma();
            frmtimkiemthaoma.ShowDialog();
        }

        private void btnSapxep_Click(object sender, EventArgs e)
        {
            MessageBox.Show("                              Giới Thiệu Các Tính Năng                         \n"
                            + "----------------------------------------------------------------------------\n\n"
                            + "1.Chức Năng Thêm : Nhập đầy đủ thông tin nhân viên rồi nhấn nút Thêm.\n\n"
                            + "2.Chức Năng Tìm Kiếm : Dùng để tìm kiếm thông tin Nhân Viên theo mã nhân viên.\n"
                            + "Chức năng tìm kiếm bao gồm 2 chức năng Sửa và Xóa nhân viên tìm thấy.\n"
                            + "  + Chức Năng Sửa : Thay đổi thông tin nhân viên trên bảng rồi nhấn nút sửa.\n"
                            + "  + Chức Năng Xóa : Chọn để xóa nhân viên.\n\n"
                            + "3.Chức Năng Cập Nhật : Cập nhật mới sau các thay đổi trong tất cả quá trình thao tác", "Hướng Dẫn", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            FormHanghoa frmhanghoa = new FormHanghoa();
            this.Hide();
            frmhanghoa.Closed += (s, args) => this.Close();
            frmhanghoa.ShowDialog();
        }

        private void btnTrangchu_Click(object sender, EventArgs e)
        {
            FormMenu frmmenu = new FormMenu();
            this.Hide();
            frmmenu.Closed += (s, args) => this.Close();
            frmmenu.ShowDialog();
        }
    }
}
