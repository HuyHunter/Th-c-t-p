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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            lblquanlynhanvien.Text = "I.Quản Lý Nhân Viên";
            lblThemnhanvien.Text = "1.Thêm Mới Nhân Viên";
            lblXoanhanvien.Text = "2.Xóa Nhân Viên";
            lblTimkiem.Text = "3.Tìm Kiếm Nhân Viên";
            lblQuanlyhanghoa.Text = "II.Quản Lý Hàng Hóa";
            lblThemhanghoa.Text = "1.Thêm Mới Sản Phẩm";
            lblXoahanghoa.Text = "2.Xóa Sản Phẩm";
            lblTimkiemhanghoa.Text = "3.Tìm Kiếm Sản Phẩm. Bổ Sung Số Lượng";
            lblBanhang.Text = "III.Bán Hàng";
            lblXulyhoadon.Text = "1.Xử Lý Nghiệp Vụ Bán Hàng";
            lblxulynghipvu.Text = "2.Xử Lý Thông Tin Hóa Đơn";
            lbltusuong.Text = "--Phần Mềm Thuộc Bản Quyền Của Lê Kim Phòng Th13a--";
            lblThongke.Text = "IV.Thống Kê";
            lblThongke1.Text = "1.Thống Kê Chung Về Nhân Viên";
            lblThongke2.Text = "2.Thống Kê Chung Về Hàng Hóa";
            lblThongke3.Text = "3.Thống Kê Ngoài Lề";
        }

        private void btnBanhang_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Closed += (s, args) => this.Close();
            frm.ShowDialog(); 
        }

        private void btnQuanlynhanvien_Click(object sender, EventArgs e)
        {
            FormNhanVien frm = new FormNhanVien();
            this.Hide();
            frm.Closed += (s, args) => this.Close();
            frm.ShowDialog(); 
        }

        private void btnQuanlyhanghoa_Click(object sender, EventArgs e)
        {
            FormHanghoa frmhanghoa = new FormHanghoa();
            this.Hide();
            frmhanghoa.Closed += (s, args) => this.Close();
            frmhanghoa.ShowDialog();
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            FormThongke frmthongke = new FormThongke();
            this.Hide();
            frmthongke.Closed += (s, args) => this.Close(); 
            frmthongke.ShowDialog();
        }
    }
}
