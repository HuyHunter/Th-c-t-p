using System;
using System.Data;
using System.Windows.Forms;
using formDangNhap.Class;

namespace formDangNhap
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" hello bro @@");
        }

        private void getdata()
        {
            int ret = 0;
            Connection  doIt = new Connection();
            DataSet ds = new DataSet();
            string tableName = "tblHoaDon";
            string sql = "select * from tblHoaDon";
            ret = doIt.getSql(ref ds, tableName, sql);
            doIt.close();
            if (ret < 0)
            {
                MessageBox.Show("Không thành công ");
                Close();
            }
            else
            {
                dgvHienThi.DataSource = ds.Tables[tableName].DefaultView;
                dgvHienThi.Refresh();

            }
        }
        private void binding()
        {
            txtMaHd.DataBindings.Clear();
            txtMaHd.DataBindings.Add("Text", dgvHienThi.DataSource, "MaHD");
            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", dgvHienThi.DataSource, "MaKH");
            TxtNguoiLap.DataBindings.Clear();
            TxtNguoiLap.DataBindings.Add("Text", dgvHienThi.DataSource, "NguoiLap");
            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("Text", dgvHienThi.DataSource, "TongTien");
            dtpTGmuon.DataBindings.Clear();
            dtpTGmuon.DataBindings.Add("Text", dgvHienThi.DataSource, "TGMuon");
            dtpTGtra.DataBindings.Clear();
            dtpTGtra.DataBindings.Add("Text", dgvHienThi.DataSource, "TGTra");
        }
        private void GiaoVien_Load(object sender, EventArgs e)
        {
            getdata();
            binding();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void Form2_Load(object sender, EventArgs e)
        {
            getdata();
            binding();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormMain f2 = new FormMain();
            this.Hide();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtMaHd.Enabled = true;
            txtMaKH.Enabled = true;
            TxtNguoiLap.Enabled = true;
            txtTongTien.Enabled = true;
            dtpTGmuon.Enabled = true;
            dtpTGtra.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HoaDonObj hd = new HoaDonObj();
            hd.MAHD = txtMaHd.Text;
            hd.MAKH = txtMaKH.Text;
            hd.NGUOILAP = TxtNguoiLap.Text;
            hd.TONGTIEN = float.Parse(txtTongTien.ToString());
            hd.TGMUON = dtpTGmuon.Value;
            hd.TGTRA = dtpTGtra.Value;
            HoaDonBus bus = new HoaDonBus();
            int ret;
            ret = bus.update(hd);
            bus.close();
            if (ret < 0)
            {
                MessageBox.Show("Không sửa đc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            getdata();
            binding();
            txtMaHd.Enabled = false;
            txtMaKH.Enabled = false;
            TxtNguoiLap.Enabled = false;
            txtTongTien.Enabled = false;
            dtpTGmuon.Enabled = false;
            dtpTGtra.Enabled = false;
            btnCapNhat.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemHoaDon thd = new ThemHoaDon();
            this.Hide();
            thd.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
        }
    }
}
