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
        public fMain()
        {
            InitializeComponent();
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
            fDanhSachHangHoa from = new fDanhSachHangHoa();
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
