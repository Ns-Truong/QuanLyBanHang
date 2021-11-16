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
    public partial class fDanhSachNhanVien : Form
    {
        public fDanhSachNhanVien()
        {
            InitializeComponent();
            LoadDataGridView();
            Binding();
        }
        DataTable NhanVien;
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
        private void Binding()
        {
            txtMaNV.DataBindings.Add(new Binding("Text", dgrvNhanVien.DataSource, "MaNV"));
            txtTenNV.DataBindings.Add(new Binding("Text", dgrvNhanVien.DataSource, "TenNV"));
            txtNgaySinh.DataBindings.Add(new Binding("Text", dgrvNhanVien.DataSource, "NgaySinh"));
            txtDiaChi.DataBindings.Add(new Binding("Text", dgrvNhanVien.DataSource, "DiaChi"));
            txtSDT.DataBindings.Add(new Binding("Text", dgrvNhanVien.DataSource, "SDT"));
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM NhanVien";
            NhanVien = Functions.GetDataToTable(sql);
            dgrvNhanVien.DataSource = NhanVien;
            dgrvNhanVien.AllowUserToAddRows = false;
            dgrvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValue()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã của nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên của nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            if (txtNgaySinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh của nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNgaySinh.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ của nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (txtSDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại của nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return;
            }
            sql = "Select MaNV From NhanVien where MaNV=N'" + txtMaNV.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên bị trùng, bạn phải nhập mã khác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            string GioiTinh = "";
            if (rdbtNam.Checked == true)
            {
                GioiTinh = "Nam";
            }
            else
            {
                GioiTinh = "Nữ";
            }
            sql = "INSERT INTO NhanVien VALUES(N'" + txtMaNV.Text + "',N'" + txtTenNV.Text + "',N'" + txtNgaySinh.Text + "',N'" + GioiTinh + "',N'" + txtDiaChi.Text + "',N'" + txtSDT.Text + "')";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (NhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để sửa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa có danh sách nhân viên nào!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Functions.IsDate(txtNgaySinh.Text))
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh của nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ của nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại của nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string GioiTinh = "";
            if (rdbtNam.Checked == true)
            {
                GioiTinh = "Nam";
            }
            else
            {
                GioiTinh = "Nữ";
            }
            sql = "UPDATE NhanVien SET TenNV = N'" + txtTenNV.Text.ToString() + "', NgaySinh = N'" + Functions.ConvertDateTime(txtNgaySinh.Text) + "', GioiTinh = N'" + GioiTinh + "', DiaChi = N'" + txtDiaChi.Text.ToString() + "', SDT = N'" + txtSDT.Text.ToString() + "' WHERE MaNV=N'" + txtMaNV.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (NhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn nhân viên nào!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xoá nhân viên này không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    sql = "DELETE NhanVien WHERE MaNV = N'" + txtMaNV.Text + "'";
                    Functions.RunSqlDel(sql);
                    LoadDataGridView();
                    ResetValue();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void dgrvNhanVien_Click(object sender, EventArgs e)
        {
            if (dgrvNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam")
            {
                rdbtNam.Checked = true;
                rdbtNu.Checked = false;
            }
            else
            {
                rdbtNam.Checked = false;
                rdbtNu.Checked = true;
            }
        }

        private void txtMaNV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtSDT_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtTenNV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtNgaySinh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDiaChi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnThem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnSua_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnXoa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnReset_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnThoat_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
