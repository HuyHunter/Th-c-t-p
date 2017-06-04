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

namespace QLNS_THUCTAP
{
    public partial class TimkiemPB : Form
    {
        String strConnect = @"Data Source = PHAMTUNG\SQLEXPRESS;Initial Catalog = QUANLINHANSU; Integrated Security = True";

        public TimkiemPB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QUANLI ql = new QUANLI();
            this.Hide();
            ql.ShowDialog();
        }

        private void txtTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DTGV.DataSource = SqlHelper.ExecuteDataset(strConnect, "TIMKIEM_PHONGBAN", txtTimkiem.Text.Trim()).Tables[0];
            }
        }
    }
}
