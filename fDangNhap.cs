using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }
        bool Login(string TaiKhoan, string MatKhau)
        {
            return DangNhapSQL.Instance.DangNhap(TaiKhoan, MatKhau);
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (Login(txtTaiKhoan.Text, txtMatKhau.Text))
            {
                MessageBox.Show("Bạn đã đăng nhập thành công!", "Thông báo");
                fMain form = new fMain(txtTaiKhoan.Text, txtMatKhau.Text);
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản khoặc mật khẩu!", "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Functions.Disconnect(); //Đóng kết nối
        }
        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void fDangNhap_Load(object sender, EventArgs e)
        {
            Functions.Connect();
        }
    }
}
