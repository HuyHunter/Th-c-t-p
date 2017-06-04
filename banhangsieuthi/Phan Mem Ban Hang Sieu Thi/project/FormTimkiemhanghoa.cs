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
    public partial class FormTimkiemhanghoa : Form
    {
        public FormTimkiemhanghoa()
        {
            InitializeComponent();
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            int timkiem = 1;
            string sql = @"select * from HANGHOA";
            DataTable dt = DataProvider.LoadCSDL(sql);
            int n = dt.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                if (txtMatimkiem.Text == dt.Rows[i][0].ToString())
                {
                    timkiem = 0;
                    FormChinhsuahanghoa frmchinhsua = new FormChinhsuahanghoa();
                    frmchinhsua.Masanpham = dt.Rows[i][0].ToString();
                    frmchinhsua.Tensanpham = dt.Rows[i][1].ToString();
                    frmchinhsua.Gianhap = dt.Rows[i][2].ToString();
                    frmchinhsua.Giaban = dt.Rows[i][3].ToString();
                    frmchinhsua.Soluong = dt.Rows[i][4].ToString();
                    this.Hide();
                    frmchinhsua.Closed += (s, args) => this.Close();
                    frmchinhsua.ShowDialog();
                    break;
                }
            }
            if (timkiem == 1)
            {
                MessageBox.Show("Không Tồn Tại Sản Phẩm Có Mã " + txtMatimkiem.Text);
            }
        }
    }
}
