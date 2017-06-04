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
    public partial class FormThongke : Form
    {
        public FormThongke()
        {
            InitializeComponent();
        }
        private void FormThongke_Load(object sender, EventArgs e)
        {
            string sqlsanpham = @"select hh.Masanpham,hh.Tensanpham from HANGHOA hh";
            DataTable dtsanpham = DataProvider.LoadCSDL(sqlsanpham);
            cmbDanhsachsanpham.DataSource = dtsanpham;
            cmbDanhsachsanpham.DisplayMember = "Tensanpham";
            cmbDanhsachsanpham.ValueMember = "Masanpham";
            lblSoluongmathang.Text = "Số Lượng Mặt Hàng : " + dtsanpham.Rows.Count.ToString();

            string sqlphongban = @"select pb.Maphongban,pb.Tenphongban from PHONGBAN pb";
            DataTable dtphongban = DataProvider.LoadCSDL(sqlphongban);
            cmbDanhsachphongban.DataSource = dtphongban;
            cmbDanhsachphongban.DisplayMember = "Tenphongban";
            cmbDanhsachphongban.ValueMember = "Maphongban";
            lblSoluongphongban.Text = "Số Lượng Phòng Ban : " + dtphongban.Rows.Count;

            string sqlnhanvien = @"select nv.Manhanvien,nv.Tennhanvien from NHANVIEN nv";
            DataTable dtnhanvien = DataProvider.LoadCSDL(sqlnhanvien);
            cmbDanhsachnhanvien.DataSource = dtnhanvien;
            cmbDanhsachnhanvien.DisplayMember = "Tennhanvien";
            cmbDanhsachnhanvien.ValueMember = "Manhanvien";
            lblSoluongnhanvien.Text = "Số Lượng Nhân Viên : " + dtnhanvien.Rows.Count.ToString();

            string sqlkhachhang = @"select * from KHACHHANG";
            DataTable dtkhachhang = DataProvider.LoadCSDL(sqlkhachhang);
            lblKhachhang.Text = "+ Số Lượng Khách Hàng Tới Mua Hàng : " + dtkhachhang.Rows.Count.ToString();

            float tongdoanhthu = 0;
            string sqltongdoanhthu = @"select hd.Masanpham,hd.Tienthanhtoan from HOADON hd";
            DataTable dttongdoanhthu = DataProvider.LoadCSDL(sqltongdoanhthu);
            int n = dttongdoanhthu.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                tongdoanhthu += float.Parse(dttongdoanhthu.Rows[i][1].ToString());
            }
            lblTongdoanhthu.Text = "+ Tổng Doanh Thu Tính Đến Hiện Tại : " + tongdoanhthu.ToString();
        }

        private void cmbDanhsachsanpham_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(cmbDanhsachsanpham.SelectedValue.ToString());
            string sqlsanpham = @"select hd.Mahoadon, hd.Masanpham, hd.Tienthanhtoan, hh.Giaban
                                  from HANGHOA hh, HOADON hd
                                  where hh.Masanpham = hd.Masanpham ";
            DataTable dtsanpham = DataProvider.LoadCSDL(sqlsanpham);
            int n = dtsanpham.Rows.Count;

            string sqlhangton = @"select * from HANGHOA";
            DataTable dthangton = DataProvider.LoadCSDL(sqlhangton);
            int m = dthangton.Rows.Count;
            int soluongdaban = 0;
            float tiendoanhthu = 0;
            for (int i = 0; i < n; i++)
            {
                if (cmbDanhsachsanpham.SelectedValue.ToString() == dtsanpham.Rows[i][1].ToString())
                {
                    tiendoanhthu += float.Parse(dtsanpham.Rows[i][2].ToString());
                    soluongdaban += (int.Parse(tiendoanhthu.ToString()) / int.Parse(dtsanpham.Rows[i][3].ToString()));
                    lblSoluongdaban.Text = "SL Đã Bán : " + soluongdaban.ToString();
                    lblDoanhthu.Text = "Doanh Thu : " + tiendoanhthu.ToString() + " VNĐ";
                    break;
                }
                else
                {
                    lblDoanhthu.Text = "Doanh Thu : " + tiendoanhthu.ToString() + " VNĐ";
                    lblSoluongdaban.Text = "SL Đã Bán : 0";
                }
            }
            for (int j = 0; j < m; j++)
            {
                if (cmbDanhsachsanpham.SelectedValue.ToString() == dthangton.Rows[j][0].ToString())
                {
                    lblGianhap.Text = "Giá Nhập : " + dthangton.Rows[j][2].ToString();
                    lblGiaban.Text = "Giá Bán : " + dthangton.Rows[j][3].ToString();
                    lblSoluongton.Text = "Số Lượng Tồn : " + dthangton.Rows[j][4].ToString();
                    if (int.Parse(dthangton.Rows[j][4].ToString()) < 5)
                    {
                        MessageBox.Show("Mặt Hàng Này Gần Hết. Xin Nhập Thêm.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                }
            }
        }

        private void cmbDanhsachphongban_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlphongban = @"select * from PHONGBAN";
            DataTable dtphongban = DataProvider.LoadCSDL(sqlphongban);
            int n = dtphongban.Rows.Count;
            int soluong = 0;
            for (int i = 0; i < n; i++)
            {
                soluong += int.Parse(dtphongban.Rows[i][2].ToString());
            }
            for (int i = 0; i < n; i++)
            {
                if (cmbDanhsachphongban.SelectedValue.ToString() == dtphongban.Rows[i][0].ToString())
                {
                    lblSoluongnhansu.Text = "Số Lượng Nhân Sự : " + dtphongban.Rows[i][2].ToString();
                    lblChiem.Text = "Chiếm : " + ((float.Parse(dtphongban.Rows[i][2].ToString()) / soluong) * 100).ToString("0.00") + " %";
                    break;
                }
            }
        }

        private void cmbDanhsachnhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlnhanvien = @"select nv.Manhanvien,nv.Tennhanvien,nv.Maphongban,nv.Hesoluong,nv.Luongcanban, pb.Tenphongban from NHANVIEN nv, PHONGBAN pb where nv.Maphongban = pb.Maphongban";
            DataTable dtnhanvien = DataProvider.LoadCSDL(sqlnhanvien);
            int n = dtnhanvien.Rows.Count;
            float tongluong = 0;
            for (int i = 0; i < n; i++)
            {
                tongluong += float.Parse(dtnhanvien.Rows[i][3].ToString()) * (float.Parse(dtnhanvien.Rows[i][4].ToString()));
            }

            for (int i = 0; i < n; i++)
            {
                if (cmbDanhsachnhanvien.SelectedValue.ToString() == dtnhanvien.Rows[i][0].ToString())
                {
                    lblNhanvien.Text = "NV : " + dtnhanvien.Rows[i][1].ToString();
                    lblPhongban.Text = "Phòng Ban : " + dtnhanvien.Rows[i][5].ToString();
                    lblLuong.Text = "Lương : " + (float.Parse(dtnhanvien.Rows[i][3].ToString())*float.Parse(dtnhanvien.Rows[i][4].ToString())).ToString();
                    lblChiem1.Text = "Chiếm : " + ((float.Parse(dtnhanvien.Rows[i][3].ToString()) * float.Parse(dtnhanvien.Rows[i][4].ToString()) / tongluong) * 100).ToString("0.00") + " %";
                }
            }
        }

        private void btnTrangchu_Click(object sender, EventArgs e)
        {
            FormMenu frmmenu = new FormMenu();
            this.Hide();
            frmmenu.Closed += (s, args) => this.Close();
            frmmenu.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 frmhanghoa = new Form1();
            this.Hide();
            frmhanghoa.Closed += (s, args) => this.Close();
            frmhanghoa.ShowDialog();
        }
    }
}
