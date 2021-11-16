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
    public partial class fDanhSachHoaDon : Form
    {
        public fDanhSachHoaDon()
        {
            InitializeComponent();
            LoadDataGridView();
            Binding();
        }
        DataTable HoaDon;
        private void Binding()
        {
            txtMaHD.DataBindings.Add(new Binding("Text", dgrvHoaDon.DataSource, "MaHD"));
            txtMaHH.DataBindings.Add(new Binding("Text", dgrvHoaDon.DataSource, "MaHH"));
            txtTenHH.DataBindings.Add(new Binding("Text", dgrvHoaDon.DataSource, "TenHH"));
            txtSoLuong.DataBindings.Add(new Binding("Text", dgrvHoaDon.DataSource, "SoLuong"));
            txtDonGia.DataBindings.Add(new Binding("Text", dgrvHoaDon.DataSource, "DonGia"));
            txtGiamGia.DataBindings.Add(new Binding("Text", dgrvHoaDon.DataSource, "GiamGia"));
            txtThanhTien.DataBindings.Add(new Binding("Text", dgrvHoaDon.DataSource, "ThanhTien"));
            txtTongTien.DataBindings.Add(new Binding("Text", dgrvHoaDon.DataSource, "TongTien"));
            txtNgayBan.DataBindings.Add(new Binding("Text", dgrvHoaDon.DataSource, "NgayBan"));
            txtMaNV.DataBindings.Add(new Binding("Text", dgrvHoaDon.DataSource, "MaNV"));
            txtTenNV.DataBindings.Add(new Binding("Text", dgrvHoaDon.DataSource, "TenNV"));
            txtMaKH.DataBindings.Add(new Binding("Text", dgrvHoaDon.DataSource, "MaKH"));
            txtTenKH.DataBindings.Add(new Binding("Text", dgrvHoaDon.DataSource, "TenKhachHang"));
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT dbo.CTHoaDon.MaHD, dbo.CTHoaDon.MaHH, dbo.HangHoa.TenHH, dbo.CTHoaDon.SoLuong, dbo.CTHoaDon.DonGia, dbo.CTHoaDon.GiamGia, dbo.CTHoaDon.ThanhTien, dbo.HoaDon.TongTien, dbo.HoaDon.NgayBan, dbo.HoaDon.MaNV, dbo.NhanVien.TenNV, dbo.HoaDon.MaKH, dbo.KhacHang.TenKhachHang FROM dbo.CTHoaDon INNER JOIN dbo.HangHoa ON dbo.CTHoaDon.MaHH = dbo.HangHoa.MaHH INNER JOIN dbo.HoaDon ON dbo.CTHoaDon.MaHD = dbo.HoaDon.MaHD INNER JOIN dbo.KhacHang ON dbo.HoaDon.MaKH = dbo.KhacHang.MaKhachHang INNER JOIN dbo.NhanVien ON dbo.HoaDon.MaNV = dbo.NhanVien.MaNV";
            HoaDon = Functions.GetDataToTable(sql);
            dgrvHoaDon.DataSource = HoaDon;
            dgrvHoaDon.ScrollBars = ScrollBars.Both;
            dgrvHoaDon.AllowUserToAddRows = false;
            dgrvHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();
        }
        private void ResetValue()
        {
            txtMaHD.Text = "";
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtGiamGia.Text = "";
            txtThanhTien.Text = "";
            txtTongTien.Text = "";
            txtNgayBan.Text = "";
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtMaKH.Text = "";
            txtTenKH.Text = "";
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            /*if (txtMaHD.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHD.Focus();
                return;
            }*/
            if (txtMaHH.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn chưa nhập mã hàng hóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHH.Focus();
                return;
            }
            if (txtSoLuong.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn chưa nhập số lượng hàng hóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            if (txtDonGia.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập đơn giá!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGia.Focus();
                return;
            }
            if (txtGiamGia.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn chưa nhập mã số tiền giảm giá!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Focus();
                return;
            }
            if (txtThanhTien.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập thành tiềnn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtThanhTien.Focus();
                return;
            }
            if (txtTongTien.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tổng tiền!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTongTien.Focus();
                return;
            }
            if (txtNgayBan.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn chưa nhập ngày bán!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNgayBan.Focus();
                return;
            }
            if (txtMaNV.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (txtMaKH.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNgayBan.Focus();
                return;
            }
            sql = "Select MaHD From HoaDon where MaHD = N'" + txtMaHD.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên bị trùng, bạn phải nhập mã khác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHD.Focus();
                return;
            }
            //sql = "INSERT INTO dbo.HoaDon(MaHD, MaNV, NgayBan, MaKH, TongTien) VALUES(N'" + txtMaHD.Text + "', N'" + txtMaNV.Text + "', N'" + txtNgayBan.Text + "', N'" + txtMaKH + "', N'" + txtTongTien.Text + "') INSERT INTO dbo.CTHoaDon(MaHD, MaHH, SoLuong, DonGia, GiamGia, ThanhTien) VALUES(N'" + txtMaHD + "', N'" + txtMaHH + "', N'" + txtSoLuong + "', N'" + txtDonGia + "', N'" + txtGiamGia + "', N'" + txtThanhTien + "')";
            sql = "INSERT INTO dbo.HoaDon(MaHD, MaNV, NgayBan, MaKH, TongTien) VALUES(N'" + txtMaHD.Text + "', N'" + txtMaNV.Text + "', '" + txtNgayBan.Text + "', N'" + txtMaKH + "', " + txtTongTien.Text + ") INSERT INTO dbo.CTHoaDon(MaHD, MaHH, SoLuong, DonGia, GiamGia, ThanhTien) VALUES(N'" + txtMaHD + "', N'" + txtMaHH + "', " + txtSoLuong + ", " + txtDonGia + ", " + txtGiamGia + ", " + txtThanhTien + ")";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void In_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }
    }
}
