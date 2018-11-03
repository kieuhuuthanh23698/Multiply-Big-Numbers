using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaiToanNhanSoNguyenLon
{
    public partial class Nhan2SoNguyenLon : Form
    {
        public Nhan2SoNguyenLon()
        {
            InitializeComponent();
        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            if (txtA.Text != "" && txtB.Text != "")
            {
                SoNguyenLon a = new SoNguyenLon(txtA.Text, 1);
                SoNguyenLon b = new SoNguyenLon(txtB.Text, 1);
                txtKetQua.Text = SoNguyenLon.nhanSoNguyenLon(a,b).xuat();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtKetQua.Text = "";
            txtB.Text = "";
            txtA.Text = "";
        }

    }
}
