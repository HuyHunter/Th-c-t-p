using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyKho.Dao
{
    public class NhaCungCap_dal
    {
        public static DataTable Select()
        {
            return KetNoi.GetList("xem_nhacungcap", null);
        }
    }
}
