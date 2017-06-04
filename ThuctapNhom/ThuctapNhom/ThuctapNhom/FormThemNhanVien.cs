using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ThuctapNhom
{
    public partial class FormThemNhanVien : Form
    {
        public static string kn = @"Data Source=JOJO-PC\SQLEXPRESS;Initial Catalog=QUANLINHANSU;Integrated Security=True";
        SqlConnection con;
        DataTable dt;
        SqlDataAdapter da;
        public SqlConnection Open() // mo ket noi
        {
            con = new SqlConnection(kn);
            if (con.State == ConnectionState.Closed)
                con.Open();
            return con;
        }
        public SqlConnection Close()  // dong ket noi
        {
            con = new SqlConnection(kn);
            if (con.State == ConnectionState.Open)
                con.Close();
            return con;
        }
        public FormThemNhanVien()
        {
            InitializeComponent();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
        NhanVien_obj nv;
        private void btLuu_Click(object sender, EventArgs e)
        {          
            int gt = 2;
            if (rdbNam.Checked)
            {
                gt = 1;

            }
            else if (rdbNu.Checked)
            {
                gt = 0;
            }

            try
            {

                Open();
                string sqlInsert = @"insert into NHANVIEN
                    values('" + txtID.Text + "', '" + txtHoten.Text + "', '" + dtpNgaySinh.Value + "','" + gt + "', '" + txtQuequan.Text + "','" + txtDiachi.Text + "','" + txtCMND.Text + "', '" + txtDienthoai.Text + "','" + txtEmail.Text + "','" + cmbTenPhongBan.SelectedValue.ToString() + "','" + txtBacLuong.Text + "', '" + cmbChucVu.SelectedValue.ToString() + "')";
                SqlCommand cm = new SqlCommand(sqlInsert, con);
                cm.CommandText = sqlInsert;
                cm.ExecuteNonQuery();
                getdata();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtHoten.Clear();
            txtEmail.Clear();
            txtDienthoai.Clear();
            txtDiachi.Clear();
            txtCMND.Clear();
            txtQuequan.Clear();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            FormNhanVien nv = new FormNhanVien();
            this.Hide();
            nv.ShowDialog();
        }


        private void getdata()
        {
            SqlConnection con = new SqlConnection(globalParameter.str);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();

            DataTable data1 = new DataTable();
            DataTable data = new DataTable();
            cm.Connection = con;

            cm.CommandText = "select * from CHUCVU";
            da.SelectCommand = cm;
            da.Fill(data);
            cmbChucVu.DataSource = data;
            cmbChucVu.DisplayMember = "tenchucvu";
            cmbChucVu.ValueMember = "macv";

            cm.CommandText = "select * from PHONGBAN";
            da.SelectCommand = cm;
            da.Fill(data1);
            cmbTenPhongBan.DataSource = data1;
            cmbTenPhongBan.DisplayMember = "tenphongban";
            cmbTenPhongBan.ValueMember = "mapb";

        }
      //  string macv, tenphongban;

        private void FormThemNhanVien_Load(object sender, EventArgs e)
        {
            //FormThemNhanVien tnv = new FormThemNhanVien();
            //tnv.tenphongban = (cmbTenPhongBan.SelectedValue).ToString();
            //tnv.macv = cmbChucVu.SelectedValue.ToString();
            getdata();
        }
    }
}
