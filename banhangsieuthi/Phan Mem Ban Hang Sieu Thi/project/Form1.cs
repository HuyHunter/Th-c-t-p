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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dtpNgaysinh.Format = DateTimePickerFormat.Custom;
            dtpNgaysinh.CustomFormat = "yyyy/MM/dd";
            dtpNgayban.Format = DateTimePickerFormat.Custom;
            dtpNgayban.CustomFormat = "yyyy/MM/dd";
            string sql2 = @"select nv.Manhanvien, nv.Tennhanvien, pb.Tenphongban
                            from NHANVIEN nv, PHONGBAN pb
                            where nv.Maphongban = pb.Maphongban and pb.Maphongban = 5";
            DataTable dt2 = DataProvider.LoadCSDL(sql2);
            cmbNhanVien.DataSource = dt2;
            cmbNhanVien.DisplayMember = "Tennhanvien";
            cmbNhanVien.ValueMember = "Manhanvien";            
            Loadsanpham();
            dgvSanpham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public void Loadsanpham()
        {
            string sql = @"select hs.Masanpham,hs.Tensanpham,hs.Giaban,hs.Soluong
                           from HANGHOA hs";
            DataTable dt = DataProvider.LoadCSDL(sql);
            dgvSanpham.DataSource = dt;
            dgvSanpham.AllowUserToAddRows = false;
            dgvSanpham.RowHeadersVisible = false;
        }
        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            bool checkkiemtra = true;
            if (txtTenkhachhang.Text == "")
            {
                MessageBox.Show("Bạn Chưa Nhập Tên Khách Hàng");
                txtTenkhachhang.Focus();
                checkkiemtra = false;
            }
            else if (txtDiachi.Text == "")
            {
                MessageBox.Show("Bạn Chưa Nhập Địa Chỉ");
                checkkiemtra = false;
                txtDiachi.Focus();
            }
            else if (txtPhone.Text == "")
            {
                MessageBox.Show("Bạn Chưa Nhập Số Điện Thoại");
                checkkiemtra = false;
                txtPhone.Focus();
            }
            else if (rdbNam.Checked == false && rdbNu.Checked == false)
            {
                MessageBox.Show("Bạn Chưa Chọn Giới Tính");
                checkkiemtra = false;
            }
            if (checkkiemtra == true)
            {
                bool kiemtramuahang = false;
                for (int i = 0; i < dgvSanpham.RowCount; i++)
                {
                    if (Convert.ToBoolean(dgvSanpham.Rows[i].Cells[0].Value) == true)
                    {
                        kiemtramuahang = true;
                        break;
                    }
                }
                if (kiemtramuahang == false)
                {
                    MessageBox.Show("Bạn Chưa Mua Loại Sản Phẩm Nào");
                }
                else
                {
                    for (int j = 0; j < dgvSanpham.RowCount; j++)
                    {
                        int kiemtra = 1;
                        if (Convert.ToBoolean(dgvSanpham.Rows[j].Cells[0].Value) == true)
                        {
                            if (dgvSanpham.Rows[j].Cells[1].Value == null)
                            {
                                MessageBox.Show("Bạn Chưa Nhập Số Lượng Mua Cho Sản Phẩm Có Tên " + dgvSanpham.Rows[j].Cells[4].Value.ToString());
                                kiemtra = 0;
                            }
                            else
                            {
                                try
                                {
                                    int soluongmua = int.Parse(dgvSanpham.Rows[j].Cells[1].Value.ToString());
                                    if (soluongmua > int.Parse(dgvSanpham.Rows[j].Cells[6].Value.ToString()) || soluongmua <= 0)
                                    {
                                        MessageBox.Show("Số Lượng Mua Mặt Hàng " + dgvSanpham.Rows[j].Cells[4].Value.ToString() + " Không Phù Hợp");
                                        kiemtra = 0;
                                        break;
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Số Lượng Mua Mặt Hàng " + dgvSanpham.Rows[j].Cells[4].Value.ToString() + " Không Phù Hợp");
                                    kiemtra = 0;
                                }
                            }
                            if (kiemtra == 1)
                            {
                                float tongtien = 0;
                                for (int i = 0; i < dgvSanpham.RowCount; i++)
                                {
                                    if (Convert.ToBoolean(dgvSanpham.Rows[i].Cells[0].Value) == true)
                                    {
                                        int masanpham = int.Parse(dgvSanpham.Rows[i].Cells[3].Value.ToString());
                                        dgvSanpham.Rows[i].Cells[2].Value = (float.Parse(dgvSanpham.Rows[i].Cells[1].Value.ToString()) * (float.Parse(dgvSanpham.Rows[i].Cells[5].Value.ToString()))).ToString();
                                        tongtien += float.Parse(dgvSanpham.Rows[i].Cells[2].Value.ToString());
                                        int soluongtonkho = int.Parse(dgvSanpham.Rows[i].Cells[6].Value.ToString()) - int.Parse(dgvSanpham.Rows[i].Cells[1].Value.ToString());
                                        try
                                        {
                                            string sql3 = @"update HANGHOA set Soluong = '" + soluongtonkho + "' where HANGHOA.Masanpham = '" + masanpham + "'";
                                            int ketqua = DataProvider.change(sql3);
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Cập Nhật Thất Bại");
                                        }

                                    }
                                }
                                txtTongtienthanhtoan.Text = tongtien.ToString();
                            }
                        }
                    }
                }
                for (int i = 0; i < dgvSanpham.RowCount; i++)
                {
                    if (Convert.ToBoolean(dgvSanpham.Rows[i].Cells[0].Value) == true)
                    {
                        int soluongtonkho = int.Parse(dgvSanpham.Rows[i].Cells[6].Value.ToString()) - int.Parse(dgvSanpham.Rows[i].Cells[1].Value.ToString());
                        if (soluongtonkho < 5)
                        {
                            MessageBox.Show("Số Lượng Mặt Hàng " + dgvSanpham.Rows[i].Cells[4].Value.ToString() + " Gần Hết.Xin Nhập Thêm Số Lượng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true; // chặn nhập từ phím vào
            }
        }
        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            //dem++;
            int makhachhang = 0;
            string sqlkhachhang = @"select kh.Makhachhang from KHACHHANG kh";
            DataTable dtkhachhang = DataProvider.LoadCSDL(sqlkhachhang);
            makhachhang = dtkhachhang.Rows.Count;
            string gioitinh = "";
            if (rdbNam.Checked == true)
            {
                gioitinh = "Nam";
            }
            else if (rdbNu.Checked == true)
            {
                gioitinh = "Nữ";
            }
            string tennhanvien = "";
            string sql = @"select nv.Manhanvien, nv.Tennhanvien, pb.Tenphongban
                           from NHANVIEN nv, PHONGBAN pb
                           where nv.Maphongban = pb.Maphongban and pb.Maphongban = 5";
            DataTable dt = DataProvider.LoadCSDL(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(cmbNhanVien.SelectedValue.ToString()) == int.Parse(dt.Rows[i][0].ToString()))
                {
                    tennhanvien = dt.Rows[i][1].ToString();
                    break;
                }
            }
            if (txtTongtienthanhtoan.Text != "")
            {
                bool kiemtrahoadon = true;
                if (txtTienkhachdua.Text == "")
                {
                    MessageBox.Show("Chưa Nhập Tiền Khách Đưa");
                    txtTienkhachdua.Focus();
                    kiemtrahoadon = false;
                }
                else
                {
                    try
                    {
                        float tienkhachdua = float.Parse(txtTienkhachdua.Text);
                        if (tienkhachdua < float.Parse(txtTongtienthanhtoan.Text))
                        {
                            MessageBox.Show("Khách Hàng Đưa Thiếu Tiền");
                            kiemtrahoadon = false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Tiền Khách Đưa Không Phù Hợp");
                        kiemtrahoadon = false;
                    }
                }
                float tienthua = float.Parse(txtTienkhachdua.Text) - float.Parse(txtTongtienthanhtoan.Text);
                if (kiemtrahoadon == true)
                {
                    try
                    {
                        string sqlthemkhach = @"insert into KHACHHANG(Makhachhang,Tenkhachhang,Ngaysinh,Gioitinh,Diachi,Sodienthoai)
                                            values ('" + (makhachhang + 1) + "', N'" + txtTenkhachhang.Text + "', '" + dtpNgaysinh.Value.ToString("yyyy/MM/dd") + "', N'" + gioitinh + "', N'" + txtDiachi.Text + "', '" + txtPhone.Text + "')";
                        int ketqua = DataProvider.change(sqlthemkhach);
                        if (ketqua > 0)
                        {
                            MessageBox.Show("Thêm Thông Tin Khách Hàng Thành Công", "Thêm Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm Khách Hàng Thất Bại");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Thêm Khách Hàng Thất Bại");
                    }
                    MessageBox.Show("-----Thông Tin Khách Hàng------\n\n" + "Tên Khách Hàng : " + txtTenkhachhang.Text + "\nSinh Ngày : " + dtpNgaysinh.Value.ToString("dd/MM/yyyy") + "\nGiới Tính : " + gioitinh + "\nĐịa Chỉ : " + txtDiachi.Text +
                        "\nSố Điện Thoại : " + txtPhone.Text + "\n\n------------------------" + "\n Ngày Mua Hàng : " + dtpNgayban.Value.ToString("dd/MM/yyyy") + "\n Tổng Tiền Phải Thanh Toán : " + txtTongtienthanhtoan.Text + "\n Tiền Khách Đưa : " + txtTienkhachdua.Text +
                        "\n Tiền Thừa Trả Lại Khách : " + tienthua.ToString() + "\n\n---------------------" + "\nNhân Viên Bán Hàng : " + tennhanvien);
                   // string sqlinserthoadon = @"insert into HOADON(Mahoadon,Manhanvien,Makhachhang,Masanpham,Giaban,Soluong,Thanhtien,Ngaymua) values ('"+demhoadon+"', '"+(cmbNhanVien.SelectedIndex + 1)+"', '"+demkhachang+"')";
                }
            }
            else
            {
                MessageBox.Show("Chưa Đủ Dữ Liệu Để Thanh Toán");
            }

            int sodong = dgvSanpham.RowCount;
            int hoadon = 0;
            for (int i = 0; i < sodong; i++)
            {
                if (Convert.ToBoolean(dgvSanpham.Rows[i].Cells[0].Value) == true)
                {
                    try
                    {
                        string sqlthemhoadon = @"insert into HOADON(Mahoadon,Manhanvien,Makhachhang,Masanpham,Ngaymua,Tienthanhtoan) 
                                             values ('" + (makhachhang + 1) + "', '" + cmbNhanVien.SelectedValue + "', '" + (makhachhang + 1) + "', '" + int.Parse(dgvSanpham.Rows[i].Cells[3].Value.ToString()) + "', '" + dtpNgayban.Value.ToString("yyyy/MM/dd") + "', '" + float.Parse(dgvSanpham.Rows[i].Cells[2].Value.ToString()) + "')";
                        int ketqua = DataProvider.change(sqlthemhoadon);
                        if (ketqua > 0)
                        {
                            hoadon = 1;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Thêm Hóa Đơn Thất Bại");
                    }
                }
            }
            if (hoadon == 1)
            {
                MessageBox.Show("Thêm Hóa Đơn Thành Công", "Thêm Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (hoadon == 0)
            {
                MessageBox.Show("Thêm Hóa Đơn Thất Bại");
            }
        }
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            Loadsanpham();
            txtTenkhachhang.Text = "";
            txtDiachi.Text = "";
            txtPhone.Text = "";
            txtTongtienthanhtoan.Text = "";
            txtTienkhachdua.Text = "";
        }
        private void btnTrangchu_Click(object sender, EventArgs e)
        {
            FormMenu frmmenu = new FormMenu();
            this.Hide();
            frmmenu.Closed += (s, args) => this.Close();
            frmmenu.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            FormThongke frmthongke = new FormThongke();
            this.Hide();
            frmthongke.Closed += (s, args) => this.Close();
            frmthongke.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormHanghoa frmhanghoa = new FormHanghoa();
            this.Hide();
            frmhanghoa.Closed += (s, args) => this.Close();
            frmhanghoa.ShowDialog();
        }

        private void btnHoadon_Click(object sender, EventArgs e)
        {
            FormHoadon frmhoadon = new FormHoadon();
            frmhoadon.ShowDialog();
        }

        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            FormKhachhang frmkhachhang = new FormKhachhang();
            frmkhachhang.ShowDialog();
        }

        private void btnHuongdan_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("   Hướng dẫn sử dụng chức năng Xác Nhận và Thanh Toán    " + "\n----------------------------------------------------------"
                             + "\n\nBước 1: Nhập đầy đủ thông tin khách mua hàng" + "\n\nBước 2 : Chọn những sản phẩm đã mua và nhập vào số lượng mua ở cột [Số Lượng Mua]"
                             + "\n\nBước 3 : Nhấn nút Xác Nhận để tính tiền cần thanh toán của khách hàng. Tiền cần thanh toán sẽ hiện lên trên ô Tổng Tiền Thanh Toán"
                             + "\n\nBước 4 : Nhập các dữ liệu cần thiết trong bảng hóa đơn và tiền khách trả ở ô Tiền Khách Đưa rồi bấm nút Thanh Toán", "Hướng Dẫn Sử Dụng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
