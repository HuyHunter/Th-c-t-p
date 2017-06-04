using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ThuctapNhom
{
    public partial class HienThiTiemKiem : Form
    {
        public HienThiTiemKiem()
        {
            InitializeComponent();
        }

        public string manhanvien, tennv, dienthoai, diachi, quenquan, CMND, email, bacluong;
        public DateTime ngaysinh;
        public int gioitinh, phongban,chucvu, thang, nam;
        public double ngay;
        private string tennhanvien;
        private string sodienthoai;

       /// public object DataProvider { get; private set; }

        private void HienThiTiemKiem_Load(object sender, EventArgs e)
        {
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "yyyy/MM/dd";
            // MessageBox.Show(dtpNgaysinh.Value.ToString() + "dài " + dtpNgaysinh.Value.ToString().Length.ToString());
            dtpNgaySinh.Value.AddDays(ngay);
            dtpNgaySinh.Value.AddMonths(thang);
            dtpNgaySinh.Value.AddYears(nam);

            string sql = @"select * from NHANVIEN";
            DataTable dt = project.DataProvider.LoadCSDL(sql);
            cmbChucVu.DataSource = dt;
            cmbChucVu.DisplayMember = "macv";
            cmbChucVu.ValueMember = "mapb";
            cmbChucVu.SelectedIndex = chucvu;
            cmbTenPhongBan.DataSource = dt;
            cmbTenPhongBan.DisplayMember = "tenphongban";
            cmbTenPhongBan.ValueMember = "mapb";
            cmbTenPhongBan.SelectedIndex = phongban-1;
            txtID.Text = manhanvien;
            txtID.Enabled = false;
            txtHoten.Text = tennv;
            txtDiachi.Text = diachi;
            txtDienthoai.Text = dienthoai;
            txtBacLuong.Text = bacluong;
            txtCMND.Text = CMND;
            txtEmail.Text = email;
            txtQuequan.Text = quenquan;
            
            if (gioitinh == 1)
            {
                rdbNam.Checked = true;
            }
            else if (gioitinh == 2)
            {
                rdbNu.Checked = true;
            }
            dtpNgaySinh.Value = ngaysinh;
          //  txtHesoluong.Text = hesoluong;
           // txtNgaysinh.Text = Ngaysinh;
            // dtpNgaysinh.Value = ngaysinh;
        }

    }
}

