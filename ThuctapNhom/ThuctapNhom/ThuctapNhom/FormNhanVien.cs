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
using System.Globalization;

namespace ThuctapNhom
{
    public partial class FormNhanVien : Form
    {
        public static string kn = @"Data Source=JOJO-PC\SQLEXPRESS;Initial Catalog=QUANLINHANSU;Integrated Security=True";

        SqlConnection con;
        DataTable dt;
        SqlDataAdapter da;
        public SqlConnection Open() // mo ket noi
        {
            con = new SqlConnection(kn);
            if (con.State == ConnectionState.Closed)
                con.Open();
            return con;
        }
        public SqlConnection Close()  // dong ket noi
        {
            con = new SqlConnection(kn);
            if (con.State == ConnectionState.Open)
                con.Close();
            return con;
        }
        public void hienthi()
        {
            Open();
            string sqlSelect = "select * from NHANVIEN";
            SqlCommand cm = new SqlCommand(sqlSelect, con);
            da = new SqlDataAdapter(cm);
            dt = new DataTable();
            //  da.SelectCommand = cm;
            da.Fill(dt);
            dgvnhanvien.DataSource = dt;

        }
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            hienthi();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {

            FormThemNhanVien nv1 = new FormThemNhanVien();
            this.Hide();
            nv1.ShowDialog();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            this.Hide();
            fm.ShowDialog();
        }

        private void btnsuanv_Click(object sender, EventArgs e)
        {
            txtdiachi.Enabled = true;
            txtdienthoai.Enabled = true;
            txtemail.Enabled = true;
            txthoten.Enabled = true;
            txtquequan.Enabled = true;
            txtsoCMND.Enabled = true;
            dtpngaysinh.Enabled = true;
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {

            try
            {
                Open();
                string sqlUpdate = @"update NHANVIEN set hoten = '" + txthoten.Text + "', ngaysinh ='" + dtpngaysinh.Value + "' , diachi ='" + txtdiachi.Text + "',email='" + txtemail.Text + "' , dienthoai='" + txtdienthoai.Text + "' , socmt = '" + txtsoCMND.Text + "' ,  quequan ='" + txtquequan.Text + "'   where manv='" + txtID.Text + "'";
                SqlCommand cm = new SqlCommand(sqlUpdate, con);
                cm.CommandText = sqlUpdate;
                cm.ExecuteNonQuery();
                hienthi();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi", ex.Message);
            }

            txtdiachi.Enabled = false;
            txtdienthoai.Enabled = false;
            txtemail.Enabled = false;
            txthoten.Enabled = false;
            txtquequan.Enabled = false;
            txtsoCMND.Enabled = false;
            dtpngaysinh.Enabled = true;
        }

        private void btnxoanv_Click(object sender, EventArgs e)
        {
            Open();
            try
            {
                string sqlDelete = "delete from NHANVIEN where manv ='" + txtID.Text + "'";
                SqlCommand cm = new SqlCommand(sqlDelete, con);
                cm.CommandText = sqlDelete;
                cm.ExecuteNonQuery();
                hienthi();
                Close();
                //SqlCommand command = new SqlCommand("SP_DELETE_NHANVIEN", con);
                //command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.Add(new SqlParameter("@id", txtID.Text));
                //command.ExecuteNonQuery();
                //MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //dt.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa dữ liệu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            hienthi();
            Close();
        }
        //string id, hoten, ngaysinh, soCMND;

        //private void btnCheck_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Open();
        //        if (txtTimKiem.Text == "")
        //        {
        //            MessageBox.Show("Chưa Nhập Mã Tìm Kiếm");
        //        }
        //        else
        //        {
        //            string sql = @"select nv.manv,nv.hoten,nv.ngaysinh,nv.gioitinh,
        //                    nv.quequan,nv.diachi,nv.socmt,nv.email,nv.macv,nv.bacluong,pb.tenphongban, pb.mapb
        //                   from NHANVIEN nv, PHONGBAN pb
        //                   where nv.mapb = pb.mapb";
        //            DataTable dt = project.DataProvider.LoadCSDL(sql);
        //            int n = dt.Rows.Count;
        //            int idx = 1;
        //            for (int i = 0; i < n; i++)
        //            {
        //                if (txtTimKiem.Text == dt.Rows[i][0].ToString())
        //                {
        //                    // MessageBox.Show(dt.Rows[i][2].ToString());
        //                    idx = 0;
        //                    HienThiTiemKiem frm = new HienThiTiemKiem();
        //                    //FormTimKiem.manhanvien = dt.Rows[i][0].ToString();
        //                    //FormTimKiem.tennhanvien = dt.Rows[i][1].ToString();
        //                    //FormTimKiem.diachi = dt.Rows[i][4].ToString();
        //                    frm.manhanvien = dt.Rows[i][0].ToString();
        //                    frm.tennv = dt.Rows[i][1].ToString();
        //                    int demchuoi = dt.Rows[i][2].ToString().Length;
        //                    string chuoi = dt.Rows[i][2].ToString();
        //                    int cat = 0;
        //                    for (int j = 0; j < demchuoi; j++)
        //                    {
        //                        if (chuoi[j] == ' ')
        //                        {
        //                            cat = j;
        //                            break;
        //                        }
        //                    }
        //                    chuoi = chuoi.Substring(0, cat);
        //                    int start = 0, end = 0;
        //                    for (int j = 0; j < chuoi.Length - 1; j++)
        //                    {
        //                        if (chuoi[j] == '/')
        //                        {
        //                            start = j;
        //                            for (int k = j + 1; k < chuoi.Length; k++)
        //                            {
        //                                if (chuoi[k] == '/')
        //                                {
        //                                    end = k;
        //                                    break;
        //                                }
        //                            }
        //                            break;
        //                        }
        //                    }
        //                    // frm.Ngay = double.Parse(chuoi.Substring(0, start));
        //                    //  frm.Thang = int.Parse(chuoi.Substring(start + 1, (end - start - 1)));
        //                    //  frm.Nam = int.Parse(chuoi.Substring(end + 1));
        //                    // MessageBox.Show(ngay.ToString() + " " + thang.ToString() + " "+ nam.ToString());
        //                    // MessageBox.Show(chuoi.Substring(start + 1, (end - start - 1)));
        //                    // ngay = chuoi.Substring();
        //                    // frm.ngaysinh = DateTime.ParseExact(dt.Rows[i][2].ToString(), "yyyy/MM/dd", CultureInfo.InstalledUICulture);
        //                     //frm.ngaysinh = chuoi;
        //                    frm.ngaysinh = dtpngaysinh.Value;

        //                    int Gioitinh = 0;
        //                    if (dt.Rows[i][3].ToString().Trim() == "Nam")
        //                    {
        //                        Gioitinh = 1;
        //                    }
        //                    else if (dt.Rows[i][3].ToString().Trim() == "Nữ")
        //                    {
        //                        Gioitinh = 2;
        //                    }
        //                    frm.gioitinh = Gioitinh;
        //                    frm.quenquan = dt.Rows[i][4].ToString();
        //                    frm.diachi = dt.Rows[i][5].ToString();
        //                   // frm.diachi = dt.Rows[i][6].ToString();
        //                    frm.CMND = dt.Rows[i][6].ToString();
        //                    frm.dienthoai = dt.Rows[i][7].ToString();
        //                    frm.diachi = dt.Rows[i][8].ToString();
        //                    frm.bacluong = dt.Rows[i][9].ToString();
        //                    frm.chucvu = int.Parse(dt.Rows[i][10].ToString());
        //                    frm.phongban = int.Parse(dt.Rows[i][11].ToString());
        //                    this.Hide();
        //                    frm.Closed += (s, args) => this.Close();
        //                    frm.ShowDialog();
        //                    break;
        //                }
        //            }
        //            if (idx == 1)
        //            {
        //                MessageBox.Show("Không Tồn Tại Nhân Viên Có Mã " + txtTimKiem.Text);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}


        //private void txtTimKiem_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //       // dt.Clear();
        //        Open();      
        //        //SqlCommand command = new SqlCommand();
        //        //command.Connection = con;
        //        //command.CommandType = CommandType.StoredProcedure;
        //        //command.CommandText = "SP_TIMKIEM_NHANVIEN";
        //        //command.Parameters.Add(new SqlParameter("@id", txtTimKiem.Text));
        //        //command.Parameters.Add(new SqlParameter("@hoten", txtTimKiem.Text));
        //        //da.SelectCommand = command;
        //        //da.Fill(dt);
        //        //dgvnhanvien.DataSource = dt;
        //        //Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi");
        //    }
        //}
        int index;
        private void dgvnhanvien_Click_1(object sender, EventArgs e)
        {

            index = dgvnhanvien.CurrentRow.Index;
            txtID.Text = dgvnhanvien.Rows[index].Cells[0].Value.ToString();
            txthoten.Text = dgvnhanvien.Rows[index].Cells[1].Value.ToString();
            dtpngaysinh.Text = dgvnhanvien.Rows[index].Cells[2].Value.ToString();
            txtquequan.Text = dgvnhanvien.Rows[index].Cells[3].Value.ToString();
            cmbPhongBan.Text = dgvnhanvien.Rows[index].Cells[4].Value.ToString();
            txtdiachi.Text = dgvnhanvien.Rows[index].Cells[5].Value.ToString();
            txtsoCMND.Text = dgvnhanvien.Rows[index].Cells[6].Value.ToString();
            txtdienthoai.Text = dgvnhanvien.Rows[index].Cells[7].Value.ToString();
            txtemail.Text = dgvnhanvien.Rows[index].Cells[8].Value.ToString();
            cmbChucVu.Text = dgvnhanvien.Rows[index].Cells[9].Value.ToString();
        }
    }
}
