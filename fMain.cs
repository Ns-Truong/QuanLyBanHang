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
    public partial class fMain : Form
    {
        private string TaiKhoan = "";
        private string MatKhau = "";
        private string Quyen = "";
        public fMain()
        {
            InitializeComponent();
        }
        public fMain(string TK, string MK)
        {
            InitializeComponent();
            this.TaiKhoan = TK;
            this.MatKhau = MK;
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            mnAdmin.Enabled = false;
            toolTaiKhoan.Text = TaiKhoan;
            string sql = "SELECT Quyen.Quyen FROM Login INNER JOIN Quyen ON Quyen.id = Login.Quyen WHERE TaiKhoan = '" + TaiKhoan + "' AND MatKhau = '" + MatKhau + "'";
            string Q = Functions.GetFieldValues(sql);
            toolQuyen.Text = Q;
            if (Q == "Admin")
            {
                mnAdmin.Enabled = true;
            }
            this.Quyen = Q;
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void mnAdmin_Click(object sender, EventArgs e)
        {
            fAdmin from = new fAdmin();
            this.Hide();
            from.ShowDialog();
            this.Show();
        }

        private void mnDanhSachNhanVien_Click(object sender, EventArgs e)
        {
            fDanhSachNhanVien from = new fDanhSachNhanVien();
            this.Hide();
            from.ShowDialog();
            this.Show();
        }

        private void mnDoiMatKhau_Click(object sender, EventArgs e)
        {
            fDoiMatKhau from = new fDoiMatKhau();
            from.Show();
            this.Show();
        }

        private void mnDSHoaDon_Click(object sender, EventArgs e)
        {
            fDanhSachHoaDon from = new fDanhSachHoaDon();
            this.Hide();
            from.ShowDialog();
            this.Show();
        }

        private void mnDSHangHoa_Click(object sender, EventArgs e)
        {
            fDanhSachHangHoa from = new fDanhSachHangHoa(Quyen);
            this.Hide();
            from.ShowDialog();
            this.Show();
        }

        private void mnDSKhachHang_Click(object sender, EventArgs e)
        {
            fKhachHang from = new fKhachHang();
            this.Hide();
            from.ShowDialog();
            this.Show();
        }

        private void mnLapHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void mnBaoCao_Click(object sender, EventArgs e)
        {

        }

        private void mnTroGiup_Click(object sender, EventArgs e)
        {

        }

        private void mnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void mnInHoaDon_Click(object sender, EventArgs e)
        {

        }

    }
}
