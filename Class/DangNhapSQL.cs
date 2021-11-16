using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Class
{
    class DangNhapSQL
    {
        private static DangNhapSQL instance;

        public static DangNhapSQL Instance
        {
            get { if (instance == null) instance = new DangNhapSQL(); return instance; }

            private set { instance = value; }
        }

        private DangNhapSQL() { }

        public bool DangNhap(string TaiKhoan, string MatKhau)
        {
            string sql = "SELECT * FROM dbo.Login WHERE TaiKhoan = N'" + TaiKhoan + "'AND MatKhau = N'" + MatKhau + "' ";
            DataTable ketqua = Functions.GetDataToTable(sql);
            return ketqua.Rows.Count > 0;
        }
    }
}
