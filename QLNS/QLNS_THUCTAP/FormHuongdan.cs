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
    public partial class FormHuongdan : Form
    {
        public FormHuongdan()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Tag == "Thêm")
            {
                wb1.Show();
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
