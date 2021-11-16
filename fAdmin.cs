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
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
            LoadDataGridView();
        }
        DataTable Admin;
        public static int st;
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM Login";
            //Đọc dữ liệu từ bảng
            Admin = Functions.GetDataToTable(sql);
            //Nguồn dữ liệu
            dgrvTaiKhoan.DataSource = Admin;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgrvTaiKhoan.AllowUserToAddRows = false;
            //Không cho sửa dữ liệu trực tiếp
            dgrvTaiKhoan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        public void SetStatus(Boolean vale)
        {
            txtTaiKhoan.ReadOnly = vale;
            txtMatKhau.ReadOnly = vale;
            cbbQuyen.Enabled = !vale;
        }
        private void ResetValue()
        {
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            cbbQuyen.SelectedIndex = 0;
        }
        private void fAdmin_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * FROM Quyen";
            LoadDataGridView();
            Functions.FillCombo(sql, cbbQuyen, "id", "Quyen");
            cbbQuyen.SelectedIndex = -1;
            SetStatus(true);
        }

        private void dgrvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id;
            string sql;
            txtTaiKhoan.Text = dgrvTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMatKhau.Text = dgrvTaiKhoan.Rows[e.RowIndex].Cells[1].Value.ToString();
            id = dgrvTaiKhoan.Rows[e.RowIndex].Cells[2].Value.ToString();
            sql = "SELECT Quyen FROM Quyen WHERE id=N'" + id + "'";
            cbbQuyen.Text = Functions.GetFieldValues(sql);
        }

        private void fAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            st = 1;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            SetStatus(false);
            ResetValue();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            st = 2;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            SetStatus(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (st == 1)
            {
                string sql;
                if (txtTaiKhoan.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTaiKhoan.Focus();
                    return;
                }
                if (txtMatKhau.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatKhau.Focus();
                    return;
                }
                if (cbbQuyen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chọn nhập quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbQuyen.Focus();
                    return;
                }
                sql = "SELECT TaiKhoan FROM Login WHERE TaiKhoan=N'" + txtTaiKhoan.Text.Trim() + "'";
                if (Functions.CheckKey(sql))
                {
                    MessageBox.Show("Tài khoản đã tồn tại, bạn phải chọn tên tài khoản khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTaiKhoan.Focus();
                    return;
                }
                sql = "INSERT INTO Login VALUES(N'" + txtTaiKhoan.Text.Trim() + "',N'" + txtMatKhau.Text.Trim() + "',N'" + cbbQuyen.SelectedValue.ToString() + "')";
                Functions.RunSQL(sql);
            }
            if (st == 2)
            {
                string sql;
                if (Admin.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để sửa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtTaiKhoan.Text == "")
                {
                    MessageBox.Show("Bạn chưa ghi tên tài khoản muốn sửa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtMatKhau.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu muốn đổi!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cbbQuyen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbQuyen.Focus();
                    return;
                }
                sql = "UPDATE Login SET MatKhau = N'" + txtMatKhau.Text.ToString() + "', Quyen = " + cbbQuyen.SelectedValue.ToString() + "WHERE TaiKhoan = N'" + txtTaiKhoan.Text.ToString() + "'";
                Functions.RunSQL(sql);
            }
            LoadDataGridView();
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            SetStatus(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (Admin.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu để xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTaiKhoan.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa ghi tên tài khoản muốn xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xoá tài khoản này không này không?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes:
                    sql = "DELETE Login WHERE TaiKhoan = N'" + txtTaiKhoan.Text + "'";
                    Functions.RunSqlDel(sql);
                    LoadDataGridView();
                    break;
                case DialogResult.No:
                    break;
            }
            LoadDataGridView();
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

        private void dgrvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id;
            string sql;
            txtTaiKhoan.Text = dgrvTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMatKhau.Text = dgrvTaiKhoan.Rows[e.RowIndex].Cells[1].Value.ToString();
            id = dgrvTaiKhoan.Rows[e.RowIndex].Cells[2].Value.ToString();
            sql = "SELECT Quyen FROM Quyen WHERE id=N'" + id + "'";
            cbbQuyen.Text = Functions.GetFieldValues(sql);
        }
    }
    /*
              private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM Login";
            Admin = Functions.GetDataToTable(sql);
            dgrvTaiKhoan.DataSource = Admin;
            dgrvTaiKhoan.AllowUserToAddRows = false;
            dgrvTaiKhoan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Binding()
        {
            txtTaiKhoan.DataBindings.Add(new Binding("Text", dgrvTaiKhoan.DataSource, "TaiKhoan"));
            txtMatKhau.DataBindings.Add(new Binding("Text", dgrvTaiKhoan.DataSource, "MatKhau"));
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

        private void dgrvTaiKhoan_Click(object sender, EventArgs e)
        {
            if (dgrvTaiKhoan.CurrentRow.Cells["Quyen"].Value.ToString() == "true")
            {
                ckbQuyen.Checked = true;
            }
            else
            {
                ckbQuyen.Checked = false;
            }
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTaiKhoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTaiKhoan.Focus();
                return;
            }
            if (txtMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhau.Focus();
                return;
            }
            int Quyen;
            if (ckbQuyen.Checked == true)
            {
                Quyen = 1;
            }
            else
            {
                Quyen = 0;
            }
            sql = "SELECT TaiKhoan FROM Login WHERE TaiKhoan=N'" + txtTaiKhoan.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Tài khoản đã tồn tại, bạn phải chọn tên tài khoản khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTaiKhoan.Focus();
                return;
            }
            sql = "INSERT INTO Login VALUES(N'" + txtTaiKhoan.Text.Trim() + "',N'" + txtMatKhau.Text.Trim() + "',N'" + Quyen + "')";
            Functions.RunSQL(sql);
            LoadDataGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (Admin.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để sửa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Bạn chưa ghi tên tài khoản muốn sửa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu muốn đổi!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string Quyen = "";
            if (ckbQuyen.Checked == true)
            {
                Quyen = "1";
            }
            else
            {
                Quyen = "0";
            }
            sql = "UPDATE Login SET MatKhau = N'" + txtMatKhau.Text.ToString() + "', Quyen = " + Quyen.ToString() + "WHERE TaiKhoan = N'" + txtTaiKhoan.Text.ToString() + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (Admin.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu để xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTaiKhoan.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa ghi tên tài khoản muốn xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xoá tài khoản này không này không?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes:
                    sql = "DELETE Login WHERE TaiKhoan = N'" + txtTaiKhoan.Text + "'";
                    Functions.RunSqlDel(sql);
                    LoadDataGridView();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetValue();
        }
        private void ResetValue()
        {
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            ckbQuyen.Checked = false;
        }

        private void fAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void dgrvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
     */
}
