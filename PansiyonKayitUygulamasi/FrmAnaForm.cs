using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PansiyonKayitUygulamasi
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void btnAdminGiris_Click(object sender, EventArgs e)
        {
            FrmGirisPaneli fr = new FrmGirisPaneli();
            fr.Show();
            this.Hide();
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            FrmYeniMusteri fr = new FrmYeniMusteri();
            fr.Show();
        }

        private void btnOdalar_Click(object sender, EventArgs e)
        {
            FrmOdalar fr = new FrmOdalar();
            fr.Show();
        }

        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            FrmMusteriler fr = new FrmMusteriler();
            fr.Show();
        }
    }
}
