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
    public partial class FormPhongBan : Form
    {
        public FormPhongBan()
        {
            InitializeComponent();
        }

        private void FormPhongBan_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(globalParameter.str);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable datadangky = new DataTable();
          
            cm.Connection = conn;
            cm.CommandText = "select * from PHONGBAN";
            da.SelectCommand = cm;
            da.Fill(datadangky);
            cmbdanhsach.DataSource = datadangky;
            cmbdanhsach.DisplayMember = "tenphongban";
            cmbdanhsach.ValueMember = "mapb";
            cmbdanhsach.SelectedValue = "mapb";
            
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            try
            {
                FormThongTinPhongBan fr = new FormThongTinPhongBan();
                fr.mapb = (cmbdanhsach.SelectedValue).ToString();
                fr.Show();
                Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
