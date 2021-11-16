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
    public partial class fSetup : Form
    {
        public fSetup()
        {
            InitializeComponent();
        }

        private void fSetup_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformLayout();
            label2.Text = progressBar1.Value.ToString() + "%";
        }
    }
}
