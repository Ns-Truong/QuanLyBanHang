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
            Binding();
        }
        DataTable Admin;
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
    }
}
