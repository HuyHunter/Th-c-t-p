using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QLTV
{
    public partial class FormLogin : Form
    {
  
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                string id = txtTaikhoan.Text.Trim();
                string pass = txtMatkhau.Text.Trim();
                DataTable dt = SqlHelper.ExecuteDataset(QLTV.Class.StrConnect.strConnect(), "checkIdPass", id, pass).Tables[0];
                if (dt.Rows.Count > 0 )
                {
                    MessageBox.Show("Đăng nhập thành công !", "Thông báo");
                    Form quanly = new FormMain();
                    this.Hide();
                    quanly.ShowDialog();
                }
                else
            {
                MessageBox.Show("Đăng nhập thất bại ! \n Kiểm tra lại Tài khoản và Mật khẩu", "Thông báo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
