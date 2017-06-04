using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace formDangNhap.Class
{
    class HoaDonBus
    {
        public Connection doIt = null;
        public void close()
        {
            if (doIt == null) return;
            if (doIt.isOpen() < 0) return;
            doIt.close();
        }
        public int update(HoaDonObj hd)
        {
            int ret = 0;
            string sql = @"update tblHoaDon set MaHD=@MaHD,MaKH=@MaKH,NguoiLap=@NguoiLap,TongTien=@TongTien,TGMuon=@TGMuon,TGTra=@TGTra where MaKH=@MaKH";
            List<SqlParameter> li = new List<SqlParameter>();
            SqlParameter a;
            a = new SqlParameter("MaHD", SqlDbType.NVarChar);
            a.Value = hd.MAHD;
            li.Add(a);
            a = new SqlParameter("MaKH", SqlDbType.NVarChar);
            a.Value = hd.MAKH;
            li.Add(a);
            a = new SqlParameter("NguoiLap", SqlDbType.NVarChar);
            a.Value = hd.NGUOILAP;
            li.Add(a);
            a = new SqlParameter("TongTien", SqlDbType.BigInt);
            a.Value = hd.TONGTIEN;
            li.Add(a);
            a = new SqlParameter("TGTra", SqlDbType.DateTime);
            a.Value = hd.TGTRA;
            li.Add(a);
            a = new SqlParameter("TGMuon", SqlDbType.DateTime);
            a.Value = hd.TGMUON;
            li.Add(a);
            if (doIt == null)
                doIt = new Connection();
            if (doIt.isOpen() < 0) ret = doIt.connect();
            if (ret < 0) return -2;
            ret = doIt.doSql(sql, li.ToArray());
            return ret;
        }
        public int insert(HoaDonObj dk)
        {
            int ret = 0;
            string sql = @"insert into tblHoaDon(MaHD,MaKH,NguoiLap,TongTien,TGMuon,TGTra) 
                         values(@MaHD,@MaKH,@NguoiLap,@TongTien,@TGMuon,@TGTra)";

            List<SqlParameter> li = new List<SqlParameter>();
            SqlParameter a;
            a = new SqlParameter("MaHD", SqlDbType.NVarChar);
            a.Value = dk.MAHD;
            li.Add(a);
            a = new SqlParameter("MaKH", SqlDbType.NVarChar);
            a.Value = dk.MAKH;
            li.Add(a);
            a = new SqlParameter("NguoiLap", SqlDbType.NVarChar);
            a.Value = dk.NGUOILAP;
            li.Add(a);
            a = new SqlParameter("TongTien", SqlDbType.BigInt);
            a.Value = dk.TONGTIEN;
            li.Add(a);
            a = new SqlParameter("TGMuon", SqlDbType.DateTime);
            a.Value = dk.TGMUON;
            li.Add(a);
            a = new SqlParameter("TGTra", SqlDbType.DateTime);
            a.Value = dk.TGTRA;
            li.Add(a);


            if (doIt == null)
                doIt = new Connection();
            if (doIt.isOpen() < 0) ret = doIt.connect();
            if (ret < 0) return -2;
            if (ret >= 0)
            {
                ret = doIt.doSql(sql, li.ToArray());
            }
            return ret;
        }
    public int delete(HoaDonObj dk)
    {
        int ret = 0;
        string sql = @"delete from tblHoaDon where MaHD=@MaHD ";

        List<SqlParameter> li = new List<SqlParameter>();
        SqlParameter a;
        a = new SqlParameter("MaHD", SqlDbType.NVarChar);
        a.Value = dk.MAHD;
        li.Add(a);
        a = new SqlParameter("MaKH", SqlDbType.NVarChar);
        a.Value = dk.MAKH;
        li.Add(a);
        a = new SqlParameter("NguoiLap", SqlDbType.NVarChar);
        a.Value = dk.NGUOILAP;
        li.Add(a);
        a = new SqlParameter("TongTien", SqlDbType.BigInt);
        a.Value = dk.TONGTIEN;
        li.Add(a);
        a = new SqlParameter("TGMuon", SqlDbType.DateTime);
        a.Value = dk.TGMUON;
        li.Add(a);
        a = new SqlParameter("TGTra", SqlDbType.DateTime);
        a.Value = dk.TGTRA;
        li.Add(a);


        if (doIt == null)
            doIt = new Connection();
        if (doIt.isOpen() < 0) ret = doIt.connect();
        if (ret < 0) return -2;
        if (ret >= 0)
        {
            ret = doIt.doSql(sql, li.ToArray());
        }
        return ret;
    }
}
}
