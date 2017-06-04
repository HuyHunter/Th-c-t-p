using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThuctapNhom
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        //private void TheadFunction()
        //{
        //    Thread.Sleep(2000);
        //    if (this.InvokeRequired)
        //    {
        //        this.BeginInvoke((MethodInvoker)delegate()
        //        {
        //            label1.Text = "...Đang Kiểm Tra Kết Nối Đến CSDL";
        //        });
        //    }
        //    else
        //    {
        //        label1.Text = "...Đang Kiểm Tra Kết Nối Đến CSDL";
        //    }
        //    Thread.Sleep(1500);
        //    if (this.InvokeRequired)
        //    {
        //        this.BeginInvoke((MethodInvoker)delegate()
        //        {
        //            this.Visible = false;
        //            new FormConnect().Show();
        //        });
        //    }
        //    else
        //    {
        //        this.Visible = false;
        //        new FormConnect().Show();
        //    }

        //}

        private void FormStart_Load(object sender, EventArgs e)
        {
          //  label1.Text = "...Đang Mở Ứng Dụng";
          //  Thread th = new Thread(new ThreadStart(TheadFunction));
          //  th.IsBackground = true;
          //  th.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
