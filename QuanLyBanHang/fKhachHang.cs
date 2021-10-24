using QuanLyBanHang.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class fKhachHang : Form
    {
        public fKhachHang()
        {
            InitializeComponent();
            LoadDataGridView();
            Binding();
        }
        DataTable KhachHang;
        private void Binding()
        {
            txtMaKH.DataBindings.Add(new Binding("Text", dgrvThongTinKH.DataSource, "MaKhachHang"));
            txtTenKH.DataBindings.Add(new Binding("Text", dgrvThongTinKH.DataSource, "TenKhachHang"));
            txtSDT.DataBindings.Add(new Binding("Text", dgrvThongTinKH.DataSource, "SDT"));
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT dbo.KhacHang.MaKhachHang, dbo.KhacHang.TenKhachHang, dbo.KhacHang.SDT, dbo.HoaDon.MaHD, dbo.NhanVien.TenNV, dbo.HoaDon.NgayBan, dbo.HoaDon.TongTien FROM dbo.HoaDon INNER JOIN dbo.KhacHang ON dbo.HoaDon.MaKH = dbo.KhacHang.MaKhachHang INNER JOIN dbo.NhanVien ON dbo.HoaDon.MaNV = dbo.NhanVien.MaNV";
            KhachHang = Functions.GetDataToTable(sql);
            dgrvThongTinKH.DataSource = KhachHang;
            dgrvThongTinKH.AllowUserToAddRows = false;
            dgrvThongTinKH.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void fKhachHang_Load(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn thực sự muốn thoát ?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            switch (result)
            {
                case DialogResult.OK:
                    this.Close();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        private void fKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
