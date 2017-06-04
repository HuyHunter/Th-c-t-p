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
    public partial class TimkiemNS : Form
    {

        String strConnect = @"Data Source = PHAMTUNG\SQLEXPRESS;Initial Catalog = QUANLINHANSU; Integrated Security = True";
        public TimkiemNS()
        {
            InitializeComponent();
        }


        private void TimkiemNS_Load(object sender, EventArgs e)
        {

        }


        private void txtTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Enter)
            {
                DTGV.DataSource = SqlHelper.ExecuteDataset(strConnect, "TIMKIEM_NHANVIEN", txtTimkiem.Text.Trim()).Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QUANLI ql = new QUANLI();
            this.Hide();
            ql.ShowDialog();
        }
    }
}
