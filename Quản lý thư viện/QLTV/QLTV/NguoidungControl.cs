using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace QLTV
{
    public partial class NguoidungControl : UserControl
    {
        public NguoidungControl()
        {
            InitializeComponent();
            KetNoiCSDL();
            LoadData();
        }
        SqlConnection con = new SqlConnection(@"Data Source=KN-PC\KN;Initial Catalog=QL_ThuVien;Integrated Security=True");
        //ham ket noi
        private void KetNoiCSDL()
        {
            con.Open();
            string sql = "select * from BanDoc";
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);

            DataTable dt = new DataTable();// Chon mot table ao de luu tru dunlieu
            da.Fill(dt);// do du lieu vao kho
            con.Close();
            dgvHienthi.DataSource = dt;// do du lieu vao data GV



        }
        private void LoadData()
        {
            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", dgvHienthi.DataSource, "MaBD");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", dgvHienthi.DataSource, "HoTen");
            txtCMND.DataBindings.Clear();
            txtCMND.DataBindings.Add("Text", dgvHienthi.DataSource, "CMND");
            txtDiachi.DataBindings.Clear();
            txtDiachi.DataBindings.Add("Text", dgvHienthi.DataSource, "DiaChi");
            txtDienthoai.DataBindings.Clear();
            txtDienthoai.DataBindings.Add("Text", dgvHienthi.DataSource, "DienThoai");
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dgvHienthi.DataSource, "Email");
            cbbMalop.DataBindings.Clear();
            cbbMalop.DataBindings.Add("Text", dgvHienthi.DataSource, "MaLop");
            dtpNgaysinh.DataBindings.Clear();
            dtpNgaysinh.DataBindings.Add("Text", dgvHienthi.DataSource, "NgaySinh");
            rbdNam.DataBindings.Clear();
            rbdNam.DataBindings.Add("Text", dgvHienthi.DataSource, "GioiTinh");
            if (rbdNam.Text == "Nam")
            {
                rbdNam.Text = "Nam";
                rbdNam.Checked = true;
                rbdNu.Text = "Nữ";

            }
            else
            {
                rbdNu.Text = "Nữ";
                rbdNu.Checked = true;
                rbdNam.Text = "Nam";
            }


        }
        public void themND(string ma, string ten, string gioitinh, string ngaysinh, string cmnd, string malop, string diachi, string email, string sdt)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sql = "them_ND";
                SqlCommand comd = new SqlCommand(sql, con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.Add(new SqlParameter("ma", SqlDbType.NVarChar)).Value = ma;
                comd.Parameters.Add(new SqlParameter("ten", SqlDbType.NVarChar)).Value = ten;
                comd.Parameters.Add(new SqlParameter("gioitinh", SqlDbType.NVarChar)).Value = gioitinh;
                comd.Parameters.Add(new SqlParameter("ngaysinh", SqlDbType.Date)).Value = ngaysinh;
                comd.Parameters.Add(new SqlParameter("cmnd", SqlDbType.NVarChar)).Value = cmnd;

                comd.Parameters.Add(new SqlParameter("malop", SqlDbType.NVarChar)).Value = malop;
                comd.Parameters.Add(new SqlParameter("diachi", SqlDbType.NVarChar)).Value = diachi;
                comd.Parameters.Add(new SqlParameter("email", SqlDbType.NVarChar)).Value = email;
                comd.Parameters.Add(new SqlParameter("sdt", SqlDbType.NVarChar)).Value = sdt;

                comd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void suaND(string ma, string ten, string gioitinh, string ngaysinh, string cmnd, string malop, string diachi, string email, string sdt)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sql = "sua_ND";
                SqlCommand comd = new SqlCommand(sql, con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.Add(new SqlParameter("mand", SqlDbType.NVarChar)).Value = ma;
                comd.Parameters.Add(new SqlParameter("tennd", SqlDbType.NVarChar)).Value = ten;
                comd.Parameters.Add(new SqlParameter("gioitinhnd", SqlDbType.NVarChar)).Value = gioitinh;
                comd.Parameters.Add(new SqlParameter("ngaysinnhnd", SqlDbType.Date)).Value = ngaysinh;
                comd.Parameters.Add(new SqlParameter("cmndnd", SqlDbType.NVarChar)).Value = cmnd;

                comd.Parameters.Add(new SqlParameter("malopnd", SqlDbType.NVarChar)).Value = malop;
                comd.Parameters.Add(new SqlParameter("diachind", SqlDbType.NVarChar)).Value = diachi;
                comd.Parameters.Add(new SqlParameter("emailnd", SqlDbType.NVarChar)).Value = email;
                comd.Parameters.Add(new SqlParameter("sdtnd", SqlDbType.NVarChar)).Value = sdt;

                comd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void xoaND(string ma)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sql = "xoa_ND";
                SqlCommand comd = new SqlCommand(sql, con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.Add(new SqlParameter("mabd", SqlDbType.NVarChar)).Value = ma;
             

                comd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {

            string gt = "";
            if (rbdNam.Checked == true)
            { gt = "Nam"; }
            else if(rbdNu.Checked==true)
            { gt = "Nu"; }
            themND(txtMa.Text, txtTen.Text, gt, dtpNgaysinh.Text, txtCMND.Text, cbbMalop.Text, txtDiachi.Text, txtEmail.Text, txtDienthoai.Text);
            KetNoiCSDL();
            MessageBox.Show("Them Thanh Cong");
            LoadData();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string gt = "";
            if (rbdNam.Checked == true)
            { gt = "Nam"; }
            else if (rbdNu.Checked == true)
            { gt = "Nu"; }
            suaND(txtMa.Text, txtTen.Text, gt, dtpNgaysinh.Text, txtCMND.Text, cbbMalop.Text, txtDiachi.Text, txtEmail.Text, txtDienthoai.Text);
            KetNoiCSDL();
            MessageBox.Show("Sua Thanh Cong");
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMa.Clear();
            txtTen.Clear();        
            txtCMND.Clear();            
            txtDiachi.Clear();            
            txtDienthoai.Clear();            
            txtEmail.Clear();            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xoaND(txtMa.Text);
            KetNoiCSDL();
            MessageBox.Show("Them Thanh Cong");
            LoadData();

        }
    }
}
