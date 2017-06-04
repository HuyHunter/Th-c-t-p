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
    public partial class FormLogin : Form
    {
        public static bool quyen;
        SqlConnection conn;
        SqlCommand command;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(globalParameter.str);
                conn.Open();
                string sql = "select count(*) from [dbo].[USER] where username = @acc and password = @pass";
                command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("@acc", txtUsername.Text));
                command.Parameters.Add(new SqlParameter("@pass", txtPassword.Text));
                int x = (int)command.ExecuteScalar();
                if (x == 1) // neu dang nhap thanh cong
                {
                    //MessageBox.Show("Dang nhap thanh cong");
                    FormMain fr = new FormMain();
                   // fr.tentk = txtUsername.Text;
                   // SqlCommand cmd = new SqlCommand("select  quyen from [dbo].[User] where username = '" + txtUsername.Text + "'", conn);
                    //quyen = (bool)cmd.ExecuteScalar();

                    fr.Show();
                    this.Hide();
                    
                    
                }
                else
                {
                    lbInfor.Text = "ID or Password is incorrect";
                    lbInfor.ForeColor = Color.Red;
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShow.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
