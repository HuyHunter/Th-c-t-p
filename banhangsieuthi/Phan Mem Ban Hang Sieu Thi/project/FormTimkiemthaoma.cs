using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace project
{
    public partial class FormTimkiemthaoma : Form
    {
        public FormTimkiemthaoma()
        {
            InitializeComponent();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (txtTimkiem.Text == "")
            {
                MessageBox.Show("Chưa Nhập Mã Tìm Kiếm");
            }
            else
            {
                string sql = @"select nv.Manhanvien,nv.Tennhanvien,nv.Ngaysinh,nv.Gioitinh,
                            nv.Diachi,nv.Sodienthoai,pb.Tenphongban, nv.Hesoluong,nv.Luongcanban, pb.Maphongban
                           from NHANVIEN nv, PHONGBAN pb
                           where nv.Maphongban = pb.Maphongban";
                DataTable dt = DataProvider.LoadCSDL(sql);
                int n = dt.Rows.Count;
                int idx = 1;
                for (int i = 0; i < n; i++)
                {
                    if (txtTimkiem.Text == dt.Rows[i][0].ToString())
                    {
                       // MessageBox.Show(dt.Rows[i][2].ToString());
                        idx = 0;
                        FormTimKiem frm = new FormTimKiem();
                        //FormTimKiem.manhanvien = dt.Rows[i][0].ToString();
                        //FormTimKiem.tennhanvien = dt.Rows[i][1].ToString();
                        //FormTimKiem.diachi = dt.Rows[i][4].ToString();
                        frm.manhanvien = dt.Rows[i][0].ToString();
                        frm.tennhanvien = dt.Rows[i][1].ToString();
                        int demchuoi = dt.Rows[i][2].ToString().Length;
                        string chuoi = dt.Rows[i][2].ToString();
                        int cat = 0;
                        for (int j = 0; j < demchuoi; j++)
                        {
                            if (chuoi[j] == ' ')
                            {
                                cat = j;
                                break;
                            }
                        }
                        chuoi = chuoi.Substring(0, cat);
                        int start = 0, end = 0;
                        for (int j = 0; j < chuoi.Length - 1; j++)
                        {
                            if (chuoi[j] == '/')
                            {
                                start = j;
                                for (int k = j + 1; k < chuoi.Length; k++)
                                {
                                    if (chuoi[k] == '/')
                                    {
                                        end = k;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                       // frm.Ngay = double.Parse(chuoi.Substring(0, start));
                      //  frm.Thang = int.Parse(chuoi.Substring(start + 1, (end - start - 1)));
                      //  frm.Nam = int.Parse(chuoi.Substring(end + 1));
                       // MessageBox.Show(ngay.ToString() + " " + thang.ToString() + " "+ nam.ToString());
                       // MessageBox.Show(chuoi.Substring(start + 1, (end - start - 1)));
                       // ngay = chuoi.Substring();
                       // frm.ngaysinh = DateTime.ParseExact(dt.Rows[i][2].ToString(), "yyyy/MM/dd", CultureInfo.InstalledUICulture);
                        frm.Ngaysinh = chuoi;
                        int Gioitinh = 0;
                        if (dt.Rows[i][3].ToString().Trim() == "Nam")
                        {
                            Gioitinh = 1;
                        }
                        else if (dt.Rows[i][3].ToString().Trim() == "Nữ")
                        {
                            Gioitinh = 2;
                        }
                        frm.gioitinh = Gioitinh;
                        frm.diachi = dt.Rows[i][4].ToString();
                        frm.sodienthoai = dt.Rows[i][5].ToString();
                        frm.hesoluong = dt.Rows[i][7].ToString();
                        frm.luongcanban = dt.Rows[i][8].ToString();
                        frm.phongban = int.Parse(dt.Rows[i][9].ToString());
                        this.Hide();
                        frm.Closed += (s, args) => this.Close();
                        frm.ShowDialog();
                        break;
                    }
                }
                if (idx == 1)
                {
                    MessageBox.Show("Không Tồn Tại Nhân Viên Có Mã " + txtTimkiem.Text);
                }
            }
        }
    }
}
