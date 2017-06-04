using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace project
{
    public partial class FormDangnhap : Form
    {
        public FormDangnhap()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cm;
        private string cnStr= @"Data Source=JOJO-PC\SQLEXPRESS;Initial Catalog=BANHANGSIEUTHI;Integrated Security=True";

        private void FormDangnhap_Load(object sender, EventArgs e)
        {
            txtMatkhau.PasswordChar = '*';
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(cnStr);
                conn.Open();
                string sql = "select count(*) from [dbo].[user] where username=@acc and pass=@pass";
                cm = new SqlCommand(sql, conn);
                cm.Parameters.Add(new SqlParameter("@acc", txtTendangnhap.Text));
                cm.Parameters.Add(new SqlParameter("@pass", txtMatkhau.Text));
                int x = (int)cm.ExecuteScalar();
                if (x == 1)
                {

                    FormMenu f2 = new FormMenu();
                    this.Hide();
                    f2.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuenmatkhau_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mật Khẩu Của Bạn Là : 123456");
        }
    }
}
