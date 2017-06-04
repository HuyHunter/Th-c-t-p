using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ThuctapNhom
{
    class NhanVienBus
    {

        public connection doIt = null;
        public int insert(NhanVien_obj nv)
        {
            int ret = 0;
            //gv = new GiaoVienObj();
            string sql = @"insert into NHANVIEN(manv, hoten , ngaysinh , gioitinh , quequan , diachi , socmt , dienthoai , email ,macv ,matrdhv,bacluong,mapb)
                                         values(@manv,@hoten,@ngaysinh , @gioitinh , @quequan,@diachi,@soCMND , @dienthoai ,@email,@macv ,@matrdhv,@bacluong,@mapb)";
            List<SqlParameter> li = new List<SqlParameter>();
            SqlParameter a;
            a = new SqlParameter("manv", SqlDbType.VarChar);
            a.Value = nv.IDNV;
            li.Add(a);
            a = new SqlParameter("hoten", SqlDbType.NVarChar);
            a.Value = nv.hotenNV;
            li.Add(a);
            a = new SqlParameter("ngaysinh", SqlDbType.Date);
            a.Value = nv.ngaysinhNV;
            li.Add(a);
            a = new SqlParameter("gioitinh", SqlDbType.Bit);
            a.Value = nv.gioitinhNV;
            li.Add(a);
            a = new SqlParameter("quequan", SqlDbType.NVarChar);
            a.Value = nv.quequanNV;
            li.Add(a);
            a = new SqlParameter("diachi", SqlDbType.NVarChar);
            a.Value = nv.diachiNV;
            li.Add(a);
            a = new SqlParameter("socmt", SqlDbType.VarChar);
            a.Value = nv.soCMNDNV;
            li.Add(a);
            a = new SqlParameter("dienthoai", SqlDbType.VarChar);
            a.Value = nv.dienthoaiNV;
            li.Add(a);
            a = new SqlParameter("email", SqlDbType.NVarChar);
            a.Value = nv.emailNV;
            li.Add(a);
            a = new SqlParameter("macv", SqlDbType.VarChar);
            a.Value = nv.CV_IDNV;
            li.Add(a);
            a = new SqlParameter("matrdhv", SqlDbType.NVarChar);
            a.Value = nv.MATRDHV;
            li.Add(a);
            a = new SqlParameter("bacluong", SqlDbType.NVarChar);
            a.Value = nv.Bacluong;
            li.Add(a);
            a = new SqlParameter("mapb", SqlDbType.NVarChar);
            a.Value = nv.PB_IDNV;
            li.Add(a);




            if (doIt == null)
            {
                doIt = new connection();
            }
            if (doIt.isOpen() < 0)
            {
                ret = doIt.connect();
            }
            if (ret < 0)
            {
                return -2;
            }
            ret = doIt.doSql(sql, li.ToArray());
            return ret;
        }
        public int update(NhanVien_obj nv)
        {
            int ret = 0;// kiem tra , neu tra ve 0 thi thuc hien dc , nho hon 0 thi ko thuc hien dc
            string sql = @"update NHANVIEN set hoten = @hoten , ngaysinh = @ngaysinh , diachi =@diachi,email=@email , dienthoai=@dienthoai , socmt = @socmt ,  quequan =@quequan   where manv=@manv";
            List<SqlParameter> li = new List<SqlParameter>();
            SqlParameter a;
            a = new SqlParameter("manv", SqlDbType.VarChar);
            a.Value = nv.IDNV;
            li.Add(a);
            a = new SqlParameter("hoten", SqlDbType.NVarChar);
            a.Value = nv.hotenNV;
            li.Add(a);
            a = new SqlParameter("ngaysinh", SqlDbType.Date);
            a.Value = nv.ngaysinhNV;
            li.Add(a);
            a = new SqlParameter("diachi", SqlDbType.VarChar);
            a.Value = nv.diachiNV;
            li.Add(a);
            a = new SqlParameter("email", SqlDbType.VarChar);
            a.Value = nv.emailNV;
            li.Add(a);
            a = new SqlParameter("dienthoai", SqlDbType.VarChar);
            a.Value = nv.dienthoaiNV;
            li.Add(a);
            a = new SqlParameter("socmt", SqlDbType.VarChar);
            a.Value = nv.soCMNDNV;
            li.Add(a);
            a = new SqlParameter("matrdhv", SqlDbType.NVarChar);
            a.Value = nv.MATRDHV;
            li.Add(a);
            a = new SqlParameter("bacluong", SqlDbType.NVarChar);
            a.Value = nv.Bacluong;
            li.Add(a);
            a = new SqlParameter("quequan", SqlDbType.VarChar);
            a.Value = nv.quequanNV;
            li.Add(a);



            if (doIt == null)
            {
                doIt = new connection();
            }
            if (doIt.isOpen() < 0)
            {
                ret = doIt.connect();
            }

            if (ret < 0)
            {
                return -1;
            }
            ret = doIt.doSql(sql, li.ToArray());
            return ret;
        }
        
        public void close()
        {
            if (doIt == null)
            {
                return;
            }
            if (doIt.isOpen() < 0)
            {
                return;
            }
            doIt.close();
        }
       
    }

}
