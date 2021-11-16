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
        public static int st;
        public static int id = 0;
        private string Quyen = "";
        DataTable HangHoa;
        public fDanhSachHangHoa(string Q)
        {
            InitializeComponent();
            LoadDataGridView();
            this.Quyen = Q;
        }
        public void SetStatus(Boolean vale)
        {
            txtMaHH.ReadOnly = vale;
            txtTenHH.ReadOnly = vale;
            txtSoLuong.ReadOnly = vale;
            txtGiaNhap.ReadOnly = vale;
            txtGiaBan.ReadOnly = vale;
            txtLoaiHang.ReadOnly = vale;
            txtDonViTinh.ReadOnly = vale;
            dtpNSX.Enabled = !vale;
            dtpHSD.Enabled = !vale;
            txtNhaCungCap.ReadOnly = vale;
            txtAnh.ReadOnly = vale;
            txtGhiChu.ReadOnly = vale;
        }
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
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            st = 1;
            SetStatus(false);
            ResetValue();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
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
            txtGhiChu.Text = "";
            txtAnh.Text = "";
            pcbAnh.Image = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            st = 2;
            SetStatus(false);
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
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

        private void dgrvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql, ma = "";

            txtMaHH.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenHH.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoLuong.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtGiaNhap.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtGiaBan.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtLoaiHang.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDonViTinh.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[6].Value.ToString();
            dtpNSX.Value = (DateTime)dgrvHangHoa.Rows[e.RowIndex].Cells[7].Value;
            dtpHSD.Value = (DateTime)dgrvHangHoa.Rows[e.RowIndex].Cells[8].Value;
            txtNhaCungCap.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[9].Value.ToString();
            //txtAnh.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtGhiChu.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[11].Value.ToString();

            ma = txtMaHH.Text;
            sql = "SELECT Anh FROM HangHoa WHERE MaHH = N'" + ma + "'";
            txtAnh.Text = Functions.GetFieldValues(sql);
            pcbAnh.Image = Image.FromFile(txtAnh.Text);
        }

        private void fDanhSachHangHoa_Load(object sender, EventArgs e)
        {
            /*if (Quyen == "Nhân viên" || Quyen == "")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
                btnReset.Enabled = false;
                btnChonAnh.Enabled = false;
            }*/
            LoadDataGridView();
            SetStatus(true);
            btnLuu.Enabled = false;
        }

        private void btnMo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Title = "Chọn File ảnh";
                open.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
                open.FilterIndex = 2;
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pcbAnh.Image = Image.FromFile(open.FileName);
                    txtAnh.Text = open.FileName;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(st == 1)
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
                sql = "Select MaHH From HangHoa where MaHH=N'" + txtMaHH.Text.Trim() + "'";
                if (Functions.CheckKey(sql))
                {
                    MessageBox.Show("Mã hàng hóa bị trùng, bạn phải nhập mã khác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaHH.Focus();
                    return;
                }
                sql = "INSERT INTO HangHoa VALUES(N'" + txtMaHH.Text.Trim() + "',N'" + txtTenHH.Text.Trim() + "',N'" + txtSoLuong.Text.Trim() + "',N'" + txtGiaNhap.Text.Trim() + "',N'" + txtGiaBan.Text.Trim() + "',N'" + txtLoaiHang.Text.Trim() + "',N'" + txtDonViTinh.Text.Trim() + "',N'" + dtpNSX.Value.ToString("MM/dd/yyyy") + "',N'" + dtpHSD.Value.ToString("MM/dd/yyyy") + "',N'" + txtNhaCungCap.Text.Trim() + "',N'" + txtAnh.Text.Trim() + "',N'" + txtGhiChu.Text.Trim() + "')";
                Functions.RunSQL(sql);
            }
            if(st == 2)
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
                sql = "UPDATE HangHoa SET TenHH = N'" + txtTenHH.Text.Trim() + "', SoLuong = N'" + txtSoLuong.Text.Trim() + "', DonGiaNhap = N'" + txtGiaNhap.Text.Trim() + "', DonGiaBan = N'" + txtGiaBan.Text.Trim() + "', LoaiHang = N'" + txtLoaiHang.Text.Trim() + "', DVT = N'" + txtDonViTinh.Text.Trim() + "', NSX = N'" + dtpNSX.Value.ToString("MM/dd/yyyy") + "', HSD = N'" + dtpHSD.Value.ToString("MM/dd/yyyy") + "', NhaCungCap = N'" + txtNhaCungCap.Text.Trim() + "', Anh = N'" + txtAnh.Text.Trim() + "', GhiChu = N'" + txtGhiChu.Text.Trim() + "' WHERE MaHH = N'" + txtMaHH.Text + "'";
                Functions.RunSQL(sql);
            }
            LoadDataGridView();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            SetStatus(true);
        }

        private void fDanhSachHangHoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
                this.Close();
            }
        }

        private void dgrvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql, ma = "";

            txtMaHH.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenHH.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoLuong.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtGiaNhap.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtGiaBan.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtLoaiHang.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDonViTinh.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[6].Value.ToString();
            dtpNSX.Value = (DateTime)dgrvHangHoa.Rows[e.RowIndex].Cells[7].Value;
            dtpHSD.Value = (DateTime)dgrvHangHoa.Rows[e.RowIndex].Cells[8].Value;
            txtNhaCungCap.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[9].Value.ToString();
            //txtAnh.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtGhiChu.Text = dgrvHangHoa.Rows[e.RowIndex].Cells[11].Value.ToString();

            ma = txtMaHH.Text;
            sql = "SELECT Anh FROM HangHoa WHERE MaHH = N'" + ma + "'";
            txtAnh.Text = Functions.GetFieldValues(sql);
            pcbAnh.Image = Image.FromFile(txtAnh.Text);
        }
    }
}
