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
    public partial class fDanhSachHangHoa : Form
    {
        public fDanhSachHangHoa()
        {
            InitializeComponent();
            LoadDataGridView();
            Binding();
        }
        DataTable HangHoa;
        private void Binding()
        {
            txtMaHH.DataBindings.Add(new Binding("Text", dgrvHangHoa.DataSource, "MaHH"));
            txtTenHH.DataBindings.Add(new Binding("Text", dgrvHangHoa.DataSource, "TenHH"));
            txtSoLuong.DataBindings.Add(new Binding("Text", dgrvHangHoa.DataSource, "SoLuong"));
            txtGiaNhap.DataBindings.Add(new Binding("Text", dgrvHangHoa.DataSource, "DonGiaNhap"));
            txtGiaBan.DataBindings.Add(new Binding("Text", dgrvHangHoa.DataSource, "DonGiaBan"));
            txtLoaiHang.DataBindings.Add(new Binding("Text", dgrvHangHoa.DataSource, "LoaiHang"));
            txtDonViTinh.DataBindings.Add(new Binding("Text", dgrvHangHoa.DataSource, "DVT"));
            dtpNSX.DataBindings.Add(new Binding("Text", dgrvHangHoa.DataSource, "NSX"));
            dtpHSD.DataBindings.Add(new Binding("Text", dgrvHangHoa.DataSource, "HSD"));
            txtNhaCungCap.DataBindings.Add(new Binding("Text", dgrvHangHoa.DataSource, "NhaCungCap"));
            txtAnh.DataBindings.Add(new Binding("Text", dgrvHangHoa.DataSource, "Anh"));
            txtGhiChu.DataBindings.Add(new Binding("Text", dgrvHangHoa.DataSource, "GhiChu"));
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM HangHoa";
            HangHoa = Functions.GetDataToTable(sql);
            dgrvHangHoa.DataSource = HangHoa;
            dgrvHangHoa.AllowUserToAddRows = false;
            dgrvHangHoa.EditMode = DataGridViewEditMode.EditProgrammatically;
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
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaHH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã hàng hóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHH.Focus();
                return;
            }
            if (txtTenHH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên hàng hóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHH.Focus();
                return;
            }
            if (txtSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số lượng hàng hóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            if (txtGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đơn giá nhập!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaNhap.Focus();
                return;
            }
            if (txtGiaBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đơn giá bán!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaBan.Focus();
                return;
            }
            sql = "Select MaNV From HangHoa where MaNV=N'" + txtMaHH.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên bị trùng, bạn phải nhập mã khác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHH.Focus();
                return;
            }
            sql = "INSERT INTO HangHoa VALUES(N'" + txtMaHH.Text.Trim() + "',N'" + txtTenHH.Text.Trim() + "',N'" + txtSoLuong.Text.Trim() + "',N'" + txtGiaNhap.Text.Trim() + "',N'" + txtGiaBan.Text.Trim() + "',N'" + txtLoaiHang.Text.Trim() + "',N'" + txtDonViTinh.Text.Trim() + "',N'" + dtpNSX.Text.Trim() + "',N'" + dtpHSD.Text.Trim() + "',N'" + txtNhaCungCap.Text.Trim() + "',N'" + txtAnh.Text.Trim() + "',N'" + txtGhiChu.Text.Trim() + "')";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
        }
        private void ResetValue()
        {
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            txtLoaiHang.Text = "";
            txtDonViTinh.Text = "";
            dtpNSX.Text = "";
            dtpHSD.Text = "";
            txtNhaCungCap.Text = "";
            txtAnh.Text = "";
            txtGhiChu.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (HangHoa.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để sửa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã hàng hóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHH.Focus();
                return;
            }
            if (txtTenHH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên hàng hóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHH.Focus();
                return;
            }
            if (txtSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số lượng hàng hóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            if (txtGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đơn giá nhập!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaNhap.Focus();
                return;
            }
            if (txtGiaBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đơn giá bán!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaBan.Focus();
                return;
            }
            sql = "UPDATE HangHoa SET TenHH = N'" + txtTenHH.Text.Trim() + "', SoLuong = N'" + txtSoLuong.Text.Trim() + "', DonGiaNhap = N'" + txtGiaNhap.Text.Trim() + "', DonGiaBan = N'" + txtGiaBan.Text.Trim() + "', LoaiHang = N'" + txtLoaiHang.Text.Trim() + "', DVT = N'" + txtDonViTinh.Text.Trim() + "', NSX = N'" + dtpNSX.Text.Trim() + "', HSD = N'" + dtpHSD.Text.Trim() + "', NhaCungCap = N'" + txtNhaCungCap.Text.Trim() + "', Anh = N'" + txtAnh.Text.Trim() + "', GhiChu = N'" + txtGhiChu.Text.Trim() + "' WHERE MaHH = N'" + txtMaHH.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (HangHoa.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn hàng hóa nào!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xoá nhân viên này không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    sql = "DELETE HangHoa WHERE MaNV = N'" + txtMaHH.Text + "'";
                    Functions.RunSqlDel(sql);
                    LoadDataGridView();
                    ResetValue();
                    break;
                case DialogResult.No:
                    break;
            }
        }
    }
}
