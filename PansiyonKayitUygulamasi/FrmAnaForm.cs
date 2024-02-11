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
            fr.ShowDialog();
        }

        private void btnOdalar_Click(object sender, EventArgs e)
        {
            FrmOdalar fr = new FrmOdalar();
            fr.ShowDialog();
        }

        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            FrmMusteriler fr = new FrmMusteriler();
            fr.ShowDialog();
        }

        private void btnHakkimizda_Click(object sender, EventArgs e)
        {
            string mesaj = "Bu Program Mustafa Emre İlhan tarafından yazılmıştır";
            string tarih = "25.06.2021";
            MessageBox.Show(mesaj+" "+tarih);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMusteriCikis_Click(object sender, EventArgs e)
        {
            FrmMusteriCikis fr = new FrmMusteriCikis();
            fr.ShowDialog();
        }

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongDateString();
            lblSaat.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnCikisYapmisMusteriler_Click(object sender, EventArgs e)
        {
            FrmCikisYapmisMusteriler fr = new FrmCikisYapmisMusteriler();
            fr.ShowDialog();
        }
    }
}
