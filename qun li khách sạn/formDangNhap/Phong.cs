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

namespace formDangNhap
{
    public partial class Phong : Form
    {
        public Phong()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=JOJO-PC\SQLEXPRESS;Initial Catalog=QL_KhachSan;Integrated Security=True");
        //ham ket noi
        private void KetNoiCSDL()
        {
            con.Open();
            string sql = "select * from tblPhong";
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
            txtMaPhong.DataBindings.Clear();
            txtMaPhong.DataBindings.Add("Text", dgvHienThi.DataSource, "MaPhong");
            txtTenphong.DataBindings.Clear();
            txtTenphong.DataBindings.Add("Text", dgvHienThi.DataSource, "TenPhong");
            txtLoaiPhong.DataBindings.Clear();
            txtLoaiPhong.DataBindings.Add("Text", dgvHienThi.DataSource, "LoaiPhong");
            txtTinhTrang.DataBindings.Clear();
            txtTinhTrang.DataBindings.Add("Text", dgvHienThi.DataSource, "TinhTrang");
            txtGiaPhong.DataBindings.Clear();
            txtGiaPhong.DataBindings.Add("Text", dgvHienThi.DataSource, "GiaPhong");


        }
        //Ham Sua
        public void suaPhong(string map, string tenphong, string loaiphong, string tinhtrang, string giaphong)

        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sql = "SuaPhong";
                SqlCommand comd = new SqlCommand(sql, con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.Add(new SqlParameter("MaPhong", SqlDbType.NVarChar)).Value = map;
                comd.Parameters.Add(new SqlParameter("TenPhong", SqlDbType.NVarChar)).Value = tenphong;
                comd.Parameters.Add(new SqlParameter("LoaiPhong", SqlDbType.NVarChar)).Value = loaiphong;
                comd.Parameters.Add(new SqlParameter("TinhTrang", SqlDbType.NVarChar)).Value = tinhtrang;
                comd.Parameters.Add(new SqlParameter("GiaPhong", SqlDbType.BigInt)).Value = giaphong;

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
        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemPhong tp = new ThemPhong();
            this.Hide();
            tp.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            this.Hide();
            fm.Show();

        }

        private void Phong_Load(object sender, EventArgs e)
        {
            KetNoiCSDL();
            
        }

        private void dgvHienThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Khi click vao 1 o
            try
            {
                dgvHienThi.CurrentRow.Selected = true;//du lieu dc chon ca dong
            }
            catch { }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LoadData();
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtGiaPhong.Enabled = true;
            txtLoaiPhong.Enabled = true;
            txtTenphong.Enabled = true;
            txtTinhTrang.Enabled = true;

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            suaPhong(txtMaPhong.Text, txtTenphong.Text, txtLoaiPhong.Text, txtTinhTrang.Text, txtGiaPhong.Text);
            KetNoiCSDL();
            MessageBox.Show("Sua thanh cong");
            LoadData();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
