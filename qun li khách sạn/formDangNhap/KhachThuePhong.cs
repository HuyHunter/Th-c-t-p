using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
namespace formDangNhap
{
    public partial class KhachThuePhong : Form
    {
        //string strConnect = @"Data Source =LATITUDE-PC;Initial Catalog = QL_KhachSan; Integrated Security = True";

        public KhachThuePhong()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=JOJO-PC\SQLEXPRESS;Initial Catalog=QL_KhachSan;Integrated Security=True");
        //ham ket noi
        private void KetNoiCSDL()
        {
            con.Open();
            string sql = "select * from tblKhachThuePhong";
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);

            DataTable dt = new DataTable();// Chon mot table ao de luu tru dunlieu
            da.Fill(dt);// do du lieu vao kho
            con.Close();
            dgvHienThi.DataSource = dt;// do du lieu vao data GV



        }
        //Ham Load Data tu dgv len textbox
        private void LoadData()
        {
            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", dgvHienThi.DataSource, "MaKH");
            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", dgvHienThi.DataSource, "TenKH");
            TxtGT.DataBindings.Clear();
            TxtGT.DataBindings.Add("Text", dgvHienThi.DataSource, "GT");
            txtCMND.DataBindings.Clear();
            txtCMND.DataBindings.Add("Text", dgvHienThi.DataSource, "CMND");
            dtpNgaysinh.DataBindings.Clear();
            dtpNgaysinh.DataBindings.Add("Text", dgvHienThi.DataSource, "NgaySinh");


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemKhachThuePhong tktp = new ThemKhachThuePhong();
            this.Hide();
            tktp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            this.Hide();
            fm.Show();
        }

        private void KhachThuePhong_Load(object sender, EventArgs e)
        {
            KetNoiCSDL();
        }

       
        //Ham Sua
        public void suaPhong(string makh, string tenkh, string gt, string ngaysinh, string cmnd)

        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sql = "SuaKhachThuePhong";
                SqlCommand comd = new SqlCommand(sql, con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.Add(new SqlParameter("MaKH", SqlDbType.NVarChar)).Value = makh;
                comd.Parameters.Add(new SqlParameter("TenKH", SqlDbType.NVarChar)).Value = tenkh;
                comd.Parameters.Add(new SqlParameter("GT", SqlDbType.NVarChar)).Value = gt;
                comd.Parameters.Add(new SqlParameter("NgaySinh", SqlDbType.Date)).Value = ngaysinh;
                comd.Parameters.Add(new SqlParameter("CMND", SqlDbType.VarChar)).Value = cmnd;

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

   

        private void btnSua_Click_1(object sender, EventArgs e)
        {

            LoadData();
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtCMND.Enabled = true;

            txtTenKH.Enabled = true;
            txtCMND.Enabled = true;
            dtpNgaysinh.Enabled = true;
        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            suaPhong(txtMaKH.Text, txtTenKH.Text, TxtGT.Text, dtpNgaysinh.Text, txtCMND.Text);
            KetNoiCSDL();
            MessageBox.Show("Sua Thanh Cong");
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            txtCMND.Enabled = false;

            txtTenKH.Enabled = false;
            txtCMND.Enabled = false;
            dtpNgaysinh.Enabled = false;
        }
    }
}
