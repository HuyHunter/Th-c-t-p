using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using formDangNhap.Class;

namespace formDangNhap
{
    public partial class form1 : Form
    {
        SqlConnection conn;
        SqlCommand cm;

        public form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '*';
            //MessageBox.Show("Do you want???", "Login", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(golbalDalameter.str);
                conn.Open();
                string sql = "select count(*) from [dbo].[User] where username=@acc and password=@pass";
                cm = new SqlCommand(sql, conn);
                cm.Parameters.Add(new SqlParameter("@acc", txtTK.Text));
                cm.Parameters.Add(new SqlParameter("@pass", txtMatKhau.Text));
                int x = (int)cm.ExecuteScalar();
                //MessageBox.Show(""+x);
                if (x == 1)
                {
                    FormMain f2 = new FormMain();
                    this.Hide();
                    f2.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
            //else
                //MessageBox.Show("tài khoản mật khẩu không đúng");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("mật khẩu cần đc xác minh oke oke, gửi đến số điện thoại 0963311011");
        }

        private void button3_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void button3_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
