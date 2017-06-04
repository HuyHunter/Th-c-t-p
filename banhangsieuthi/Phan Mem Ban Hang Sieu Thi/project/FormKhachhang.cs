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
    public partial class FormKhachhang : Form
    {
        public FormKhachhang()
        {
            InitializeComponent();
        }

        private void FormKhachhang_Load(object sender, EventArgs e)
        {
            string sqlkhachhang = @"select * from KHACHHANG";
            DataTable dtkhachhang = DataProvider.LoadCSDL(sqlkhachhang);
            dgvKhachhang.DataSource = dtkhachhang;
            dgvKhachhang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
